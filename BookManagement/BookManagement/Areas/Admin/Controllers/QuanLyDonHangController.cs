using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagement.DAO;

namespace BookManagement.Areas.Admin.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: Admin/QuanLyDonHang
        public ActionResult Index(int pageNumber = 1, int pageSize = 8)
        {
            GioHangDAO gioHangDAO = new GioHangDAO();
            return View(gioHangDAO.dsDonHang(pageNumber,pageSize));
        }

        public ActionResult Details(string id, int pageNumber = 1, int pageSize = 8)
        {
            GioHangDAO gioHangDAO = new GioHangDAO();
            return View(gioHangDAO.chiTietDH(id, pageNumber, pageSize));
        }
    }
}