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
        public List<Hivemember> Matches { get; set; }
        public Hivemember UserLoggedIn { get; set; }
        public MatchesViewModel(IAccountManager manager)
        {
            _manger = manager;
            Messenger.Default.Register<Hivemember>(this, CurrentUser);
        }

        private void CurrentUser(Hivemember obj)
        {
            UserLoggedIn = obj;
            Matches = _manger.GetMatches(UserLoggedIn);

        }
    }
}
