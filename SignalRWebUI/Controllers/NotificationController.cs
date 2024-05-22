using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
