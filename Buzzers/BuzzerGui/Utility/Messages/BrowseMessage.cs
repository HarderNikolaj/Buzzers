using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.Utility.Messages
{
    public class BrowseMessage
    {
        public Hivemember Hivemember { get; private set; }
        public BrowseMessage(Hivemember hivemember)
        {
            Hivemember = hivemember;
        }
    }
}
