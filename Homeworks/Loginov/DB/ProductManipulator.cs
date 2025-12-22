using Npgsql;

namespace Db;

public static class ProductManipulator
{
    public static void Insert1()
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

    public static void Insert0()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = @"
INSERT INTO products(productname, description, price, quantityinstock) 
VALUES (:productname, :description, :price, :quantityinstock);
";
        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("productname", "Волейбольный мяч"));
        parameters.Add(new NpgsqlParameter("description", "для пляжного волейбола"));
        parameters.Add(new NpgsqlParameter("price", 2000));
        parameters.Add(new NpgsqlParameter("quantityinstock", 1));

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

    public static void Update(int id)
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = @"
UPDATE products SET proce = :price WHERE  id = :id";

        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("price", 1000));
        parameters.Add(new NpgsqlParameter("id", id));

        try
        {
            var affectedRowsCount = cmd.ExecuteNonQuery().ToString();
            Console.WriteLine($"Update Products. Affected rows count: {affectedRowsCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating products table: {e.Message}, stacktrace : {e.StackTrace}");
            throw;
        }
    }

    public static void GetStock()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = "SELECT SUM(quantityinstock) FROM products";

        using var cmd = new NpgsqlCommand(sql, connection);
        var reader = cmd.ExecuteReader();
        
        Int32 total = 0;
        while (reader.Read())
        {
            total += reader.GetInt32(0);
        }
        Console.WriteLine($"Stock comprises {total} items.");
    }
    
    public static void GetTop5MostExpansiveProducts()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = "SELECT productid, productname, price FROM products ORDER BY price DESC limit 5";
        using var cmd = new NpgsqlCommand(sql, connection);
        var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            var productid = reader.GetInt16(0);
            var productname = reader.GetString(1);
            var price = reader.GetDecimal(2);

            Console.WriteLine(
                $"Read: [productid={productid},productname={productname},price={price}]");
        }
    }
    
    public static void GetScarceItems()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = "SELECT productid, productname, price FROM products WHERE quantityinstock < 5";
        using var cmd = new NpgsqlCommand(sql, connection);
        var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            var productid = reader.GetInt16(0);
            var productname = reader.GetString(1);
            var price = reader.GetDecimal(2);

            Console.WriteLine(
                $"Read: [productid={productid},productname={productname},price={price}]");
        }
    }
}