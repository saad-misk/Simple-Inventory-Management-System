using SimpleInventoryManagementSystem.MongoDB;

namespace SimpleInventoryManagementSystem
{
    public class Inventory
    {
        private MongoDBDatabase _database;

        public Inventory()
        {
            _database = new MongoDBDatabase();
        }

        public async Task AddProductAsync(Product product)
        {
            await _database.AddProductAsync(product);
        }

        public async Task DisplayProductsAsync()
        {
            var products = await _database.GetProductsAsync();
            if (products.Count == 0)
            {
                Console.WriteLine("There are no products!");
                return;
            }

            foreach (Product product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine("--------------------------------------");
            }
        }

        public async Task EditProductAsync(string name)
        {
            var product = await _database.SearchProductAsync(name);
            if (product == null)
            {
                Console.WriteLine("Product Not Found!");
                return;
            }

            Console.WriteLine("Enter new name (leave blank to keep current): ");
            var newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                product.Name = newName;
            }

            Console.Write("Enter new price (leave blank to keep current): ");
            var priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out var newPrice))
            {
                product.Price = (double)newPrice;
            }

            Console.Write("Enter new quantity (leave blank to keep current): ");
            var quantityInput = Console.ReadLine();
            if (int.TryParse(quantityInput, out var newQuantity))
            {
                product.Quantity = newQuantity;
            }

            await _database.UpdateProductAsync(name, product);
        }

        public async Task DeleteProductAsync(string name)
        {
            var product = await _database.SearchProductAsync(name);
            if (product == null)
            {
                Console.WriteLine("Product Not Found!");
                return;
            }

            await _database.DeleteProductAsync(name);
            Console.WriteLine("Product Deleted.");
        }

        public async Task SearchProductAsync(string name)
        {
            var product = await _database.SearchProductAsync(name);
            if (product == null)
            {
                Console.WriteLine("Product Not Found");
                return;
            }

            Console.WriteLine(product);
        }
    }
}
