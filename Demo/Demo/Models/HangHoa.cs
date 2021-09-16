using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    /// <summary>
    /// Thông tin hàng hóa
    /// </summary>
    public class HangHoa
    {
        [Display(Name ="Mã hàng hóa")]
        public int MaHh { get; set; }
        [Display(Name ="Tên hàng hóa")]
        public string TenHh { get; set; }
        [Display(Name ="Đơn giá")]
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => SoLuong * DonGia;
    }

    public class HangHoaModel : HangHoa
    {
        public string GiaTriKhac { get; set; }
        public string Comment { get; set; }
    }
}
