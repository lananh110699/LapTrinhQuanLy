using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTLABaiThucHanh613.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(String Masinhvien, string Tensinhvien)
        {
            ViewBag.Message = Masinhvien + "   " + Tensinhvien;
            return View();
        }
    }
}