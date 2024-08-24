using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagementApp.Exceptions;
using ContactManagementApp.Models;

namespace ContactManagementApp.Repositories
{
    internal class ContactDetailsRepository
    {
        public void AddContactDetail(ContactDetails contactDetail)
        {
            Contact.ContactDetails.Add(contactDetail);
        }
        public void DeleteContactDetail(ContactDetails contactDetail)
        {
            Contact.ContactDetails.Remove(contactDetail);
        }
        public List<ContactDetails> GetAllContactDetails()
        {
            if (Contact.ContactDetails.Count != 0)
                return Contact.ContactDetails;
            else throw new NoContactDetailsLeftToDisplayException("No Contact Details Left To Display!!\n" +
                    "............................................................................................");
        }
        public ContactDetails CheckContactDetailIdExists(int id)
        {
            var contactDetail = Contact.ContactDetails.Where(c => c.ContactDetailId == id).FirstOrDefault();
            return contactDetail;
        }
    }
}
