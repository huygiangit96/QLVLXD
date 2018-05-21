namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qlvlxd.vatlieu")]
    public partial class vatlieu
    {
        public int ID { get; set; }

        [StringLength(45)]
        public string Ten { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(45)]
        public string Image { get; set; }
    }
}
