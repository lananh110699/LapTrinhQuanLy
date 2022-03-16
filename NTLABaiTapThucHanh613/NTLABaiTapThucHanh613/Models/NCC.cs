using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace NTLABaiTapThucHanh613.Models
{
    [Table("NCC")]
    public class NCC
    {
        [Key]
        [Required(ErrorMessage = "Mã NCC không được bỏ trống")]
        [Display(Name = "Mã NCC")]
        public string MaNCC { get; set; }

        [Required(ErrorMessage = "Tên NCC không được bỏ trống")]
        [Display(Name = "Tên NCC")]
        public string TenNCC { get; set; }

        [Required(ErrorMessage = "Tên Hàng không được bỏ trống")]
        [Display(Name = "Tên Hàng")]
        public string TenHang { get; set; }


        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }


        [Required(ErrorMessage = "SĐT không được bỏ trống")]
        [Display(Name = "SĐT")]
        public int SDT { get; set; }
    }
}