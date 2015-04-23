using System;

namespace RonsHouse.FantasyGolf.Model
{
    public class Tour : BaseEntity
    {
		public string Name { get; set; }
		public string Website { get; set; }
		public DateTime ModifiedOn { get; set; }
    }
}