using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Theme
{
    Teaching,
    Drawing,
    Coding
}

namespace AlexProject.Models
{
    public class Job : BaseModel
    {
        public string Name { get; set; }
        public Theme Theme { get; set; }
        public string price { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
