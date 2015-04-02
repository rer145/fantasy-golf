using System;

namespace RonsHouse.FantasyGolf.Model
{
	public class LeagueUser
	{
		public int LeagueId { get; set; }
		public int UserId { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}