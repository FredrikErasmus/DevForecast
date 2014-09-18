using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevForecast.Models
{
    public class DayForecast
    {
        DateTime _startDate;
        DateTime _endDate;
        int _startDateDaysInMonth;
        int _endDateDaysInMonth;
        long _monthDifference;
        TimeSpan _duration;
        IList<DateTime> _dayForecastCollection;
        public DayForecast(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
            GenerateDateRangeCollection();
        }
        private void GenerateDateRangeCollection()
        {
            _dayForecastCollection = new List<DateTime>();
            _startDateDaysInMonth = DateTime.DaysInMonth(_startDate.Year, _startDate.Month);
            _endDateDaysInMonth = DateTime.DaysInMonth(_endDate.Year, _endDate.Month);
            _duration = _endDate - _startDate;
            _monthDifference = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Month, _startDate, _endDate);
            ProcessDayForecastCollection(_startDateDaysInMonth, _startDate, _dayForecastCollection);
            for (int i = 1; i < _monthDifference; i++)
            {
                DateTime inbetweenDt = _startDate.AddMonths(i);
                var inbetweenDtDaysInMonth = DateTime.DaysInMonth(inbetweenDt.Year, inbetweenDt.Month);
                ProcessDayForecastCollection(inbetweenDtDaysInMonth, inbetweenDt, _dayForecastCollection);
            }
        }
        private void ProcessDayForecastCollection(int daysInMonth, DateTime dateTimeItem, IList<DateTime> dateTimeCollection)
        {
            for (var i = 1; i <= daysInMonth; i++)
            {
                var dayForecastItem = new DateTime(dateTimeItem.Year, dateTimeItem.Month, i);
                dateTimeCollection.Add(dayForecastItem);
            }
        }
        public IList<DateTime> DayForecastCollection { get { return _dayForecastCollection; } }
        public int StartDaysInMonth { get { return _startDateDaysInMonth; } }
        public int EndDaysInMonth { get { return _endDateDaysInMonth; } }
        public TimeSpan Duration { get { return _duration; } }
        public long MonthDifference { get { return _monthDifference; } }
        public DateTime StartDate { get { return _startDate; } }
        public DateTime EndDate { get { return _endDate; } }
    }
}
