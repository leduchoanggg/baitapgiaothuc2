using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Book
    {
        public int Id { get; set; }

        // Bắt buộc nhập tên (không được để trống)
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        // Bắt buộc nhập giá và giá phải > 0
        [Required(ErrorMessage = "Không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
    }
}