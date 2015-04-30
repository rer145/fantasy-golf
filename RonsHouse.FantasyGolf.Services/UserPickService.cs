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

		public static void Save(string user, string tournament, string golfer)
		{
			int userId = 0;
			int tournamentId = 0;
			int golferId = 0;

			Int32.TryParse(user, out userId);
			Int32.TryParse(tournament, out tournamentId);
			Int32.TryParse(golfer, out golferId);

			if (userId > 0 && tournamentId > 0 && golferId > 0)
			{
				UserPickService.Save(userId, tournamentId, golferId);
			}
		}

		public static void Save(int userId, int tournamentId, int golferId)
		{
			using (var db = new FantasyGolfContext())
			{
				var query = from up in db.UserPick
						   where up.UserId == userId && up.TournamentId == tournamentId
						   select up;

				var pick = query.FirstOrDefault();

				if (pick == null)
				{
					pick = new UserPick();
					db.UserPick.Add(pick);
				}
				else
				{
					db.Entry(pick).State = System.Data.Entity.EntityState.Modified;
				}
				
				pick.UserId = userId;
				pick.TournamentId = tournamentId;
				pick.GolferId = golferId;
				pick.CreatedOn = DateTime.Now;
				
				var pickChange = new UserPickChangeLog
				{
					UserId = userId,
					TournamentId = tournamentId,
					GolferId = golferId,
					CreatedOn = DateTime.Now
				};

				db.UserPickChangeLog.Add(pickChange);
				db.SaveChanges();
			}
		}
	}
}