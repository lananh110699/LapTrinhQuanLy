using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NTLABaiTapThucHanh613.Models
{
    [Table("Xuất Kho")]
    public class XuatKho
    {
        [Key]

        [Display(Name = "Mã Phiếu Xuất")]
        [Required(ErrorMessage = "Mã Phiếu Xuất không được bỏ trống")]
        public string MaPhieuXuat { get; set; }

        [Display(Name = "Ngày Xuất")]
        [Required(ErrorMessage = "Ngày Xuất không được bỏ trống")]
        public string NgayXuat { get; set; }

        [Display(Name = "Mã Hàng")]
        [Required(ErrorMessage = "Mã Hàng không được bỏ trống")]
        public string MaHang { get; set; }

        [Display(Name = "Tên Hàng")]
        [Required(ErrorMessage = "Tên Hàng không được bỏ trống")]
        public string TenHang { get; set; }

        [Display(Name = "Số Lượng")]
        [Required(ErrorMessage = "Số Lượng không được bỏ trống")]
        public int SoLuong { get; set; }

        [Display(Name = "Đơn Giá")]
        [Required(ErrorMessage = "Đơn Giá không được bỏ trống")]
        public int DonGia { get; set; }

        [Display(Name = "Thành Tiền")]
        public int ThanhTien { get; set; }
    }
}