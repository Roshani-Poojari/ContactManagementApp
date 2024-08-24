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
    internal class ContactDetailMenu
    {
        private static readonly ContactRepository _contactRepository = new ContactRepository();
        private static readonly ContactDetailsRepository _contactDetailsRepository = new ContactDetailsRepository();
        public static void DisplayContactDetailMenu()
        {
            Console.WriteLine("............................................................................................");
            Console.WriteLine("                                       STAFF DASHBOARD                                     ");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("What do you wish to do?\n" +
                        "1. Add New Contact Detail\n" +
                        "2. Modify Existing Contact Detail\n" +
                        "3. Delete Contact Detail\n" +
                        "4. Display All Contact Details\n" +
                        "5. Find Contact Detail By Id\n" +
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
                    AddContactDetail();
                    break;
                case 2:
                    UpdateContactDetail();
                    break;
                case 3:
                    DeleteContactDetail();
                    break;
                case 4:
                    DisplayAllContactDetails();
                    break;
                case 5:
                    GetContactDetailById();
                    break;
                case 6:
                    MainMenu.DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("\nEnter valid choice!!!");
                    break;
            }
        }
        static void AddContactDetail()
        {
            Console.WriteLine("Enter Contact Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var existingContact = _contactRepository.CheckContactIdExist(id);
            if (existingContact == null)
            {
                throw new ContactDoesNotExistException("\nContact with given Id does not exist!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter Contact Detail Id: ");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            var contactDetail = _contactDetailsRepository.CheckContactDetailIdExists(contactDetailId);
            if (contactDetail != null)
            {
                throw new ContactDetailIdAlreadyExistsException("\nContact Detail with above id already exists!!\n" +
                    "............................................................................................");

            }
            Console.WriteLine("Enter Number: ");
            long number = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email Id: ");
            string email = Console.ReadLine();
            _contactDetailsRepository.AddContactDetail(new ContactDetails() { ContactId=id, ContactDetailId=contactDetailId, Number = number, Email = email});
            Console.WriteLine("\nNew Contact Detail Added Successfully\n" +
                "............................................................................................");
        }
        static void UpdateContactDetail()
        {
            Console.WriteLine("Enter Contact Detail Id: ");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            var existingContactDetail = _contactDetailsRepository.CheckContactDetailIdExists(contactDetailId);
            if (existingContactDetail == null)
            {
                throw new ContactDetailDoesNotExistException("\nContact Detail with above id does not exists!!\n" +
                    "............................................................................................");

            }
            Console.WriteLine("Enter New Number: ");
            long newNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter New Email Id: ");
            string newEmail = Console.ReadLine();
            existingContactDetail.Number = newNumber;
            existingContactDetail.Email = newEmail;
            Console.WriteLine("\nContact Detail Updated Successfully\n" +
                "............................................................................................");
        }
        static void DeleteContactDetail()
        {
            Console.WriteLine("Enter Contact Detail Id: ");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            var existingContactDetail = _contactDetailsRepository.CheckContactDetailIdExists(contactDetailId);
            if (existingContactDetail == null)
            {
                throw new ContactDetailDoesNotExistException("\nContact Detail with above id does not exists!!\n" +
                    "............................................................................................");

            }
            _contactDetailsRepository.DeleteContactDetail(existingContactDetail);
            Console.WriteLine("\nContact Detail Deleted Successfully\n" +
                "............................................................................................");
        }
        static void DisplayAllContactDetails()
        {
            var contactDetails = _contactDetailsRepository.GetAllContactDetails();
            contactDetails.ForEach(contactDetail => Console.WriteLine(contactDetail));
        }
        static void GetContactDetailById()
        {
            Console.WriteLine("Enter Contact Detail Id: ");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            var existingContactDetail = _contactDetailsRepository.CheckContactDetailIdExists(contactDetailId);
            if (existingContactDetail == null)
            {
                throw new ContactDetailDoesNotExistException("\nContact Detail with above id does not exists!!\n" +
                    "............................................................................................");

            }
            Console.WriteLine(existingContactDetail);
        }
    }
}
