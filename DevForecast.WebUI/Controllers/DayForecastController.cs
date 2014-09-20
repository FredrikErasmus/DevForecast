using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevForecast.WebUI.Controllers
{
    public class DayForecastController : ApiController
    {
        DevForecast.Models.Services.DayForecastService dayforecast;
        public IEnumerable<DevForecast.Models.DayForecast> GetDayForecasts()
        {
            dayforecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6),
                new Models.DayForecastConfiguration
                {
                    DayEndOfWeek = "Friday",
                    DayStartOfWeek = "Monday",
                    DefaultHoursInDay = 8,
                    WeekDaysToExclude = new List<string> { "Saturday", "Sunday" }
                });
            return dayforecast.DayForecastCollection.AsEnumerable();
        }
    }
}
