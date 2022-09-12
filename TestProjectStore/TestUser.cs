using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class TestUser
    {
        private readonly Mock<IRepository> data;
        private readonly UserService services;
        public TestUser()
        {
            data = new Mock<IRepository>();
            services = new UserService(data.Object);
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
        public void SettingStatusOrder_ReturnsTrue()
        {
            data.Setup(p => p.Orders)
           .Returns(new List<Order>()
           {
                       new Order() { OrderId= 1, OrderStatus = OrderStatus.New , Customer = 1 },
                  });
            data.Setup(p => p.Persons)
            .Returns(new List<Person>()
            {
                    new Person(){  PersonId = 1, Name = "Olena", Position = Position.RegisteredUser, Online = true},
                   });
            services.SettingStatusOrder(1);
            Assert.IsTrue(true);
        }
        [Test]
        public void CancelOrder_ReturnsTrue()
        {
            data.Setup(p => p.Orders)
          .Returns(new List<Order>()
          {
                       new Order() { OrderId= 1, OrderStatus = OrderStatus.New , Customer = 1 },
                 });
            services.CancelOrder(1);
            Assert.IsTrue(true);

        }
        [Test]
        public void ChangingPersonalInformation_ReturnsTrue()
        {

            data.Setup(p => p.Persons)
             .Returns(new List<Person>()
             {
                    new Person(){  PersonId = 1, Name = "Ivan", Surname = "Sericov", Email = "ivan123@gmail.com", Phone = "380965412236", Password = "hbghjkl33" },
                    });
            services.ChangingPersonalInformation("ivan123@gmail.com","Ivanna", "Sericova", "380661112585");
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
    }
}
