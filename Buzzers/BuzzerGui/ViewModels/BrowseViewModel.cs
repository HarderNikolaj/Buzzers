using Application;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuzzerGui.Utility;

namespace BuzzerGui.ViewModels
{
    public class BrowseViewModel : ViewModelBase
    {
        private Hivemember potentialMatch { get; set; }
        private Hivemember UserLoggedIn { get; set; }
        private IAccountManager _manager;
        public Hivemember PotentialMatch 
        { 
            get => potentialMatch;
            set 
            {
                if (UserLoggedIn is Honeypot)
                {
                    _manager.GetBee(UserLoggedIn.Id);
                }
                else if (UserLoggedIn is Bee)
                {
                    _manager.GetHoneypot(UserLoggedIn.Id);
                }
            }
        }

        public BrowseViewModel(IAccountManager accountManager) 
        {
            //Messenger.Default.
            _manager = accountManager;
            Messenger.Default.Register<Hivemember>(this, LoginChange);
        }

        private void LoginChange(Hivemember obj)
        {
            UserLoggedIn = obj;
        }
    }
}
