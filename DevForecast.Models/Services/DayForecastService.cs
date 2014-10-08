using DevForecast.Models.Interfaces;
using DevForecast.Models.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        int _totalDays;
        IList<DayForecast> _dayForecastCollection;
        IList<List<DayForecast>> _weekDayForecastCollection;
        DayForecastConfiguration _dayForecastConfiguration;
        IDapperRepository<DayForecast> _dapperRepository;
        IList<string> _week;
        public DayForecastService(DateTime startDate, DateTime endDate, DayForecastConfiguration dayForecastConfiguration, IDapperRepository<DayForecast> dapperRepository)
        {
            _startDate = startDate;
            _endDate = endDate;
            _dayForecastConfiguration = dayForecastConfiguration;
            _dapperRepository = dapperRepository;
            GenerateDateRangeCollection();
        }
        private void GenerateDateRangeCollection()
        {
            _dayForecastCollection = new List<DayForecast>();
            _startDateDaysInMonth = DateTime.DaysInMonth(_startDate.Year, _startDate.Month);
            _endDateDaysInMonth = DateTime.DaysInMonth(_endDate.Year, _endDate.Month);
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
                if (df.FullDayOfTheWeek == _dayForecastConfiguration.DayEndOfWeek)
                {
                    _weekDayForecastCollection.Add(weekItem);
                    weekItem = new List<DayForecast>();
                }
            }
            _week = _dayForecastCollection.GroupBy(d => d.FullDayOfTheWeek).Select(gd => gd.Key).ToList();
            //here
        }
        private void ProcessDayForecastCollection(int daysInMonth, DateTime dateTimeItem, IList<DayForecast> dateTimeCollection)
        {
            for (var i = 1; i <= daysInMonth; i++)
            {
                bool canAddDay = true;
                var dayForecastItem = new DateTime(dateTimeItem.Year, dateTimeItem.Month, i);
                if (_dayForecastConfiguration != null)
                {
                    if(_dayForecastConfiguration.WeekDaysToExclude != null)
                    {
                        string day = dayForecastItem.ToString("dddd");
                        if (_dayForecastConfiguration.WeekDaysToExclude.Contains(day))
                            canAddDay = false;
                    }
                }
                if (canAddDay)
                {
                    _totalDays++;
                    dateTimeCollection.Add(new DayForecast
                    {
                        FullDayOfTheWeek = dayForecastItem.ToString("dddd"),
                        FullMonth = dayForecastItem.ToString("MMMM"),
                        Year = dayForecastItem.Year,
                        DayOfTheMonth = dayForecastItem.Day,
                        ShortDayOfTheWeek = dayForecastItem.ToString("ddd"),
                        ShortMonth = dayForecastItem.ToString("MMM"),
                        TotalHours = _dayForecastConfiguration.DefaultHoursInDay,
                        TotalMinutes = _dayForecastConfiguration.DefaultHoursInDay * 60,
                        TotalSeconds = (_dayForecastConfiguration.DefaultHoursInDay * 60) * 60
                    });
                }
            }
        }
        public void Get()
        {
            _dapperRepository.Get("");
        }
        public IList<DayForecast> DayForecastCollection { get { return _dayForecastCollection; } }
        public int StartDaysInMonth { get { return _startDateDaysInMonth; } }
        public int EndDaysInMonth { get { return _endDateDaysInMonth; } }
        public int TotalDays { get { return _totalDays; } }
        public long MonthDifference { get { return _monthDifference; } }
        public DateTime StartDate { get { return _startDate; } }
        public DateTime EndDate { get { return _endDate; } }
        public IList<List<DayForecast>> WeekDayForecastCollection { get { return _weekDayForecastCollection; } }
        public DayForecastConfiguration DayForecastConfiguration { get { return _dayForecastConfiguration; } set { _dayForecastConfiguration = value; } }
        public IList<string> Week { get { return _week; } }
    }
}
