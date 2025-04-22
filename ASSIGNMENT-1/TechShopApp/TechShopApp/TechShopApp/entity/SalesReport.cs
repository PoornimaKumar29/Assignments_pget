using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApp.entity
{
    public class SalesReport
    {
        public DateTime Date { get; set; }
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }

        // Constructor
        public SalesReport(DateTime date, int orderID, string productName, decimal totalAmount, int quantity)
        {
            Date = date;
            OrderID = orderID;
            ProductName = productName;
            TotalAmount = totalAmount;
            Quantity = quantity;
        }
    }
}
