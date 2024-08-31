using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class Product
    {
        private string Name {  get; set; }
        private string? Description { get; set; }
        private double Price {  get; set; }
        private int Quantity { get; set; }

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
