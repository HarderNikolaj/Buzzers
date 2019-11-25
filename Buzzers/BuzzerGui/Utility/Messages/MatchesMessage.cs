using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.Utility.Messages
{
    public class MatchesMessage
    {
        public Hivemember Hivemember { get; private set; }
        public MatchesMessage(Hivemember hivemember)
        {
            Hivemember = hivemember;
        }
    }
}
