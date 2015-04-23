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
			if (!Page.IsPostBack)
			{
				SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
				connection.Open();

				var leagues = connection.Query<League>("select * from League order by Season desc");
				league_list.DataSource = leagues;
				league_list.DataBind();
				league_list.Items.Insert(0, new ListItem("-- Choose a League --", ""));
				league_list.SelectedIndex = 0;

				if (Session["FantasyGolf.CurrentLeague"] != null)
				{
					league_list.SelectedValue = Session["FantasyGolf.CurrentLeague"].ToString();
					noleague_panel.Visible = false;
				}
				else
				{
					noleague_panel.Visible = true;
				}

				connection.Close();
			}
		}

		protected void OnSelectLeague(object sender, EventArgs e)
		{
			//set session variable for league
			//redirect to page
			if (!String.IsNullOrEmpty(league_list.SelectedValue))
			{
				Session["FantasyGolf.CurrentLeague"] = league_list.SelectedValue;
				Response.Redirect("default.aspx", false);
			}
		}
	}
}