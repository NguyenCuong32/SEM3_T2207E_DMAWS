using System;
using System.ComponentModel.DataAnnotations;

namespace StudentMvc.Models
{
    public class StudentModel
    {
        [Key]
        [Display(Name = "Mã sinh viên")]
        public string StudentId { get; set; }
        [Display(Name = "Tên sinh viên")]
        public string StudentName { get; set; }
        [Display(Name = "Ngày sinh")]
        public String Birthday { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}

