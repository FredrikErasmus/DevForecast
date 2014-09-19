using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevForecast.Models.Services
{
    public class DayForecastService
    {        
        DateTime _startDate;
        DateTime _endDate;
        int _startDateDaysInMonth;
        int _endDateDaysInMonth;
        long _monthDifference;
        TimeSpan _duration;
        IList<DayForecast> _dayForecastCollection;
        IList<List<DayForecast>> _weekDayForecastCollection;
        public DayForecastService(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
            GenerateDateRangeCollection();
        }
        private void GenerateDateRangeCollection()
        {
            _dayForecastCollection = new List<DayForecast>();
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
            List<DayForecast> weekItem = new List<DayForecast>();
            _weekDayForecastCollection = new List<List<DayForecast>>();
            foreach(var df in _dayForecastCollection)
            {
                weekItem.Add(df);
                if (df.DayOfTheWeek == "Sunday")
                {
                    _weekDayForecastCollection.Add(weekItem);
                    weekItem = new List<DayForecast>();
                }
            }
        }
        private void ProcessDayForecastCollection(int daysInMonth, DateTime dateTimeItem, IList<DayForecast> dateTimeCollection)
        {
            for (var i = 1; i <= daysInMonth; i++)
            {
                var dayForecastItem = new DateTime(dateTimeItem.Year, dateTimeItem.Month, i);
                dateTimeCollection.Add(new DayForecast { 
                    DayOfTheWeek = dayForecastItem.ToString("dddd"), 
                    Month = dayForecastItem.ToString("MMMM"), 
                    Year = dayForecastItem.Year, 
                    DayOfTheMonth = dayForecastItem.Day
                });
            }
        }
        public IList<DayForecast> DayForecastCollection { get { return _dayForecastCollection; } }
        public int StartDaysInMonth { get { return _startDateDaysInMonth; } }
        public int EndDaysInMonth { get { return _endDateDaysInMonth; } }
        public TimeSpan Duration { get { return _duration; } }
        public long MonthDifference { get { return _monthDifference; } }
        public DateTime StartDate { get { return _startDate; } }
        public DateTime EndDate { get { return _endDate; } }
        public IList<List<DayForecast>> WeekDayForecastCollection { get { return _weekDayForecastCollection; } }
    }
}
