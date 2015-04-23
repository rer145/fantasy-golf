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
	public partial class AdminStatsPage : BaseAdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (base.IsLeagueSelected)
				{
					//load up values
					SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
					connection.Open();

					var tournaments = connection.Query<Tournament>("Tournament_List", new { LeagueId = base.CurrentLeague }, commandType: CommandType.StoredProcedure);
					tournament_list.DataSource = tournaments;
					tournament_list.DataBind();
					tournament_list.Items.Insert(0, "");
					tournament_list.SelectedIndex = 0;

					var users = connection.Query<User>("LeagueUser_List", new { LeagueId = base.CurrentLeague }, commandType: CommandType.StoredProcedure);
					user_list.DataSource = users;
					user_list.DataBind();
					user_list.Items.Insert(0, "");
					user_list.SelectedIndex = 0;

					connection.Close();

					BindStandingsGrid();
				}
			}
		}

		protected void OnSelectTournament(object sender, EventArgs e)
		{
			//BindTournamentResults();
			//BindStandingsGrid();
			BindGrids();
		}

		protected void OnSelectUser(object sender, EventArgs e)
		{
			//BindUserPicksGrid();
			//BindStandingsGrid();
			BindGrids();
		}

		protected void BindGrids()
		{
			BindTournamentResults();
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
						try { results_grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
						catch { }
						data.Close();
					}

					connection.Close();
				}
			}
			else
			{
				results_grid.DataSource = null;
				results_grid.DataBind();
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
					cmd.Parameters.Add(new SqlParameter("LeagueId", base.CurrentLeague));

					IDataReader data = cmd.ExecuteReader();
					standings_grid.DataSource = data;
					standings_grid.DataBind();
					try { standings_grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
					catch { }
					data.Close();
				}

				var groupings = connection.Query<TournamentGrouping>("TournamentGrouping_List", new { LeagueId = base.CurrentLeague }, commandType: CommandType.StoredProcedure);
				groupings_list.DataSource = groupings;
				groupings_list.DataBind();

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
						try { userpicks_grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
						catch { }
						data.Close();
					}

					connection.Close();
				}
			}
			else
			{
				userpicks_grid.DataSource = null;
				userpicks_grid.DataBind();
			}
		}

		protected void OnDataBindTournamentGrouping(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				var grid = (GridView)e.Item.FindControl("tournament_grouping_standings_grid");
				if (grid != null)
				{
					var grouping = (TournamentGrouping)e.Item.DataItem;
					using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
					{
						connection.Open();

						using (SqlCommand cmd = new SqlCommand("User_GetStandingsByTournamentGrouping", connection))
						{
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.Parameters.Add(new SqlParameter("TournamentGroupingId", grouping.Id));

							IDataReader data = cmd.ExecuteReader();
							grid.DataSource = data;
							grid.DataBind();
							try { grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
							catch { }
							data.Close();
						}

						connection.Close();
					}
				}
			}
		}
	}
}