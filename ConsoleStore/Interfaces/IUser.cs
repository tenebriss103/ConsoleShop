using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Services
{
    public interface IUser
    {
        bool GetProducts();

        void SeeOrderHistory();
        bool SearchProductByName(string search);
        bool CreatingNewOrder(int prodId);
        bool ChangingPersonalInformation(string userEmail, string name, string surname, string phone);
       bool SettingStatusOrder(int orderId);
         void SignOut();
    }
}
