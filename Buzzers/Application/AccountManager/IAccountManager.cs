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
        bool CreateUser(Hivemember hivemember, string password);
        bool DeleteUser(int id);
        void Edit(Hivemember hivemember);
        Hivemember Login(string email, string password);
        Bee GetBee(int id);
        Honeypot GetHoneypot(int id);
        void Buzz(Hivemember Buzzer, Hivemember Buzzee, Boolean Buzz);
    }
}
