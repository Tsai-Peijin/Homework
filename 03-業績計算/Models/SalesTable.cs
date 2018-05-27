namespace _03_業績計算.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesTable")]
    public partial class SalesTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Salesman { get; set; }

        public int Pen { get; set; }

        public int Pencil { get; set; }

        public int Eraser { get; set; }

        public int Ruler { get; set; }

        public int Whiteout { get; set; }

        public int Quantity
        {
            get;set;
        }
    }
}
