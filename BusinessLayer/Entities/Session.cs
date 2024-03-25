﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Session:Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }

        public Session(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
