using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class Inventory
    {

        List<Product> products = new List<Product>();
        
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DisplayProducts()
        {
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

        public void EditProduct(string name)
        {
            var product = products.FirstOrDefault(p => p.Name.Equals(name));

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

        }

        public void DeleteProduct()
        {

        }

        public void SearchProduct()
        {

        }

        
    }
}
