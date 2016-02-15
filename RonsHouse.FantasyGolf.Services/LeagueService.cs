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

		public static League SaveResult(string league, string name, string tour, string season)
		{
			int leagueId = 0;
			int tourId = 0;
			int seasonId = 0;

			Int32.TryParse(league, out leagueId);
			Int32.TryParse(tour, out tourId);
			Int32.TryParse(season, out seasonId);

			if (tourId > 0 && seasonId > 0)
			{
				return LeagueService.SaveResult(leagueId, name, tourId, seasonId);
			}

			return null;
		}

		public static League SaveResult(int id, string name, int tourId, int season)
		{
			League result = null;
			
			using (var db = new FantasyGolfContext())
			{
				if (id > 0)
				{
					var query = from x in db.League
								where x.Id == id
								select x;
					
					var temp = query.FirstOrDefault();
					if (temp == null)
					{
						result = new League();
						db.League.Add(result);
					}
					else
					{
						result = temp;
						db.Entry(result).State = System.Data.Entity.EntityState.Modified;
					}
				}
				else
				{
					result = new League();
					db.League.Add(result);
				}

				result.Name = name;
				result.TourId = tourId;
				result.Season = season;
				result.ManagerId = 1;
				result.PlayoffFormatId = 1;
				result.RegularSeasonFormatId = 1;
				result.BeginsOn = null;
				result.EndsOn = null;
				result.IsActive = true;
				result.CreatedOn = DateTime.Now;

				db.SaveChanges();
			}

			return result;
		}
	}
}