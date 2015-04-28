using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RonsHouse.FantasyGolf.EF;

namespace RonsHouse.FantasyGolf.Services
{
	public static class UserPickService
	{
		public static UserPick Get(int userId, int tournamentId)
		{
			var cache = new CacheService();
			return cache.Get("fg.userpick-" + userId.ToString() + "-" + tournamentId.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.UserPick
								 where x.UserId == userId && x.TournamentId == tournamentId
								 select x;

					return result.FirstOrDefault();
				}
			});
		}
		
		public static IList<UserPick> List(int userId)
		{
			var cache = new CacheService();
			return cache.Get("fg.userpicks-" + userId.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.UserPick
								  where x.UserId == userId
								  orderby x.Tournament.BeginsOn
								  select x;

					return result.ToList();
				}
			});
		}
	}
}