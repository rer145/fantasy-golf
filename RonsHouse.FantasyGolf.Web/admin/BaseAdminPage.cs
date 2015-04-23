using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public class BaseAdminPage : Page
	{
		protected override void OnLoad(EventArgs e)
		{
			//DropDownList leagueList = (DropDownList)base.Master.FindControl("league_list");
			//if (leagueList != null)
			//{
			//	leagueList.Visible = false;
			//}

			base.OnLoad(e);
		}
	}
}