using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.Models
{
    internal class Log
    {
        public int id { get; set; }
        public DateTime Time { get; set; }
        public List<Offers> OfferLog { get; set; }
        public List<Message> Messages { get; set; }
        public List<Ad> Ads { get; set; }
    }
}
