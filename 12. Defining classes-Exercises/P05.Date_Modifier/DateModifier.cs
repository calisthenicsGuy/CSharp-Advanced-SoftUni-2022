
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Date_Modifier
{
    public class DateModifier
    {
        public static int CalculateDifference(string firstDate, string secondDate)
        { 
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            //TimeSpan diff = first - second;
            //return (int)diff.TotalDays;

            return Math.Abs((int)(first - second).TotalDays);
        }
    }
}
