using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using RonsHouse.FantasyGolf.Web.Controls;
using RonsHouse.FantasyGolf.EF;

namespace RonsHouse.FantasyGolf.Web.Admin.Remote
{
	public partial class TournamentPage : BaseAdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void OnSyncTournaments(object sender, EventArgs e)
		{
			string json = "";

			using (WebClient client = new WebClient())
			{
				json = client.DownloadString("http://www.pgatour.com/data/r/current/schedule.json");
			}

			if (!String.IsNullOrEmpty(json))
			{
				var serializer = new JavaScriptSerializer();
				serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
				dynamic schedule = serializer.Deserialize(json, typeof(object));

				foreach (var tour in schedule.tours)
				{
					Response.Write("Tour: " + tour.desc + " (" + tour.tourCodeLc + ") - " + tour.trns.Count.ToString() + " tournaments<br />");
				}
			}
		}
	}
}