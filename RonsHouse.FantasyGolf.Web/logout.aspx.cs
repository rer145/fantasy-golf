using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;

namespace RonsHouse.FantasyGolf.Web
{
	public partial class LogoutPage : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var authManager = HttpContext.Current.GetOwinContext().Authentication;
			authManager.SignOut();
			Response.Redirect("~/default.aspx");
			
			//FormsAuthentication.SignOut();
			//Response.Redirect("/default.aspx");
		}
	}
}