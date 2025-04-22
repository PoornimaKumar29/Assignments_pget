namespace TechShopApp.entity
{
    public class Product
    {
        private int productID;
        private string productName;
        private string productDescription;
        private int productPrice;

        // Constructor
        public Product()
        {

        }
        public Product(int productID, string productName, string productDescription, int productPrice)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.ProductPrice = productPrice;
        }

        // Properties
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        public int ProductPrice
        {
            get { return productPrice; }
            set
            {
                if (value >= 0) productPrice = value;
                else Console.WriteLine("Price cannot be negative.");
            }
        }
    }
}
