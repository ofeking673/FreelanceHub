using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.Models
{
    internal class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Theme Theme { get; set; }
        public int price { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
