using BlackBoxBoard.Server.Extensions;
using BlackBoxBoard.Server.Infrastructure;
using BlackBoxBoard.Server.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

await DatabaseExtensions.RunMigrationsIfNeededAsync(args, builder.Configuration);


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
        options.UseNpgsql(connectionString));
}

var app = builder.Build();

app.UseSwaggerWithUi(); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (!app.Environment.IsDevelopment())
{
    await app.ApplyMigrationsOnStartupAsync(); 
}

app.Run();