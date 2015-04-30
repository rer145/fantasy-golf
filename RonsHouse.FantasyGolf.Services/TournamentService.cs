using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RonsHouse.FantasyGolf.EF;

namespace RonsHouse.FantasyGolf.Services
{
	public static class TournamentService
	{
		public static Tournament Get(int id)
		{
			var cache = new CacheService();
			return cache.Get("fg.tournament-" + id.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.Tournament
								 where x.Id == id && x.IsActive == true
								 select x;

					return result.FirstOrDefault();
				}
			});
		}

		public static IList<Tournament> List(int leagueId)
		{
			var cache = new CacheService();
			return cache.Get("fg.tournaments-" + leagueId.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from lt in db.LeagueTournament
								 where lt.LeagueId == leagueId && lt.IsActive == true
								 orderby lt.Tournament.BeginsOn
								 select lt.Tournament;

					return result.ToList();
				}
			});
		}

		public static void SaveResult(string tournament, string golfer, string place, string winnings, bool isCut, bool isTied, bool isWithdrawn, bool isDisqualified, bool isPlayoff)
		{
			int tournamentId = 0;
			int golferId = 0;
			int place2 = 0;
			decimal winnings2 = Decimal.Zero;

			Int32.TryParse(tournament, out tournamentId);
			Int32.TryParse(golfer, out golferId);
			Int32.TryParse(place, out place2);
			Decimal.TryParse(winnings, out winnings2);

			if (tournamentId > 0 && golferId > 0 && place2 > 0 && winnings2 > Decimal.Zero)
			{
				TournamentService.SaveResult(tournamentId, golferId, place2, winnings2, isCut, isTied, isWithdrawn, isDisqualified, isPlayoff);
			}
		}

		public static void SaveResult(int tournamentId, int golferId, int place, decimal winnings, bool isCut, bool isTied, bool isWithdrawn, bool isDisqualified, bool isPlayoff)
		{
			using (var db = new FantasyGolfContext())
			{
				var query = from x in db.TournamentResult
							where x.TournamentId == tournamentId && x.GolferId == golferId
							select x;

				var result = query.FirstOrDefault();
				if (result == null)
				{
					result = new TournamentResult();
					db.TournamentResult.Add(result);
				}
				else
				{
					db.Entry(result).State = System.Data.Entity.EntityState.Modified;
				}

				result.TournamentId = tournamentId;
				result.GolferId = golferId;
				result.Place = place;
				result.Winnings = winnings;
				result.IsCut = isCut;
				result.IsTied = isTied;
				result.IsWithdrawn = isWithdrawn;
				result.IsDisqualified = isDisqualified;
				result.IsPlayoff = isPlayoff;

				db.SaveChanges();
			}
		}
	}
}