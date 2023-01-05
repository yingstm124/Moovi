using Microsoft.AspNetCore.Mvc;

namespace Moovi
{
    public class ViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
