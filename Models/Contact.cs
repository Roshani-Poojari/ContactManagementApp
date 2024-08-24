using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Models
{
    internal class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public static List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();
        public string Activity()
        {
            if (IsActive)
                return "Active";
            return "Inactive";
        }
        public override string ToString()
        {
            return $"\nUserId: {UserId}\n" +
                $"Contact Id: {ContactId}\n" +
                $"Name: {FirstName} {LastName}\n" +
                $"Activity: {Activity()}\n\n";
        }
    }
}
