using Data;
using GreenhouseFactoryService.Seeder;
using Microsoft.EntityFrameworkCore;

namespace GreenhouseFactoryService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        // Add services to the container.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();

        var app = builder.Build();
        
        using (var scope = app.Services.CreateScope())
        {
            Console.WriteLine("Migration started");
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureDeleted();
            db.Database.Migrate();
            Console.WriteLine("Migration done.");
            
            Console.WriteLine("Seeding database.");
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
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

        app.Run();
    }
}