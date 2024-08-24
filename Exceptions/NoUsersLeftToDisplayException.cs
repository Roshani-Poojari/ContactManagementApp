using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Exceptions
{
    internal class NoUsersLeftToDisplayException:Exception
    {
        public NoUsersLeftToDisplayException(string message):base(message){}
    }
}
