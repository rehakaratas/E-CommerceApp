using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
