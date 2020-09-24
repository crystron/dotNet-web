using System;
using System.Web.Mvc;
using BookManagement.DTO;
using BookManagement.Models;
using BookManagement.DAO;

namespace BookManagement.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangKi(TaiKhoanDTO tk)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.MaTK = "";
            taiKhoan.TenTK = tk.TenTK;
            taiKhoan.MatKhau = tk.MatKhau;
            taiKhoan.Email = tk.Email;
            taiKhoan.Quyen = 0;
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            string MaTK = taiKhoanDAO.Create(taiKhoan);
            if ( MaTK == null)
            {
                return View("Index");
            }
            return View("Success");
        }
    }
}