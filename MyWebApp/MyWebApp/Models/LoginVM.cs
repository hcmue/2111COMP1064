using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class LoginVM
    {
        [Required]
        [MaxLength(20)]
        [Display(Name ="Mã khách hàng")]
        public string MaKh { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }
    }
}
