using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RonsHouse.FantasyGolf.Model;

using Dapper;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public partial class AdminMasterPage : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void OnSelectLeague(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(league_list.SelectedValue))
			{
				Session["FantasyGolf.CurrentLeague"] = league_list.SelectedValue;
				Response.Redirect("default.aspx", false);
			}
		}
	}
}