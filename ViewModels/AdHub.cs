using AlexProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.ViewModels
{
    public class AdHub //exists to show all ads
    {
        public Theme sortingTheme { get; set; }
        public List<Theme> themes { get; set; }
        public List<Job> adList { get; set; }
        public int Page {  get; set; }
    }
}
