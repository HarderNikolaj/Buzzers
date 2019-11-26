using Application;
using BuzzerGui.Utility.Messages;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuzzerGui.Utility;
using Domain;
using Domain.Enums;

namespace BuzzerGui.ViewModels
{
    class ChatViewModel : ViewModelBase, INavigationViewModel
    {
        public List<ChatMessage> ChatMessages { get; set; }
        public Hivemember UserLoggedIn { get; set; }
        public Hivemember ChatPartner { get; set; }
        public IAccountManager _manager;
        public string NewText { get; set; }


        public ChatViewModel(IAccountManager manager)
        {
            Messenger.Default.Register<ChatsMessage>(this, NewChat);
            _manager = manager;
        }

        private void NewChat(ChatsMessage obj)
        {
            UserLoggedIn = obj.LoggedInUser;
            ChatPartner = obj.ChatPartner;
            ChatMessages = _manager.GetChatMessages(UserLoggedIn, ChatPartner);
        }
    }
}
