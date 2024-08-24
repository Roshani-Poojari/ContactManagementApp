using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagementApp.Exceptions;
using ContactManagementApp.Models;
//using ContactApp.Services;

namespace ContactManagementApp.Repositories
{
    internal class ContactRepository
    {
        public void AddContact(Contact contact)
        {
            User.Contacts.Add(contact);
        }
        public List<Contact> GetAllContacts()
        {
            if (User.Contacts.Count != 0)
                return User.Contacts;
            else throw new NoContactsLeftToDisplayException("No Contacts Left To Display!!\n" +
                    "............................................................................................");
        }
        public Contact CheckContactIdExist(int id)
        {
            var contact = User.Contacts.Where(c => c.ContactId == id).FirstOrDefault();
            return contact;
        }
    }
}
