using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Exceptions
{
    internal class NoContactDetailsLeftToDisplayException : Exception
    {
        public NoContactDetailsLeftToDisplayException(string message) : base(message) { }
    }
}
