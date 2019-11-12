using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DbCommunicator
{
    public interface IDbCommunicator
    {
        void CreateBee(Bee hivemember, string password);
        void CreateHoneypot(Honeypot hivemember, string password);
        bool Delete(int id);
        int Login(string email, string pass);
        Honeypot FindHoneypot(int id);
        Bee FindBee(int id);

    }
}
