﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RonsHouse.FantasyGolf.EF;
using RonsHouse.FantasyGolf.Services;
using RonsHouse.FantasyGolf.Web.Controls;

namespace RonsHouse.FantasyGolf.Web.Admin.User
{
	public partial class PicksPage : BaseAdminLeaguePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (base.IsLeagueSelected)
				{
					var users = UserService.List(this.CurrentLeagueId);
					user_list.DataSource = users;
					user_list.DataBind();
					user_list.Items.Insert(0, "");
					user_list.SelectedIndex = 0;
				}
			}
		}

		//protected void OnSubmitUserPicks(object sender, EventArgs e)
		//{
		//	BootstrapGridView grid = (BootstrapGridView)base.FindControl("userpicks_grid");
		//	if (grid != null)
		//	{
		//		foreach (GridViewRow row in grid.Rows)
		//		{
		//			DropDownList list = row.FindControl("golfer_list") as DropDownList;
		//			if (list != null)
		//			{
		//				OnSelectGolfer(list, null);
		//			}
		//		}
		//	}
		//}

		protected void OnSelectUser(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(user_list.SelectedValue))
			{
				if (base.IsLeagueSelected)
				{
					using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
					{
						connection.Open();

						using (SqlCommand cmd = new SqlCommand("User_GetPicksByTournament", connection))
						{
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.Parameters.Add(new SqlParameter("UserId", user_list.SelectedValue));
							cmd.Parameters.Add(new SqlParameter("LeagueId", base.CurrentLeagueId));

							IDataReader data = cmd.ExecuteReader();
							userpicks_grid.DataSource = data;
							userpicks_grid.DataBind();
							data.Close();
						}
						
						connection.Close();
					}
				}
			}
			else
			{
				userpicks_grid.DataSource = null;
				userpicks_grid.DataBind();
			}
		}

		protected void OnDataBoundUserPicks(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				DropDownList golfer_list = (DropDownList)e.Row.FindControl("golfer_list");
				golfer_list.DataSource = GolferService.ListActive();	//hopefully the caching works
				golfer_list.DataBind();
				golfer_list.Items.Insert(0, "-- Choose a Golfer --");

				//get current pick (if any)
				int tournamentId = Convert.ToInt32(((HiddenField)e.Row.FindControl("userpick_hidden")).Value);
				int userId = Convert.ToInt32(user_list.SelectedValue);

				var pick = UserPickService.Get(userId, tournamentId);	//should get all on page load and search through collection (too many db calls)
				try
				{
					if (pick != null)
						golfer_list.SelectedValue = pick.GolferId.ToString();
				}
				catch { }
			}
		}

		protected void OnSelectGolfer(object sender, EventArgs e)
		{
			var ddl = (DropDownList)sender;
			if (ddl != null)
			{
				int tournamentId = Convert.ToInt32(ddl.Attributes["TournamentId"].ToString());
				int userId = Convert.ToInt32(user_list.SelectedValue);
				int golferId = Convert.ToInt32(ddl.SelectedValue);

				if (tournamentId > 0 && userId > 0 && golferId > 0)
					UserPickService.Save(userId, tournamentId, golferId);
			}
		}
	}
}