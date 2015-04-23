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
	public partial class AdminResultsPage : BaseAdminLeaguePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (base.IsLeagueSelected)
				{
					SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
					connection.Open();

					var tournaments = connection.Query<Tournament>("Tournament_List", new { LeagueId = base.CurrentLeague }, commandType: CommandType.StoredProcedure);
					tournament_list.DataSource = tournaments;
					tournament_list.DataBind();
					tournament_list.Items.Insert(0, "");
					tournament_list.SelectedIndex = 0;

					connection.Close();
				}
				message_label_panel.Visible = false;
			}
		}

		protected void OnSelectTournament(object sender, EventArgs e)
		{
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
			connection.Open();

			if (!String.IsNullOrEmpty(tournament_list.SelectedValue))
			{
				var golfers = connection.Query<Golfer>("select distinct g.*, g.LastName + ', ' + g.FirstName as Name from Golfer g inner join UserPick up on up.GolferId = g.Id where up.TournamentId = " + tournament_list.SelectedValue + " order by LastName");
				golfer_list.DataSource = golfers;
				golfer_list.DataBind();
				golfer_list.Items.Insert(0, "");
				golfer_list.SelectedIndex = 0;
			}

			connection.Close();

			BindGrids();
		}

		protected void OnSaveResults(object sender, EventArgs e)
		{
			//save values
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
			connection.Open();

			connection.Query("TournamentResult_Set", new
			{
				TournamentId = tournament_list.SelectedValue,
				GolferId = golfer_list.SelectedValue,
				Place = place_textbox.Text,
				Winnings = winnings_textbox.Text,
				IsCut = cut_checkbox.Checked,
				IsTied = tied_checkbox.Checked,
				IsWithdrawn = wd_checkbox.Checked,
				IsDisqualified = dq_checkbox.Checked,
				IsPlayoff = playoff_checkbox.Checked
			}, commandType: CommandType.StoredProcedure);

			connection.Close();

			//Response.Write("tournament: " + tournament_list.SelectedValue + "<br />");
			//Response.Write("golfer: " + golfer_list.SelectedValue + "<br />");
			//Response.Write("place: " + place_textbox.Text + "<br />");
			//Response.Write("winnings: " + winnings_textbox.Text + "<br />");
			//Response.Write("cut: " + cut_checkbox.Checked + "<br />");
			//Response.Write("tied: " + tied_checkbox.Checked + "<br />");
			//Response.Write("wd: " + wd_checkbox.Checked + "<br />");
			//Response.Write("dq: " + dq_checkbox.Checked + "<br />");
			//Response.Write("playoff: " + playoff_checkbox.Checked + "<br />");
			
			
			message_label_panel.Visible = true;
			message_label.Text = "Result was saved";

			//reset values
			golfer_list.SelectedIndex = 0;
			place_textbox.Text = "";
			winnings_textbox.Text = "";
			cut_checkbox.Checked = false;
			wd_checkbox.Checked = false;
			tied_checkbox.Checked = false;
			playoff_checkbox.Checked = false;
			dq_checkbox.Checked = false;

			BindGrids();
		}

		protected void BindGrids()
		{
			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
			{
				connection.Open();

				if (base.IsLeagueSelected)
				{
					using (SqlCommand cmd = new SqlCommand("User_GetStandings", connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add(new SqlParameter("LeagueId", base.CurrentLeague));

						IDataReader data = cmd.ExecuteReader();
						standings_grid.DataSource = data;
						standings_grid.DataBind();
						try
						{
							standings_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
						}
						catch { }
						data.Close();
					}
				}

				if (!String.IsNullOrEmpty(tournament_list.SelectedValue))
				{
					using (SqlCommand cmd = new SqlCommand("Tournament_GetResults", connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add(new SqlParameter("TournamentId", tournament_list.SelectedValue));

						IDataReader data = cmd.ExecuteReader();
						results_grid.DataSource = data;
						results_grid.DataBind();
						try 
						{ 
							results_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
						}
						catch { }
						data.Close();
					}
				}

				connection.Close();
			}
		}
	}
}