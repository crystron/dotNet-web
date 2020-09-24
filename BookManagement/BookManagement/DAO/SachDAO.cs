using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Data;

namespace BookManagement.DAO
{
    public class SachDAO
    {
        BookDb db = null;
        public SachDAO()
        {
            db = new BookDb();
        }
         
        public IQueryable<Sach> dsSach()
        {
            return db.Saches.Select(p => p);
        }
        public void Create(Sach sach)
        {
                db.Saches.Add(sach);
                db.SaveChanges();
        }

        public Sach Details(string id)
        {
            return db.Saches.Find(id);
        }

        public void Edit(Sach sp)
        {
            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            Sach sach = db.Saches.Find(id);
            if ( sach !=  null)
            {
                db.Saches.Remove(sach);
                db.SaveChanges();
            }
        }

        public IEnumerable<Sach> listProduct(int pagenumber, int pagesize)
        {
            return db.Saches.OrderBy(p => p.MaSach).ToPagedList(pagenumber, pagesize);
        }

        public IEnumerable<Sach> dsSanPhamTheoUuTien(int uutien, int page, int pagesize)
        {
            return db.Saches.Where(p => p.UuTien == uutien && p.SL >0).OrderByDescending(p => p.MaSach).ToPagedList(page, pagesize);
        }

        public IEnumerable<Sach> dsSanPhamTheoLoai(string loaisanpham, int page, int pagesize)
        {
            return db.Saches.Where(p => p.MaTL == loaisanpham).OrderByDescending(p => p.MaSach).ToPagedList(page, pagesize);
        }

        public IEnumerable<Sach> dsSanPhamTheoDanhMuc(int madanhmuc, int page, int pagesize)
        {
            return db.Saches.Where(p => p.MaDM == madanhmuc).OrderByDescending(p => p.MaSach).ToPagedList(page, pagesize);
        }

        public IEnumerable<Sach> Search (string str, int page, int pagesize)
        {
            return db.Saches.Where(x => x.MaSach == str).OrderByDescending(p => p.MaSach).ToPagedList(page, pagesize);
        }
        public IEnumerable<Sach> dsHetHang(int page, int pagesize)
        {
            return db.Saches.Where(p => p.SL < 0).OrderByDescending(p => p.MaSach).ToPagedList(page, pagesize);
        }
        public IEnumerable<Sach> dsBan(int pagenumber, int pagesize)
        {
            return db.Saches.Where(p => p.SL > 0).OrderByDescending(p => p.MaSach).ToPagedList(pagenumber, pagesize);
        }

        //Tìm Kiếm
        public IEnumerable<Sach> timKiemND(string str, int pagenumber, int pagesize)
        {
            return db.TimKiem(str,0).ToList().ToPagedList(pagenumber,pagesize);
        }
        public IEnumerable<Sach> timKiemNQT(string str, int pagenumber, int pagesize)
        {
            return db.TimKiem(str, null).ToList().ToPagedList(pagenumber, pagesize);
        }
    }
}