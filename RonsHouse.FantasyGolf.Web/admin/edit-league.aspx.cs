using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RonsHouse.FantasyGolf.EF;
using RonsHouse.FantasyGolf.Services;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public partial class AdminEditLeaguePage : BaseAdminPage
	{
		private int _id;
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["id"] != null)
				_id = Convert.ToInt32(Request.QueryString["id"]);

			if (!Page.IsPostBack)
			{
				league_user_panel.Visible = (_id > 0);
				league_tournament_panel.Visible = (_id > 0);
				
				if (_id > 0)
				{
					League league = LeagueService.Get(_id);
					name_textbox.Text = league.Name;
					tour_list.SelectedValue = league.TourId.ToString();
					season_textbox.Text = league.Season.ToString();
				}
				else
				{
					season_textbox.Text = DateTime.Now.Year.ToString();
				}

				using (var db = new FantasyGolfContext())
				{
					var tours = from x in db.Tour
								where x.IsActive == true
								orderby x.Name
								select x;

					tour_list.DataSource = tours.ToList();
					tour_list.DataBind();
					tour_list.Items.Insert(0, "");
					tour_list.SelectedIndex = 0;
				}
			}
		}

		protected void OnSaveLeague(object sender, EventArgs e)
		{
			notification_control.Visible = false;
			
			League league = LeagueService.SaveResult(_id.ToString(), name_textbox.Text, tour_list.SelectedValue, season_textbox.Text);
			if (league != null && league.Id > 0)
			{
				Response.Redirect("/admin/edit-league.aspx?id=" + league.Id.ToString());
			}
			else
			{
				notification_control.NotificationType = Web.Controls.NotificationType.Error;
				notification_control.IsDismissable = false;
				notification_control.NotificationText = "The league could not be saved for some reason.";
			}
		}

		protected void OnSaveLeagueUsers(object sender, EventArgs e)
		{

		}

		protected void OnSaveLeagueTournaments(object sender, EventArgs e)
		{

		}
	}
}