using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Exceptions
{
    internal class UserDoesNotExistException:Exception
    {
        public UserDoesNotExistException(string message):base(message) { }
        
    }
}
