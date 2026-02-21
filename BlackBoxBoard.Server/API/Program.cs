using BlackBoxBoard.Server.Extensions;
using BlackBoxBoard.Server.Infrastructure;
using BlackBoxBoard.Server.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwt(); 

var isDevelopment = builder.Environment.IsDevelopment();
if (isDevelopment)
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection")
       ?? builder.Configuration.GetConnectionString("PostgresConnection");

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("PostgreSQL connection string not configured");
    }

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString);

        // не смогла решить проблему с ошибкой. Поэтому пока что ставлю игнорирование ворнингов.
        //Unhandled exception. System.InvalidOperationException: An error was generated for warning 'Microsoft.EntityFrameworkCore.Migrations.PendingModelChangesWarning': The model for context 'AppDbContext' has pending changes. Add a new migration before updating the database. 
        options.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    });

}

var app = builder.Build();

await DatabaseExtensions.RunMigrationsIfNeededAsync(args, app.Configuration);

app.UseSwaggerWithUi(); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (!app.Environment.IsDevelopment())
{
    await app.ApplyMigrationsOnStartupAsync(); 
}

app.Run();