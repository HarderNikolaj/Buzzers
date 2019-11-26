using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;

namespace Domain
{
    public class ChatMessage
    {
        public Hivemember Sender { get; set; }
        public Hivemember Reciever { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }


    }
}
