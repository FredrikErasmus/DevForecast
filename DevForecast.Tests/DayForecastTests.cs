using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevForecast.Tests
{
    [TestClass]
    public class DayForecastTests
    {
        [TestMethod]
        public void CheckStartDateDaysInMonth()
        {
            DevForecast.Models.Services.DayForecastService dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6));
            Assert.IsTrue(dayForecast.StartDaysInMonth == 30);
        }
        [TestMethod]
        public void CheckTotalDays()
        {
            DevForecast.Models.Services.DayForecastService dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6));
            Assert.IsTrue(dayForecast.Duration.TotalDays == 181);
        }
        [TestMethod]
        public void CheckIfForecastCollectionIsNotEmpty()
        {
            DevForecast.Models.Services.DayForecastService dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6));
            Assert.IsTrue(dayForecast.DayForecastCollection.Count > 0);
        }
        [TestMethod]
        public void CheckMonthDifference()
        {
            DevForecast.Models.Services.DayForecastService dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6));
            Assert.IsTrue(dayForecast.MonthDifference == 6);
            Assert.IsTrue(dayForecast.Duration.Days == dayForecast.DayForecastCollection.Count);
        }
        [TestMethod]
        public void CheckWeek()
        {
            DevForecast.Models.Services.DayForecastService dayForecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6));
            List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            CollectionAssert.AreEqual(dayForecast.WeekDayForecastCollection.First().Select(tv => tv.DayOfTheWeek).ToList(), days);  
        }
    }
}
