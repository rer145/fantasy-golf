using System;

namespace RonsHouse.FantasyGolf.Model
{
    public class Tournament : BaseEntity
    {
		public string Name { get; set; }
		public DateTime BeginsOn { get; set; }
		public DateTime EndsOn { get; set; }
    }
}