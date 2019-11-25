using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.Utility.Messages
{
    public class DetailsMessage
    {
        public Hivemember Hivemember { get; private set; }
        public DetailsMessage(Hivemember hivemember)
        {
            Hivemember = hivemember;
        }
    }
}
