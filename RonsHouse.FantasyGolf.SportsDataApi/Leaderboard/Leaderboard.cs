using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonsHouse.FantasyGolf.SportsDataApi.Leaderboard
{

	public class Leaderboards
	{
		public string id { get; set; }
		public string name { get; set; }
		public float purse { get; set; }
		public float winning_share { get; set; }
		public int points { get; set; }
		public string event_type { get; set; }
		public string start_date { get; set; }
		public string end_date { get; set; }
		public Season[] seasons { get; set; }
		public string coverage { get; set; }
		public string status { get; set; }
		public Leaderboard[] leaderboard { get; set; }
	}

	public class Season
	{
		public string id { get; set; }
		public int year { get; set; }
		public Tour tour { get; set; }
	}

	public class Tour
	{
		public string id { get; set; }
		public string name { get; set; }
		public string alias { get; set; }
	}

	public class Leaderboard
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string country { get; set; }
		public string id { get; set; }
		public int position { get; set; }
		public bool tied { get; set; }
		public float money { get; set; }
		public float points { get; set; }
		public int score { get; set; }
		public int strokes { get; set; }
		public Round[] rounds { get; set; }
	}

	public class Round
	{
		public int score { get; set; }
		public int strokes { get; set; }
		public int thru { get; set; }
		public int eagles { get; set; }
		public int birdies { get; set; }
		public int pars { get; set; }
		public int bogeys { get; set; }
		public int double_bogeys { get; set; }
		public int other_scores { get; set; }
		public int holes_in_one { get; set; }
		public int sequence { get; set; }
	}

}
