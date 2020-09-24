using BookManagement.DAO;
using System.Web.Mvc;

namespace BookManagement.Areas.Admin.Controllers
{
    public class QuanLyTacGiaController : Controller
    {
        // GET: Admin/QuanLyTacGia
        public ActionResult Index()
        {

            TacGiaDAO tacGiaDAO = new TacGiaDAO();
            return View(tacGiaDAO.dsTacGia());
        }
    }
}