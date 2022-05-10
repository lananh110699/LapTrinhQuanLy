using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NTLABaiTapThucHanh613.Models
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        [Display(Name = "Mã Hàng")]
        [Required(ErrorMessage = "Mã Hàng không được bỏ trống")]
        public string MaHang { get; set; }


        [Required(ErrorMessage = "Tên Hàng không được bỏ trống")]
        [Display(Name = "Tên Hàng")]
        [MinLength(3)]
        public string TenHang { get; set; }


        [Required(ErrorMessage = "Số Lượng không được bỏ trống")]
        [Display(Name = "Số Lượng")]
        public int SoLuong { get; set; }


        [Required(ErrorMessage = "Đơn Giá không được bỏ trống")]
        [Display(Name = "Đơn Giá")]
        public int DonGia { get; set; }
        public ICollection<XuatKho> XuatKho { get; set; }
        public ICollection<NhapKho> NhapKho { get; set; }
    }
}