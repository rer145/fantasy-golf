using System;

namespace RonsHouse.FantasyGolf.Model
{
    public class User : BaseEntity
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
    }
}