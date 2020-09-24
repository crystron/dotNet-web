using BookManagement.DAO;
using BookManagement.Models;
using System;
using System.Web.Mvc;

namespace BookManagement.Areas.Admin.Controllers
{
    public class QuanLyDanhMucController : BaseController
    {
        // GET: Admin/QuanLyDanhMuc        
        public ActionResult Index()
        {
            DanhMucDAO danhMucDAO = new DanhMucDAO();
            return View(danhMucDAO.dsDanhMuc());
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDanhMuc([Bind(Include = "MaDM,TenDM,MetaTitle")] DanhMuc dm)
        {
            if (ModelState.IsValid)
            {
                DanhMucDAO danhMucDAO = new DanhMucDAO();

                danhMucDAO.Create(dm);
                return Redirect("Index");
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DanhMucDAO danhMucDAO = new DanhMucDAO();
            return View(danhMucDAO.Find(id));
        }
        [HttpPost]
        public ActionResult EditDanhMuc(DanhMuc dm)
        {
            if (ModelState.IsValid)
            {
                DanhMucDAO danhMucDAO = new DanhMucDAO();
                danhMucDAO.Edit(dm);
                return Redirect("Index");
            }
            else
            {
                return View("Edit", dm);
            }
        }
        public ActionResult Delete(int id)
        {
            DanhMucDAO danhMucDAO = new DanhMucDAO();
            danhMucDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}