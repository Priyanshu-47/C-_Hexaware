using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    internal class Inventory
    {
        // Attributes
        public int InventoryID { get; set; }
        public Products ProductID { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

        // Constructor
        public Inventory(int inventoryID, Products productID, int quantityInStock, DateTime lastStockUpdate)
        {
            InventoryID = inventoryID;
            ProductID = productID;
            QuantityInStock = quantityInStock;
            LastStockUpdate = lastStockUpdate;
        }

        // Methods (only declarations)
        //public Products GetProduct();

        //public int GetQuantityInStock();

        //public void AddToInventory(int quantity);

        //public void RemoveFromInventory(int quantity);

        //public void UpdateStockQuantity(int newQuantity);

        //public bool IsProductAvailable(int quantityToCheck);

        //public decimal GetInventoryValue();

        //public void ListLowStockProducts(int threshold);

        //public void ListOutOfStockProducts();

        //public void ListAllProducts();
    }
}
