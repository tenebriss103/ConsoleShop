using ClassLibrary1.Menu;
using ClassLibrary1.Models;
using ClassLibrary1.MyException;
using ClassLibrary1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1.Services
{
    public class UserService : IUser
    {
        private readonly IRepository repository;
        
        public UserService(IRepository repo)
        {
            repository = repo;
        }
        public void SeeOrderHistory()
        {
            var person = repository.Persons.FirstOrDefault(p => p.Online);
            
            var id = repository.Orders.Where(p => person.PersonId == p.Customer);

            foreach (var item in id)
            {
                Print.PrintList(item.ToString()); 
            }
        }      

        public bool SettingStatusOrder(int orderId)
        {           
            var id = repository.Orders.FirstOrDefault(p => p.OrderId == orderId);
            var person = repository.Persons.FirstOrDefault(p=>p.Online);
            
            if (id is null)
            {
                throw new ShopException("There is no order in your history with such ID."); 
                
            }
            id.Customer = person.PersonId;
           id.OrderStatus = OrderStatus.Received;
            return true;
        }
        public bool CancelOrder(int orderId)
        {
            var id = repository.Orders.FirstOrDefault(p => p.OrderId == orderId);            
            if (id is null)
            {
                throw new ShopException("There is no order in your history with such ID.");              
            }
            id.OrderStatus = OrderStatus.CanceledByUser;
            return true;
        }

        public bool ChangingPersonalInformation(string userEmail, string name, string surname, string phone)
        {
            var person = repository.Persons.FirstOrDefault(p => p.Online);
            if (person is null)
            {
                throw new ShopException("No such user");              
            }

            Person newPers = new Person
            {
                Name = name,
                Surname = surname,
                Phone = phone,
                Email = userEmail,
                Position = Position.RegisteredUser
            };

            if (!newPers.Email.Contains("@"))
            {
                throw new ShopException("Email should contain '@' symbol"); 
            }
            repository.Persons.Add(newPers);
            return true;
        }

        public bool CreatingNewOrder(int prodId)
        {

            var persOnline = repository.Persons.FirstOrDefault(p => p.Online);

            var product = repository.Products.FirstOrDefault(p => p.ProductId == prodId);
            if (product is null)
            {
                throw new ShopException("Product not found!");
            }
            var countofOrd = repository.Orders.Count(o => o.Customer == persOnline.PersonId);

            Order newOrd = new Order
            {
                OrderId = countofOrd + 1,
                OrderStatus = OrderStatus.New,
                Customer = persOnline.PersonId,
                Goods = new List<Product>()
            {
                new Product()
                {
                    ProductId = prodId,
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    Description = product.Description,
                }
            }
            };
            repository.Orders.Add(newOrd);
            return true;

        }
        public bool GetProducts()
        {
            var a = repository.Products.OrderBy(p => p.ProductId).ToList();
            foreach (var product in a)
            {
                Print.PrintList(product.ToString());
            }
            return true;
        }

        public bool SearchProductByName(string search)
        {
            var prod = repository.Products.ToArray();
            var prodStr = prod.FirstOrDefault(p => p.Name == search).ToString();
            if (prodStr is null)
            {
                throw new ShopException("Product not found!");
            }
            Print.PrintList(prodStr);
            return true;
        }

        public void SignOut()
        {
           var person = repository.Persons.FirstOrDefault(p=>p.Online);
            person.Online = false;
           
        }
    }
}
