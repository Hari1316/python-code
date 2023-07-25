using Microsoft.AspNetCore.Mvc;


namespace MSCMS_Presentationlayer.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
