using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebBanGauBong.Models;

namespace WebBanGauBong.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
