using MassTransit;
using Messaging;
using SoilMoisture.Application;

namespace SoilMoistureService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<ISoilMoistureService, SoilMoisture.Application.SoilMoistureService>();
        builder.Services.AddScoped<SoilMoistureEventConsumer>();
        builder.Services.AddScoped<IWaterEventService, WaterEventProducer>();
        
        var rabbitHost = builder.Configuration["RabbitMq:Host"] ?? "localhost";
        var rabbitPort = int.Parse(builder.Configuration["RabbitMq:Port"] ?? "5672");
        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<SoilMoistureEventConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitHost, "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ConfigureEndpoints(context);
            });
        });
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddControllers();
        
        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}