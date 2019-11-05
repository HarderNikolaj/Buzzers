using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class Bee : Hivemember
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public Haircolor Haircolor { get; set; }
        public Eyecolor Eyecolor { get; set; }
    }
}
