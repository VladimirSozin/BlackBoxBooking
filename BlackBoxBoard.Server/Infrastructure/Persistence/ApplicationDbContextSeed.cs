
using BlackBoxBoard.Server.Domain.References;
using BlackBoxBoard.Server.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Role("ADMIN", "Administrator", "Администратора", 1, 1),
                new Role("MANAGER", "Manager", "Руководитель", 2, 1),
                new Role("EMPLOYEE", "Employee", "Сотрудник", 3, 1),
                new Role("HR", "HR Specialist", "Отдел кадров", 4, 1)
            );
            await context.SaveChangesAsync();
        }
    }
}