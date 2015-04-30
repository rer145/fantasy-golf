using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Exceptionless;

[assembly: OwinStartup(typeof(RonsHouse.FantasyGolf.Web.Startup))]

namespace RonsHouse.FantasyGolf.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

			app.UseCookieAuthentication(new CookieAuthenticationOptions
				{
					AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
					LoginPath = new PathString("/login.aspx")
				});

			ExceptionlessClient.Default.Register();
		}
	}
}
