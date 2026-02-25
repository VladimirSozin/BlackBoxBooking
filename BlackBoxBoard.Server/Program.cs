using BlackBoxBoard.Server.Extensions;
using BlackBoxBoard.Server.Modules.ApprovalWorkflow;
using BlackBoxBoard.Server.Modules.Employees;
using BlackBoxBoard.Server.Modules.LeaveManagement;
using BlackBoxBoard.Server.Modules.References;
using BlackBoxBoard.Server.Modules.Shared;
using BlackBoxBoard.Server.Modules.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwt();

builder.Services.AddSharedModule();
builder.Services.AddEmployeesModule();
builder.Services.AddLeaveManagementModule();
builder.Services.AddApprovalWorkflowModule();
builder.Services.AddUsersModule();     
builder.Services.AddReferencesModule();

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
        options.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    });
}

var app = builder.Build();

app.UseSwaggerWithUi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (!app.Environment.IsDevelopment())
{
    app.MigrateDatabase();
}

app.Run();