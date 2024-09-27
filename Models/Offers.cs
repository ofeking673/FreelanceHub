using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.Models
{
    internal class Offers
    {
        public int Id { get; set; }
        public Job offeredJob { get; set; }
        public User OfferingUser { get; set; }
        public int newPrice { get; set; }

    }
}
