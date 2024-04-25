using Microsoft.AspNetCore.Mvc;

namespace VendendoPecas.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
