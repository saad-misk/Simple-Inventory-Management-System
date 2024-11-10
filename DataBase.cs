using Microsoft.Data.SqlClient;

namespace SimpleInventoryManagementSystem
{
    public class DataBase
    {
        private readonly string _connString;

        public DataBase(string connString)
        {
            _connString = connString;
        }

        public async Task<Guid> AddProductAsync(Product product)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var query = "INSERT INTO Products (Id, Name, Price, Quantity) OUTPUT INSERTED.Id VALUES (@Id, @Name, @Price, @Quantity)";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);

                conn.Open();
                var newId = (Guid)await command.ExecuteScalarAsync();
                return newId;
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = new List<Product>();

            using (var conn = new SqlConnection(_connString))
            {
                var query = "SELECT Id, Name, Price, Quantity FROM Products";
                var command = new SqlCommand(query, conn);

                conn.Open();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var product = new Product(
                            Id: reader.GetGuid(reader.GetOrdinal("Id")),
                            Name: reader.GetString(reader.GetOrdinal("Name")),
                            Price: Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                            Quantity: reader.GetInt32(reader.GetOrdinal("Quantity"))
                        );
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            Product product = null;

            using (var conn = new SqlConnection(_connString))
            {
                var query = "SELECT Id, Name, Price, Quantity FROM Products WHERE Name = @Name";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Name", name);

                conn.Open();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        product = new Product(
                            Id: reader.GetGuid(reader.GetOrdinal("Id")),
                            Name: reader.GetString(reader.GetOrdinal("Name")),
                            Price: Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                            Quantity: reader.GetInt32(reader.GetOrdinal("Quantity"))
                        );
                    }
                }
            }
            return product;
        }

        public async Task<bool> UpdateProductAsync(string name, Product updatedProduct)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var query = "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE Name = @OriginalName";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Name", updatedProduct.Name);
                command.Parameters.AddWithValue("@Price", updatedProduct.Price);
                command.Parameters.AddWithValue("@Quantity", updatedProduct.Quantity);
                command.Parameters.AddWithValue("@OriginalName", name);

                conn.Open();
                var rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteProductAsync(string name)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var query = "DELETE FROM Products WHERE Name = @Name";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Name", name);

                conn.Open();
                var rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }
    }
}
