using BookManagement.Areas.Admin.Models;
using BookManagement.DAO;
using System.Web.Mvc;

namespace BookManagement.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TaiKhoan ur)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            if (ModelState.IsValid)
            {
                if (taiKhoanDAO.kiemtraTk(ur.TenTK, ur.MatKhau))
                {
                    TaiKhoan u = new TaiKhoan();
                    u.TenTK = taiKhoanDAO.GetTaiKhoan(ur.TenTK).TenTK;
                    u.MatKhau = taiKhoanDAO.GetTaiKhoan(ur.TenTK).MatKhau;
                    u.TenHienThi = taiKhoanDAO.GetTaiKhoan(ur.TenTK).TenHienThi;
                    u.Quyen = taiKhoanDAO.GetTaiKhoan(ur.TenTK).Quyen;
                    u.MaTK = taiKhoanDAO.GetTaiKhoan(ur.TenTK).MaTK;
                    u.MaKH = taiKhoanDAO.GetTaiKhoan(ur.TenTK).MaKH;
                    Session.Add("UserLogin", u);
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View("Index");
        }
        public ActionResult SingOut()
        {

            Session["UserLogin"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Denied()
        {
            return View();
        }
    }
}