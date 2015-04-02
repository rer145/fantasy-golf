using System;

namespace RonsHouse.FantasyGolf.Model
{
	public class BaseApiEntity : BaseEntity
	{
		public Guid SportsDataApiId { get; set; }
		public DateTime LastSyncedOn { get; set; }
	}
}
