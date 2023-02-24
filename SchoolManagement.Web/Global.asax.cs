using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Builder;
using Owin;
using SchoolManagement.Web.App_Start;
using Swashbuckle.Application;
using System.Configuration;
using System.Web.Configuration;
using System;
using System.Web.Http;
using System.Security.Claims;
using System.Text;
using Microsoft.Owin.Security.Jwt;

namespace SchoolManagement.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependencyInjectionConfig.Register();
            GlobalConfiguration.Configuration
               .EnableSwagger(c =>
               {
                   c.SingleApiVersion("v1", "SchoolManagement API");
               })
                .EnableSwaggerUi();

        }
    }
}
