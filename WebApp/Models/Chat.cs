using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.Models
{
        public class Chat : BaseModel
        {
            public List<Message> Messages { get; set; }
            public int UserId { get; set; }
            public int SellerId { get; set; }
            public int jobId {  get; set; }
        }
}
