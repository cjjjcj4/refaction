using Dapper;
using refactor_me.Models;
using System;
using System.Linq;


namespace refactor_me.Dao
{
    public class ProductDao
    {
        public Products LoadAllProducts()
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "SELECT * FROM Product";
                var result = conn.Query<Product>(query);

                Products products = new Products(result.ToList());
                return products;
            }
        }

        public Products LoadProductsByName(String name)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "SELECT * FROM product WHERE Name = @Name";
                var result = conn.Query<Product>(query, new { name });

                Products products = new Products(result.ToList());
                return products;
            }
        }

        public Product LoadProductById(Guid id)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "SELECT * FROM product WHERE Id = @id";
                Product result = conn.Query<Product>(query, new { id }).SingleOrDefault();
                return result;
            }
        }

        public void AddProduct(Product product)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "INSERT INTO product VALUES(@Id,@Name,@Description,@Price,@DeliveryPrice)";
                conn.Execute(query, product);
            } 
        }

        public void UpdateProduct(Guid id, Product product)
        {
            using (var conn = Helpers.NewConnection())
            {
                Product originalProduct = LoadProductById(id);
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

        public void DeleteProduct(Guid id)
        {
            using (var conn = Helpers.NewConnection())
            {
                string deleteOptionsQuery = "DELETE FROM Product WHERE Id = @Id";
                string deleteProductQuery = "DELETE FROM ProductOption WHERE ProductId = @Id";

                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        conn.Execute(deleteOptionsQuery, new { Id = id }, transaction);
                        conn.Execute(deleteProductQuery, new { Id = id }, transaction);
                        transaction.Commit();
                    } catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }


            }
        }

    }
}
