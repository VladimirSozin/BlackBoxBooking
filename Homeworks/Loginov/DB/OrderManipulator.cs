using Npgsql;

namespace Db;

public class OrderManipulator
{
    public static void Insert()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();
        try
        {
            var sql = @"
INSERT INTO orders(userid, orderdate, status) 
VALUES (:userid, :orderdate, :status)
RETURNING orderid;";

            using var cmd1 = new NpgsqlCommand(sql, connection);
            var parameters = cmd1.Parameters;
            parameters.Add(new NpgsqlParameter("userid", 1));
            parameters.Add(new NpgsqlParameter("orderdate", DateTime.Now));
            parameters.Add(new NpgsqlParameter("status", "delivered"));

            var orderId = (long)cmd1.ExecuteScalar();

            Console.WriteLine($"Order ID: {orderId}");

            sql = @"
INSERT INTO orderdetails(orderid, productid, quantity, totalcost) 
VALUES (:orderid, :productid, :quantity, :totalcost)";

            using var cmd2 = new NpgsqlCommand(sql, connection);
            parameters = cmd2.Parameters;
            parameters.Add(new NpgsqlParameter("orderid", orderId));
            parameters.Add(new NpgsqlParameter("productId", 1));
            parameters.Add(new NpgsqlParameter("quantity", 1));
            parameters.Add(new NpgsqlParameter("totalcost", 2000));

            var affectedRowsCount = cmd2.ExecuteNonQuery().ToString();
            Console.WriteLine($"Insert into orderdetails table. Affected rows count: {affectedRowsCount}");

            sql = @"
INSERT INTO orderdetails(orderid, productid, quantity, totalcost) 
VALUES (:orderid, :productid, :quantity, :totalcost)";

            using var cmd3 = new NpgsqlCommand(sql, connection);
            parameters = cmd3.Parameters;
            parameters.Add(new NpgsqlParameter("orderid", orderId));
            parameters.Add(new NpgsqlParameter("productId", 2));
            parameters.Add(new NpgsqlParameter("quantity", 2));
            parameters.Add(new NpgsqlParameter("totalcost", 3000));

            affectedRowsCount = cmd3.ExecuteNonQuery().ToString();
            Console.WriteLine($"Insert into orderdetails table. Affected rows count: {affectedRowsCount}");

            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine($"Rolled back the transaction due to {e.Message}, stacktrace: {e.StackTrace}");
        }
    }

    public static void GetByUser(int userId)
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = @"
SELECT orderid, orderdate, status FROM orders WHERE userid = :userId";

        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("userId", userId));

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var orderId = reader.GetInt16(0);
            var orderDate = reader.GetDateTime(1);
            var status = reader.GetString(2);

            Console.WriteLine(
                $"Read: [orderId={orderId},orderDate={orderDate},status={status}]");
        }
    }

    public static void getTotalPrice(int orderId)
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        var sql = "SELECT totalcost FROM orderdetails WHERE orderid = :orderId";

        using var cmd = new NpgsqlCommand(sql, connection);
        var parameters = cmd.Parameters;
        parameters.Add(new NpgsqlParameter("orderId", orderId));

        var reader = cmd.ExecuteReader();

        decimal total = 0;
        while (reader.Read())
        {
            total += reader.GetDecimal(0);
        }

        Console.WriteLine(
            $"Read: [orderId={orderId},total={total}]");
    }
}