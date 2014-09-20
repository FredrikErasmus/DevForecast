using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevForecast.Models
{
    public class DayForecastConfiguration
    {
        public int DefaultHoursInDay { get; set; }
        public List<string> WeekDaysToExclude { get; set; }
        public string DayStartOfWeek { get; set; }
        public string DayEndOfWeek { get; set; }
    }
}
