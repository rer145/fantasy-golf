namespace RonsHouse.FantasyGolf.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("League")]
    public partial class League
    {
        public League()
        {
            LeagueTournament = new HashSet<LeagueTournament>();
            LeagueUser = new HashSet<LeagueUser>();
            TournamentGrouping = new HashSet<TournamentGrouping>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int TourId { get; set; }

        public int Season { get; set; }

        public int ManagerId { get; set; }

        public DateTime? BeginsOn { get; set; }

        public DateTime? EndsOn { get; set; }

        public int RegularSeasonFormatId { get; set; }

        public int PlayoffFormatId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual User User { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual ICollection<LeagueTournament> LeagueTournament { get; set; }

        public virtual ICollection<LeagueUser> LeagueUser { get; set; }

        public virtual ICollection<TournamentGrouping> TournamentGrouping { get; set; }
    }
}
