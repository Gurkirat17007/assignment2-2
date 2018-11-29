namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sport
    {
        [Key]
        public int Boys { get; set; }

        [Required]
        [StringLength(10)]
        public string Soccer { get; set; }

        [Required]
        [StringLength(10)]
        public string Baseball { get; set; }

        [Required]
        [StringLength(10)]
        public string Rugby { get; set; }

        
    }
}
