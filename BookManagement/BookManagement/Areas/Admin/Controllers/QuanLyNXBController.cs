using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagement.DAO;

namespace BookManagement.Areas.Admin.Controllers
{
    public class QuanLyNXBController : Controller
    {
        // GET: Admin/QuanLyNXB
        public ActionResult Index()
        {
            NXBDAO nXBDAO = new NXBDAO();
            return View(nXBDAO.dsNXB());
        }
    }
}