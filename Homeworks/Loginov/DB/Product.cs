using Npgsql;

namespace Db;

public static class Product
{
    public static void Insert()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = @"
INSERT INTO products(productname, description, price, quantityinstock) 
VALUES (:productname, :description, :price, :quantityinstock);
";

        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("productname", "Футбольный мяч"));
        parameters.Add(new NpgsqlParameter("description", "для большого футбола"));
        parameters.Add(new NpgsqlParameter("price", 3000));
        parameters.Add(new NpgsqlParameter("quantityinstock", 100));

        try
        {
            var affectedRowsCount = cmd.ExecuteNonQuery().ToString();
            Console.WriteLine($"Insert into Products. Affected rows count: {affectedRowsCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error inserting products table: {e.Message}, stacktrace : {e.StackTrace}");
            throw;
        }
    }
}