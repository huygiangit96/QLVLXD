using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.View
{
    public class PhieuNhapView
    {
        public int ID { get; set; }
        public DateTime? NgayNhap { get; set; }
        public int? SoLuong { get; set; }
        public string NhaCC { get; set; }
        public string NhanVien { get; set; }
        public string VatLieu { get; set; }
        public int? Status { get; set; }
    }
}
