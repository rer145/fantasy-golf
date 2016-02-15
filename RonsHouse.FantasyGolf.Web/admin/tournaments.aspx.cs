using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RonsHouse.FantasyGolf.EF;
using RonsHouse.FantasyGolf.Services;
using Newtonsoft.Json;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public partial class AdminTournamentsPage : BaseAdminLeaguePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindTournamentGrid();
				//BindRemoteTournamentGrid();
			}
		}

		protected void BindTournamentGrid()
		{
			var tournaments = TournamentService.List(this.CurrentLeagueId);
			tournament_grid.DataSource = tournaments;
			tournament_grid.DataBind();
		}

		protected void OnClickTournamentOption(object sender, CommandEventArgs e)
		{
			switch (e.CommandName.ToLower())
			{
				case "picks":
					break;
				case "remoteresults":
					break;
				case "edit":
					break;
				case "delete":
					break;
			}
		}
	}
}