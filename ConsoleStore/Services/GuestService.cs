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
    public class GuestService : IGuest
    {
        private readonly IRepository repository;
        

        public GuestService(IRepository repo)
        {
            repository = repo;
          
        }

        public bool AccountRegistration(string name, string surname, string phone, string email, string password)
        {
            Person person = new Person
            {
                Name = name,
                Surname = surname,
                Phone = phone
            };
            if (!int.TryParse(phone, out var number))
            {
                throw new ShopException("Phone should contain numbers");

            }

            person.Email = email;
            if (!email.Contains("@"))
            {
                throw new ShopException("Email should contain '@' symbol");

            }
            person.Password = password;
            person.Position = Position.RegisteredUser;         
            repository.Persons.Add(person);
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


    }
}
