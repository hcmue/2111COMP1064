using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Student
    {
        [Display(Name ="Mã sinh viên")]
        public string StudentId { get; set; }
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Display(Name = "Điểm")]
        public double Mark { get; set; }
    }
}
