using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
   public class Order
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int Customer { get; set; } 
        public List<Product> Goods { get; set; }

        private static int NextId { get; set; } = 0;
        public Order()
        {
            OrderId = NextId+1;
          NextId++;
        }
        public override string ToString()
        {
            return $"Id: {OrderId}, Status: {OrderStatus}, Customer: {Customer},  Goods : { Goods } ";
        }
    }
}
