using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Menu
{
   public class GuestMenu
    {
       
        private readonly  GuestService guestService;
        

        public GuestMenu(IRepository repo)
        {
            IRepository repository = repo;
            guestService = new GuestService(repository);
            
        }
        public void PrintOptionsGuest()
        {
            Console.WriteLine("1) Search for goods by name");
            Console.WriteLine("2) User account registratione");
            Console.WriteLine("3) Login");

        }
        public bool PrintAccountRegistration()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter phone: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            guestService.AccountRegistration(name, surname, phone, email, password);
            Console.WriteLine("You have succesfully registered!!");
            return true;
        }


        public bool PrintSearchProductByName()
        {
            Console.WriteLine("Enter name: ");
            string search = Console.ReadLine();
            guestService.SearchProductByName(search);
            return true;
        }
    }
}
