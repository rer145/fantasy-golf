using System;

namespace RonsHouse.FantasyGolf.Model
{
	public class TournamentGrouping : BaseEntity
	{
		public int LeagueId { get; set; }
		public string Name { get; set; }
		public int DisplayOrder { get; set; }
	}
}