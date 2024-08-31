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

        public void EditProduct()
        {

        }

        public void DeleteProduct()
        {

        }

        public void SearchProduct()
        {

        }

        
    }
}
