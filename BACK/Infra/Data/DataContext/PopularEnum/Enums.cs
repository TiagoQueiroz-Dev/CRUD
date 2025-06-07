using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Collections;
using System.Linq;
using Domain.Enums;
using Domain.Interfaces;

namespace Data.DataContext.PopularEnum;

public static class Enums
{
    public static void InicializarEnums(DbContext context)
    {
        var assembly = typeof(IEnumEntity).Assembly;
        var enumTypes = assembly.GetTypes().Where(t => t.IsEnum).ToList();

        foreach (var enumType in enumTypes)
        {
            var entityType = assembly
                .GetTypes()
                .FirstOrDefault(t =>
                    t.IsClass &&
                    typeof(IEnumEntity).IsAssignableFrom(t) &&
                    t.Name.StartsWith(enumType.Name.Replace("E", "")));

            if (entityType == null || !typeof(IEnumEntity).IsAssignableFrom(entityType))
                continue;

            var dbSetProp = context.GetType().GetProperties()
                .FirstOrDefault(p =>
                    p.PropertyType.IsGenericType &&
                    p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                    p.PropertyType.GetGenericArguments()[0] == entityType);

            if (dbSetProp == null) continue;

            var dbSet = dbSetProp.GetValue(context);

            //dados no banco
            var currentEntities = ((IQueryable<object>)dbSet)
                .ToList()
                .Select(e => new
                {
                    Id = (int)entityType.GetProperty("Id")?.GetValue(e),
                    Nome = (string)entityType.GetProperty("Nome")?.GetValue(e)!,
                    Original = e
                }).ToList();

            //Dados esperados do enum
            var enumValues = Enum.GetValues(enumType).Cast<object>().ToList();
            var desiredEntities = enumValues
                .Select(val => new
                {
                    Id = (int)val,
                    Nome = val.ToString()
                }).ToList();

            // 3. Inserir ou atualizar
            foreach (var val in desiredEntities)
            {
                var existing = currentEntities.FirstOrDefault(c => c.Id == val.Id);
                if (existing == null)
                {
                    // Novo
                    var entity = Activator.CreateInstance(entityType);
                    entityType.GetProperty("Id")?.SetValue(entity, val.Id);
                    entityType.GetProperty("Nome")?.SetValue(entity, val.Nome);

                    typeof(DbSet<>).MakeGenericType(entityType)
                        .GetMethod("Add")!
                        .Invoke(dbSet, new object[] { entity });
                }
                else if (existing.Nome != val.Nome)
                {
                    // Atualizar nome
                    entityType.GetProperty("Nome")?.SetValue(existing.Original, val.Nome);
                    context.Entry(existing.Original).State = EntityState.Modified;
                }
            }

            // 4. Remover valores que não existem mais no enum
            var idsNoEnum = desiredEntities.Select(e => e.Id).ToHashSet();
            var toRemove = currentEntities.Where(c => !idsNoEnum.Contains(c.Id)).ToList();

            foreach (var item in toRemove)
            {
                typeof(DbSet<>).MakeGenericType(entityType)
                    .GetMethod("Remove")!
                    .Invoke(dbSet, new object[] { item.Original });
            }

            context.SaveChanges();
        }
    }
}