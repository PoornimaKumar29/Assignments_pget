namespace TechShopApp.entity
{
    public class Order
    {
        private int orderID;
        private Customer customer;  // Relationship with Customer
        private DateTime orderDate;
        private int totalAmount;
        public string Status { get; set; }

        public Order()
        {

        }
        // Constructor
        public Order(int orderID, Customer customer, DateTime orderDate, int totalAmount)
        {
            this.OrderID = orderID;
            this.Customer = customer;
            this.OrderDate = orderDate;
            this.TotalAmount = totalAmount;
        }

        // Properties
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public int TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
    }
}
