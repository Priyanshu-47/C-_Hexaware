using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.entity;
using TechShop.Exceptions;
using TechShop.utility;

namespace TechShop.Dao
{
    public class TechShopDao
    {
        public string connectionString;
        SqlCommand cmd = null;

        public TechShopDao()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        //Managing product list 
        public List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve products from the database
                string sql = "SELECT * FROM Products";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products product = new Products
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["ProductName"].ToString(),
                                Description = reader["Description"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"])
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public void AddProduct(Products product)
        {
            try
            {
                // Check for duplicate product
                if (GetProducts().Exists(p => p.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ProductNotFoundException("Product with the same name already exists.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert product into the database
                    string sql = "INSERT INTO Products (ProductName, Description, Price) VALUES (@ProductName, @Description, @Price)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", product.ProductName);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
            }
        }

        public void UpdateProduct(Products updatedProduct)
        {
            try
            {
                // Check if the product exists
                if (!GetProducts().Exists(p => p.ProductID == updatedProduct.ProductID))
                {
                    throw new ProductNotFoundException("Product does not exist.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update product in the database
                    string sql = "UPDATE Products SET ProductName = @ProductName, Description = @Description, Price = @Price WHERE ProductID = @ProductID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", updatedProduct.ProductID);
                        command.Parameters.AddWithValue("@ProductName", updatedProduct.ProductName);
                        command.Parameters.AddWithValue("@Description", updatedProduct.Description);
                        command.Parameters.AddWithValue("@Price", updatedProduct.Price);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (ProductNotFoundException)
            {
                Console.WriteLine("Product not found");
            }
        }

        public void RemoveProduct(int productID)
        {
            try
            {
                // Check if the product has existing orders (assuming there's an Orders table with a foreign key ProductID)
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlCheckOrders = "SELECT COUNT(*) FROM Orders WHERE ProductID = @ProductID";
                    using (SqlCommand commandCheckOrders = new SqlCommand(sqlCheckOrders, connection))
                    {
                        commandCheckOrders.Parameters.AddWithValue("@ProductID", productID);
                        int orderCount = Convert.ToInt32(commandCheckOrders.ExecuteScalar());

                        if (orderCount > 0)
                        {
                            throw new ProductNotFoundException("Cannot remove product with existing orders.");
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Remove product from the database
                    string sql = "DELETE FROM Products WHERE ProductID = @ProductID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", productID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine("Product Not Found");
            }
        }

    }
}
