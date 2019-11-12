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

        public bool CreateUser(Hivemember member, string password)
        {
            //validate
            //TODO Oprettelse med password
            if (member is Bee)
            {
                _db.CreateBee((Bee)member);
            }
            else if (member is Honeypot)
            {
                _db.CreateHoneypot((Honeypot)member);
            }
            return true;
        }

        public bool DeleteUser(int id)
        {
            return _db.Delete(id);
        }

        public void Edit(Hivemember hivemember)
        {
            throw new NotImplementedException();
        }

        public int Login(string email, string password)
        {
            return _db.Login(email, password);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Bee GetBee(int id) 
        {
            return _db.FindBee(id);
        }

        public Honeypot GetHoneypot(int id)
        {
            return _db.FindHoneypot(id);
        }
    }
}
