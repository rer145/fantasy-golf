using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

using RonsHouse.FantasyGolf.Model;

using Dapper;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public class BaseAdminLeaguePage : BaseAdminPage
	{
		public bool IsLeagueSelected
		{
			get { return Session["FantasyGolf.CurrentLeague"] != null && !String.IsNullOrEmpty(Session["FantasyGolf.CurrentLeague"].ToString()); }
		}

		public int CurrentLeague
		{
			get { return IsLeagueSelected ? Convert.ToInt32(Session["FantasyGolf.CurrentLeague"]) : 0; }
		}
		
		protected override void OnLoad(EventArgs e)
		{
			Panel noLeaguePanel = (Panel)base.Master.FindControl("noleague_panel");
			if (noLeaguePanel != null)
				noLeaguePanel.Visible = !IsLeagueSelected;

			if (!Page.IsPostBack)
			{
				DropDownList leagueList = (DropDownList)base.Master.FindControl("league_list");
				if (leagueList != null)
				{
					leagueList.Visible = true;

					SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
					connection.Open();

					var leagues = connection.Query<League>("select * from League order by Season desc");
					leagueList.DataSource = leagues;
					leagueList.DataBind();
					leagueList.Items.Insert(0, new ListItem("-- Choose a League --", ""));
					leagueList.SelectedIndex = 0;

					if (CurrentLeague > 0)
						leagueList.SelectedValue = CurrentLeague.ToString();

					connection.Close();
				}
			}

			base.OnLoad(e);
		}
	}
}