using Application;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuzzerGui.Utility;
using BuzzerGui.Utility.Messages;

namespace BuzzerGui.ViewModels
{
    public class BrowseViewModel : ViewModelBase, INavigationViewModel
    {
        private Hivemember _userLoggedIn;
        private Hivemember _potentialMatch;
        private IAccountManager _manager;
        public Hivemember PotentialMatch 
        { 
            get => _potentialMatch;
            private set 
            {
                _potentialMatch = value;
                OnPropertyChanged();
            }
        }

        public BrowseViewModel(IAccountManager accountManager) 
        {
            Messenger.Default.Register<BrowseMessage>(this, CurrentUser);
            _manager = accountManager;
        }

        public void FindPotentialMatch()
        {
            if (_userLoggedIn.GetType().ToString() == "Domain.Users.Honeypot")
            {
                PotentialMatch = _manager.GetBee(_userLoggedIn.Id);
            }
            else if (_userLoggedIn.GetType().ToString() == "Domain.Users.Bee")
            {
                PotentialMatch = _manager.GetHoneypot(_userLoggedIn.Id);
            }
        }

        private void CurrentUser(BrowseMessage obj)
        {
            _userLoggedIn = obj.Hivemember;
            FindPotentialMatch();
        }
    }
}
