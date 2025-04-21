using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebBanGauBong.Data;
using WebBanGauBong.ViewModels;

namespace WebBanGauBong.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            SetViewBags();
            return View();
        }

        private void SetViewBags()
        {
            var category = _context.Categories.Select(c => CategoryVM.Mapping(c)).ToList();
            ViewBag.Category = new SelectList(category, "CategoryId", "Name");
        }
    }
}
