namespace RonsHouse.FantasyGolf.EF
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class FantasyGolfContext : DbContext
	{
		public FantasyGolfContext()
			: base("name=default")
		{
		}

		public virtual DbSet<Golfer> Golfer { get; set; }
		public virtual DbSet<League> League { get; set; }
		public virtual DbSet<LeagueTournament> LeagueTournament { get; set; }
		public virtual DbSet<LeagueTournamentGrouping> LeagueTournamentGrouping { get; set; }
		public virtual DbSet<LeagueUser> LeagueUser { get; set; }
		public virtual DbSet<PlayoffFormat> PlayoffFormat { get; set; }
		public virtual DbSet<RegularSeasonFormat> RegularSeasonFormat { get; set; }
		public virtual DbSet<Tour> Tour { get; set; }
		public virtual DbSet<Tournament> Tournament { get; set; }
		public virtual DbSet<TournamentGrouping> TournamentGrouping { get; set; }
		public virtual DbSet<TournamentResult> TournamentResult { get; set; }
		public virtual DbSet<User> User { get; set; }
		public virtual DbSet<UserPick> UserPick { get; set; }
		public virtual DbSet<UserPickChangeLog> UserPickChangeLog { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Golfer>()
				.Property(e => e.FirstName)
				.IsUnicode(false);

			modelBuilder.Entity<Golfer>()
				.Property(e => e.LastName)
				.IsUnicode(false);

			modelBuilder.Entity<Golfer>()
				.HasMany(e => e.TournamentResult)
				.WithRequired(e => e.Golfer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Golfer>()
				.HasMany(e => e.UserPick)
				.WithRequired(e => e.Golfer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Golfer>()
				.HasMany(e => e.UserPickChangeLog)
				.WithRequired(e => e.Golfer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<League>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<League>()
				.HasMany(e => e.LeagueTournament)
				.WithRequired(e => e.League)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<League>()
				.HasMany(e => e.LeagueUser)
				.WithRequired(e => e.League)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<League>()
				.HasMany(e => e.TournamentGrouping)
				.WithRequired(e => e.League)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PlayoffFormat>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<PlayoffFormat>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<RegularSeasonFormat>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<RegularSeasonFormat>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Tour>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Tour>()
				.Property(e => e.Website)
				.IsUnicode(false);

			modelBuilder.Entity<Tour>()
				.HasMany(e => e.Golfer)
				.WithRequired(e => e.Tour)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tour>()
				.HasMany(e => e.League)
				.WithRequired(e => e.Tour)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tour>()
				.HasMany(e => e.PlayoffFormat)
				.WithRequired(e => e.Tour)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tour>()
				.HasMany(e => e.RegularSeasonFormat)
				.WithRequired(e => e.Tour)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tour>()
				.HasMany(e => e.Tournament)
				.WithRequired(e => e.Tour)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tournament>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Tournament>()
				.HasMany(e => e.LeagueTournament)
				.WithRequired(e => e.Tournament)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tournament>()
				.HasMany(e => e.LeagueTournamentGrouping)
				.WithRequired(e => e.Tournament)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tournament>()
				.HasMany(e => e.TournamentResult)
				.WithRequired(e => e.Tournament)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tournament>()
				.HasMany(e => e.UserPick)
				.WithRequired(e => e.Tournament)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tournament>()
				.HasMany(e => e.UserPickChangeLog)
				.WithRequired(e => e.Tournament)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<TournamentGrouping>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<TournamentGrouping>()
				.HasMany(e => e.LeagueTournamentGrouping)
				.WithRequired(e => e.TournamentGrouping)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<TournamentResult>()
				.Property(e => e.Winnings)
				.HasPrecision(19, 4);

			modelBuilder.Entity<User>()
				.Property(e => e.FirstName)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.Property(e => e.LastName)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.League)
				.WithRequired(e => e.User)
				.HasForeignKey(e => e.ManagerId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.LeagueUser)
				.WithRequired(e => e.User)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.UserPick)
				.WithRequired(e => e.User)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.UserPickChangeLog)
				.WithRequired(e => e.User)
				.WillCascadeOnDelete(false);
		}
	}
}
