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
    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ViewModelLocator>());

            container.Register(Component.For<IMainWindowViewModel>()
                .ImplementedBy<MainWindowViewModel>());

            container.Register(Component.For<ILoggedInWindowViewModel>()
                .ImplementedBy<LoggedInWindowViewModel>());
        }
    }
}
