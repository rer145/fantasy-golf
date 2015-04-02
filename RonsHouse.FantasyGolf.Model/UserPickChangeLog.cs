using System;

namespace RonsHouse.FantasyGolf.Model
{
	public class UserPickChangeLog
	{
		public int UserId { get; set; }
		public int TournamentId { get; set; }
		public int GolferId { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}