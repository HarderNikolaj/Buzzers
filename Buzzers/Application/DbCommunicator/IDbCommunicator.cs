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
        void CreateHivemember(Bee hivemember);
        void CreateHoneypot(Honeypot hivemember);
        bool Delete(int id);
        int Login(string email, string pass);
    }
}
