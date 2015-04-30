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
	public partial class AdminGolfersPage : BaseAdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindData();
				message_label_panel.Visible = false;
			}
		}

		protected void OnSaveGolfer(object sender, EventArgs e)
		{
			GolferService.Save(firstname_textbox.Text, lastname_textbox.Text, tour_list.SelectedValue);

			firstname_textbox.Text = "";
			lastname_textbox.Text = "";

			message_label_panel.Visible = true;
			message_label.Text = "Golfer was saved";

			BindData();
		}

		protected void BindData()
		{
			var golfers = GolferService.ListActive();
			golfer_grid.DataSource = golfers;
			golfer_grid.DataBind();

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
}