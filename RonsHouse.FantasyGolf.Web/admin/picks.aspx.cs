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
	public partial class AdminPicksPage : BaseAdminLeaguePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (base.IsLeagueSelected)
				{
					//load up values
					//SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
					//connection.Open();

					//var tournaments = connection.Query<Tournament>("Tournament_List", new { LeagueId = base.CurrentLeague }, commandType: CommandType.StoredProcedure);
					using (var db = new FantasyGolfContext())
					{
						var tournaments = TournamentService.List(this.CurrentLeagueId);
						tournament_list.DataSource = tournaments;
						tournament_list.DataBind();
						tournament_list.Items.Insert(0, "");
						tournament_list.SelectedIndex = 0;

						//var users = connection.Query<RonsHouse.FantasyGolf.Model.User>("LeagueUser_List", new { LeagueId = base.CurrentLeague }, commandType: CommandType.StoredProcedure);
						var users = UserService.List(this.CurrentLeagueId);
						user_list.DataSource = users;
						user_list.DataBind();
						user_list.Items.Insert(0, "");
						user_list.SelectedIndex = 0;

						//var golfers = connection.Query<Golfer>("select *, LastName + ', ' + FirstName as Name from Golfer order by LastName");
						var golfers = GolferService.ListActive();
						golfer_list.DataSource = golfers;
						golfer_list.DataBind();
						golfer_list.Items.Insert(0, "");
						golfer_list.SelectedIndex = 0;
					}
				}
				message_label_panel.Visible = false;
			}
		}

		protected void OnSelectTournament(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void OnSavePick(object sender, EventArgs e)
		{
			////save values
			//SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
			//connection.Open();

			//connection.Query("UserPick_Set", new { 
			//	TournamentId = tournament_list.SelectedValue, 
			//	UserId = user_list.SelectedValue, 
			//	GolferId = golfer_list.SelectedValue 
			//}, commandType: CommandType.StoredProcedure);

			//connection.Close();

			UserPickService.Save(user_list.SelectedValue, tournament_list.SelectedValue, golfer_list.SelectedValue);
			//should the change log be here, or in the UserPick.Save mehtod?

			message_label_panel.Visible = true;
			message_label.Text = "Pick was saved";

			BindGrid();
		}

		protected void BindGrid()
		{
			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
			{
				connection.Open();

				using (SqlCommand cmd = new SqlCommand("UserPick_GetByTournament", connection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("TournamentId", tournament_list.SelectedValue));

					IDataReader data = cmd.ExecuteReader();
					picks_grid.DataSource = data;
					picks_grid.DataBind();
					try { picks_grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
					catch { }
					data.Close();
				}

				connection.Close();
			}
		}
	}
}