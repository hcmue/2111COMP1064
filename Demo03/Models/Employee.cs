using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo03.Models
{
    public enum Gender
    {
        Nam, Nữ
    }

    public class Employee
    {
        public Guid? ID { get; set; }

        [Display(Name = "Mã nhân viên")]
        [Remote(controller:"Demo", action:"KiemTraTrungMaNhanVien")]
        public string EmployeeNo { get; set; }

        [Display(Name = "Họ tên")]
        [MinLength(3, ErrorMessage = "Tối thiểu 3 kí tự")]
        [StringLength(100)]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }


        [EmailAddress]
        [Compare("Email")]
        public string EmailConfirm { get; set; }


        [Display(Name = "Website")]
        [Url]
        public string Website { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [BirthDateCheck]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Giới tính")]
        public Gender Gender { get; set; }

        [Display(Name = "Lương")]
        [Range(0, double.MaxValue)]
        public double Salary { get; set; }

        [Display(Name = "Bán thời gian")]
        public bool IsPartTime { get; set; }

        [Display(Name = "Địa chỉ")]
        [RegularExpression("[a-zA-Z 0-9]*")]
        public string Address { get; set; }

        [Display(Name = "Điện thoại")]
        [RegularExpression("0[35789][0-9]{8}")]
        public string Phone { get; set; }

        [Display(Name = "Số tài khoản")]
        [CreditCard]
        public string CreditCard { get; set; }

        [Display(Name = "Thông tin thêm")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}
