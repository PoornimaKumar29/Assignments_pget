using System;

namespace TechShopApp.entity
{
    public class Inventory
    {
        private int inventoryID;
        private Product product;  // One-to-one relationship with Product
        private int quantityInStock;
        private DateTime lastStockUpdate;

        // Constructor
        public Inventory(int inventoryID, Product product, int quantityInStock, DateTime lastStockUpdate)
        {
            this.InventoryID = inventoryID;
            this.Product = product;
            this.QuantityInStock = quantityInStock;
            this.LastStockUpdate = lastStockUpdate;
        }

        // Properties
        public Inventory()
        {

        }
        public int InventoryID
        {
            get { return inventoryID; }
            set { inventoryID = value; }
        }

        public Product Product
        {
            get { return product; }
            set
            {
                if (value != null) product = value;
                else Console.WriteLine("Product cannot be null.");
            }
        }

        public int QuantityInStock
        {
            get { return quantityInStock; }
            set
            {
                if (value >= 0) quantityInStock = value;
                else Console.WriteLine("Quantity in stock cannot be negative.");
            }
        }

        public DateTime LastStockUpdate
        {
            get { return lastStockUpdate; }
            set
            {
                if (value <= DateTime.Now) lastStockUpdate = value;
                else Console.WriteLine("Stock update date cannot be in the future.");
            }
        }
    }
}
