using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo03.Models
{
    public class DangKy
    {
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="*")]
        [MinLength(5, ErrorMessage ="Tối thiểu 5 kí tự")]
        public string HoTen { get; set; }

        [Display(Name = "Tuổi")]
        [Range(16, 60, ErrorMessage ="Tuổi từ 16 - 60")]
        public int Tuoi { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
