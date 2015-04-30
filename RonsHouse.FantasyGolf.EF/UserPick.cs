namespace RonsHouse.FantasyGolf.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserPick")]
    public partial class UserPick
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TournamentId { get; set; }

        public int GolferId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Golfer Golfer { get; set; }

        public virtual Tournament Tournament { get; set; }

        public virtual User User { get; set; }
    }
}
