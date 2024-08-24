using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Exceptions
{
    internal class InactiveUserException:Exception
    {
        public InactiveUserException(string message):base(message) { }

    }
}
