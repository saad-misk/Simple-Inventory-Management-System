using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-PEKH0BU;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;";
            var dataBase = new DataBase(connectionString);
            var inventory = new Inventory(dataBase);

            PrintHelloMessage();

            while (true)
            {
                DisplayMenue();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var product = ReadProduct();
                        await inventory.AddProduct(product);
                        break;

                    case "2":
                        await inventory.DisplayProducts();
                        break;

                    case "3":
                        Console.Write("Enter product name to edit: ");
                        var editName = Console.ReadLine() ?? "";
                        await inventory.EditProduct(editName);
                        break;

                    case "4":
                        Console.Write("Enter product name to delete: ");
                        var deleteName = Console.ReadLine() ?? "";
                        await inventory.DeleteProduct(deleteName);
                        break;

                    case "5":
                        Console.Write("Enter product name to search: ");
                        var searchName = Console.ReadLine() ?? "";
                        await inventory.SearchProduct(searchName);
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("\n************************************************************\n");
            }
        }

        static void PrintHelloMessage()
        {
            Console.WriteLine("\r\n  _____                           _                        __  __                                                            _   \r\n |_   _|                         | |                      |  \\/  |                                                          | |  \r\n   | |   _ __ __   __ ___  _ __  | |_  ___   _ __  _   _  | \\  / |  __ _  _ __    __ _   __ _   ___  _ __ ___    ___  _ __  | |_ \r\n   | |  | '_ \\\\ \\ / // _ \\| '_ \\ | __|/ _ \\ | '__|| | | | | |\\/| | / _` || '_ \\  / _` | / _` | / _ \\| '_ ` _ \\  / _ \\| '_ \\ | __|\r\n  _| |_ | | | |\\ V /|  __/| | | || |_| (_) || |   | |_| | | |  | || (_| || | | || (_| || (_| ||  __/| | | | | ||  __/| | | || |_ \r\n |_____||_| |_| \\_/  \\___||_| |_| \\__|\\___/ |_|    \\__, | |_|  |_| \\__,_||_| |_| \\__,_| \\__, | \\___||_| |_| |_| \\___||_| |_| \\__|\r\n                                                    __/ |                                __/ |                                   \r\n                                                   |___/                                |___/                                    \r\n");
        }

        static void DisplayMenue()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search Product");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
        }

        static Product ReadProduct()
        {
            Console.Write("Enter product name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Enter product price: ");
            var price = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter product quantity: ");
            var quantity = int.Parse(Console.ReadLine() ?? "0");

            return new Product(name, price, quantity);
        }


    }

}

