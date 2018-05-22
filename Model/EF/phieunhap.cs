namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qlvlxd.phieunhap")]
    public partial class phieunhap
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public int? SoLuong { get; set; }

        public int? ID_NhaCC { get; set; }

        public int? ID_NV { get; set; }

        public int? Status { get; set; }

        public int? ID_VL { get; set; }

        public virtual nhacc nhacc { get; set; }

        public virtual nhanvien nhanvien { get; set; }

        public virtual vatlieu vatlieu { get; set; }
    }
}
