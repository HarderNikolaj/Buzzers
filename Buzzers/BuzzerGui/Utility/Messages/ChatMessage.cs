using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.Utility.Messages
{
    class ChatMessage
    {
        Hivemember LoggedInUser { get; set; }
        Hivemember ChatPartner { get; set; }
        public ChatMessage(Hivemember loggedInUser, Hivemember chatPartner)
        {
            LoggedInUser = loggedInUser;
            ChatPartner = chatPartner;
        }
    }
}
