﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MemberStory
    {
        public string Image { get; set; }
        public string Story { get; set; }

        public MemberStory()
        {

        }
        public MemberStory(string image, string story)
        {
            Image = image;
            Story = story;
        }
    }
}
