using System;
using System.Collections.Generic;
using BookManagement.Models;
using System.Web.Mvc;
using BookManagement.DAO;

namespace BookManagement.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        public ActionResult Index(string strSearch,int pagenumber = 1, int pagesize = 8)
        {
            SachDAO sachDAO = new SachDAO();
            if (strSearch != null)
            {
                return View(sachDAO.timKiemND(strSearch,pagenumber,pagesize));
            }
            return View(sachDAO.dsBan(pagenumber,pagesize));
        }
    }
}