namespace Assignment_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class phones1
    {
        [Required]
        [StringLength(70)]
        public string phones { get; set; }

        [Key]
        [StringLength(50)]
        public string models { get; set; }

        public int price { get; set; }

        [Required]
        [StringLength(50)]
        public string condition { get; set; }

        public virtual phone phone { get; set; }
    }
}
