using Application;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuzzerGui.Utility;
using BuzzerGui.Utility.Messages;
using System.Windows.Input;
using Prism.Commands;

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

        public ICommand BuzzOffCommand { get; private set; }
        public ICommand BuzzOnCommand { get; private set; }
        public BrowseViewModel(IAccountManager accountManager) 
        {
            Messenger.Default.Register<BrowseMessage>(this, CurrentUser);

            BuzzOffCommand = new DelegateCommand(BuzzOff, CanBuzz).ObservesProperty(()=> PotentialMatch);
            BuzzOnCommand = new DelegateCommand(BuzzOn, CanBuzz).ObservesProperty(() => PotentialMatch);

            _manager = accountManager;
        }

        private bool CanBuzz()
        {
            return PotentialMatch != null;
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
        private void BuzzOff()
        {
            _manager.Buzz(_userLoggedIn, PotentialMatch, false);
            FindPotentialMatch();
        }
        private void BuzzOn()
        {
            _manager.Buzz(_userLoggedIn, PotentialMatch, true);
            FindPotentialMatch();
        }
    }
}
