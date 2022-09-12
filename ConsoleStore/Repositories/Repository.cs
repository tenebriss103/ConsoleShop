using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Repositories
{
    public class Repository: IRepository
    {
        public List<Person> Persons { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }

        public Repository()
        {
            Persons = new List<Person>();
            Products = new List<Product>();
            Orders = new List<Order>();
            DataFilling();
        }
        public void DataFilling()
        {
            var person1 = new Person { PersonId = 1, Name = "Ivan", Surname = "Sericov", Email = "ivan123@gmail.com", Phone = "380965412236", Password = "hbghjkl33", Position = Position.RegisteredUser };
            var person2 = new Person { PersonId = 2, Name = "Oleg", Surname = "Ivanov", Email = "olegG65@gmail.com", Phone = "380685449985", Password = "lokjiole954", Position = Position.RegisteredUser };
            var person3 = new Person { PersonId = 3, Name = "Olena", Surname = "Krasna", Email = "olenaK@gmail.com", Phone = "380631115698", Password = "87okljuip", Position = Position.Administrator };
            Persons.Add(person1);
            Persons.Add(person2);
            Persons.Add(person3);

            var product1 = new Product { ProductId = 1, Name = "Alpine", Price = 102.30m, Category = "Tea", Description = "Herbal blend of lemongrass, chamomile flower, thorns, orange peel" };
            var product2 = new Product { ProductId = 2, Name = "Cherry", Price = 130m, Category = "Tea", Description = "Made on the basis of Sudanese rose petals, dried natural cherries" };
            var product3 = new Product { ProductId = 3, Name = "Dallmayr Hakuna Matata", Price = 435m, Category = "Сoffee", Description = "A bouquet of Arabica and robosta with a harmonious taste and a velvety and delicate foam" };
            var product4 = new Product { ProductId = 4, Name = "Starbucks Veranda Blend", Price = 270m, Category = "Сoffee", Description = "The lightest roast with the softest and most unforgettable taste" };
            var product5 = new Product { ProductId = 5, Name = "Milk Oolong", Price = 110.60m, Category = "Tea", Description = "Jin Xuan - oolong type tea, bred in 1980 in Taiwan" };
            var product6 = new Product { ProductId = 6, Name = "Lavazza Rossa", Price = 420.10m, Category = "Сoffee", Description = "A cult variety from a well-known Italian brand" };
            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product3);
            Products.Add(product4);
            Products.Add(product5);
            Products.Add(product6);

            var order1 = new Order { OrderId = 1, Customer = person1.PersonId, Goods = new List<Product>() { product2 }, OrderStatus = OrderStatus.CanceledBytheAdministrator, };
            var order2 = new Order { OrderId = 2, Customer = person1.PersonId, Goods = new List<Product>() { product2, product4 }, OrderStatus = OrderStatus.Sent, };
            var order3 = new Order { OrderId = 3, Customer = person2.PersonId, Goods = new List<Product>() { product1, product5, product6 }, OrderStatus = OrderStatus.PaymentReceived, };
            Orders.Add(order1);
            Orders.Add(order2);
            Orders.Add(order3);

        }
    }
}
