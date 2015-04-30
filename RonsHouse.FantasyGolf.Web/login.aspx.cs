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

using RonsHouse.FantasyGolf.EF;
using RonsHouse.FantasyGolf.Services;

namespace RonsHouse.FantasyGolf.Web
{
	public partial class LoginPage : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void OnLogin(object sender, EventArgs e)
		{
			var email = email_textbox.Text;
			var pass = password_textbox.Text;

			var userStore = new UserStore<IdentityUser>();
			var userManager = new UserManager<IdentityUser>(userStore);
			var user = userManager.Find(email_textbox.Text, password_textbox.Text);

			if (user != null)
			{
				var profile = UserService.Get(user.Email);	//TODO: save to session
				if (profile != null)
				{
					Session["FantasyGolf.User"] = profile;
				}
				
				var authManager = HttpContext.Current.GetOwinContext().Authentication;
				var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
				authManager.SignIn(new AuthenticationProperties() { IsPersistent = rememberme_checkbox.Checked }, userIdentity);

				if (Request.QueryString["RedirectUrl"] != null)
				{
					Response.Redirect(Server.UrlDecode(Request.QueryString["RedirectUrl"].ToString()));
				}
				else
				{
					Response.Redirect("~/admin/default.aspx");
				}
			}
			else
			{
				base.ErrorPanel.Visible = true;
				base.ErrorText = "Your login failed.";
			}
		}
	}
}