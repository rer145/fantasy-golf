using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RonsHouse.FantasyGolf.EF;
using RonsHouse.FantasyGolf.Services;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public partial class AdminDefaultPage : BaseAdminPage
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
			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
			{
				connection.Open();

				using (SqlCommand cmd = new SqlCommand("User_GetLeagues", connection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("UserId", base.CurrentUser.Id));

					IDataReader data = cmd.ExecuteReader();
					leagues_grid.DataSource = data;
					leagues_grid.DataBind();
					try { leagues_grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
					catch { }
					data.Close();
				}
				connection.Close();
			}
		}

		//protected void BindStandingsGrid()
		//{
		//	if (base.IsLeagueSelected)
		//	{
		//		using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
		//		{
		//			connection.Open();

		//			using (SqlCommand cmd = new SqlCommand("User_GetStandings", connection))
		//			{
		//				cmd.CommandType = CommandType.StoredProcedure;
		//				cmd.Parameters.Add(new SqlParameter("LeagueId", base.CurrentLeagueId));

		//				IDataReader data = cmd.ExecuteReader();
		//				standings_grid.DataSource = data;
		//				standings_grid.DataBind();
		//				try { standings_grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
		//				catch { }
		//				data.Close();
		//			}
		//			connection.Close();
		//		}
		//	}
		//}
	}
}