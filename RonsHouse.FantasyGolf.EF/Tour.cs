namespace RonsHouse.FantasyGolf.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        public Tour()
        {
            Golfer = new HashSet<Golfer>();
            League = new HashSet<League>();
            PlayoffFormat = new HashSet<PlayoffFormat>();
            RegularSeasonFormat = new HashSet<RegularSeasonFormat>();
            Tournament = new HashSet<Tournament>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Website { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<Golfer> Golfer { get; set; }

        public virtual ICollection<League> League { get; set; }

        public virtual ICollection<PlayoffFormat> PlayoffFormat { get; set; }

        public virtual ICollection<RegularSeasonFormat> RegularSeasonFormat { get; set; }

        public virtual ICollection<Tournament> Tournament { get; set; }
    }
}
