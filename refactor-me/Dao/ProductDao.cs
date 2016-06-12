using Dapper;
using refactor_me.Models;
using System;
using System.Linq;


namespace refactor_me.Dao
{
    public class ProductDao
    {
        public Products loadAllProducts()
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "SELECT * FROM Product";
                var result = conn.Query<Product>(query);

                Products products = new Products(result.ToList());
                return products;
            }
        }

        public Products loadProductsByName(String name)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "SELECT * FROM product WHERE Name = @Name";
                var result = conn.Query<Product>(query, new { name });

                Products products = new Products(result.ToList());
                return products;
            }
        }

        public Product loadProductById(Guid id)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "SELECT * FROM product WHERE Id = @id";
                Product result = conn.Query<Product>(query, new { id }).SingleOrDefault();
                return result;
            }
        }

        public void addProduct(Product product)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "INSERT INTO product VALUES(@Id,@Name,@Description,@Price,@DeliveryPrice)";
                conn.Execute(query, product);
            } 
        }

        public void updateProduct(Guid id, Product product)
        {
            using (var conn = Helpers.NewConnection())
            {
                Product originalProduct = loadProductById(id);
                if(originalProduct != null)
                {
                    string query = @"UPDATE product SET Name = @Name, Description = @Description, Price = @Price, DeliveryPrice = @DeliveryPrice 
                                    WHERE Id = @Id";
                    conn.Execute(query, new {
                        product.Name,
                        product.Description,
                        product.Price,
                        product.DeliveryPrice,
                        Id = id
                    });
                }
            }
        }

        public void deleteProduct(Guid id)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "DELETE FROM Product WHERE Id = @Id";
                conn.Execute(query, new { Id = id });
            }
        }

    }
}
