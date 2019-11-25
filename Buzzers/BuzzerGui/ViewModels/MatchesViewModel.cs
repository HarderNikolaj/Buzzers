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
    public class MatchesViewModel : ViewModelBase, INavigationViewModel
    {
        private IAccountManager _manger;
        public List<Hivemember> matches { get; set; }
        public Hivemember userLoggedIn;
        public MatchesViewModel(IAccountManager manager)
        {
            _manger = manager;
            Messenger.Default.Register<Hivemember>(this, CurrentUser);
        }

        private void CurrentUser(Hivemember obj)
        {
            userLoggedIn = obj;
            matches = _manger.GetMatches(userLoggedIn);

        }
    }
}
