using BookManagement.Models;
using BookManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace BookManagement.DAO
{
    public class KhachHangDAO
    {
        BookDb db = null;
        public KhachHangDAO()
        {
            db = new BookDb();
        }
        public string ThemKhachHang(KhachHang kh)
        {
            db.KhachHangs.Add(kh);
            db.SaveChanges();
            return kh.MaKH;
        }
        public String GetMaxMKH()
        {
            int mkhINT = 0;
            string maKH = "";
            string[] mtext = { "0", "00", "000", "0000", "00000", "000000", "0000000"};
            var item = db.KhachHangs.OrderByDescending(s => s.MaKH).FirstOrDefault();
            if (item == null)
                mkhINT = 1;
            else
                mkhINT = Convert.ToInt32(item.MaKH.Replace("KH", "")) + 1;


            if (mkhINT < 10)
            {
                maKH = "KH" + mtext[6] + mkhINT;
            }
            else if (mkhINT < 100 && mkhINT >9)
            {
                maKH = "KH" + mtext[5] + mkhINT;
            }
            else if (mkhINT < 1000 && mkhINT > 999)
            {
                maKH = "KH" + mtext[4] + mkhINT;
            }
            else if (mkhINT < 10000 && mkhINT > 9999)
            {
                maKH = "KH" + mtext[3] + mkhINT;
            }
            else if (mkhINT < 100000 && mkhINT > 99999)
            {
                maKH = "KH" + mtext[2] + mkhINT;
            }
            else if (mkhINT < 1000000 && mkhINT > 999999)
            {
                maKH = "KH" + mtext[1] + mkhINT;
            }
            else if (mkhINT < 10000000 && mkhINT > 9999999)
            {
                maKH = "KH" + mtext[0] + mkhINT;
            }

            return maKH;
        }

        public IPagedList<KhachHangDTO> dsKhachMuaHang(int page, int pagesize)
        {
            var select = from a in db.KhachHangs
                         join b in db.GioHangs on a.MaKH equals b.MaKH
                         select new KhachHangDTO { MaKH = a.MaKH, TenKH = a.TenKh, SoDT = a.SoDT, Email = a.Email, DiaChi = a.DiaChi, NgayDatHang = b.NgayDatHang, TongTien = b.TongTien, MaGH = b.MaGH };
            return select.OrderByDescending(p => p.NgayDatHang).ToPagedList(page, pagesize);
        }
        public KhachHang Details(string id)
        {
            return db.KhachHangs.Find(id);
        }
        public string Find(string kh)
        {
            return db.TEST(kh).ToString();
        }

        public bool CheckSoDT(KhachHang khachHang)
        {
            foreach ( Char c in khachHang.SoDT)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}