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
            DictionaryAdministrator(command);        

        }
        private void ChooseOptionsUser()
        {
            Console.WriteLine("Choose options please ");
            int command = Convert.ToInt32(Console.ReadLine());
            DictionaryUser(command);
            
        }
        private void ChooseOptionsGuest()
        {
            Console.WriteLine("Choose options please ");
            int command = Convert.ToInt32(Console.ReadLine());
            DictionaryGuest(command);
           
        }

        public void DictionaryGuest(int command)
        {
            var dico = new Dictionary<int, Delegate>();
            dico[1] = new Func<bool>(guestMenu.PrintSearchProductByName);
            dico[2] = new Func<bool>(guestMenu.PrintAccountRegistration);
            dico[3] = new Func<bool>(LoginAccount);

            foreach (int item in dico.Keys)
            {
                if (item == command)
                {
                    dico[item].DynamicInvoke();
                    ChooseOptionsGuest();
                }               
            }
        }
        public void DictionaryUser(int command)
        {
            var dico = new Dictionary<int, Delegate>();
            dico[1] = new Func<bool>(userService.GetProducts);
            dico[2] = new Func<bool>(userMenu.PrintSearchProductByName);
            dico[3] = new Func<bool>(userMenu.PrintCreatingNewOrder);
            dico[4] = new Func<bool>(userMenu.PrintCancelOrder);
            dico[5] = new Func<bool>(userService.SeeOrderHistory);
            dico[6] = new Func<bool>(userMenu.PrintSettingStatusOrder);
            dico[7] = new Func<bool>(userMenu.PrintChangingPersonalInformation);
            dico[8] = new Func<bool>(userService.SignOut);
            
            foreach (int item in dico.Keys)
            {
                if (item == command)
                {

                    dico[item].DynamicInvoke();                    
                    if (command == 8)
                    {
                        guestMenu.PrintOptionsGuest();
                        ChooseOptionsGuest();
                    }
                    else
                    {
                        userMenu.PrintOptionsUser();
                        ChooseOptionsUser();
                    }
                }
            }

        }
        public void DictionaryAdministrator(int command)
        {
            var dico = new Dictionary<int, Delegate>();
            dico[1] = new Func<bool>(administratorService.GetProducts);
            dico[2] = new Func< bool>(administratorMenu.PrintSearchProductByName);
            dico[3] = new Func<bool>(administratorMenu.PrintCreatingNewOrder);
            dico[4] = new Func<bool>(administratorService.ViewingInformationUsers);
            dico[5] = new Func<bool>(administratorMenu.PrintChangingInformationUsers);
            dico[6] = new Func<bool>(administratorMenu.PrintAddNewProduct);
            dico[7] = new Func< bool>(administratorMenu.PrintChangeInformationProduct);
            dico[8] = new Func<bool>(administratorMenu.PrintChangeStatusOrder);
            dico[9] = new Func<bool>(administratorService.SignOut);
            foreach (int item in dico.Keys)
            {
                if (item == command)
                {
                    
                    dico[item].DynamicInvoke();                    
                    if (command == 9)
                    {
                        guestMenu.PrintOptionsGuest();
                        ChooseOptionsGuest();
                    }
                    else
                    {
                        administratorMenu.PrintOptionsAdmin();
                        ChooseOptionsAdmin();
                    }
                }
            }

        }

        public bool LoginAccount()
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
            return true;

        }

        public void Start()
        {
            guestMenu.PrintOptionsGuest();
            ChooseOptionsGuest();

        }


    }
}
