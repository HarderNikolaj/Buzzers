using Application;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuzzerGui.Utility;
using Prism.Commands;
using System.Windows.Input;
using BuzzerGui.Utility.Messages;

namespace BuzzerGui.ViewModels
{
    public class MatchesViewModel : ViewModelBase, INavigationViewModel
    {
        private IAccountManager _manager;
        public List<Hivemember> Matches { get; set; }
        public Hivemember UserLoggedIn { get; set; }
        public ICommand EnterChatCommand { get; private set; }
        public MatchesViewModel(IAccountManager manager)
        {
            _manager = manager;
            Messenger.Default.Register<MatchesMessage>(this, CurrentUser);

            EnterChatCommand = new DelegateCommand<Hivemember>(EnterChat);
        }

        private void EnterChat(Hivemember chatPartner)
        {
            throw new NotImplementedException();
        }

        private void CurrentUser(MatchesMessage obj)
        {
            UserLoggedIn = obj.Hivemember;
            Matches = _manager.GetMatches(UserLoggedIn);
        }
    }
}
