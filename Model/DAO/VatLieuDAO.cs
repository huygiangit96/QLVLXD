using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class VatLieuDAO
    {
        QLVLDbContext db = null;
        public VatLieuDAO()
        {
            db = new QLVLDbContext();
        }
        public vatlieu GetByID(int id)
        {
            return db.vatlieux.SingleOrDefault(x => x.ID == id);
        }
        public List<vatlieu> ListAll()
        {
            return db.vatlieux.ToList();
        }
        public bool Insert(vatlieu item)
        {
            try
            {
                db.vatlieux.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(vatlieu item)
        {
            var dbEntry = db.vatlieux.SingleOrDefault(x => x.ID == item.ID);
            try
            {
                dbEntry.Image = item.Image;
                dbEntry.Ten = item.Ten;
                dbEntry.UpdateDate = item.UpdateDate;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void ChangeStatus(int id)
        {
            var dbEntry = db.vatlieux.SingleOrDefault(x => x.ID == id);
            dbEntry.Status = dbEntry.Status == 1 ? 0 : 1;
            db.SaveChanges();
        }
        public bool Delete(int id)
        {
            try
            {
                var dbEntry = db.vatlieux.SingleOrDefault(x => x.ID == id);
                db.vatlieux.Remove(dbEntry);
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
