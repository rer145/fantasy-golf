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
			//save values
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
			connection.Open();

			connection.Query("Golfer_Save", new { 
				FirstName = firstname_textbox.Text, 
				LastName = lastname_textbox.Text,
				TourId = tour_list.SelectedValue
			}, commandType: CommandType.StoredProcedure);

			connection.Close();

			firstname_textbox.Text = "";
			lastname_textbox.Text = "";

			message_label_panel.Visible = true;
			message_label.Text = "Golfer was saved";

			BindData();
		}

		protected void BindData()
		{
			//load up values
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
			connection.Open();

			var golfers = connection.Query<Golfer>("select LastName, FirstName, LastName + ', ' + FirstName as Name from Golfer order by LastName");
			golfer_grid.DataSource = golfers;
			golfer_grid.DataBind();
			try { golfer_grid.HeaderRow.TableSection = TableRowSection.TableHeader; }
			catch { }

			var tours = connection.Query<Golfer>("select * from Tour order by Name");
			tour_list.DataSource = tours;
			tour_list.DataBind();
			tour_list.Items.Insert(0, "");
			tour_list.SelectedIndex = 0;

			connection.Close();
		}
	}
}