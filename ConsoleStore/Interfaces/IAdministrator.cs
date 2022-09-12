using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Services
{
    public interface IAdministrator
    {
         bool GetProducts();

       bool SearchProductByName(string search);

        bool CreatingNewOrder(int prodId);

        bool ViewingInformationUsers();

        bool ChangingInformationUsers(int userId, string name, string surname, string phone, string email);

        bool AddNewProduct(string name, decimal price, string description, string category);

        bool ChangeInformationProduct(int prodId, string name, decimal price, string description, string category);

        bool ChangeStatusOrder(int orderId, OrderStatus status);

         void SignOut();
       





    }
}
