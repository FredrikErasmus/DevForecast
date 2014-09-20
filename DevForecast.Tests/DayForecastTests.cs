using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevForecast.Tests
{
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
        [TestMethod]
        public void CheckStartDateDaysInMonth()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            Assert.IsTrue(dayForecast.StartDaysInMonth == 30);
        }
        [TestMethod]
        public void CheckTotalDays()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            Assert.IsTrue(dayForecast.TotalDays == dayForecast.DayForecastCollection.Count);
        }
        [TestMethod]
        public void CheckIfForecastCollectionIsNotEmpty()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            Assert.IsTrue(dayForecast.DayForecastCollection.Count > 0);
        }
        [TestMethod]
        public void CheckMonthDifference()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            Assert.IsTrue(dayForecast.MonthDifference == 6);
        }
        [TestMethod]
        public void CheckWeek()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            var daysToCompare = dayForecast.WeekDayForecastCollection.First().Select(tv => tv.FullDayOfTheWeek).ToList();
            CollectionAssert.AreEqual(daysToCompare, days);  
        }
        [TestMethod]
        public void CheckShortDay()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            Assert.AreEqual("Mon", dayForecast.DayForecastCollection.First().ShortDayOfTheWeek);
        }
        [TestMethod]
        public void CheckShortMonth()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            var shortmonth = DateTime.Now.ToString("MMM");
            Assert.AreEqual(shortmonth, dayForecast.DayForecastCollection.First().ShortMonth);
        }
        [TestMethod]
        public void CheckIfDaysAreExcluded()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            Assert.IsFalse(dayForecast.DayForecastCollection.Where(df => df.FullDayOfTheWeek == "Saturday").Any());
            Assert.IsFalse(dayForecast.DayForecastCollection.Where(df => df.FullDayOfTheWeek == "Sunday").Any());
        }
        [TestMethod]
        public void CheckDaysHoursMinutesForSingleDay()
        {
            dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), configuration);
            var singleDay = dayForecast.DayForecastCollection.First();
            Assert.AreEqual(configuration.DefaultHoursInDay, singleDay.TotalHours);
            Assert.AreEqual(configuration.DefaultHoursInDay * 60, singleDay.TotalMinutes);
            Assert.AreEqual((configuration.DefaultHoursInDay * 60) * 60, singleDay.TotalSeconds);
        }
    }
}
