using System;
using System.Data.SqlClient;
using TechShopApp.entity;
using TechShopApp.exception;
using TechShopApp.util;
using Microsoft.Data.SqlClient;
namespace TechShopApp.dao
{
    public class ServiceProvider : IServiceProvider
    {
        public void RegisterCustomer(Customer customer)
        {
            // Validation: Ensure customer values are valid.
            if (string.IsNullOrWhiteSpace(customer.FirstName) || string.IsNullOrWhiteSpace(customer.LastName) ||
                string.IsNullOrWhiteSpace(customer.Email) || string.IsNullOrWhiteSpace(customer.Phone) ||
                string.IsNullOrWhiteSpace(customer.Address))
            {
                Console.WriteLine("Customer details are invalid.");
                return; // Exit early if invalid
            }

            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    // Query to insert a new customer without specifying the Customer_id (since it's auto-generated)
                    string query = "INSERT INTO Customers (Customer_FirstName, Customer_LastName, Customer_Email, Customer_Phone, Address) " +
                                   "VALUES (@FirstName, @LastName, @Email, @Phone, @Address)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@Address", customer.Address);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the insert was successful by checking rows affected.
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Customer registered successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to register the customer.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public void AddProduct(Product product)
        {
            // Validation: Ensure product values are valid.
            if (string.IsNullOrWhiteSpace(product.ProductName) || product.ProductPrice <= 0)
            {
                Console.WriteLine("Product Name or Price is invalid.");
                return; // Exit early if invalid
            }

            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO Products (Product_Name, Product_Description, Product_Price) " +
                                   "VALUES (@ProductName, @Description, @Price)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Description", product.ProductDescription);
                    command.Parameters.AddWithValue("@Price", product.ProductPrice);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the insert was successful by checking rows affected.
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Product added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add the product.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public void UpdateProduct(Product product)
        {
            // Validation: Ensure product values are valid.
            if (product.ProductID <= 0 || string.IsNullOrWhiteSpace(product.ProductName) || product.ProductPrice <= 0)
            {
                Console.WriteLine("Product details are invalid.");
                return; // Exit early if invalid
            }

            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    // Ensure column names match the ones in your database
                    string query = "UPDATE Products SET Product_Name = @ProductName, Product_Description = @Description, Product_Price = @Price WHERE Product_id = @ProductID";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Add parameters for product details
                    command.Parameters.AddWithValue("@ProductID", product.ProductID); // The ID of the product to update
                    command.Parameters.AddWithValue("@ProductName", product.ProductName); // Updated name
                    command.Parameters.AddWithValue("@Description", product.ProductDescription); // Updated description
                    command.Parameters.AddWithValue("@Price", product.ProductPrice); // Updated price

                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the update was successful by checking rows affected.
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Product updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No product found to update.");
                    }
                }
                catch (Exception ex)
                {
                    // Error handling
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public void RemoveProduct(int productID)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM Products WHERE Product_id = @ProductID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", productID);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Product with ID {productID} was successfully removed.");
                        }
                        else
                        {
                            Console.WriteLine($"No product found with ID {productID}.");
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Error occurred while removing the product: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }}
        public void PlaceOrder(Order order)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO Orders (Customer_id, Order_Date, Total_Amount) VALUES (@CustomerId, @OrderDate, @TotalAmount)";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Use the updated column names based on your new SQL schema
                    command.Parameters.AddWithValue("@CustomerId", order.Customer.CustomerID);  // Updated to match the new column name 'Customer_id'
                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate);              // Updated to match the new column name 'Order_Date'
                    command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);          // Updated to match the new column name 'Total_Amount'

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO OrderDetails (Order_id, Product_id, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (orderDetail.Order == null || orderDetail.Product == null)
                        {
                            throw new ArgumentNullException("Order or Product in OrderDetail cannot be null.");
                        }

                        command.Parameters.AddWithValue("@OrderID", orderDetail.Order.OrderID);
                        command.Parameters.AddWithValue("@ProductID", orderDetail.Product.ProductID);
                        command.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Order detail added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows were inserted. Please check the data.");
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine($"SQL Error: {sqlEx.Message}");
                }
                catch (ArgumentNullException argEx)
                {
                    Console.WriteLine($"Argument Error: {argEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                }}}
        public string GetOrderStatus(int orderID)
        {
            try
            {
                using (SqlConnection connection = DatabaseConnector.OpenConnection())
                {
                    string query = "SELECT Status FROM Orders WHERE Order_id = @OrderID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader["Status"].ToString();
                            }
                            else
                            {
                                return "Order not found.";
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                return "Database error occurred while retrieving order status.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return "Unexpected error occurred while retrieving order status.";
            }
        }

        //
        public void AddInventory(Inventory inventory)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO Inventory (ProductID, QuantityInStock, LastStockUpdate) VALUES (@ProductID, @QuantityInStock, @LastStockUpdate)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", inventory.Product.ProductID);
                    command.Parameters.AddWithValue("@QuantityInStock", inventory.QuantityInStock);
                    command.Parameters.AddWithValue("@LastStockUpdate", inventory.LastStockUpdate);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }}}

        public void UpdateInventory(Inventory inventory)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "UPDATE Inventory SET QuantityInStock = @QuantityInStock, LastStockUpdate = @LastStockUpdate WHERE InventoryID = @InventoryID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@InventoryID", inventory.InventoryID);
                    command.Parameters.AddWithValue("@QuantityInStock", inventory.QuantityInStock);
                    command.Parameters.AddWithValue("@LastStockUpdate", inventory.LastStockUpdate);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }}}

        public void RemoveInventory(int inventoryID)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM Inventory WHERE InventoryID = @InventoryID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@InventoryID", inventoryID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }}}
        public void UpdateCustomerAccount(Customer customer)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = "UPDATE Customers SET Customer_FirstName = @FirstName, Customer_LastName = @LastName, Customer_Email = @Email, Customer_Phone = @Phone, Address = @Address WHERE Customer_id = @CustomerID";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@Address", customer.Address);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public void ProcessPayment(int orderID, decimal amount, string paymentMethod)
        {
            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    // Step 1: Insert Payment Details
                    string paymentQuery = "INSERT INTO Payments (OrderID, Amount, PaymentMethod, PaymentDate) VALUES (@OrderID, @Amount, @PaymentMethod, @PaymentDate)";
                    SqlCommand paymentCommand = new SqlCommand(paymentQuery, connection);
                    paymentCommand.Parameters.AddWithValue("@OrderID", orderID);
                    paymentCommand.Parameters.AddWithValue("@Amount", amount);
                    paymentCommand.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    paymentCommand.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                    paymentCommand.ExecuteNonQuery();

                    // Step 2: Update Order Status to "Paid"
                    string orderStatusQuery = "UPDATE Orders SET Status = 'Paid' WHERE OrderID = @OrderID";
                    SqlCommand orderStatusCommand = new SqlCommand(orderStatusQuery, connection);
                    orderStatusCommand.Parameters.AddWithValue("@OrderID", orderID);
                    orderStatusCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public List<Product> SearchProducts(string searchQuery)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = @"
                SELECT Product_id, Product_Name, Product_Description, Product_Price 
                FROM Products 
                WHERE Product_Name LIKE @SearchQuery OR Product_Description LIKE @SearchQuery";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productID = Convert.ToInt32(reader["Product_id"]);
                                string productName = reader["Product_Name"].ToString();
                                string description = reader["Product_Description"] != DBNull.Value
                                    ? reader["Product_Description"].ToString()
                                    : string.Empty;
                                int price = Convert.ToInt32(reader["Product_Price"]);

                                Product product = new Product(productID, productName, description, price);
                                products.Add(product);
                            }}}}
                catch (SqlException sqlEx)
                {
                    Console.WriteLine($"SQL Error: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                }
            }            return products;
        }
        public List<Product> GetRecommendedProducts(int customerID)
        {
            List<Product> recommendedProducts = new List<Product>();

            using (SqlConnection connection = DatabaseConnector.OpenConnection())
            {
                try
                {
                    string query = @"
                   SELECT DISTINCT p.Product_id, p.Product_Name, CAST(p.Product_Description AS
                    NVARCHAR(MAX)) AS Product_Description, p.Product_Price FROM Products p
                INNER JOIN OrderDetails od ON p.Product_id = od.Product_id
                INNER JOIN Orders o ON o.Order_id = od.Order_id
                WHERE o.Customer_id = @CustomerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Assuming you have a constructor like:
                                // public Product(int productId, string name, string description, decimal price)
                                Product product = new Product(
                                    Convert.ToInt32(reader["Product_id"]),
                                    reader["Product_Name"].ToString(),
                                    reader["Product_Description"].ToString(),
                                    Convert.ToInt32(reader["Product_Price"])
                                );

                                recommendedProducts.Add(product);
                            }}}}
                catch (SqlException sqlEx)
                {Console.WriteLine("Database error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }return recommendedProducts;
        }    }
}