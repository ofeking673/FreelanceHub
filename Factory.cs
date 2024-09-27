using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexProject.Managers;

namespace AlexProject
{
    internal class Factory
    {
        public ChatManager ChatManager {  get; set; }
        public JobManager JobManager { get; set; }
        public OfferManager OfferManager { get; set; }

        //will add more functionality later
    }
}
