namespace _03_業績計算.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductTable")]
    public partial class ProductTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Products { get; set; }

        public int Sum { get; set; }

        public int Quantity { get; set; }
    }
}
