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

		public static IList<Golfer> ListActive(int tournamentId)
		{
			var cache = new CacheService();
			return cache.Get("fg.golfers-" + tournamentId.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.Golfer
								 join up in db.UserPick on x.Id equals up.GolferId
								 where x.IsActive == true && up.TournamentId == tournamentId
								 orderby x.LastName, x.FirstName
								 select x;

					return result.ToList();
				}
			});
		}
		
		public static void Save(string firstName, string lastName, string tour)
		{
			int tourId = 0;

			Int32.TryParse(tour, out tourId);

			if (tourId > 0)
			{
				GolferService.Save(firstName, lastName, tourId);
			}
		}

		public static void Save(string firstName, string lastName, int tourId)
		{
			//TODO: need to handle spelling updates by passing in ID #
			
			using (var db = new FantasyGolfContext())
			{
				var query = from x in db.Golfer
							where x.FirstName == firstName && x.LastName == lastName && x.TourId == tourId
							select x;

				var golfer = query.FirstOrDefault();

				if (golfer == null)
				{
					golfer = new Golfer();
					db.Golfer.Add(golfer);
				}
				else
				{
					db.Entry(golfer).State = System.Data.Entity.EntityState.Modified;
				}

				golfer.FirstName = firstName;
				golfer.LastName = lastName;
				golfer.TourId = tourId;
				golfer.CreatedOn = DateTime.Now;

				db.SaveChanges();
			}
		}
	}
}