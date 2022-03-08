using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NTLABaiThucHanh613.Models
{
    [Table("Student")]

    public class Student
    {
        [Key]
        public string StudnetID { get; set; }
        public string StudnetName { get; set; }
    }
}