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
using System.Data.Entity.Validation;

using RonsHouse.FantasyGolf.EF;
using RonsHouse.FantasyGolf.Services;

namespace RonsHouse.FantasyGolf.Web
{
	public partial class RegisterPage : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void OnRegister(object sender, EventArgs e)
		{
			bool isValid = false;
			string message = String.Empty;
			
			if (password_textbox.Text == confirm_password_textbox.Text)
			{
				isValid = true;
			}

			if (isValid)
			{
				var userStore = new UserStore<IdentityUser>();
				var manager = new UserManager<IdentityUser>(userStore);

				var user = new IdentityUser();
				user.UserName = email_textbox.Text;
				user.Email = email_textbox.Text;
				user.EmailConfirmed = true;

				user.Claims.Add(new IdentityUserClaim()
					{
						UserId = email_textbox.Text,
						ClaimType = "FirstName",
						ClaimValue = firstname_textbox.Text
					});
				user.Claims.Add(new IdentityUserClaim()
					{
						UserId = email_textbox.Text,
						ClaimType = "LastName",
						ClaimValue = lastname_textbox.Text
					});

				try
				{
					IdentityResult result = manager.Create(user, password_textbox.Text);
					if (result.Succeeded)
					{
						var authManager = HttpContext.Current.GetOwinContext().Authentication;
						var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
						authManager.SignIn(new AuthenticationProperties() { }, userIdentity);

						//TODO: add user info to User table for profile information
						// do lookups between identity and User via email?
						var profile = UserService.Get(user.Email);
						if (profile != null)
						{
							Session["FantasyGolf.User"] = UserService.Create(email_textbox.Text, firstname_textbox.Text, lastname_textbox.Text);
						}
						
						Response.Redirect("~/admin/default.aspx");
					}
					else
					{
						base.ErrorPanel.Visible = true;
						base.ErrorText = "<ul>";
						foreach (var error in result.Errors)
						{
							base.ErrorText += "<li>" + error + "</li>";
						}
						base.ErrorText += "</ul>";
					}
				}
				catch (DbEntityValidationException dbex)
				{
					base.ErrorPanel.Visible = true;
					base.ErrorText = "<ul>";
					foreach (var eve in dbex.EntityValidationErrors)
					{
						foreach (var error in eve.ValidationErrors)
						{
							base.ErrorText += "<li>Error in " + eve.Entry.Entity.GetType().Name + " - Property: " + error.PropertyName + " / Message: " + error.ErrorMessage + "</li>";
						}
					}
					base.ErrorText += "</ul>";
				}
			}
			else
			{
				base.ErrorPanel.Visible = true;
				base.ErrorText = "Your passwords did not match or some other validation failed.";
			}
		}
	}
}