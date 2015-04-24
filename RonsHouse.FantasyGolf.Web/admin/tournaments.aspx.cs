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
	public partial class AdminTournamentsPage : BaseAdminLeaguePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindTournamentGrid();
			}
		}

		protected void BindTournamentGrid()
		{
			//load up values
			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
			{
				connection.Open();

				var tournaments = connection.Query<Tournament>("Tournament_List", new { LeagueId = base.CurrentLeague }, commandType: CommandType.StoredProcedure);
				tournament_grid.DataSource = tournaments;
				tournament_grid.DataBind();
				try { tournament_grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
				catch { }

				connection.Close();
			}
		}
	}
}