using BlackBoxBoard.Server.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlackBoxBoard.Server.Extensions;

public static class DatabaseExtensions
{
    public static async Task RunMigrationsIfNeededAsync(string[] args, IConfiguration configuration)
    {
        if (!args.Contains("--migrate-database"))
            return;

        Console.WriteLine("Starting database migrations...");

        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection")
            ?? configuration.GetConnectionString("PostgresConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("ERROR: Connection string not found!");
            return;
        }

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        using var context = new AppDbContext(optionsBuilder.Options);

        await WaitForDatabaseAsync(context);
        await context.Database.MigrateAsync();

        Console.WriteLine("Migrations and seed completed successfully!");
        Environment.Exit(0); 
    }

    /// Применяет миграции при старте приложения (на проде)
    public static async Task ApplyMigrationsOnStartupAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            if (!await context.Database.CanConnectAsync())
            {
                Console.WriteLine("Database not available yet, skipping automatic migrations...");
                return;
            }

            await context.Database.MigrateAsync();
            Console.WriteLine("Startup migrations completed");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during startup migrations: {ex.Message}");
        }
    }

    private static async Task WaitForDatabaseAsync(DbContext context)
    {
        for (int i = 0; i < 30; i++)
        {
            try
            {
                if (await context.Database.CanConnectAsync())
                {
                    Console.WriteLine("Connected to database");
                    return;
                }
            }
            catch
            {
            }
            Console.WriteLine($"Waiting for database... ({i + 1}/30)");
            await Task.Delay(1000);
        }
    }
}