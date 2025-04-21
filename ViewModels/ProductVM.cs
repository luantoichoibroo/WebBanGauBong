using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebBanGauBong.Models;
using System.ComponentModel;

namespace WebBanGauBong.ViewModels
{
    public class ProductVM
    {
        public Guid ProductId { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [RegularExpression(@"^[a-zA-Z0-9\s\u00C0-\u1EF9]+$", ErrorMessage = "Tên Tranh chỉ được chứa chữ, số và ký tự tiếng Việt có dấu")]
        public string Name { get; set; }

        [DisplayName("Giá")]
        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Giá phải là số")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Price { get; set; }

        [DisplayName("Số lượng tồn kho")]
        [Range(1, float.MaxValue, ErrorMessage = "Số lượng tồn kho phải lớn hơn 0")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Số lượng tồn kho phải là số")]
        public int Stock { get; set; }

        [DisplayName("Hình ảnh")]
        public string? ImageUrl { get; set; }
        [DisplayName("Hình ảnh")]
        public IFormFile? Image { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DisplayName("Ngày cập nhật mới nhất")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [DisplayName("Danh mục")]
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public static Product Mapping(ProductVM productVM)
        {
            return new Product
            {
                Name = productVM.Name,
                Price = productVM.Price,
                Stock = productVM.Stock,
                ImageUrl = productVM.ImageUrl,
                CreatedAt = productVM.CreatedAt,
                UpdatedAt = productVM.UpdatedAt,
                CategoryId = productVM.CategoryId,
                Category = productVM.Category
            };
        }

        public static ProductVM Mapping(Product productVM)
        {
            return new ProductVM
            {
                ProductId = productVM.ProductId,
                Name = productVM.Name,
                Price = productVM.Price,
                Stock = productVM.Stock,
                ImageUrl = productVM.ImageUrl,
                CreatedAt = productVM.CreatedAt,
                UpdatedAt = productVM.UpdatedAt,
                CategoryId = productVM.CategoryId,
                Category = productVM.Category
            };
        }
    }
}
