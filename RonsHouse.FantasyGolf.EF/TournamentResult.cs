namespace RonsHouse.FantasyGolf.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TournamentResult")]
    public partial class TournamentResult
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TournamentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GolferId { get; set; }

        public int Place { get; set; }

        public bool IsCut { get; set; }

        public bool IsTied { get; set; }

        public bool IsDisqualified { get; set; }

        public bool IsWithdrawn { get; set; }

        public bool IsPlayoff { get; set; }

        [Column(TypeName = "money")]
        public decimal Winnings { get; set; }

        public virtual Golfer Golfer { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
