using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
       
       
        private static int NextId { get; set; } = 0;

        public Product()
        {
            NextId++;
            ProductId = NextId;
        }

        public override string ToString()
        {
            return $"Id: {ProductId}, Name: {Name}, Price: {Price}, Description: {Description}, Category: {Category} ";
        }

        
    }
}
