using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ContactManagementApp.Exceptions;
using ContactManagementApp.Models;

namespace ContactManagementApp.Repositories
{
    internal class UserRepository
    {
        public static List<User> users = new List<User>(){ new User() { UserId = 1, FirstName = "Admin1", LastName = "Admin1", IsAdmin = true, IsActive = true } ,
                                                           new User() { UserId = 2, FirstName = "Staff1", LastName = "Staff1", IsAdmin = false, IsActive = true }};
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public List<User> GetAllUsers()
        {
            if (users.Count != 0)
                return users;
            else
                throw new NoUsersLeftToDisplayException("No Users Left To Display!!\n" +
                   "............................................................................................");
        }
        public User CheckUserIdExist(int id)
        {
            var user = users.Where(user => user.UserId == id).FirstOrDefault();
            return user;
        }
    }
}
