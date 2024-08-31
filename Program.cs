using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class Program
    {


        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            inventory.AddProduct(new Product("pencils", 10, 100));
            inventory.AddProduct(new Product("erasers", 10, 100));
            inventory.AddProduct(new Product("boards", 10, 100));

            inventory.DisplayProducts();
        }

    }
}
