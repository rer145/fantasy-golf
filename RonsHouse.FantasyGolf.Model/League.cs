using System;

namespace RonsHouse.FantasyGolf.Model
{
    public class League : BaseEntity
    {
		public string Name { get; set; }
		public int Tour { get; set; }
		public int Season { get; set; }
		public int ManagerId { get; set; }
		public DateTime BeginsOn { get; set; }
		public DateTime EndsOn { get; set; }
    }
}