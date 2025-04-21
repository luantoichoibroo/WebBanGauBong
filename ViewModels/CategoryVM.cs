using System.ComponentModel.DataAnnotations;
using WebBanGauBong.Models;

namespace WebBanGauBong.ViewModels
{
    public class CategoryVM
    {
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public static CategoryVM Mapping(Category category)
        {
            return new CategoryVM
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }

        public static Category Mapping(CategoryVM category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }
    }
}
