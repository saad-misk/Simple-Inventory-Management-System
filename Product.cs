using MongoDB.Bson.Serialization.Attributes;
using System.Text;

namespace SimpleInventoryManagementSystem
{
    public class Product
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product() { }
        public Product(string Name, double Price, int Quantity)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        public Product(Guid Id, string Name, double Price, int Quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
            st.Append($"Product: {Name}, Price per unit: ${Price}, Quantity: {Quantity}");
            if (Description == null)
            {
                st.Append("\n\tDescription: no info");
            }
            else
            {
                st.Append($"\n\tDescription: {Description}");
            }

            return st.ToString();
        }
    }
}
