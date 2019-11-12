using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using Application;
using Application.DbCommunicator;
using Domain.Enums;
using Application.MapperClasses;

namespace BuzzerConsole
{
    class Session
    {
        public Hivemember UserLoggedIn { get; set; }
        public IAccountManager AcManager { get; set; }

        public Session(IAccountManager accountManager)
        {
            AcManager = accountManager;
        }

        private void Header()
        {
            if (UserLoggedIn == null)
                Console.WriteLine("Buzzers - Login");
            else
                Console.Write($"Buzzers - {UserLoggedIn.Nickname ?? UserLoggedIn.FirstName}\n\n");
        }

        public void LoginScreen()
        {
            while (UserLoggedIn is null)
            {
                Header();
                Console.Write("Email:´");
                var login = Console.ReadLine();
                Console.WriteLine("Password: ");
                var password = Console.ReadLine();
                var userId = AcManager.Login(login, password);
                Console.Clear();
                using (var contexts = new Entities())
                {
                    if (userId != 0)
                    {
                        UserLoggedIn = HivememberEntityMapper.MapHivememberToHoneypot(contexts.hivemembers
                        .Where(i => i.id == userId)
                        .FirstOrDefault());
                    }
                }
            }
        }
    }
}

