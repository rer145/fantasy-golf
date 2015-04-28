using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RonsHouse.FantasyGolf.EF;

namespace RonsHouse.FantasyGolf.Services
{
	public static class GolferService
	{
		public static Golfer Get(int id)
		{
			var cache = new CacheService();
			return cache.Get("fg.golfer-" + id.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.Golfer
						   where x.Id == id
						   select x;

					return result.FirstOrDefault();
				}
			});
		}
		
		public static IList<Golfer> ListActive()
		{
			var cache = new CacheService();
			return cache.Get("fg.golfers", 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.Golfer
								  where x.IsActive == true
								  orderby x.LastName, x.FirstName
								  select x;

					return result.ToList();
				}
			});
		}
	}
}