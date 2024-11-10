using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class Inventory
    {
        private readonly DataBase _dataBase;

        public Inventory(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task AddProduct(Product product)
        {
            var newId = await _dataBase.AddProductAsync(product);
            Console.WriteLine($"Product added with ID: {newId}");
        }

        public async Task DisplayProducts()
        {
            var products = await _dataBase.GetAllProductsAsync();

            if (products.Count == 0)
            {
                Console.WriteLine("There are no products!!");
                return;
            }

            foreach (Product product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine("--------------------------------------");
            }
        }

        public async Task EditProduct(string name)
        {
            var product = await _dataBase.GetProductByNameAsync(name);

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
            if (double.TryParse(priceInput, out var newPrice))
            {
                product.Price = newPrice;
            }

            Console.Write("Enter new quantity (leave blank to keep current): ");
            var quantityInput = Console.ReadLine();
            if (int.TryParse(quantityInput, out var newQuantity))
            {
                product.Quantity = newQuantity;
            }

            bool success = await _dataBase.UpdateProductAsync(name, product);
            Console.WriteLine(success ? "Product updated successfully." : "Product update failed.");
        }

        public async Task DeleteProduct(string name)
        {
            bool success = await _dataBase.DeleteProductAsync(name);
            Console.WriteLine(success ? "Product Deleted." : "Product Not Found!!!");
        }

        public async Task SearchProduct(string name)
        {
            var product = await _dataBase.GetProductByNameAsync(name);
            if (product == null)
            {
                Console.WriteLine("Product Not Found");
                return;
            }
            Console.WriteLine(product);
        }
    }
}
