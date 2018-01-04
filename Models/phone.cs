namespace Assignment_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class phone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phone()
        {
            phones1 = new HashSet<phones1>();
        }

        [Key]
        [StringLength(70)]
        public string phones { get; set; }

        [Required]
        [StringLength(50)]
        public string models { get; set; }

        [Column("launch year")]
        public int launch_year { get; set; }

        public int price { get; set; }

        public int ratings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phones1> phones1 { get; set; }
    }
}
