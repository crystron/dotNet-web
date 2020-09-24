using BookManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BookManagement.DAO
{
    public class TheLoaiDAO
    {
        BookDb db = null;
        public TheLoaiDAO()
        {
            db = new BookDb();
        }
        public List<TheLoai> dsTheLoai()
        {
            return db.TheLoais.Select(p => p).ToList();
        }
        public void Create(TheLoai theLoai)
        {
            db.TheLoais.Add(theLoai);
            db.SaveChanges();
        }
        public void Edit(TheLoai theLoai)
        {
            db.Entry(theLoai).State = EntityState.Modified;
            db.SaveChanges();
        }
        public TheLoai Details(string id)
        {
            return db.TheLoais.Find(id);
        }
        public void Delete(string id)
        {
            TheLoai theLoai = db.TheLoais.Find(id);
            if ( theLoai !=  null)
            {
                db.TheLoais.Remove(theLoai);
                db.SaveChanges();
            }
        }
    }
}