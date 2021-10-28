using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCodeFirst.Entities
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public string Hinh { get; set; }

        public int? MaLoaiTruoc { get; set; }
        [ForeignKey("MaLoaiTruoc")]
        public Loai LoaiTruoc { get; set; }

        public ICollection<HangHoa> HangHoas { get; set; }
    }
}
