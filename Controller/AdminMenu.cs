
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ContactManagementApp.Exceptions;
using ContactManagementApp.Models;
using ContactManagementApp.Repositories;

namespace ContactManagementApp.Controller
{
    internal class AdminMenu
    {
        private static readonly UserRepository _userRepository = new UserRepository();

        public static void DisplayAdminMenu()
        {
            Console.WriteLine("............................................................................................");
            Console.WriteLine("                                       ADMIN DASHBOARD                                     ");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("What do you wish to do?\n" +
                        "1. Add New User\n" +
                        "2. Modify Existing User\n" +
                        "3. Delete User\n" +
                        "4. Display All Users\n" +
                        "5. Find User By Id\n" +
                        "6. Logout\n\n" +
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
                    AddUser();
                    break;
                case 2:
                    UpdateUser();
                    break;
                case 3:
                    DeleteUser();
                    break;
                case 4:
                    DisplayAllUsers();
                    break;
                case 5:
                    GetUserById();
                    break;
                case 6:
                    MainMenu.DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("\nEnter valid choice!!!");
                    break;
            }
        }
        static void AddUser()
        {
            Console.WriteLine("Enter User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = _userRepository.CheckUserIdExist(id);
            if (user != null)
            {
                throw new UserIdAlreadyExistsException("\nUser with above id already exists!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter First Name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter User Role (Admin / Staff): ");
            string role = Console.ReadLine().ToLower();
            bool isAdmin = SetIsAdmin(role);
            Console.WriteLine("Enter User Activity (Active / Inactive): ");
            string activity = Console.ReadLine().ToLower();
            bool isActive = SetIsActive(activity);
            _userRepository.AddUser(new User() { UserId = id, FirstName = fname, LastName = lname, IsAdmin = isAdmin, IsActive = isActive });
            Console.WriteLine("\nNew User Added Successfully\n" +
                "............................................................................................");
        }
        static void UpdateUser()
        {
            Console.WriteLine("Enter User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var existingUser = _userRepository.CheckUserIdExist(id);
            if (existingUser == null)
            {
                throw new UserDoesNotExistException("\nUser with given Id does not exist!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter New First Name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter New Last Name: ");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter New User Role (Admin / Staff): ");
            string role = Console.ReadLine().ToLower();
            bool isAdmin = SetIsAdmin(role);
            Console.WriteLine("Enter New User Activity (Active / Inactive): ");
            string activity = Console.ReadLine().ToLower();
            bool isActive = SetIsActive(activity);
            existingUser.FirstName = fname;
            existingUser.LastName = lname;
            existingUser.IsAdmin = isAdmin;
            existingUser.IsActive = isActive;
            Console.WriteLine("\nUser Updated Successfully\n" +
                "............................................................................................");
        }
        static void DeleteUser()
        {
            Console.WriteLine("Enter User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var existingUser = _userRepository.CheckUserIdExist(id);
            if (existingUser == null)
            {
                throw new UserDoesNotExistException("\nUser with given Id does not exist!!\n" +
                    "............................................................................................");
            }
            existingUser.IsActive = false;
            Console.WriteLine("\nUser Deleted Successfully\n" +
                "............................................................................................");
        }
        static void DisplayAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            users.ForEach(user => Console.WriteLine(user));
        }
        static void GetUserById()
        {
            Console.WriteLine("Enter User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var existingUser = _userRepository.CheckUserIdExist(id);
            if (existingUser == null)
            {
                throw new UserDoesNotExistException("\nUser with given Id does not exist!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine(existingUser);
        }
        static bool SetIsAdmin(string role)
        {
            if (role == "admin")
                return true;
            else if (role == "staff")
                return false;
            else throw new InvalidRoleException("\nEnter valid role!!\n" +
                "............................................................................................");
        }
        static bool SetIsActive(string activity)
        {
            if (activity == "active")
                return true;
            else if (activity == "inactive")
                return false;
            else throw new InvalidActivityException("\nEnter valid activity!!\n" +
                "............................................................................................");
        }
    }
}
