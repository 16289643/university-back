using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using University.BL.Data;

//[assembly: OwinStartup(typeof(University.Web.Startup))]

namespace University.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Se configura con la DB para que sea usado una unica instacisa por request 
            app.CreatePerOwinContext(UniversityContext.Create);
        }
    }
}

