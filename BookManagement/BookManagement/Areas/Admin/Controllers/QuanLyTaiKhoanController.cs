using BookManagement.DAO;
using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BookManagement.Areas.Admin.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        // GET: Admin/QuanLyTaiKhoan
        public ActionResult Index(int pageNumber = 1, int pageSize = 16)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            return View(taiKhoanDAO.dsTaiKhoan(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTaiKhoan(TaiKhoan taiKhoan)
        {       
            if ( ModelState.IsValid )
            {
                TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                taiKhoanDAO.Create(taiKhoan);
                return Redirect("Index");
            }
            return View("Create");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            return View(taiKhoanDAO.Details(id));
        }
        [HttpPost]
        public ActionResult EditTaiKhoan(TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
                taiKhoanDAO.Edit(taiKhoan);
                return Redirect("Index");
            }
            return View("Edit", taiKhoan);
        }
        public ActionResult Details(string id)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            return View(taiKhoanDAO.Details(id));
        }
        public ActionResult Delete(string id)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            taiKhoanDAO.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult ShowHistory()
        {
            SaveHistoryDAO saveHistoryDAO = new SaveHistoryDAO();
            return View(saveHistoryDAO.dsLichSu());
        }
    }
}