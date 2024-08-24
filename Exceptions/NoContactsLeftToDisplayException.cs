using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Exceptions
{
    internal class NoContactsLeftToDisplayException : Exception
    {
        public NoContactsLeftToDisplayException(string message) : base(message) { }

    }
}
