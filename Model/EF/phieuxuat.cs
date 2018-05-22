namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qlvlxd.phieuxuat")]
    public partial class phieuxuat
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuat { get; set; }

        public int? ID_NV { get; set; }

        public int? SoLuong { get; set; }

        public int? ID_Team { get; set; }

        public int? Status { get; set; }

        public int? ID_VL { get; set; }

        [StringLength(45)]
        public string phieuxuatcol { get; set; }

        public virtual doithicong doithicong { get; set; }

        public virtual nhanvien nhanvien { get; set; }

        public virtual vatlieu vatlieu { get; set; }
    }
}
