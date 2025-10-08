using Application.Waters;
using Data;
using Data.Waters;
using GreenhouseFactoryService.Seeder;
using MassTransit;
using Messaging;
using Microsoft.EntityFrameworkCore;

namespace GreenhouseFactoryService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed(_ => true);
            });
        });
        
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        // Add services to the container.
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddScoped<WaterEventConsumer>();
        builder.Services.AddScoped<IWaterRepository, WaterRepository>();
        builder.Services.AddScoped<IWaterService,  WaterService>();

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
        
        var app = builder.Build();
        
        using (var scope = app.Services.CreateScope())
        {
            Console.WriteLine("Migration started");
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            Console.WriteLine("Migration done.");
            
            Console.WriteLine("Seeding database.");
            DataSeeder.Seeder(context);
            Console.WriteLine("Seeding database done.");
        }
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors("AllowAll");
        
        app.Run();
    }
}