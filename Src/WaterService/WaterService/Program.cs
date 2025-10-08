using Application;
using Application.Interfaces;
using MassTransit;
using Messaging;
using WaterService.Hubs;
using WaterService.Notifications;

namespace WaterService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IWaterService, Application.WaterService>();
        builder.Services.AddScoped<IWaterNotification, WaterNotification>();
        builder.Services.AddScoped<WaterEventConsumer>();
        builder.Services.AddSignalR();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed(_ => true); // tillader alle origins
            });
        });
        
        var rabbitHost = builder.Configuration["RabbitMq:Host"] ?? "localhost";
        var rabbitPort = int.Parse(builder.Configuration["RabbitMq:Port"] ?? "5672");
        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<WaterEventConsumer>();
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
        
        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();
        
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        app.UseCors("AllowAll");
        app.MapHub<WaterHub>("/waterHub");
        
        app.Run();
    }
}