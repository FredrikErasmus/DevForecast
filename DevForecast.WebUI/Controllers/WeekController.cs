using DevForecast.Models;
using DevForecast.Models.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevForecast.WebUI.Controllers
{
    public class WeekController : ApiController
    {
        DevForecast.Models.Services.DayForecastService dayforecast;
        public IEnumerable<string> GetWeek()
        {
            dayforecast = new Models.Services.DayForecastService(DateTime.Now, DateTime.Now.AddMonths(6), new Models.DayForecastConfiguration
                {
                    DayEndOfWeek = "Friday",
                    DayStartOfWeek = "Monday",
                    DefaultHoursInDay = 8,
                    WeekDaysToExclude = new List<string> { "Saturday", "Sunday" }
                }, new DapperRepository<DayForecast>(new SqlConnection(ConfigurationManager.ConnectionStrings["DevForecast"].ConnectionString)));
            return dayforecast.Week;
        }
    }
}
