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
            if (member is Bee)
            {
                _db.CreateMember((Bee)member, password);
            }
            else if (member is Honeypot)
            {
                _db.CreateMember((Honeypot)member, password);
            }
            return true;
        }

        public bool DeleteUser(int id)
        {
            return _db.Delete(id);
        }

        public void Edit(Hivemember hivemember)
        {
            _db.Edit(hivemember);
        }

        public Hivemember Login(string email, string password)
        {
            return _db.Login(email, password);
        }

        public Bee GetBee(int id)
        {
            return _db.FindBee(id);
        }

        public Honeypot GetHoneypot(int id)
        {
            return _db.FindHoneypot(id);
        }

        public void Buzz(Hivemember Buzzer, Hivemember Buzzee, bool Buzz)
        {
            _db.CreateBuzz(Buzzer, Buzzee, Buzz);
        }
    }
}
