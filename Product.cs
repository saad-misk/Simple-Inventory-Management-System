using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class Product
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string? description;
        public string? Description
        {
            get { return description; }
            set { description = value; }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
            st.Append($"Product: {Name}, Price per unit: ${Price}, Quantity: {Quantity}");
            if (Description == null)
            {
                st.Append("\n\tDescription: no inforamtion!");
            }
            else
            {
                st.Append($"\n\tDescription: {Description}");
            }

            return st.ToString();
        }

    }
}
