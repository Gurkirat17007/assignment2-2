namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team
    {
        [Key]
        public int Boys { get; set; }

        [Required]
        [StringLength(10)]
        public string Girls { get; set; }

        [Required]
        [StringLength(10)]
        public string Kids { get; set; }

        [Required]
        [StringLength(10)]
        public string Old { get; set; }

        public virtual Sport Sport { get; set; }
    }
}
