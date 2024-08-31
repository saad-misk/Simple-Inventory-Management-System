using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // Initialize the Product instance within the Main method
            Product p = new Product("bags", 60, 100);

            // Output the product details
            Console.WriteLine("hi");
            Console.WriteLine(p.ToString());
        }

    }
}
