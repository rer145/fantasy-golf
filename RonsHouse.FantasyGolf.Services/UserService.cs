using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RonsHouse.FantasyGolf.EF;

namespace RonsHouse.FantasyGolf.Services
{
	public static class UserService
	{
		public static User Get(int id)
		{
			var cache = new CacheService();
			return cache.Get("fg.user-" + id.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.User
								 where x.Id == id && x.IsActive == true
								 select x;

					return result.FirstOrDefault();
				}
			});
		}

		public static User Get(string email)
		{
			var cache = new CacheService();
			return cache.Get("fg.user-" + email, 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from x in db.User
								 where x.Email == email && x.IsActive == true
								 select x;

					return result.FirstOrDefault();
				}
			});
		}

		public static IList<User> List(int leagueId)
		{
			var cache = new CacheService();
			return cache.Get("fg.users-" + leagueId.ToString(), 60, () =>
			{
				using (var db = new FantasyGolfContext())
				{
					var result = from lu in db.LeagueUser
								 where lu.LeagueId == leagueId && lu.IsActive == true
								 orderby lu.User.LastName, lu.User.FirstName
								 select lu.User;

					return result.ToList();
				}
			});
		}

		public static User Create(string email, string firstName, string lastName)
		{
			User user = new User
			{
				FirstName = firstName,
				LastName = lastName,
				Email = email
			};

			using (var db = new FantasyGolfContext())
			{
				//db.Entry<User>(user);
				db.SaveChanges();
			}

			return user;
		}
	}
}