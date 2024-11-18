using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.Models
{
    public class Offer : BaseModel    {
        public int userId { get; set; }
        public int sellerId { get; set; }
        public int newPrice { get; set; }
        public int chatId {  get; set; }
        public int jobId {  get; set; }

    }
}
