using LearnApp.Application;
using LearnApp.Application.Contracts;
using LearnApp.Application.Handlers;
using LearnApp.Infrastructure;
using MediatR;
using Polly;
using Polly.Extensions.Http;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IOrderClient, OrderClient>();
        builder.Services.AddScoped<IPriceClient, PriceClient>();
        builder.Services.AddApplicationDependency();
        builder.Services.ServiceCollectionServiceExtensions();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}