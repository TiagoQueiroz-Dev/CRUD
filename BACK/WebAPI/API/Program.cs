using Application.Interfaces;
using Application.Services;
using Application.ViewModels.PessoaViewModels;
using Data.DataContext;
using Data.DataContext.PopularEnum;
using Data.Repositories;
using Domain.Repositories;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("srv-data")));

builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IPessoaApplicationService, PessoaApplicationService>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Context>();
    
    Enums.InicializarEnums(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    app.UseSwagger();  
    app.UseSwaggerUI(); 
}

app.UseCors("AllowAll");

app.UseRouting();
app.UseHttpsRedirection();


app.MapControllers();

app.Run();