using System;

namespace RonsHouse.FantasyGolf.EF
{
	public partial class User
	{
		public string Name
		{
			get { return this.LastName + ", " + this.FirstName; }
		}

		public string FullName
		{
			get { return this.FirstName + " " + this.LastName; }
		}
	}
	
	public static class UserExtensions
	{
		public static string Name(this User user, bool isLastNameFirst)
		{
			return isLastNameFirst ? user.LastName + ", " + user.FirstName : user.FirstName + " " + user.LastName;
		}
	}
}
