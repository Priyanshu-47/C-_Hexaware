using TechShop.entity;
using TechShop.Dao;
using TechShop.Exceptions;


class Program
{
    static void Main()
    {
        // Usage example
        TechShopDao techShopDao = new TechShopDao();

        // Adding a product
        Products newProduct = new Products
        {
            ProductName = "New Product",
            Description = "A new product for testing",
            Price = 19.99m
        };
        techShopDao.AddProduct(newProduct);

        // Updating a product
        Products updatedProduct = new Products
        {
            ProductID = 1, // Replace with an existing product ID
            ProductName = "Updated Product",
            Description = "An updated product for testing",
            Price = 29.99m
        };
        techShopDao.UpdateProduct(updatedProduct);

        // Removing a product
        int productIdToRemove = 2; // Replace with an existing product ID
        techShopDao.RemoveProduct(productIdToRemove);

        // Displaying the list of products
        List<Products> productList = techShopDao.GetProducts();
        Console.WriteLine("List of Products:");
        foreach (Products product in productList)
        {
            Console.WriteLine($"ID: {product.ProductID}, Name: {product.ProductName}, Description: {product.Description}, Price: {product.Price:C}");
        }
    }
}