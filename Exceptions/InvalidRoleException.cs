﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApp.Exceptions
{
    internal class InvalidRoleException : Exception
    {
        public InvalidRoleException(string message) : base(message) { }
    }
}
