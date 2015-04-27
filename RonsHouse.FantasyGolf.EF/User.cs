namespace RonsHouse.FantasyGolf.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            League = new HashSet<League>();
            LeagueUser = new HashSet<LeagueUser>();
            UserPick = new HashSet<UserPick>();
            UserPickChangeLog = new HashSet<UserPickChangeLog>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<League> League { get; set; }

        public virtual ICollection<LeagueUser> LeagueUser { get; set; }

        public virtual ICollection<UserPick> UserPick { get; set; }

        public virtual ICollection<UserPickChangeLog> UserPickChangeLog { get; set; }
    }
}
