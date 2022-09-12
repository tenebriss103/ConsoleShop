using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Menu
{
    public class Menu
    {
        private readonly Repository repository;

        private readonly AdministratorService administratorService;
        private readonly UserService userService;        
        private readonly AdministratorMenu administratorMenu;
        private readonly GuestMenu guestMenu;
        private readonly UserMenu userMenu;

        public Menu()
        {
            repository = new Repository();
            administratorService = new AdministratorService(repository);
            userService = new UserService(repository);          
            administratorMenu = new AdministratorMenu(repository);
            guestMenu = new GuestMenu(repository);
            userMenu = new UserMenu(repository);
        }       

        private void ChooseOptionsAdmin()
        {
            Console.WriteLine("Choose options please ");
            int command = Convert.ToInt32(Console.ReadLine());
            switch (command)
            {
                case 1:
                    administratorService.GetProducts();
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    break;
                case 2:
                    administratorMenu.PrintSearchProductByName();
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    break;
                case 3:
                    administratorMenu.PrintCreatingNewOrder();
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    break;
                case 4:
                    administratorService.ViewingInformationUsers();
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    break;
                case 5:
                    administratorMenu.PrintChangingInformationUsers();
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    break;
                case 6:
                    administratorMenu.PrintAddNewProduct();
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    break;
                case 7:
                    administratorMenu.PrintChangeInformationProduct();
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    break;
                case 8:
                    administratorMenu.PrintChangeStatusOrder();
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    break;
                case 9:
                    administratorService.SignOut();
                    Console.Clear();
                    guestMenu.PrintOptionsGuest();
                    ChooseOptionsGuest();
                    break;
                
            }
            
        }
        private void ChooseOptionsUser()
        {
            Console.WriteLine("Choose options please ");
            int command = Convert.ToInt32(Console.ReadLine());
            switch (command)
            {
                case 1:
                    userService.GetProducts();
                    userMenu.PrintOptionsUser();
                    ChooseOptionsUser();
                    break;
                case 2:
                    userMenu.PrintSearchProductByName();
                    userMenu.PrintOptionsUser();
                    ChooseOptionsUser();
                    break;
                case 3:
                    userMenu.PrintCreatingNewOrder();
                    userMenu.PrintOptionsUser();
                    ChooseOptionsUser();
                    break;
                case 4:
                    userMenu.PrintCancelOrder();
                    userMenu.PrintOptionsUser();
                    ChooseOptionsUser();
                    break;
                case 5:
                    userService.SeeOrderHistory();
                    userMenu.PrintOptionsUser();
                    ChooseOptionsUser();
                    break;
                case 6:
                    userMenu.PrintSettingStatusOrder();
                    userMenu.PrintOptionsUser();
                    ChooseOptionsUser();
                    break;
                case 7:
                    userMenu.PrintChangingPersonalInformation();
                    userMenu.PrintOptionsUser();
                    ChooseOptionsUser();
                    break;
                case 8:
                    userService.SignOut();
                    Console.Clear();
                    guestMenu.PrintOptionsGuest();
                    ChooseOptionsGuest();
                    break;
               
            }
        }
        private void ChooseOptionsGuest()
        {
            Console.WriteLine("Choose options please ");
            int command = Convert.ToInt32(Console.ReadLine());
            switch (command)
            {
                
                case 1:
                    guestMenu.PrintSearchProductByName();
                    break;
                case 2:
                    guestMenu.PrintAccountRegistration();
                    break;
                case 3:
                    LoginAccount();
                    break;

            }
        }
        public void LoginAccount()
        {
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
          
            foreach (var item in repository.Persons)
            {
                if (item.Email == email && item.Password == password && item.Position == Position.RegisteredUser)
                {
                    item.Online = true;
                    userMenu.PrintOptionsUser();
                    ChooseOptionsUser();
                   

                }
                else if (item.Email == email && item.Password == password && item.Position == Position.Administrator)
                {
                    item.Online = true;
                    administratorMenu.PrintOptionsAdmin();
                    ChooseOptionsAdmin();
                    

                }
            }

        }

        public void Start()
        {
            guestMenu.PrintOptionsGuest();
            ChooseOptionsGuest();


        }


    }
}
