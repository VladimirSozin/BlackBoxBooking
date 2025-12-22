using Npgsql;

namespace Db;

public static class UserManipulator
{
    public static void Insert()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = @"
INSERT INTO users(username, email, registrationdate) 
VALUES (:username, :email, :registrationdate);
";
        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("username", "root"));
        parameters.Add(new NpgsqlParameter("email", "root@web.com"));
        parameters.Add(new NpgsqlParameter("registrationdate", DateTime.Now));

        try
        {
            var affectedRowsCount = cmd.ExecuteNonQuery().ToString();
            Console.WriteLine($"Insert into users. Affected rows count: {affectedRowsCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error inserting users table: {e.Message}, stacktrace : {e.StackTrace}");
            throw;
        }
    }
}