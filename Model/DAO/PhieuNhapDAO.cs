using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.View;

namespace Model.DAO
{
    public class PhieuNhapDAO
    {
        QLVLDbContext db = null;
        public PhieuNhapDAO()
        {
            db = new QLVLDbContext();
        }
        public List<PhieuNhapView> ListView()
        {
            var data = from a in db.phieunhaps
                       join b in db.nhanviens on a.ID_NV equals b.ID
                       join c in db.nhaccs on a.ID_NhaCC equals c.ID
                       join d in db.vatlieux on a.ID_VL equals d.ID
                       select new PhieuNhapView()
                       {
                           ID = a.ID,
                           NgayNhap = a.NgayNhap,
                           SoLuong = a.SoLuong,
                           NhaCC = c.Ten,
                           NhanVien = b.Ten,
                           Status = a.Status,
                           VatLieu = d.Ten
                       };
            return data.ToList();
        }
        public bool Insert(phieunhap item)
        {
            try
            {
                db.phieunhaps.Add(item);
                if(item.Status == 1)
                {
                    var dbEntry = db.vatlieux.SingleOrDefault(x => x.ID == item.ID_VL);
                    dbEntry.SoLuong += item.SoLuong;
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
