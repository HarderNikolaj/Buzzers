using Application;
using BuzzerConsole.Startup;
using Castle.Windsor;
using Domain.Users;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new WindsorInstaller());
            var manager = container.Resolve<IAccountManager>();

            var member = new Honeypot()
            {
                FirstName = "Nikolaj",
                LastName = "Harder",
                Gender = Gender.Male,
                Nickname = "WillDoAnything4ca$h",
                Email = "pimp3@mail.com",
                BirthDate = new DateTime(1847, 05, 12),
                JobTitle = "Pimp"
            };

            manager.CreateUser(member);

            //manager.Login("pimp@mail.com", "asdf");
       //     manager.DeleteUser(2);
        }
    }
}
