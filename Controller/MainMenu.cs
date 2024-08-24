using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagementApp.Exceptions;
using ContactManagementApp.Repositories;

namespace ContactManagementApp.Controller
{
    internal class MainMenu
    {
        private static readonly UserRepository _userRepository = new UserRepository();
        public static void DisplayMainMenu()
        {
            Console.WriteLine("                               CONTACT MANAGEMENT APPLICATION                               ");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("What do you wish to do?\n" +
                        "1. Login\n" +
                        "2. Exit\n\n" +
                        "Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("............................................................................................");
                    DoTask(choice);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    UserLogin();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nEnter valid choice!!!");
                    break;
            }
        }
        static void UserLogin()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            var user = _userRepository.CheckUserIdExist(userId);
            if (user != null)
            {
                if (user.IsActive) {
                    if (user.IsAdmin)
                    {
                        AdminMenu.DisplayAdminMenu();
                    }
                    else
                    {
                        StaffMenu.DisplayStaffMenu();
                    }
                } else
                {
                    throw new InactiveUserException("\nYou are an Inactive user!!");
                }   
            }
            else
            {
                throw new UserDoesNotExistException("\nUser with given Id does not exist!!");
            }
        }
    }
}
