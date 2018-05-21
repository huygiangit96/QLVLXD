namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qlvlxd.nhanvien")]
    public partial class nhanvien
    {
        public int ID { get; set; }

        [StringLength(45)]
        public string Ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(45)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        public int? ID_VT { get; set; }

        [StringLength(45)]
        public string TaiKhoan { get; set; }

        [StringLength(45)]
        public string MatKhau { get; set; }
    }
}
