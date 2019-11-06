using Domain.Enums;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAccountManager
    {
        bool CreateUser(Hivemember hivemember);
        bool DeleteUser(int id);
        void Edit(Hivemember hivemember);
        void Login(string email, string password);
        void Logout();
    }
}
