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
            var session = container.Resolve<ISession>();

            session.LoginScreen();

        }
    }
}
