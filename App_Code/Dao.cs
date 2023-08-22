using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class Dao
{
    private const string ConnStr = "Database=tma3; Data Source=localhost; User Id=root; Password=";

    public Dao()
    {

    }

    public static IReadOnlyList<Photo> GetAllPhotos()
    {
        try
        {
            var photos = new List<Photo>();
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT * FROM slideshow";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        photos.Add(new Photo(reader.GetInt32("ID"), reader.GetString("Name"), reader.GetString("Url"),
                            reader.GetString("Description")));

                }
            }
            return photos;
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query for photos in SQL database.");
        }
    }

    public static bool DoesCustomerExist(string user, string pw)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT ID FROM customers " +
                            "WHERE Username = @user " +
                            "AND Password = @pw";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pw", pw);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read();
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query for customer in SQL database.");
        }
    }

    public static int GetUserId(string user)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT ID FROM customers " +
                            "WHERE Username = @user ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? reader.GetInt32(0) : -1;
                    }
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query for customer in SQL database.");
        }
    }

    public static bool IsUsernameTaken(string user)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT ID FROM customers " +
                            "WHERE Username = @user";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read();
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query for username in SQL database.");
        }
    }

    public static void AddUserToDatabase(string user, string pw)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "INSERT INTO customers (Username, Password) " +
                            "VALUES(@user, @pw)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pw", pw);

                    var reader = cmd.ExecuteNonQuery();
                    if (reader != 1)
                        throw new Exception();
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to create User in SQL database.");
        }
    }

    public static void SaveNewPassword(string user, string newPw)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "UPDATE customers SET Password = @pw " +
                            "WHERE Username = @user";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pw", newPw);

                    var reader = cmd.ExecuteNonQuery();
                    if (reader != 1)
                        throw new Exception();
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    public static IReadOnlyList<Component> GetAllComputers()
    {
        try
        {
            var comps = new List<Component>();
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT Name, Price, ImageUrl,Id " +
                            "FROM computers";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            comps.Add(new Component(Constants.ComponentType.Computer,
                                reader.GetString(0),
                                reader.GetDouble(1),
                                false,
                                reader.GetString(2),
                                reader.GetInt32(3)));
                        }
                    }
                }
            }

            return comps;
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    public static Component GetComputer(int id)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT Name, Price, ImageUrl,Id " +
                            "FROM computers " +
                            "WHERE Id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return new Component(Constants.ComponentType.Computer,
                                reader.GetString(0),
                                reader.GetDouble(1),
                                false,
                                reader.GetString(2),
                                reader.GetInt32(3));
                        }

                        return null;
                    }
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    public static IReadOnlyList<Component> GetAllComponents()
    {
        try
        {
            var components = new List<Component>();
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT ComponentType, Name, Price, IsDefault, ImageUrl, Id " +
                            "FROM components ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if(Constants.ComponentType.TryParse(reader.GetString(0), out Constants.ComponentType compType))
                            components.Add(new Component(compType,
                                reader.GetString(1),
                                reader.GetDouble(2),
                                reader.GetInt32(3) != 0,
                                reader.GetString(4),
                                reader.GetInt32(5)));
                        }
                    }
                }
            }
            return components;
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    public static Component GetComponent(int id)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT ComponentType, Name, Price, IsDefault, ImageUrl, Id " +
                            "FROM components " +
                            "WHERE Id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (Constants.ComponentType.TryParse(reader.GetString(0), out Constants.ComponentType compType))
                                return new Component(compType,
                                    reader.GetString(1),
                                    reader.GetDouble(2),
                                    reader.GetInt32(3) != 0,
                                    reader.GetString(4),
                                    reader.GetInt32(5));
                        }
                    }

                    return null;
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    public static int AddCartItemToOrder(CartItem item, string user)
    {
        try
        {
            var userId = GetUserId(user);
            if (userId == -1)
                return -1;

            var orderId = OrderExists(userId, item.Summary);
            if (orderId > 0)
            {
                return UpdateOrderQty(orderId);
            }

            var idType = item.Item.ParentComponent == Constants.ComponentType.Computer ? "ComputerId" : "ComponentId";

            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = $"INSERT INTO orders (Price, Detail, ImageUrl, Qty, CustomerId, {idType}) " +
                            "VALUES (@price, @details, @img, @qty, @custId, @compId)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@price", item.TotalPrice);
                    cmd.Parameters.AddWithValue("@details", item.Summary);
                    cmd.Parameters.AddWithValue("@img", item.Item.ImgUrl);
                    cmd.Parameters.AddWithValue("@qty", 1);
                    cmd.Parameters.AddWithValue("@custId", userId);
                    cmd.Parameters.AddWithValue("@compId", item.Item.Id);

                    var row = cmd.ExecuteNonQuery();
                    return GetOrderId(item.Summary, userId);
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    private static int GetOrderId(string details, int UserId)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = $"SELECT Id FROM orders " +
                            $"WHERE Detail = @details " +
                            $"AND CustomerId = @user";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@details", details);
                    cmd.Parameters.AddWithValue("@user", UserId);

                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? reader.GetInt32(0) : 0;
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    public static int UpdateOrderQty(int orderId, int newQty = -1)
    {
        try
        {
            int qty = GetOrderQty(orderId);
            if(newQty == -1)
                qty++;
            else
            {
                qty = newQty;
            }

            if (qty == 0)
            {
                DeleteOrder(orderId);
                return 0;
            }

            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "UPDATE orders SET Qty = @qty " +
                            "WHERE Id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.ExecuteNonQuery();

                    return orderId;
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    private static void DeleteOrder(int orderId)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "DELETE FROM orders WHERE Id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    private static int GetOrderQty(int orderId)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT Qty FROM orders " +
                            $"WHERE Id = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? reader.GetInt32(0) : 0;
                    }
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    private static int OrderExists(int userId, string details)
    {
        try
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT Id FROM orders " +
                            "WHERE CustomerId = @user " +
                            $"AND Detail = @details";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", userId);
                    cmd.Parameters.AddWithValue("@details", details);

                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? reader.GetInt32(0) : -1;
                    }
                }
            }
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }

    public static IReadOnlyList<CartItem> GetOrdersForUser(string user)
    {
        try
        {
            var items = new List<CartItem>();
            var userId = GetUserId(user);
            if(userId <= 0)
                return items;

            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                var query = "SELECT Id, ImageUrl, Price, Detail, Qty FROM orders " +
                            "WHERE CustomerId = @user";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new CartItem(
                                reader.GetInt32(0),
                                new Component(reader.GetString(1)),
                                reader.GetDouble(2),
                                reader.GetString(3),
                                reader.GetInt32(4)));
                        }
                    }
                }
            }

            return items;
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
        catch (Exception e)
        {
            throw new Exception("Unsuccessful query to update User's password in SQL database.");
        }
    }
}