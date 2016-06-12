using Dapper;
using refactor_me.Models;
using System;
using System.Linq;

namespace refactor_me.Dao
{
   public class ProductOptionDao
    {
        public ProductOptions LoadOptionsByProductId(Guid productId)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "SELECT * FROM ProductOption WHERE ProductId = @productId";
                var result = conn.Query<ProductOption>(query, new { productId });

                ProductOptions productOptions = new ProductOptions(result.ToList());
                return productOptions;
            }
        }

        public ProductOption LoadOptionById(Guid id)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "SELECT * FROM ProductOption WHERE Id = @Id";
                ProductOption result = conn.Query<ProductOption>(query, new { id }).SingleOrDefault();
                return result;
            }
        }

        public void AddProductOption(Guid productId, ProductOption option)
        {
            using (var conn = Helpers.NewConnection())
            {
                option.ProductId = productId;
                string query = "INSERT INTO ProductOption VALUES(@Id,@ProductId,@Name,@Description)";
                conn.Execute(query, option);
            }
        }

        public void UpdateProductOption(Guid id, ProductOption option)
        {
            using (var conn = Helpers.NewConnection())
            {
                ProductOption originalOption = LoadOptionById(id);
                if (originalOption != null)
                {
                    string query = @"UPDATE ProductOption SET Name = @Name, Description = @Description 
                                    WHERE Id = @Id";
                    conn.Execute(query, new
                    {
                        option.Name,
                        option.Description,
                        Id = id
                    });
                }
            }
        }

        public void DeleteOptionById(Guid id)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "DELETE FROM ProductOption WHERE Id = @Id";
                conn.Execute(query, new { Id = id });
            }
        }

        public void DeleteOptionsByProductId(Guid id)
        {
            using (var conn = Helpers.NewConnection())
            {
                string query = "DELETE FROM ProductOption WHERE ProductId = @Id";
                conn.Execute(query, new { Id = id });
            }
        }
    }
}
