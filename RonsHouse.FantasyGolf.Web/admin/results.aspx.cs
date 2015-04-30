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
	public partial class AdminResultsPage : BaseAdminLeaguePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (base.IsLeagueSelected)
				{
					using (var db = new FantasyGolfContext())
					{
						var tournaments = TournamentService.List(this.CurrentLeagueId);
						tournament_list.DataSource = tournaments;
						tournament_list.DataBind();
						tournament_list.Items.Insert(0, "");
						tournament_list.SelectedIndex = 0;
					}
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
				var golfers = GolferService.ListActive(Convert.ToInt32(tournament_list.SelectedValue));
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
			TournamentService.SaveResult(
				tournament_list.SelectedValue,
				golfer_list.SelectedValue,
				place_textbox.Text,
				winnings_textbox.Text,
				cut_checkbox.Checked,
				tied_checkbox.Checked,
				wd_checkbox.Checked,
				dq_checkbox.Checked,
				playoff_checkbox.Checked
			);
			
			message_label_panel.Visible = true;
			message_label.Text = "Result was saved";

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
						cmd.Parameters.Add(new SqlParameter("LeagueId", base.CurrentLeagueId));

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