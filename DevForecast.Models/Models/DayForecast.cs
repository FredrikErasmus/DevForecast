using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevForecast.Models
{
    public class DayForecast
    {
        string dayOfTheWeek;
        string month;
        int year;

        public string DayOfTheWeek { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
    }
}
