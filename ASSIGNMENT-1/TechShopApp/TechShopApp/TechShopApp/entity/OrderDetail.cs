namespace TechShopApp.entity
{
    public class OrderDetail
    {
        private int orderDetailID;
        private Order order;  // Relationship with Order
        private Product product;  // Relationship with Product
        private int quantity;
        public OrderDetail()
        {

        }
        // Constructor
        public OrderDetail(int orderDetailID, Order order, Product product, int quantity)
        {
            this.OrderDetailID = orderDetailID;
            this.Order = order;
            this.Product = product;
            this.Quantity = quantity;
        }

        // Properties
        public int OrderDetailID
        {
            get { return orderDetailID; }
            set { orderDetailID = value; }
        }

        public Order Order
        {
            get { return order; }
            set { order = value; }
        }

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value > 0) quantity = value;
                else Console.WriteLine("Quantity should be greater than 0.");
            }
        }
    }
}
