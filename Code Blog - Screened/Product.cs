using System;

namespace Adapter_Patterns.Code_Blog
{
    /// <summary>
    /// Товар.
    /// </summary>
    public class Product
    {        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}