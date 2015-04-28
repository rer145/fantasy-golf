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

using RonsHouse.FantasyGolf.Model;

using Dapper;

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

			//lookup in database

			if (email == "ron" && pass == "ron")
			{
				FormsAuthentication.RedirectFromLoginPage(email, rememberme_checkbox.Checked);
			}
		}
	}
}