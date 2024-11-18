using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.Models
{
    public class Message : BaseModel    {
        public string Author { get; set; }
        public string Content { get; set; }
        public string Destination { get; set; }
        public string chatId {  get; set; }
        public DateTime timeStamp { get; set; }
    }
}
