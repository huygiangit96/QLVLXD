using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class NhanVienDao
    {
        QLVLDbContext db = null;
        public NhanVienDao()
        {
            db = new QLVLDbContext();
        }
        public long Login(string username, string password)
        {
            var dbEntry = db.nhanviens.SingleOrDefault(x => x.TaiKhoan == username && x.MatKhau == password);
            if (dbEntry != null) return dbEntry.ID;
            return 0;
        }
        public nhanvien GetByID(long id)
        {
            return db.nhanviens.SingleOrDefault(x => x.ID == id);
        }
        public List<string> GetListCredential(long id)
        {
            var user = db.nhanviens.SingleOrDefault(x => x.ID == id);
            var data = from a in db.vtro_quyen
                       join b in db.vaitroes on a.ID_VT equals b.ID
                       join c in db.quyens on a.ID_Quyen equals c.ID
                       where b.ID == user.ID_VT
                       select new
                       {
                           RoleID = c.Ten,
                           UserGroupID = b.Ten
                       };
            return data.Select(x => x.RoleID).ToList();
        }
    }
}
