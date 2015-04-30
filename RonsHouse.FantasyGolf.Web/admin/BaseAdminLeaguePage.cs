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

using RonsHouse.FantasyGolf.EF;
using RonsHouse.FantasyGolf.Services;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public class BaseAdminLeaguePage : BaseAdminPage
	{
		public bool IsLeagueSelected
		{
			get { return Session["FantasyGolf.CurrentLeague"] != null && !String.IsNullOrEmpty(Session["FantasyGolf.CurrentLeague"].ToString()); }
		}

		public int CurrentLeagueId
		{
			get { return IsLeagueSelected ? Convert.ToInt32(Session["FantasyGolf.CurrentLeague"]) : 0; }
		}

		public League CurrentLeague
		{
			get { return IsLeagueSelected ? LeagueService.Get(this.CurrentLeagueId) : null; }
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

					leagueList.DataSource = LeagueService.GetActiveLeagues();
					leagueList.DataBind();
					leagueList.Items.Insert(0, new ListItem("-- Choose a League --", ""));
					leagueList.SelectedIndex = 0;

					if (CurrentLeagueId > 0)
						leagueList.SelectedValue = CurrentLeagueId.ToString();
				}
			}

			base.OnLoad(e);
		}
	}
}