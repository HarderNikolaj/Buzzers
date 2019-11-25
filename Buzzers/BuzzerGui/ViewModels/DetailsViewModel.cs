using Application;
using BuzzerGui.Utility;
using BuzzerGui.Utility.Messages;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.ViewModels
{
    public class DetailsViewModel : ViewModelBase, INavigationViewModel
    {
        private IAccountManager _manager;
        private Hivemember _user;

        public Hivemember User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public DetailsViewModel(IAccountManager manager)
        {
            _manager = manager;

            Messenger.Default.Register<DetailsMessage>(this, CurrentUser);
        }

        private void CurrentUser(DetailsMessage obj)
        {
            User = obj.Hivemember;
        }
    }
}
