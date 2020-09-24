using BookManagement.DAO;
using System.Web.Mvc;

namespace BookManagement.Areas.Admin.Controllers
{
    public class QuanLyTheLoaiController : Controller
    {
        // GET: Admin/QuanLyTheLoai
        public ActionResult Index()
        {
            TheLoaiDAO theLoaiDAO = new TheLoaiDAO();
            return View(theLoaiDAO.dsTheLoai());
        }
    }
}