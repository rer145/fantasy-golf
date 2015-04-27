using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RonsHouse.FantasyGolf.EF;

namespace RonsHouse.FantasyGolf.Services
{
	public static class LeagueService
	{
		public static League Get(int id)
		{
			var cache = new CacheService();
			return cache.Get("fg.league-" + id.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from l in db.League
						   where l.Id == id
						   select l;

					return result.FirstOrDefault();
				}
			});
		}
		
		public static IList<League> GetActiveLeagues()
		{
			var cache = new CacheService();
			return cache.Get("leagues", 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from l in db.League
								  where l.IsActive == true
								  orderby l.Season descending
								  select l;

					return result.ToList();
				}
			});
		}
	}
}