using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    internal class Orders
    {
        // Attributes
        public int OrderID { get; set; }
        public Customers CustomerID { get; set; } // Assuming you have a Customer class defined
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Constructor
        public Orders(int orderID, Customers customerID, DateTime orderDate, decimal totalAmount)
        {
            OrderID = orderID;
            CustomerID = customerID;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
        }

        // Methods (only declarations)
        //public decimal CalculateTotalAmount();

        //public void GetOrderDetails();

        //public void UpdateOrderStatus(string newStatus);

        //public void CancelOrder();
    }
}
