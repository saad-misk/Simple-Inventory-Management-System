using MongoDB.Driver;

namespace SimpleInventoryManagementSystem.MongoDB
{
    public class MongoDBDatabase
    {
        private readonly IMongoCollection<Product> _productCollection;

        private readonly string _connString = "mongodb://localhost:27017";

        public MongoDBDatabase()
        {
            var client = new MongoClient(_connString);
            var database = client.GetDatabase("InventoryDB");
            _productCollection = database.GetCollection<Product>("Products");
        }

        public async Task AddProductAsync(Product product)
        {
            await _productCollection.InsertOneAsync(product);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productCollection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateProductAsync(string name, Product updatedProduct)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            await _productCollection.ReplaceOneAsync(filter, updatedProduct);
        }

        public async Task DeleteProductAsync(string name)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            await _productCollection.DeleteOneAsync(filter);
        }

        public async Task<Product> SearchProductAsync(string name)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            var result = await _productCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
    }
}
