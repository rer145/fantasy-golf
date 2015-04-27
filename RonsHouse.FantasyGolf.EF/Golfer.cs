namespace RonsHouse.FantasyGolf.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Golfer")]
    public partial class Golfer
    {
        public Golfer()
        {
            TournamentResult = new HashSet<TournamentResult>();
            UserPick = new HashSet<UserPick>();
            UserPickChangeLog = new HashSet<UserPickChangeLog>();
        }

        public int Id { get; set; }

        public int TourId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid? SportsDataApiId { get; set; }

        public DateTime? LastSyncedOn { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual ICollection<TournamentResult> TournamentResult { get; set; }

        public virtual ICollection<UserPick> UserPick { get; set; }

        public virtual ICollection<UserPickChangeLog> UserPickChangeLog { get; set; }
    }
}
