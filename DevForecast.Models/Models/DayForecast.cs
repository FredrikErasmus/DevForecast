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
        int dayOfTheMonth;

        public string DayOfTheWeek { get { return dayOfTheWeek; } set { dayOfTheWeek = value; } }
        public int DayOfTheMonth { get { return dayOfTheMonth; } set { dayOfTheMonth = value; } }
        public string Month { get { return month; } set { month = value; } }
        public int Year { get { return year; } set { year = value; } }
    }
}
