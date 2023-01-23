using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.MVC.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
