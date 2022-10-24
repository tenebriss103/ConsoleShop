using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Menu
{
    public class AdministratorMenu
    {
        private readonly AdministratorService administratorService;
        public AdministratorMenu(IRepository repo)
        {
            IRepository repository = repo;
            administratorService = new AdministratorService(repository);
          

        }
        public void PrintOptionsAdmin()
        {
            Console.WriteLine("1) View the list of goods");
            Console.WriteLine("2) Search for a product by name");
            Console.WriteLine("3) Creating a new order");
            Console.WriteLine("4) Viewing personal information of users");
            Console.WriteLine("5) Changing personal information of users");
            Console.WriteLine("6) Adding a new product ");

            Console.WriteLine("7) Change of information about the product");
            Console.WriteLine("8) Change the status of the order");
            Console.WriteLine("9) Sign out of the account");
        }

        public bool PrintAddNewProduct()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            decimal price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter category: ");
            string category = Console.ReadLine();

            administratorService.AddNewProduct(name, price, description, category);
            Console.WriteLine("Product added.");
            return true;
        }
        public bool PrintCreatingNewOrder()
        {
            Console.WriteLine("Enter productId:");

            int prodId = Convert.ToInt32(Console.ReadLine());
            administratorService.CreatingNewOrder(prodId);
            return true;
        }
            public bool PrintChangeInformationProduct()
        {
            Console.WriteLine("Enter productId:");
            int prodId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("New new name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new price: ");
            decimal price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter new category: ");
            string category = Console.ReadLine();

            administratorService.ChangeInformationProduct(prodId, name, price, description, category);
            Console.WriteLine("Change information successfully!");
            return true;
        }

        public bool PrintChangingInformationUsers()
        {
            Console.WriteLine("Enter userId:");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter phone: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();

            administratorService.ChangingInformationUsers(userId, name, surname, phone, email);
            Console.WriteLine("Change information successfully!");
            return true;

        }
        public bool PrintSearchProductByName()
        {
            Console.WriteLine("Enter name: ");
            string search = Console.ReadLine();
            administratorService.SearchProductByName(search);
            return true;
        }
        public bool PrintChangeStatusOrder()
        {
            Console.WriteLine("Enter orderId:");
            int orderId = Convert.ToInt32(Console.ReadLine());
            OrderStatus status = OrderStatus.New; 

            Console.WriteLine("Select status ( 1 - New, 2 - CanceledBytheAdministrator, 3 - PaymentReceived, 4 - Sent, 5 - Received, 6 - Completed, 7 - CanceledByUser):");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                    status = OrderStatus.New;
                    break;
                case "2":
                    status = OrderStatus.CanceledBytheAdministrator;
                    break;
                case "3":
                    status = OrderStatus.PaymentReceived;
                    break;
                case "4":
                    status = OrderStatus.Sent;
                    break;
                case "5":
                    status = OrderStatus.Received;
                    break;
                case "6":
                    status = OrderStatus.Completed;
                    break;
                case "7":
                    status = OrderStatus.CanceledByUser;
                    break;
                  default:
                    Console.WriteLine("Invalid Id!");
                    break;
            }
            administratorService.ChangeStatusOrder(orderId, status);
            Console.WriteLine("Change status successfully!");
            return true;
        }
        
    }
}
