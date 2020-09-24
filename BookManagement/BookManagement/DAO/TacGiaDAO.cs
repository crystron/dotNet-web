using BookManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BookManagement.DAO
{
    public class TacGiaDAO
    {
        BookDb db = null;
        public TacGiaDAO()
        {
            db = new BookDb();
        }
        public List<TacGia> dsTacGia()
        {
            return db.TacGias.ToList();
        }
        public void Create(TacGia tacGia)
        {
            db.TacGias.Add(tacGia);
            db.SaveChanges();
        }
        public void Edit(TacGia tacGia)
        {
            db.Entry(tacGia).State = EntityState.Modified;
            db.SaveChanges();
        }
        public TacGia Details(string id)
        {
            return db.TacGias.Find(id);
        }
        public void Delete(string id)
        {
            TacGia tacGia = db.TacGias.Find(id);
            if ( tacGia != null)
            {
                db.TacGias.Remove(tacGia);
                db.SaveChanges();
            }
        }
    }
}