using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NTLABaiTapThucHanh613.Models
{
    [Table("Khach Hang")]
    public class KhachHang
    {
        [Key]
        [Display(Name = "Mã Khách Hàng")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string MaKhachHang { get; set; }

        [Display(Name = "Tên Khách Hàng")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string TenKhachHang { get; set; }

        [Display(Name = "SĐT")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public int SĐT { get; set; }

        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string DiaChi { get; set; }
        public ICollection<XuatKho> XuatKho { get; set; }
    }
}