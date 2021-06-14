using Microsoft.AspNetCore.Mvc;

namespace App_Loucos_por_Acai.Areas.Admin.Controllers
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
