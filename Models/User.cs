
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Models
{
    internal class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public static List<Contact> Contacts { get; set; } = new List<Contact>();

        public string Role()
        {
            if (IsAdmin)
                return "Admin";
            return "Staff";
        }
        public string Activity()
        {
            if (IsActive)
                return "Active";
            return "Inactive";
        }
        public override string ToString()
        {
            return $"\nUser Id: {UserId}\n" +
                $"User Name: {FirstName} {LastName}\n" +
                $"Role: {Role()}\n" +
                $"User Activity: {Activity()}\n\n";
        }
    }
}
