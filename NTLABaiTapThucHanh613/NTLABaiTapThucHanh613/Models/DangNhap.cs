using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NTLABaiTapThucHanh613.Models
{
    [Table("Đăng Nhập")]
    public class DangNhap
    {
        [Key]
        [StringLength(50)]
        [Display(Name ="Tên Đăng Nhập")]
        [Required(ErrorMessage ="Tên Đăng Nhập không được bỏ trống")]
        public string TenDangNhap { get; set; }


        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Mật Khẩu không được bỏ trống")]
        public string MatKhau { get; set; }
    }
}