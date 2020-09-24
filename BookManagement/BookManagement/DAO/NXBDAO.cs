using BookManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BookManagement.DAO
{
    public class NXBDAO
    {
        BookDb db = null;
        public NXBDAO()
        {
            db = new BookDb();
        }
        public List<NXB> dsNXB()
        {
            return db.NXBs.ToList();
        }
        public void Create(NXB nXB)
        {
            db.NXBs.Add(nXB);
            db.SaveChanges();
        }
        public void Edit(NXB nXB)
        {
            db.Entry(nXB).State = EntityState.Modified;
            db.SaveChanges();
        }
        public NXB Details(string id)
        {
            return db.NXBs.Find(id);
        }
        public void Delete(string id)
        {
            NXB nXB = db.NXBs.Find(id);
            if ( nXB !=  null)
            {
                db.NXBs.Remove(nXB);
                db.SaveChanges();
            }
        }
    }
}