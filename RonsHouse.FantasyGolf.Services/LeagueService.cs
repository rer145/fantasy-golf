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
					var result = from x in db.League
						   where x.Id == id
						   select x;

					return result.FirstOrDefault();
				}
			});
		}
		
		public static IList<League> GetActiveLeagues()
		{
			var cache = new CacheService();
			return cache.Get("fg.leagues", 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.League
								  where x.IsActive == true
								  orderby x.Season descending
								  select x;

					return result.ToList();
				}
			});
		}

		public static IList<TournamentGrouping> ListTournamentGroupings(int leagueId)
		{
			var cache = new CacheService();
			return cache.Get("fg.league-tournament-groupings-" + leagueId.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from ltg in db.LeagueTournamentGrouping
								 join tg in db.TournamentGrouping on ltg.TournamentGroupingId equals tg.Id
								 where ltg.IsActive == true && tg.IsActive == true && tg.LeagueId == leagueId
								 orderby ltg.TournamentGrouping.Name
								 select ltg.TournamentGrouping;

					return result.ToList();
				}
			});
		}
	}
}