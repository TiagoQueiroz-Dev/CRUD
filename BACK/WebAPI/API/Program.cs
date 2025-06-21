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
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("C:/Estudos/Projeto/logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var banco = builder.Configuration.GetConnectionString("srv-data");

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(banco,sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorNumbersToAdd: null
        );
        Log.Logger.Information("[tentativas de acesso ao banco de dados]");
    }));

builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IPessoaApplicationService, PessoaApplicationService>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

builder.Services.AddCors(options =>
{
    var FronrUrl = builder.Configuration.GetSection("CorsSettings:font-url").Get<string[]>();;

    options.AddPolicy("AllowAll",
        builder => builder.WithOrigins(FronrUrl).AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Context>();

    Enums.InicializarEnums(context);
}

// Configure the HTTP request pipeline.



app.UseSwagger();
app.UseSwaggerUI();


app.UseCors("AllowAll");

app.UseRouting();
app.UseHttpsRedirection();


app.MapControllers();

app.Run();