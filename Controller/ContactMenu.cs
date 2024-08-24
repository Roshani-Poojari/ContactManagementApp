using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagementApp.Exceptions;
using ContactManagementApp.Models;
using ContactManagementApp.Repositories;

namespace ContactManagementApp.Controller
{
    internal class ContactMenu
    {
        private static readonly UserRepository _userRepository = new UserRepository();
        private static readonly ContactRepository _contactRepository = new ContactRepository();
        public static void DisplayContactMenu()
        {
            Console.WriteLine("............................................................................................");
            Console.WriteLine("                                       STAFF DASHBOARD                                     ");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("What do you wish to do?\n" +
                        "1. Add New Contact\n" +
                        "2. Modify Existing Contact\n" +
                        "3. Delete Contact\n" +
                        "4. Display All Contacts\n" +
                        "5. Find Contact By Id\n" +
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
                    AddContact();
                    break;
                case 2:
                    UpdateContact();
                    break;
                case 3:
                    DeleteContact();
                    break;
                case 4:
                    DisplayAllContacts();
                    break;
                case 5:
                    GetContactById();
                    break;
                case 6:
                    MainMenu.DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("\nEnter valid choice!!!");
                    break;
            }
        }
        static void AddContact()
        {
            Console.WriteLine("Enter User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var existingUser = _userRepository.CheckUserIdExist(id);
            if (existingUser == null)
            {
                throw new UserDoesNotExistException("\nUser with given Id does not exist!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());
            var contact = _contactRepository.CheckContactIdExist(contactId);
            if (contact != null)
            {
                throw new ContactIdAlreadyExistsException("\nContact with above id already exists!!\n" +
                    "............................................................................................");
                
            }
            Console.WriteLine("Enter First Name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter Contact Activity (Active / Inactive): ");
            string activity = Console.ReadLine().ToLower();
            bool isActive = SetIsActive(activity);
            _contactRepository.AddContact(new Contact() { UserId = id,ContactId =contactId, FirstName = fname, LastName = lname,  IsActive = isActive });
            Console.WriteLine("\nNew Contact Added Successfully\n" +
                "............................................................................................");
        }
        static void UpdateContact()
        {
            Console.WriteLine("Enter Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());
            var existingContact = _contactRepository.CheckContactIdExist(contactId);
            if (existingContact == null)
            {
                throw new ContactDoesNotExistException("\nContact with above id does not exists!!\n" +
                    "............................................................................................");

            }
            Console.WriteLine("Enter New First Name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter New Last Name: ");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter New Contact Activity (Active / Inactive): ");
            string activity = Console.ReadLine().ToLower();
            bool isActive = SetIsActive(activity);
            existingContact.FirstName = fname;
            existingContact.LastName = lname;
            existingContact.IsActive = isActive;
            Console.WriteLine("\nContact Updated Successfully\n" +
                "............................................................................................");
        }
        static void DeleteContact()
        {
            Console.WriteLine("Enter Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());
            var existingContact = _contactRepository.CheckContactIdExist(contactId);
            if (existingContact == null)
            {
                throw new ContactDoesNotExistException("\nContact with above id does not exists!!\n" +
                    "............................................................................................");

            }
            existingContact.IsActive = false;
            Console.WriteLine("\nContact Deleted Successfully\n" +
                "............................................................................................");
        }
        static void GetContactById()
        {
            Console.WriteLine("Enter Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());
            var existingContact = _contactRepository.CheckContactIdExist(contactId);
            if (existingContact == null)
            {
                throw new ContactDoesNotExistException("\nContact with above id does not exists!!\n" +
                    "............................................................................................");

            }
            Console.WriteLine(existingContact);
        }
        static void DisplayAllContacts()
        {
            var contacts = _contactRepository.GetAllContacts();
            contacts.ForEach(contact => Console.WriteLine(contact));
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
