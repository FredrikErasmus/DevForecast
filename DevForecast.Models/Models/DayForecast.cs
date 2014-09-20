using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevForecast.Models
{
    public class DayForecast
    {
        string fullDayOfTheWeek;
        string shortDayOfTheWeek;
        string fullMonth;
        string shortMonth;
        int year;
        int dayOfTheMonth;
        int totalHours;
        int totalminutes;
        int totalSeconds;

        public string FullDayOfTheWeek { get { return fullDayOfTheWeek; } set { fullDayOfTheWeek = value; } }
        public string ShortDayOfTheWeek { get { return shortDayOfTheWeek; } set { shortDayOfTheWeek = value; } }
        public int DayOfTheMonth { get { return dayOfTheMonth; } set { dayOfTheMonth = value; } }
        public string FullMonth { get { return fullMonth; } set { fullMonth = value; } }
        public string ShortMonth { get { return shortMonth; } set { shortMonth = value; } }
        public int Year { get { return year; } set { year = value; } }
        public int TotalHours { get { return totalHours; } set { totalHours = value; } }
        public int TotalMinutes { get { return totalminutes; } set { totalminutes = value; } }
        public int TotalSeconds { get { return totalSeconds; } set { totalSeconds = value; } }
    }
}
