using Microsoft.AspNetCore.Mvc;
using WebBanGauBong.Data;
using WebBanGauBong.ViewModels;

namespace WebBanGauBong.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ProductVM> products = _context.Products.Select(p => ProductVM.Mapping(p)).ToList();
            return View(products);
        }
    }
}
