using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using BuzzerGui.Utility;

namespace BuzzerGui.ViewModels
{
    public class LoggedInWindowViewModel : ViewModelBase, ILoggedInWindowViewModel
    {
        public Hivemember LoggedInUser { get; set; }

        public LoggedInWindowViewModel()
        {
            Messenger.Default.Register<Hivemember>(this, Login);
        }

        private void Login(Hivemember member)
        {
            LoggedInUser = member;
        }
    }
}
