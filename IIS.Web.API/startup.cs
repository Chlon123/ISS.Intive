
using IIS.Web.API.App_Start;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIS.Web.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWebApi(WebApiConfig.Register());
        }
    }
}