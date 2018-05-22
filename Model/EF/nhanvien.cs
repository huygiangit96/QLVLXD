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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhanvien()
        {
            phieunhaps = new HashSet<phieunhap>();
            phieuxuats = new HashSet<phieuxuat>();
        }

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
        public int Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieunhap> phieunhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieuxuat> phieuxuats { get; set; }

        public virtual vaitro vaitro { get; set; }
    }
}
