using BuzzerGui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.Startup
{
    public class ViewModelLocator
    {
        public IMainWindowViewModel MainWindowViewModel { get; }
        public ILoggedInWindowViewModel LoggedInWindowViewModel { get; }
        public ViewModelLocator(IMainWindowViewModel mainWindowViewModel, ILoggedInWindowViewModel loggedInWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
            LoggedInWindowViewModel = loggedInWindowViewModel;
        }
    }
}
