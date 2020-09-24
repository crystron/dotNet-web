using BookManagement.DAO;
using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BookManagement.Areas.Admin.Controllers
{
    public class QuanLySachController : Controller
    {
        DanhMucDAO danhMucDAO = new DanhMucDAO();
        TheLoaiDAO theLoaiDAO = new TheLoaiDAO();
        TacGiaDAO tacGiaDAO = new TacGiaDAO();
        NXBDAO nXBDAO = new NXBDAO();
        // GET: Admin/QuanLySach
        public ActionResult Index(string strSearch, int pagenumber = 1, int pagesize = 5)
        {
            SachDAO sachDAO = new SachDAO();
            if (strSearch != null)
            {
                return View(sachDAO.timKiemNQT(strSearch,pagenumber, pagesize));
            }
            return View(sachDAO.listProduct(pagenumber, pagesize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.danhmuc = danhMucDAO.dsDanhMuc();
            ViewBag.theloai = theLoaiDAO.dsTheLoai();
            ViewBag.tacgia = tacGiaDAO.dsTacGia();
            ViewBag.nxb = nXBDAO.dsNXB();
            return View();
        }

        [HttpPost]
        public ActionResult CreateSach(Sach sach)
        {
            ViewBag.danhmuc = danhMucDAO.dsDanhMuc();
            ViewBag.theloai = theLoaiDAO.dsTheLoai();
            ViewBag.tacgia = tacGiaDAO.dsTacGia();
            ViewBag.nxb = nXBDAO.dsNXB();
            if (ModelState.IsValid)
            {
                SachDAO sachDAO = new SachDAO();
                sachDAO.Create(sach);
                return Redirect("Index");
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ViewBag.danhmucsanpham = danhMucDAO.dsDanhMuc();
            ViewBag.loaisanpham = theLoaiDAO.dsTheLoai();
            SachDAO sachDAO = new SachDAO();
            return View(sachDAO.Details(id));
        }

        [HttpPost]
        public ActionResult EditProduct(Sach sp, HttpPostedFileBase linkanh)
        {
            ViewBag.danhmucsanpham = danhMucDAO.dsDanhMuc();
            ViewBag.loaisanpham = theLoaiDAO.dsTheLoai();
            try
            {
                // lấy tên của hình ảnh
                var tenfile = Path.GetFileName(linkanh.FileName);
                // tạo đường dẫn
                var duongdan = Path.Combine(Server.MapPath("/Photo"), tenfile);
                if (System.IO.File.Exists(duongdan))
                {
                    sp.Hinh = linkanh.FileName;
                    ViewBag.loi = "Hình ảnh đã tồn tại";
                }
                else
                {
                    linkanh.SaveAs(duongdan);
                    sp.Hinh = linkanh.FileName;
                }
            }
            catch (Exception)
            {
                SachDAO sachDAO = new SachDAO();
                sp.Hinh = sachDAO.Details(sp.MaSach).Hinh;
            }
            if (ModelState.IsValid)
            {
                SachDAO sachDAO = new SachDAO();
                sachDAO.Edit(sp);
                return Redirect("Index");
            }
            else
            {
                return View("Edit", sp);
            }

        }

        public ActionResult Delete(string masanpham)
        {

            SachDAO sachDAO = new SachDAO();
            sachDAO.Delete(masanpham);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(string id)
        {
            SachDAO sachDAO = new SachDAO();
            return View(sachDAO.Details(id));
        }
    }
}