using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain
{
    public class Preferences
    {
        public int Id { get; set; }
        public Haircolor Haircolor { get; set; }
        public Eyecolor Eyecolor { get; set; }
        public int HeightMin { get; set; }
        public int HeightMax { get; set; }
        public int WeightMin { get; set; }
        public int WeightMax { get; set; }
        public bool AttractionMales { get; set; }
        public bool AttracitonFemales { get; set; }
    }


}
