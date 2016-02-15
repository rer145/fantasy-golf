using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RonsHouse.FantasyGolf.Services;
using RonsHouse.FantasyGolf.Web.Admin;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public partial class AdminLeaguesPage : BaseAdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindLeagueGrid();
			}
		}

		protected void BindLeagueGrid()
		{
			var leagues = LeagueService.GetActiveLeagues();
			league_grid.DataSource = leagues;
			league_grid.DataBind();
		}

		protected void OnClickLeagueOption(object sender, CommandEventArgs e)
		{
			switch (e.CommandName.ToLower())
			{
				case "edit":
					break;
				case "delete":
					break;
			}
		}

	}
}