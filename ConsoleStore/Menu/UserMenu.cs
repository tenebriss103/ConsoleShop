using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Menu
{
    public class UserMenu
    {
        private readonly UserService userService;
        public UserMenu(IRepository repo)
        {
            IRepository repository = repo;
            userService = new UserService(repository);
        }
        public void PrintOptionsUser()
        {
            Console.WriteLine("1) View the list of goods");
            Console.WriteLine("2) Search for a product by name");
            Console.WriteLine("3) Creating a new order");
            Console.WriteLine("4) Cancellation of order");
            Console.WriteLine("5) Review the history of orders and the status of their delivery");
            Console.WriteLine("6) Setting the status of the order Received ");
            Console.WriteLine("7) Change of personal information");
            Console.WriteLine("8) Sign out of the account");
        }
        
        public void PrintSettingStatusOrder()
        {
            Console.WriteLine("Enter ID of order you received::");
            int orderId = Convert.ToInt32(Console.ReadLine());
            userService.SettingStatusOrder(orderId);
            Console.WriteLine($"Status 'Received' set to order with ID {orderId}");
        }
        public void PrintChangingPersonalInformation()
        {
            Console.WriteLine("Enter email:");
            string userEmail = Console.ReadLine();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter phone: ");
            string phone = Console.ReadLine();            
            userService.ChangingPersonalInformation(userEmail, name, surname, phone);
            Console.WriteLine("Change information successfully!");

        }
        public void PrintCreatingNewOrder()
        {
            Console.WriteLine("Enter productId:");

            int prodId = Convert.ToInt32(Console.ReadLine());
            userService.CreatingNewOrder(prodId);
        }
        public void PrintCancelOrder()
        {            
            Console.WriteLine("Enter ID of order you canceled::");
            int orderId = Convert.ToInt32(Console.ReadLine());
            userService.CancelOrder(orderId);
            Console.WriteLine("Canceled");

        }
            public void PrintSearchProductByName()
        {
            Console.WriteLine("Enter name: ");
            string search = Console.ReadLine();
            userService.SearchProductByName(search);
        }

    }
    
}
