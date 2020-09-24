using BookManagement.Models;
using System.Linq;
using BookManagement.DTO;
using System.Collections.Generic;
using PagedList;
using System;

namespace BookManagement.DAO
{
    public class GioHangDAO
    {
        BookDb db = null;
        public GioHangDAO()
        {
            db = new BookDb();
        }
        public string ThemGioHang(GioHang gioHang)
        {
            db.GioHangs.Add(gioHang);
            db.SaveChanges();
            return gioHang.MaGH;
        }

        public IEnumerable<ChiTietGioHangDTO> chiTietDonHang(string MaGH, int pageNumber, int pageSize)
        {
            var li = from a in db.GioHangs join
                      b in db.ChiTietGioHangs on a.MaGH equals b.MaGH
                     join c in db.Saches on b.MaSach equals c.MaSach
                     select new ChiTietGioHangDTO { MaSach = b.MaSach, Soluong = b.SoLuong, GiaTien = b.GiaTien, TenSach = c.TenSach };
            if (li == null) return null;
            else
            {
                return li.OrderByDescending(p => p.MaSach).ToPagedList(pageNumber,pageSize);
            }
        }
        public IEnumerable<GioHang> dsDonHang(int pagenumber, int pagesize)
        {
            return db.GioHangs.OrderByDescending(p => p.NgayDatHang).ToPagedList(pagenumber, pagesize);
        }

        public String getMaGH()
        {
            int mghINT = 0;
            string maGH = "";
            string[] mtext = { "0", "00", "000", "0000", "00000", "000000", "0000000" };
            var item = db.GioHangs.OrderByDescending(s => s.MaGH).FirstOrDefault();
            if (item == null)
                mghINT = 1;
            else
                mghINT = Convert.ToInt32(item.MaGH.Replace("GH", "")) + 1;


            if (mghINT < 10)
            {
                maGH = "GH" + mtext[6] + mghINT;
            }
            else if (mghINT < 100 && mghINT > 9)
            {
                maGH = "GH" + mtext[5] + mghINT;
            }
            else if (mghINT < 1000 && mghINT > 999)
            {
                maGH = "GH" + mtext[4] + mghINT;
            }
            else if (mghINT < 10000 && mghINT > 9999)
            {
                maGH = "GH" + mtext[3] + mghINT;
            }
            else if (mghINT < 100000 && mghINT > 99999)
            {
                maGH = "GH" + mtext[2] + mghINT;
            }
            else if (mghINT < 1000000 && mghINT > 999999)
            {
                maGH = "GH" + mtext[1] + mghINT;
            }
            else if (mghINT < 10000000 && mghINT > 9999999)
            {
                maGH = "GH" + mtext[0] + mghINT;
            }

            return maGH;
        }

        public IEnumerable<ChiTietDH_Result> chiTietDH(string id, int pageNumber, int pageSize)
        {
            return db.ChiTietDH(id).ToList().OrderByDescending(p => p.TenSach).ToPagedList(pageNumber, pageSize);
        }
    }
}