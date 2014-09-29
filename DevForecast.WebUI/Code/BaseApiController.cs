using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace DevForecast.WebUI.Controllers
{
    public class BaseApiController : ApiController
    {
        private System.Web.Http.Controllers.HttpControllerContext _controllerContext;
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _controllerContext = controllerContext;
        }
        public System.Web.Http.Controllers.HttpControllerContext ControllerContext 
        {
            get { return _controllerContext; } 
        }
    }
}
