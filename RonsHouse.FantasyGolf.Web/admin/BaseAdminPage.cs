using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace RonsHouse.FantasyGolf.Web.Admin
{
	public class BaseAdminPage : Page
	{
		public bool IsLeagueSelected
		{
			get { return Session["FantasyGolf.CurrentLeague"] != null && !String.IsNullOrEmpty(Session["FantasyGolf.CurrentLeague"].ToString()); }
		}

		public int CurrentLeague
		{
			get { return IsLeagueSelected ? Convert.ToInt32(Session["FantasyGolf.CurrentLeague"]) : 0; }
		}
	}
}