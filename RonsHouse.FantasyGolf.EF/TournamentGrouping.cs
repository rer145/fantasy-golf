namespace RonsHouse.FantasyGolf.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TournamentGrouping")]
    public partial class TournamentGrouping
    {
        public TournamentGrouping()
        {
            LeagueTournamentGrouping = new HashSet<LeagueTournamentGrouping>();
        }

        public int Id { get; set; }

        public int LeagueId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual League League { get; set; }

        public virtual ICollection<LeagueTournamentGrouping> LeagueTournamentGrouping { get; set; }
    }
}
