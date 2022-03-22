using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NTLABaiTapThucHanh613.Models
{
    [Table("Nhan Vien Kho")]
    public class NVKho
    {
        [Key]
        [Display(Name = "Mã Nhân Viên")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string MaNV { get; set; }

        [Display(Name = "Tên Nhân Viên")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string TenNV { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public int SĐT { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string DiaChi { get; set; }

        [Display(Name = "STK")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string STK { get; set; }

        [Display(Name = "Ngân hàng")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string NganHang { get; set; }
    }
}