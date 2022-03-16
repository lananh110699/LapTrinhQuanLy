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
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public int SĐT { get; set; }
        public string DiaChi { get; set; }
        public string STK { get; set; }
        public string NganHang { get; set; }
    }
}