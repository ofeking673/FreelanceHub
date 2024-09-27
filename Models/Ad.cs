using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Theme
{
    Drawing,
    Teaching //will add more
}
namespace AlexProject.Models
{
    internal class Ad
    {
        public string Title { get; set; }
        public int price { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public Theme Type { get; set; }
    }
}
