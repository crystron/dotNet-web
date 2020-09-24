using BookManagement.DAO;
using System.Web.Mvc;
using PagedList;

namespace BookManagement.Areas.Admin.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        // GET: Admin/QuanLyKhachHang
        public ActionResult Index(int pageNumber = 1, int pageSize = 8)
        {
            KhachHangDAO kh = new KhachHangDAO();
            return View(kh.dsKhachMuaHang(pageNumber,pageSize));
        }
    }
}