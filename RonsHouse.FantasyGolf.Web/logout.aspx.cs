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
	public partial class LogoutPage : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			FormsAuthentication.SignOut();
			Response.Redirect("/default.aspx");
		}
	}
}