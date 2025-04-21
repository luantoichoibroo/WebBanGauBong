//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebBanGauBong.Data;
//using WebBanGauBong.Models;
//using WebBanGauBong.ViewModels;

//namespace WebBanGauBong.API
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public ProductController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [HttpPost]
//        public IActionResult Create([FromForm] ProductVM productVM)
//        {
//            try
//            {
//                if (productVM.Image != null && productVM.Image.Length > 0)
//                {
//                    SaveProductImage(productVM);
//                }

//                Product product = ProductVM.Mapping(productVM);
//                _context.Products.Add(product);
//                _context.SaveChanges();

//                return Ok("Thêm được rồi nha ní");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        private void SaveProductImage(ProductVM productVM)
//        {
//            var image = productVM.Image;

//            // Lấy đuôi mở rộng file (.jpg, .png...)
//            var extension = Path.GetExtension(image.FileName);

//            // Tạo tên file ngẫu nhiên
//            var newFileName = Guid.NewGuid().ToString() + extension;

//            // Lưu tên file vào ViewModel
//            productVM.ImageUrl = newFileName;

//            // Tạo đường dẫn đầy đủ tới thư mục wwwroot/src/images/products
//            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/src/images/products", newFileName);

//            // Tạo thư mục nếu chưa có
//            var directory = Path.GetDirectoryName(savePath);
//            if (!Directory.Exists(directory))
//                Directory.CreateDirectory(directory);

//            // Lưu file
//            using var stream = new FileStream(savePath, FileMode.Create);
//            image.CopyTo(stream);
//        }


//    }
//}
