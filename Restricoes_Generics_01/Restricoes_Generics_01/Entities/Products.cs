using System.Globalization;
using System;

namespace Entities
{
    class Products : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Products(string nome, double price)
        {
            Name = nome;
            Price = price;
        }
        public override string ToString()
        {
            return Name
                + ", "
                + Price.ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Products))
            {
                throw new NotImplementedException();
            }
            Products other = obj as Products;
            return Price.CompareTo(other.Price);

        }
    }
}
