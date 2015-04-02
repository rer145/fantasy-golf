using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonsHouse.FantasyGolf.SportsDataApi.Player
{
	public class Players
	{
		public Tour tour { get; set; }
		public Season season { get; set; }
		public Player[] players { get; set; }
	}

	public class Tour
	{
		public string id { get; set; }
		public string alias { get; set; }
		public string name { get; set; }
	}

	public class Season
	{
		public string id { get; set; }
		public int year { get; set; }
	}

	public class Player
	{
		public string id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public int height { get; set; }
		public int weight { get; set; }
		public string birthday { get; set; }
		public string country { get; set; }
		public string residence { get; set; }
		public string birth_place { get; set; }
		public bool member { get; set; }
		public DateTime updated { get; set; }
		public string college { get; set; }
		public int turned_pro { get; set; }
	}

}
