using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Controller
{
    internal class StaffMenu
    {
        public static void DisplayStaffMenu()
        {
            Console.WriteLine("............................................................................................");
            Console.WriteLine("                                       STAFF DASHBOARD                                     ");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("What do you wish to do?\n" +
                        "1. Work on Contacts\n" +
                        "2. Work on Contact Details\n" +
                        "3. Logout\n\n" +
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
                    ContactMenu.DisplayContactMenu();
                    break;
                case 2:
                    ContactDetailMenu.DisplayContactDetailMenu();
                    break;
                case 3:
                    MainMenu.DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("\nEnter valid choice!!!");
                    break;
            }
        }
    }
}
