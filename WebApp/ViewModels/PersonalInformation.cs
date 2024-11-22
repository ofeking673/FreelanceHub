using AlexProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexProject.ViewModels
{
    public class PersonalInformation
    {
        User user { get; set; }
        int CreditCardNumber { get; set; }
        int CVV { get; set; }
        DateTime expirationDate { get; set; }
    }
}
