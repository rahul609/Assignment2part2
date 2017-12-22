namespace Ass2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cars 2")]
    public partial class cars_2
    {
        [Required]
        [StringLength(70)]
        public string Cars { get; set; }

        [Key]
        [StringLength(70)]
        public string VehNo { get; set; }

        public int RentalCost { get; set; }

        public virtual car car { get; set; }
    }
}
