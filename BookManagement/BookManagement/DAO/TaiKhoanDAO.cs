using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Description;
using PagedList;

namespace BookManagement.DAO
{
    public class TaiKhoanDAO
    {
        BookDb db = null;
        public TaiKhoanDAO()
        {
            db = new BookDb();
        }

        public bool kiemtraTk(string taikhoan, string matkhau)
        {
            TaiKhoan u = db.TaiKhoans.SingleOrDefault(p => p.MatKhau == matkhau && p.TenTK == taikhoan);
            if (u != null) return true;
            else return false;
        }
        public TaiKhoan GetTaiKhoan(string taikhoan)   //KT đang nhập
        {
            TaiKhoan u = db.TaiKhoans.FirstOrDefault(i => i.TenTK == taikhoan);
            return u ; //Trả về tên TK
        }
        public IEnumerable<TaiKhoan> dsTaiKhoan(int pageNumber, int pageSize)
        {
            return db.TaiKhoans.OrderBy(p => p.MaTK).ToPagedList(pageNumber, pageSize);
        }
        public string Create(TaiKhoan taiKhoan)
        {
            db.TaiKhoans.Add(taiKhoan);
            db.SaveChanges();
            return db.TaiKhoans.OrderByDescending(p => p.MaTK).ToString();
        }
        public void Edit(TaiKhoan taiKhoan)
        {
            db.Entry(taiKhoan).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if ( taiKhoan != null)
            {
                db.TaiKhoans.Remove(taiKhoan);
                db.SaveChanges();
            }
        }
        public TaiKhoan Details(string id)
        {
            return db.TaiKhoans.Find(id);
        }
    }
}