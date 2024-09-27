using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.Models
{
    internal class Chat
    {
        public List<Message> Messages { get; set; }
        public User User { get; set; }
        public User Seller { get; set; }
    }
}
