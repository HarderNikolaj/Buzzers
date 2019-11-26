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
using System.Windows.Input;
using Prism.Commands;

namespace BuzzerGui.ViewModels
{
    class ChatViewModel : ViewModelBase, INavigationViewModel
    {
        private List<ChatMessage> _chatMessages;
        private string _newText;
        public List<ChatMessage> ChatMessages
        {
            get => _chatMessages;
            set
            {
                _chatMessages = value;
                OnPropertyChanged();
            }
        }
        public Hivemember UserLoggedIn { get; set; }
        public Hivemember ChatPartner { get; set; }
        public IAccountManager _manager;
        public ICommand SendMessageCommand { get; private set; }
        public string NewText
        {
            get => _newText;
            set
            {
                _newText = value;
                OnPropertyChanged();
            }
        }


        public ChatViewModel(IAccountManager manager)
        {
            SendMessageCommand = new DelegateCommand(SendMessage);
            Messenger.Default.Register<ChatsMessage>(this, NewChat);
            _manager = manager;
        }

        private void NewChat(ChatsMessage obj)
        {
            UserLoggedIn = obj.LoggedInUser;
            ChatPartner = obj.ChatPartner;
            ChatMessages = _manager.GetChatMessages(UserLoggedIn, ChatPartner);
        }

        private void SendMessage()
        {
            _manager.SendMessage(UserLoggedIn, ChatPartner, NewText);
            ChatMessages = _manager.GetChatMessages(UserLoggedIn, ChatPartner);
            NewText = null;
        }
    }
}
