using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RonsHouse.FantasyGolf.Model;
using RonsHouse.FantasyGolf.SportsDataApi;

using Dapper;
using RestSharp;

namespace RonsHouse.FantasyGolf.Web.Admin.Remote
{
	public partial class TournamentPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void OnSyncTournaments(object sender, EventArgs e)
		{
			tournament_list.DataSource = ApiClient.GetTournaments("pga", DateTime.Now.Year);
			tournament_list.DataBind();
		}
	}
}