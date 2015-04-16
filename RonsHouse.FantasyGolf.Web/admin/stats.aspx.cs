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
	public partial class AdminStatsPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//load up values
				SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
				connection.Open();

				var tournaments = connection.Query<Tournament>("select * from Tournament order by BeginsOn");
				tournament_list.DataSource = tournaments;
				tournament_list.DataBind();
				tournament_list.Items.Insert(0, "");
				tournament_list.SelectedIndex = 0;

				var users = connection.Query<User>("select *, LastName + ', ' + FirstName as Name from [User] order by LastName");
				user_list.DataSource = users;
				user_list.DataBind();
				user_list.Items.Insert(0, "");
				user_list.SelectedIndex = 0;

				connection.Close();
			}
			
			BindStandingsGrid();
		}

		protected void OnSelectTournament(object sender, EventArgs e)
		{
			BindTournamentResults();
			BindStandingsGrid();
		}

		protected void OnSelectUser(object sender, EventArgs e)
		{
			BindUserPicksGrid();
			BindStandingsGrid();
		}

		protected void BindTournamentResults()
		{
			if (!String.IsNullOrEmpty(tournament_list.SelectedValue))
			{
				using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
				{
					connection.Open();

					using (SqlCommand cmd = new SqlCommand("Tournament_GetResults", connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add(new SqlParameter("TournamentId", tournament_list.SelectedValue));

						IDataReader data = cmd.ExecuteReader();
						results_grid.DataSource = data;
						results_grid.DataBind();
						data.Close();
					}

					connection.Close();
				}
			}
		}

		protected void BindStandingsGrid()
		{
			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
			{
				connection.Open();

				using (SqlCommand cmd = new SqlCommand("User_GetStandings", connection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					IDataReader data = cmd.ExecuteReader();
					standings_grid.DataSource = data;
					standings_grid.DataBind();
					data.Close();
				}
				connection.Close();
			}
		}

		protected void BindUserPicksGrid()
		{
			if (!String.IsNullOrEmpty(user_list.SelectedValue))
			{
				using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
				{
					connection.Open();

					using (SqlCommand cmd = new SqlCommand("User_GetPicksByTournament", connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add(new SqlParameter("UserId", user_list.SelectedValue));

						IDataReader data = cmd.ExecuteReader();
						userpicks_grid.DataSource = data;
						userpicks_grid.DataBind();
						data.Close();
					}

					connection.Close();
				}
			}
		}
	}
}