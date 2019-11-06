using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DbCommunicator;
using Domain.Users;

namespace Application
{
    public class AccountManager : IAccountManager
    {
        private IDbCommunicator _db;
        public AccountManager(IDbCommunicator db)
        {
            _db = db;
        }

        public bool CreateUser(Hivemember member)
        {
            //validate

            if (member is Bee)
            {
                _db.CreateBee((Bee)member);
            }
            return true;
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Hivemember hivemember)
        {
            throw new NotImplementedException();
        }

        public void Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
