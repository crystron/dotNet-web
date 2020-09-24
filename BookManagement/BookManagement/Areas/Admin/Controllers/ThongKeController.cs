using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagement.Models;
using PagedList;
using BookManagement.DAO;

namespace BookManagement.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: Admin/ThongKe
        private BookDb db = new BookDb();
        public ActionResult Index(int pageNumber =1, int pageSize =8)
        {
            List<Sach> saches = db.PTonKho().OrderByDescending(p => p.SL).ToList();
            return View(saches.ToPagedList(pageNumber,pageSize));
        }
    }
}