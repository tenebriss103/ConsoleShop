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
    public class AdministratorService : IAdministrator
    {
        private readonly IRepository repository;
       
        

        public AdministratorService(IRepository repo)
        {
            repository = repo;
           
        }

        public bool AddNewProduct(string name, decimal price, string description, string category)
        {
            Product product = new Product
            {
                Name = name,
                Price = price,
                Description = description,
                Category = category
            };

            if (product.Price <= 0)
            {              
                throw new ShopException("Invalid price!"); 
                               
            }
            repository.Products.Add(product);        
            return true;

        }

        public bool ChangeInformationProduct(int prodId, string name, decimal price, string description, string category)
        {
            var id = repository.Products.FirstOrDefault(p => p.ProductId == prodId);
            if (id is null)
            {
                throw new ShopException("Invalid id!");
            }
            Product newProd = new Product
            {
                ProductId = prodId,
                Name = name,
                Price = price,
                Description = description,
                Category = category
            };
            if (newProd.Price <= 0)
            {
                throw new ShopException("Invalid price!");
            }
            repository.Products.Remove(id);
            repository.Products.Add(newProd);
            return true;
        }


        public bool ChangingInformationUsers(int userId, string name, string surname, string phone, string email)
        {            
            var id = repository.Persons.FirstOrDefault(p => p.PersonId == userId);
            if (id is null)
            {
                throw new ShopException("Invalid id!");               
               
            }
            Person newPers = new Person
            {
                PersonId = userId,
                Name = name,
                Surname = surname,
                Phone = phone,
                Email = email,
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

        public  bool ChangeStatusOrder(int orderId , OrderStatus status)
        {
            var id = repository.Orders.Find(p => p.OrderId == orderId);

            if (id is null)
            {
                throw new ShopException("Invalid Id!");                
            }
            
            id.OrderStatus = status;            
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
            var person = repository.Persons.FirstOrDefault(p => p.Online);
            person.Online = false;
           
        }


        public bool ViewingInformationUsers()
        {
           
            var a = repository.Persons.OrderBy(p => p.PersonId).ToList();
            foreach (var product in a)
            {
                Print.PrintList(product.ToString());
            }
            return true;
        }


    }
}

