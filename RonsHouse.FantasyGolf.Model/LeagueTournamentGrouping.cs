using System;

namespace RonsHouse.FantasyGolf.Model
{
	public class LeagueTournamentGrouping
	{
		public int TournamentGroupingId { get; set; }
		public int TournamentId { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}