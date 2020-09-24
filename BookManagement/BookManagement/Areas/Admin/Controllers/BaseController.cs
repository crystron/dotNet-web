using BookManagement.Areas.Admin.Models;
using System.Web.Mvc;

namespace BookManagement.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var sess = (TaiKhoan)Session["UserLogin"];
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            else if (sess.Quyen  == 0)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}