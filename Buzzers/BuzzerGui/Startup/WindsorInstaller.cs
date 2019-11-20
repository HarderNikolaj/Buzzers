using Application;
using Application.DbCommunicator;
using BuzzerGui.ViewModels;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.Startup
{
    class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAccountManager>()
                .ImplementedBy<AccountManager>()
                .LifestyleTransient());

            container.Register(Component.For<IDbCommunicator>()
                .ImplementedBy<DbCommunicator>());

      
        }
    }
}
