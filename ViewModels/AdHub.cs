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
        Theme sortingTheme { get; set; }
        List<Job> adList { get; set; }
    }
}
