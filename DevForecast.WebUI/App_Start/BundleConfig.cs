using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DevForecast.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts.Domain/app.js"));
        }
    }
}