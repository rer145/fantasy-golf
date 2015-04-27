namespace RonsHouse.FantasyGolf.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tournament")]
    public partial class Tournament
    {
        public Tournament()
        {
            LeagueTournament = new HashSet<LeagueTournament>();
            LeagueTournamentGrouping = new HashSet<LeagueTournamentGrouping>();
            TournamentResult = new HashSet<TournamentResult>();
            UserPick = new HashSet<UserPick>();
            UserPickChangeLog = new HashSet<UserPickChangeLog>();
        }

        public int Id { get; set; }

        public int TourId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime BeginsOn { get; set; }

        public DateTime EndsOn { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid? SportDataApiId { get; set; }

        public DateTime? LastSyncedOn { get; set; }

        public virtual ICollection<LeagueTournament> LeagueTournament { get; set; }

        public virtual ICollection<LeagueTournamentGrouping> LeagueTournamentGrouping { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual ICollection<TournamentResult> TournamentResult { get; set; }

        public virtual ICollection<UserPick> UserPick { get; set; }

        public virtual ICollection<UserPickChangeLog> UserPickChangeLog { get; set; }
    }
}
