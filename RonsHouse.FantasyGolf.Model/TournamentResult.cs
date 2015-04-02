using System;

namespace RonsHouse.FantasyGolf.Model
{
    public class TournamentResult
    {
		public int TournamentId { get; set; }
		public int GolferId { get; set; }
		public int Place { get; set; }
		public bool IsCut { get; set; }
		public bool IsTied { get; set; }
		public bool IsDisqualified { get; set; }
		public bool IsWithdrawn { get; set; }
		public bool IsPlayoff { get; set; }
		public decimal Winnings { get; set; }
    }
}