using System;

namespace RonsHouse.FantasyGolf.EF
{
	public partial class Golfer
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
	
	public static class GolferExtensions
	{
		public static string Name(this Golfer golfer, bool isLastNameFirst)
		{
			return isLastNameFirst ? golfer.LastName + ", " + golfer.FirstName : golfer.FirstName + " " + golfer.LastName;
		}
	}
}
