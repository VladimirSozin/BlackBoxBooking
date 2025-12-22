using System.Text;
using Npgsql;

namespace Db;

public static class DbStructureCreator
{
    public static void CreateProductTable()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("CREATE SEQUENCE public.products_id_seq;");
        stringBuilder.Append(@"-- public.products definition
CREATE TABLE public.products (
	productid int8 DEFAULT nextval('products_id_seq'::regclass) NOT NULL,
	productname varchar(255) NOT NULL,
	description text NULL,
	price numeric NULL,
	quantityinstock int4 NULL,
	CONSTRAINT products_pkey PRIMARY KEY (productid)
);");
        var sql = stringBuilder.ToString();
        try
        {
            using var cmd = new NpgsqlCommand(sql, connection);
            var affectedRowsCount = cmd.ExecuteNonQuery().ToString();
            Console.WriteLine($"Created Products table. Affected rows count: {affectedRowsCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error creating products table: {e.Message}, stacktrace : {e.StackTrace}");
        }
    }

    public static void CreateUserTable()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("CREATE SEQUENCE public.users_id_seq;");
        stringBuilder.Append(@"-- public.users definition
CREATE TABLE public.users (
	userid int8 DEFAULT nextval('users_id_seq'::regclass) NOT NULL,
	username varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	registrationdate date NOT NULL,
	CONSTRAINT users_pkey PRIMARY KEY (userid)
);");
        var sql = stringBuilder.ToString();
        try
        {
            using var cmd = new NpgsqlCommand(sql, connection);
            var affectedRowsCount = cmd.ExecuteNonQuery().ToString();
            Console.WriteLine($"Created Users table. Affected rows count: {affectedRowsCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error creating users table: {e.Message}, stacktrace : {e.StackTrace}");
        }
    }

    public static void CreateOrdersTable()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("CREATE SEQUENCE public.orders_id_seq;");
        stringBuilder.Append(@"-- public.orders definition
CREATE TABLE public.orders (
	orderid int8 DEFAULT nextval('orders_id_seq'::regclass) NOT NULL,
    userid BIGINT NOT NULL,
	orderdate date NOT NULL,
	status varchar(255) NULL,
    CONSTRAINT deposits_fk_user_id FOREIGN KEY (userid) REFERENCES users(userid) ON DELETE CASCADE,
	CONSTRAINT orders_pkey PRIMARY KEY (orderid)
);");
        var sql = stringBuilder.ToString();
        try
        {
            using var cmd = new NpgsqlCommand(sql, connection);
            var affectedRowsCount = cmd.ExecuteNonQuery().ToString();
            Console.WriteLine($"Created Orders table. Affected rows count: {affectedRowsCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error creating orders table: {e.Message}, stacktrace : {e.StackTrace}");
        }
    }
    
    public static void CreateOrderDetailsTable()
    {
        using var connection = new NpgsqlConnection(Program.ConnectionString);
        connection.Open();

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("CREATE SEQUENCE public.order_details_id_seq;");
        stringBuilder.Append(@"-- public.orderdetails definition
CREATE TABLE public.orderdetails (
	orderdetailid int8 DEFAULT nextval('order_details_id_seq'::regclass) NOT NULL,
    orderid BIGINT NOT NULL,
    productid BIGINT NOT NULL,
	quantity int4 NOT NULL,
	totalcost numeric NULL,
    CONSTRAINT deposits_fk_order_id FOREIGN KEY (orderid) REFERENCES orders(orderid) ON DELETE CASCADE,
    CONSTRAINT deposits_fk_product_id FOREIGN KEY (productid) REFERENCES products(productid) ON DELETE CASCADE,
	CONSTRAINT order_details_pkey PRIMARY KEY (orderdetailid)
);");
        var sql = stringBuilder.ToString();
        try
        {
            using var cmd = new NpgsqlCommand(sql, connection);
            var affectedRowsCount = cmd.ExecuteNonQuery().ToString();
            Console.WriteLine($"Created OrderDetails table. Affected rows count: {affectedRowsCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error creating orderdetails table: {e.Message}, stacktrace : {e.StackTrace}");
        }
    }
}