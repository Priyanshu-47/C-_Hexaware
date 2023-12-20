using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    internal class OrderDetails
    {
        // Attributes
        public int OrderDetailID { get; set; }
        public Orders OrderID { get; set; } 
        public Products ProductID { get; set; }
        public int Quantity { get; set; }

        // Constructor
        public OrderDetails(int orderDetailID, Orders orderID, Products productID, int quantity)
        {
            OrderDetailID = orderDetailID;
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
        }

        // Methods (only declarations)
        //public decimal CalculateSubtotal();

        //public void GetOrderDetailInfo();

        //public void UpdateQuantity(int newQuantity);

        //public void AddDiscount(decimal discountPercentage);
    }
}
