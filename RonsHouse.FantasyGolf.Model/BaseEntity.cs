using System;

namespace RonsHouse.FantasyGolf.Model
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
