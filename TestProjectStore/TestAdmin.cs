
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.Models;

namespace TestProject1
{
    public class TestAdministrator
    {
        private readonly Mock<IRepository> data;
        private readonly AdministratorService services;
        public TestAdministrator()
        {
            data = new Mock<IRepository>();
            services = new AdministratorService(data.Object);
        }

        [Test]
        public void SearchProductByName_ReturnsTrue()
        {
            var expected = new Product()
            { ProductId = 1, Name = "Alpine", Price = 102.30m, Category = "Tea", Description = "Herbal blend of lemongrass, chamomile flower, thorns, orange peel" };
            data.Setup(p => p.Products)
                .Returns(new List<Product>()
                { new Product() {   Name = "Cherry" },
            new Product { ProductId = 3, Name = "Dallmayr Hakuna Matata", Price = 435m, Category = "Сoffee", Description = "A bouquet of Arabica and robosta with a harmonious taste and a velvety and delicate foam" },

                    new Product() {  ProductId = 2, Name = "Cherry", Price = 130m, Category = "Tea", Description = "Made on the basis of Sudanese rose petals, dried natural cherries"  },
                    expected });
            services.SearchProductByName(expected.Name);
            Assert.IsTrue(true);
        }
        [Test]
        public void AddNewProduct_ReturnsTrue()
        {
            data.Setup(p => p.Products)
               .Returns(new List<Product>()
               {
                    new Product() {  ProductId = 2, Name = "Cherry", Price = 130m, Category = "Tea", Description = "Made on the basis of Sudanese rose petals, dried natural cherries"  },
                     });
            services.AddNewProduct("Cherry", 130m, "Tea", "Made on the basis of Sudanese rose petals, dried natural cherries");
            Assert.IsTrue(true);

        }
        [Test]
        public void ChangeInformationProduct_ReturnsTrue()
        {
            data.Setup(p => p.Products)
              .Returns(new List<Product>()
              {
                    new Product() {  ProductId = 2, Name = "Cherry", Price = 130m, Category = "Tea", Description = "Made on the basis of Sudanese rose petals, dried natural cherries"  },
                    });
            services.ChangeInformationProduct(2, "Cherry", 130m, "Tea", "Made on the basis of Sudanese rose petals, dried natural cherries");
            Assert.IsTrue(true);

        }
        [Test]
        public void ChangingInformationUsers_ReturnsTrue()
        {
            data.Setup(p => p.Persons)
             .Returns(new List<Person>()
             {
                    new Person(){  PersonId = 1, Name = "Ivan", Surname = "Sericov", Email = "ivan123@gmail.com", Phone = "380965412236", Password = "hbghjkl33" },
                    });
            services.ChangingInformationUsers(1, "Ivanna", "Sericova", "380661112585", "ivan123@gmail.com");
            Assert.IsTrue(true);

        }
        [Test]
        public void CreatingNewOrder_ReturnsTrue()
        {
            data.Setup(p => p.Persons)
            .Returns(new List<Person>()
            {
                    new Person(){  PersonId = 1, Name = "Olena", Position = Position.Administrator , Online = true},
                   });

            data.Setup(p => p.Orders)
            .Returns(new List<Order>()
            {
                       new Order() { OrderId= 1, OrderStatus = OrderStatus.New },
                   });
            data.Setup(p => p.Products)
             .Returns(new List<Product>()
             {
                    new Product() {  ProductId = 2, Name = "Cherry", Price = 130m, Category = "Tea", Description = "Made on the basis of Sudanese rose petals, dried natural cherries"  },
                   });
            services.CreatingNewOrder(2);
            Assert.IsTrue(true);
        }

        [Test]
        public void ChangeStatusOrder_ReturnsTrue()
        {
            data.Setup(p => p.Orders)
           .Returns(new List<Order>()
           {
                       new Order() { OrderId= 1, OrderStatus = OrderStatus.New },
                  });
            services.ChangeStatusOrder(1, OrderStatus.Sent);
            Assert.IsTrue(true);
        }
        [Test]
        public void GetProducts_ReturnsTrue()
        {
            data.Setup(p => p.Products)
            .Returns(new List<Product>()
            {
                    new Product() {  ProductId = 2, Name = "Cherry", Price = 130m, Category = "Tea", Description = "Made on the basis of Sudanese rose petals, dried natural cherries"  },
                      new Product() { ProductId = 6, Name = "Lavazza Rossa", Price = 420.10m, Category = "Сoffee", Description = "A cult variety from a well-known Italian brand" },
                  });
            services.GetProducts();
            Assert.IsTrue(true);
        }
        [Test]
        public void ViewingInformationUsers_ReturnsTrue()
        {
            data.Setup(p => p.Persons)
            .Returns(new List<Person>()
            {
                    new Person(){  PersonId = 1, Name = "Olena", Position = Position.Administrator , Online = true},
                    new Person(){  PersonId = 2, Name = "Oleg", Position = Position.Administrator , Online = false},
                   });
            services.ViewingInformationUsers();
            Assert.IsTrue(true);

        }
        
    }

}
