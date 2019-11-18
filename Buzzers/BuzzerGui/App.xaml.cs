using Application;
using BuzzerGui.Startup;
using BuzzerGui.Views;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BuzzerGui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new WindsorContainer();
            container.Install(new WindsorInstaller());
            container.Resolve<ViewModelLocator>();

            base.OnStartup(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
