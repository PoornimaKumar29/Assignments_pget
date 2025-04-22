

using TechShopApp.entity;

public interface IServiceProvider
{
    // 1. Customer Registration
    void RegisterCustomer(Customer customer);

    // 2. Product Catalog Management
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void RemoveProduct(int productID);

    //// 3. Placing Customer Orders
    void PlaceOrder(Order order);
    void AddOrderDetail(OrderDetail orderDetail);

    //// 4. Tracking Order Status
    string GetOrderStatus(int orderID);

    //// 5. Inventory Management
    void AddInventory(Inventory inventory);
    void UpdateInventory(Inventory inventory);
    void RemoveInventory(int inventoryID);

    //// 6. Sales Reporting
    //List<SalesReport> GenerateSalesReport(DateTime startDate, DateTime endDate);

    //// 7. Customer Account Updates
    void UpdateCustomerAccount(Customer customer);

    //// 8. Payment Processing
    void ProcessPayment(int orderID, decimal amount, string paymentMethod);

    //// 9. Product Search and Recommendations
    List<Product> SearchProducts(string searchQuery);
    List<Product> GetRecommendedProducts(int customerID);
}
