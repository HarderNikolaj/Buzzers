using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.Utility.Messages
{
    class ChatsMessage
    {
        public Hivemember LoggedInUser { get; set; }
        public Hivemember ChatPartner { get; set; }
        public ChatsMessage(Hivemember loggedInUser, Hivemember chatPartner)
        {
            LoggedInUser = loggedInUser;
            ChatPartner = chatPartner;
        }
    }
}
