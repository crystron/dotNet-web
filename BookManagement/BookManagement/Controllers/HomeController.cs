using BookManagement.DAO;
using BookManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1, int pagesize = 8)
        {         
            SachDAO sachDAO = new SachDAO();
            TheLoaiDAO theLoaiDAO = new TheLoaiDAO();
            ViewBag.sanphammoi = sachDAO.dsSanPhamTheoUuTien(3, page, pagesize).Take(4);
            ViewBag.loaisanpham = theLoaiDAO.dsTheLoai();
            ViewBag.danhsachban = sachDAO.dsBan(page, pagesize);
            ViewBag.hethang = sachDAO.dsHetHang(page, pagesize);
            return View();
        }
        
        [ChildActionOnly]
        public ActionResult DanhMucSanPham()
        {
            DanhMucDAO danhMucDAO = new DanhMucDAO();
            return PartialView(danhMucDAO.dsDanhMuc());

        }
        [ChildActionOnly]
        public PartialViewResult CatogeryLeft()
        {
            DanhMucDAO danhMucDAO = new DanhMucDAO();
            return PartialView(danhMucDAO.dsDanhMuc());
        }
        
        public ActionResult SanPhamTheoUuTien(int id, int page = 1, int pagesize = 4)
        {
            SachDAO sachDAO = new SachDAO();
            return View(sachDAO.dsSanPhamTheoUuTien(id, page, pagesize));
        }
        public ActionResult SanPhamTheoLoai(string id, int page = 1, int pagesize = 4)
        {
            SachDAO sachDAO = new SachDAO();
            return View(sachDAO.dsSanPhamTheoLoai(id, page, pagesize));
        }
        public ActionResult SanPhamTheoDanhMuc(int id, int page = 1, int pagesize = 16)
        {
            SachDAO sachDAO = new SachDAO();
            return View(sachDAO.dsSanPhamTheoDanhMuc(id, page, pagesize));
        }
        [ChildActionOnly]
        public ActionResult DanhMucTimKiem(int id)
        {
            DanhMucDAO danhMucDAO = new DanhMucDAO();
            return PartialView(danhMucDAO.Find(id));
        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TaiKhoanDTO tk)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            if (taiKhoanDAO.kiemtraTk(tk.TenTK, tk.MatKhau))
            {
                return View("Index", "Home");
            }
            else
            {
                return View("UserLogin");
            }
        }



        public ActionResult GioiThieu()
        {
            return HttpNotFound();
        }
        public ActionResult TinTuc()
        {
            return HttpNotFound();
        }
    }
}