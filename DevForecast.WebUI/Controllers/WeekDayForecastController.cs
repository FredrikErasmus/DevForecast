using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevForecast.WebUI.Controllers
{
    public class WeekDayForecastController : ApiController
    {
        DevForecast.Models.Services.DayForecastService dayforecast;
        public IEnumerable<IEnumerable<DevForecast.Models.DayForecast>> GetWeekDayForecasts()
        {
            dayforecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6));
            return dayforecast.WeekDayForecastCollection;
        }
    }
}
