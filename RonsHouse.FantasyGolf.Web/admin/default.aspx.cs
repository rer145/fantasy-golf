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
	public partial class AdminDefaultPage : BaseAdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindStandingsGrid();
			}
		}

		protected void BindStandingsGrid()
		{
			if (base.IsLeagueSelected)
			{
				using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
				{
					connection.Open();

					using (SqlCommand cmd = new SqlCommand("User_GetStandings", connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add(new SqlParameter("LeagueId", base.CurrentLeague));

						IDataReader data = cmd.ExecuteReader();
						standings_grid.DataSource = data;
						standings_grid.DataBind();
						standings_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
						data.Close();
					}
					connection.Close();
				}
			}
		}
	}
}