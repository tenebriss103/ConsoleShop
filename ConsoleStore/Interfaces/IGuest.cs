using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Services
{
    public interface IGuest
    {
       bool SearchProductByName(string search);

       bool AccountRegistration(string name, string surname, string phone, string email, string password);

    }
}
