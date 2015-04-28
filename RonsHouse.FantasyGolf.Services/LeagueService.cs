﻿using System;
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
	}
}