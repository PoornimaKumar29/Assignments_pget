using System;
using TechShopApp.dao;
using TechShopApp.entity;
using Microsoft.Data.SqlClient;
using TechShopApp.util;
using TechShopApp.exception;

namespace TechShopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Opening database connection...");
                using (SqlConnection conn = DatabaseConnector.OpenConnection())
                {
                    Console.WriteLine("Database connected successfully!\n");
                }
            }
            catch (DatabaseConnectionException ex)
            {
                Console.WriteLine("❌ Failed to connect to the database.");
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Exiting application...");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ An unexpected error occurred.");
                Console.WriteLine("Error: " + ex.Message);
                return;
            }
            ServiceProvider serviceProvider = new ServiceProvider();
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("TechShopApp Menu:");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. Place Order");
                Console.WriteLine("6. Add Order Detail");
                Console.WriteLine("7. Get Order Status");
                Console.WriteLine("8. Add Inventory");
                Console.WriteLine("9. Update Inventory");
                Console.WriteLine("10. Remove Inventory");
                Console.WriteLine("11. Update Customer Account");
                Console.WriteLine("12. Process Payment");
                Console.WriteLine("13. Search Products");
                Console.WriteLine("14. Get Recommended Products");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Register Customer
                        Console.WriteLine("Enter Customer Details:");
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();

                        Customer customer = new Customer
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            Phone = phone,
                            Address = address
                        };
                        try
                        {
                            serviceProvider.RegisterCustomer(customer);
                            Console.WriteLine("Customer Registered Successfully!");
                        }
                            catch (InvalidCustomerException ex)
                            {
                            Console.WriteLine("Failed to register customer.");
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;


                    case 2:
                        // Add Product
                        Console.WriteLine("Enter Product Details:");
                        Console.Write("Product Name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Price: ");
                        int price = Convert.ToInt32(Console.ReadLine());

                        Product product = new Product
                        {
                            ProductName = productName,
                            ProductDescription = description,
                            ProductPrice = price
                        };
                        try
                        {
                            serviceProvider.AddProduct(product);
                            Console.WriteLine("Product Added Successfully!");
                        }
                        catch (InvalidProductException ex)
                        {
                            Console.WriteLine("Failed to add product.");
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;
                    case 3:
                        // Update Product
                        Console.Write("Enter Product ID to Update: ");
                        int updateProductID = int.Parse(Console.ReadLine());
                        Console.Write("Updated Product Name: ");
                        string updatedProductName = Console.ReadLine();
                        Console.Write("Updated Description: ");
                        string updatedDescription = Console.ReadLine();
                        Console.Write("Updated Price: ");
                        int updatedPrice = Convert.ToInt32(Console.ReadLine());

                      

                        Product updatedProduct = new Product
                        {
                            ProductID = updateProductID,
                            ProductName = updatedProductName,
                            ProductDescription = updatedDescription,
                            ProductPrice = updatedPrice
                        };
                        try
                        {
                            serviceProvider.UpdateProduct(updatedProduct);
                        }
                        catch (InvalidProductException ex)
                        {
                            Console.WriteLine("Failed to update product.");
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 4:
                        // Remove Product
                        Console.Write("Enter Product ID to Remove: ");
                        int productIDToRemove = int.Parse(Console.ReadLine());
                        try
                        {
                            serviceProvider.RemoveProduct(productIDToRemove);
                        }
                        catch (InvalidProductException ex)
                        {
                            Console.WriteLine("Failed to remove product.");
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 5:
                        // Place Order
                        Console.WriteLine("Enter Order Details:");
                        Console.Write("Customer ID: ");
                        int customerIDForOrder = int.Parse(Console.ReadLine());
                        Console.Write("Order Date (yyyy-mm-dd): ");
                        DateTime orderDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Total Amount: ");
                        int totalAmount = int.Parse(Console.ReadLine());

                        Order order = new Order
                        {
                            Customer = new Customer { CustomerID = customerIDForOrder },
                            OrderDate = orderDate,
                            TotalAmount = totalAmount
                        };
                        try
                        {
                            serviceProvider.PlaceOrder(order);
                            Console.WriteLine("Order Placed Successfully!");
                        }
                        catch (OrderProcessingException ex)
                        {
                            Console.WriteLine(" Failed to place order.");
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 6:
                        // Add Order Detail
                        Console.WriteLine("Enter Order Detail:");
                        Console.Write("Order ID: ");
                        int orderIDForDetail = int.Parse(Console.ReadLine());
                        Console.Write("Product ID: ");
                        int productIDForDetail = int.Parse(Console.ReadLine());
                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        OrderDetail orderDetail = new OrderDetail
                        {
                            Order = new Order { OrderID = orderIDForDetail },
                            Product = new Product { ProductID = productIDForDetail },
                            Quantity = quantity
                        };
                        serviceProvider.AddOrderDetail(orderDetail);
                        Console.WriteLine("Order Detail Added Successfully!");
                        break;

                    case 7:
                        // Get Order Status
                        Console.Write("Enter Order ID to Get Status: ");
                        int orderIDToCheck = int.Parse(Console.ReadLine());
                        string orderStatus = serviceProvider.GetOrderStatus(orderIDToCheck);
                        Console.WriteLine($"Order Status: {orderStatus}");
                        break;

                    case 8:
                        // Add Inventory
                        Console.WriteLine("Enter Inventory Details:");
                        Console.Write("Product ID: ");
                        int productIDForInventory = int.Parse(Console.ReadLine());
                        Console.Write("Quantity in Stock: ");
                        int quantityInStock = int.Parse(Console.ReadLine());
                        Console.Write("Last Stock Update (yyyy-mm-dd): ");
                        DateTime lastStockUpdate = DateTime.Parse(Console.ReadLine());

                        Inventory inventory = new Inventory
                        {
                            Product = new Product { ProductID = productIDForInventory },
                            QuantityInStock = quantityInStock,
                            LastStockUpdate = lastStockUpdate
                        };
                        serviceProvider.AddInventory(inventory);
                        Console.WriteLine("Inventory Added Successfully!");
                        break;

                    case 9:
                        // Update Inventory
                        Console.Write("Enter Inventory ID to Update: ");
                        int inventoryIDToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Updated Quantity in Stock: ");
                        int updatedQuantityInStock = int.Parse(Console.ReadLine());
                        Console.Write("Updated Last Stock Update (yyyy-mm-dd): ");
                        DateTime updatedStockDate = DateTime.Parse(Console.ReadLine());

                        Inventory updatedInventory = new Inventory
                        {
                            InventoryID = inventoryIDToUpdate,
                            QuantityInStock = updatedQuantityInStock,
                            LastStockUpdate = updatedStockDate
                        };
                        serviceProvider.UpdateInventory(updatedInventory);
                        Console.WriteLine("Inventory Updated Successfully!");
                        break;

                    case 10:
                        // Remove Inventory
                        Console.Write("Enter Inventory ID to Remove: ");
                        int inventoryIDToRemove = int.Parse(Console.ReadLine());
                        serviceProvider.RemoveInventory(inventoryIDToRemove);
                        Console.WriteLine("Inventory Removed Successfully!");
                        break;

                    case 11:
                        // Update Customer Account
                        Console.Write("Enter Customer ID to Update: ");
                        int customerIDToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Updated First Name: ");
                        string updatedFirstName = Console.ReadLine();
                        Console.Write("Updated Last Name: ");
                        string updatedLastName = Console.ReadLine();
                        Console.Write("Updated Email: ");
                        string updatedEmail = Console.ReadLine();
                        Console.Write("Updated Phone: ");
                        string updatedPhone = Console.ReadLine();
                        Console.Write("Updated Address: ");
                        string updatedAddress = Console.ReadLine();

                        Customer updatedCustomer = new Customer
                        {
                            CustomerID = customerIDToUpdate,
                            FirstName = updatedFirstName,
                            LastName = updatedLastName,
                            Email = updatedEmail,
                            Phone = updatedPhone,
                            Address = updatedAddress
                        };
                        serviceProvider.UpdateCustomerAccount(updatedCustomer);
                        Console.WriteLine("Customer Account Updated Successfully!");
                        break;

                    case 12:
                        // Process Payment
                        Console.Write("Enter Order ID to Process Payment: ");
                        int orderIDForPayment = int.Parse(Console.ReadLine());
                        Console.Write("Enter Payment Amount: ");
                        decimal paymentAmount = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Payment Method: ");
                        string paymentMethod = Console.ReadLine();
                        try
                        {
                            serviceProvider.ProcessPayment(orderIDForPayment, paymentAmount, paymentMethod);
                            Console.WriteLine("Payment Processed Successfully!");
                        }
                        catch (PaymentProcessingException ex)
                        {
                            Console.WriteLine("❌ Failed to process payment.");
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 13:
                        // Search Products
                        Console.Write("Enter Search Product: ");
                        string searchQuery = Console.ReadLine();
                        var products = serviceProvider.SearchProducts(searchQuery);
                        Console.WriteLine("Search Results:");
                        foreach (var prod in products)
                        {
                            Console.WriteLine($"Product ID: {prod.ProductID}, Name: {prod.ProductName}, Price: {prod.ProductPrice}");
                        }
                        break;

                    case 14:
                        // Get Recommended Products
                        Console.Write("Enter Customer ID for Recommendations: ");
                        int customerIDForRecommendation = int.Parse(Console.ReadLine());
                        var recommendedProducts = serviceProvider.GetRecommendedProducts(customerIDForRecommendation);
                        Console.WriteLine("Recommended Products:");
                        foreach (var prod in recommendedProducts)
                        {
                            Console.WriteLine($"Product ID: {prod.ProductID}, Name: {prod.ProductName}, Price: {prod.ProductPrice}");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();  //
            } while (choice != 0);
        }
    }
}
