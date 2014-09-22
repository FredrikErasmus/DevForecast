using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevForecast.Models.Interfaces;
using DevForecast.Models;

namespace DevForecast.Tests
{
    public class DapperRepositoryMock : IDapperRepository<DayForecast>
    {
        public List<DayForecast> Get(string sql)
        {
            throw new NotImplementedException();
        }
    }
    [TestClass]
    public class DayForecastTests
    {
        DevForecast.Models.Services.DayForecastService dayForecast;
        Models.DayForecastConfiguration configuration = 
            new Models.DayForecastConfiguration { 
                DefaultHoursInDay = 8, 
                WeekDaysToExclude = new List<string> { 
                    "Saturday", 
                    "Sunday" 
                },
                DayStartOfWeek = "Monday",
                DayEndOfWeek = "Friday"
            };
        IDapperRepository<DayForecast> dapperRepositoryMock = new DapperRepositoryMock();
        [TestMethod]
        public void CheckStartDateDaysInMonth()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            Assert.IsTrue(dayForecast.StartDaysInMonth == 30);
        }
        [TestMethod]
        public void CheckTotalDays()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            Assert.IsTrue(dayForecast.TotalDays == dayForecast.DayForecastCollection.Count);
        }
        [TestMethod]
        public void CheckIfForecastCollectionIsNotEmpty()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            Assert.IsTrue(dayForecast.DayForecastCollection.Count > 0);
        }
        [TestMethod]
        public void CheckMonthDifference()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            Assert.IsTrue(dayForecast.MonthDifference == 6);
        }
        [TestMethod]
        public void CheckWeekForCorrectDays()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            var daysToCompare = dayForecast.WeekDayForecastCollection.First().Select(tv => tv.FullDayOfTheWeek).ToList();
            CollectionAssert.AreEqual(daysToCompare, days);  

        }
        [TestMethod]
        public void CheckShortDay()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            Assert.AreEqual("Mon", dayForecast.DayForecastCollection.First().ShortDayOfTheWeek);
        }
        [TestMethod]
        public void CheckShortMonth()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            var shortmonth = DateTime.Now.ToString("MMM");
            Assert.AreEqual(shortmonth, dayForecast.DayForecastCollection.First().ShortMonth);
        }
        [TestMethod]
        public void CheckIfDaysAreExcluded()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            Assert.IsFalse(dayForecast.DayForecastCollection.Where(df => df.FullDayOfTheWeek == "Saturday").Any());
            Assert.IsFalse(dayForecast.DayForecastCollection.Where(df => df.FullDayOfTheWeek == "Sunday").Any());
        }
        [TestMethod]
        public void CheckDaysHoursMinutesForSingleDay()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            var singleDay = dayForecast.DayForecastCollection.First();
            Assert.AreEqual(configuration.DefaultHoursInDay, singleDay.TotalHours);
            Assert.AreEqual(configuration.DefaultHoursInDay * 60, singleDay.TotalMinutes);
            Assert.AreEqual((configuration.DefaultHoursInDay * 60) * 60, singleDay.TotalSeconds);
        }
        [TestMethod]
        public void CheckWeekSingularDays()
        {
            //need an array of days that only repeats once, sort of like column headings
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration, dapperRepositoryMock);
            Assert.IsTrue(dayForecast.Week.Any());
        }
    }
}
