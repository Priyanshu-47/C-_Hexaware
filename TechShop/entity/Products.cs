    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    public class Products
    {
        // Attributes
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Products() { }
        // Constructor
        public Products(int productID, string productName, string description, decimal price)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Description = description;
            this.Price = price;
        }

        // Methods (only declarations)
        //public void GetProductDetails();

        //public void UpdateProductInfo();

        //public bool IsProductInStock();
    }
}
