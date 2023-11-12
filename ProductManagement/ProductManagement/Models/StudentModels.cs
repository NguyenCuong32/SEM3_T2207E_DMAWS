using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class StudentModels
    {
        [Key]
        [Display(Name = "Mã Sinh Viên")]
        public string StudentID { get; set; } = default!;
        [Display(Name ="Tên Sinh Viên")]
        public string StudentName { get; set; } = default!;
        [Display(Name = "Ngày Sinh")]
        public DateTime Birthday { get; set; } = default!;
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; } = default!;
    }
}
