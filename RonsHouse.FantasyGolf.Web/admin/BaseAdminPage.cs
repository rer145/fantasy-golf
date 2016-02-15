using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public class BaseAdminPage : Page		//TODO: inherit from BasePage and use message/error panels
	{
		public RonsHouse.FantasyGolf.EF.User CurrentUser
		{
			get
			{
				if (User.Identity.IsAuthenticated && Session["FantasyGolf.User"] != null)
					return (RonsHouse.FantasyGolf.EF.User)Session["FantasyGolf.User"];
				else
					return null;
			}
		}
		
		protected override void OnLoad(EventArgs e)
		{
			//DropDownList leagueList = (DropDownList)base.Master.FindControl("league_list");
			//if (leagueList != null)
			//{
			//	leagueList.Visible = false;
			//}

			if (!User.Identity.IsAuthenticated || Session["FantasyGolf.User"] == null)
			{
				Response.Redirect("~/login.aspx?RedirectUrl=" + Server.UrlEncode(Request.Url.PathAndQuery));
			}
			else
			{
				((Literal)base.Master.FindControl("account_name")).Text = ((RonsHouse.FantasyGolf.EF.User)Session["FantasyGolf.User"]).FirstName;
			}

			base.OnLoad(e);
		}
	}
}