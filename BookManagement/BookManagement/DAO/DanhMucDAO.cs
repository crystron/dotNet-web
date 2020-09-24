using BookManagement.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookManagement.DAO
{
    public class DanhMucDAO
    {
        BookDb db = null;
        public DanhMucDAO()
        {
            db = new BookDb();
        }
        public List<DanhMuc> dsDanhMuc()
        {
            return db.DanhMucs.ToList();
        }

        public void Create(DanhMuc dm)
        {
            db.DanhMucs.Add(dm);
            db.SaveChanges();
        }

        public DanhMuc Find(int id)
        {
            return db.DanhMucs.Find(id);
        }

        public void Edit(DanhMuc dm)
        {
            db.Entry(dm).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            DanhMuc dm = db.DanhMucs.Find(id);
            if (dm != null)
            {
                db.DanhMucs.Remove(dm);
                db.SaveChanges();
            }
        }
    }
}