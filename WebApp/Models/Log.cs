﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.Models
{
    public class Log : BaseModel    {
        public DateTime Time { get; set; }
        public string path { get; set; }
    }
}
