using BookManagement.Areas.Admin.Models;
using System.Web.Mvc;

namespace BookManagement.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}