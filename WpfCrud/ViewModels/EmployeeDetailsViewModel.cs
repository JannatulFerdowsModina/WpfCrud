using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrud.ViewModels
{
   public class EmployeeDetailsViewModel
    {
        public int AgeCalculate(DateTime birthDate)
        {
            var age = DateTime.Now.Date - birthDate.Date;
            return age.Days / 365;
        }
    }
}
