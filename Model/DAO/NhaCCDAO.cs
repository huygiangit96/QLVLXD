using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class NhaCCDAO
    {
        QLVLDbContext db = null;
        public NhaCCDAO()
        {
            db = new QLVLDbContext();
        }
        public List<nhacc> ListAll()
        {
            return db.nhaccs.ToList();
        }
    }
}
