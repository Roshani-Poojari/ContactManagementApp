using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Models
{
    internal class ContactDetails
    {
        [Key]
        public int ContactDetailId { get; set; }
        public long Number {  get; set; }
        public string Email { get; set; }
        public Contact Contact { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public override string ToString()
        {
            return $"\nContact Id: {ContactId}\n"+
                $"Contact Detail Id: {ContactDetailId}\n" +
                $"Number: {Number}\n" +
                $"Email id: {Email}\n\n";
        }
    }
}
