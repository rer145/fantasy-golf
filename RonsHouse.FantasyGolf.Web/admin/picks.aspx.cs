﻿using System;
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
	public partial class AdminPicksPage : System.Web.UI.Page
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

				var golfers = connection.Query<Golfer>("select *, LastName + ', ' + FirstName as Name from Golfer order by LastName");
				golfer_list.DataSource = golfers;
				golfer_list.DataBind();
				golfer_list.Items.Insert(0, "");
				golfer_list.SelectedIndex = 0;

				connection.Close();

				message_label.Visible = false;
			}
		}

		protected void OnSavePick(object sender, EventArgs e)
		{
			//save values
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
			connection.Open();

			connection.Query("UserPick_Set", new { 
				TournamentId = tournament_list.SelectedValue, 
				UserId = user_list.SelectedValue, 
				GolferId = golfer_list.SelectedValue 
			}, commandType: CommandType.StoredProcedure);

			connection.Close();
			
			
			message_label.Visible = true;
			message_label.Text = "Pick was saved";
		}
	}
}