using Microsoft.AspNetCore.Mvc;

namespace MLDev.LOTOW.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
