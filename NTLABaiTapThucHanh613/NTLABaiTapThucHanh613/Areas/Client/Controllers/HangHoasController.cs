using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NTLABaiTapThucHanh613.Models;

namespace NTLABaiTapThucHanh613.Areas.Client.Controllers
{
    public class HangHoasController : Controller
    {
        private LTQLDB db = new LTQLDB();
        AutoGenerateKey aukey = new AutoGenerateKey();

        // GET: Client/HangHoas
        public ActionResult Index()
        {
            return View(db.HangHoas.ToList());
        }

        public ActionResult Upfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upfile (HttpPostedFileBase file)
        {
            string filePath = string.Empty;
            if (file !=null)
            {
                string path = Server.MapPath("~/Uploads/");
                filePath = path + Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(filePath);
                string conString = string.Empty;
                switch (extension)
                {
                    case ".xls":
                        conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + filePath + ";Extended Properties='Excel 8.0;HDR=YES' ";
                        break;
                    case ".xlsx":
                        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + filePath + ";Extended Properties='Excel 12.0;HDR=YES' ";
                        break;
                }
                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);
                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;
                            connExcel.Open();
                            DataTable dtExcelShema;
                            dtExcelShema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelShema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From[" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();

                        }    
                    }    
                }
                conString = @"data source=DESKTOP-S60DTPV;initial catalog=LTQLDB;integrated security=True";
                using (SqlConnection con = new SqlConnection(conString)) 
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        
                        sqlBulkCopy.DestinationTableName = "dbo.HangHoa";
                        sqlBulkCopy.ColumnMappings.Add("MaHang", "MaHang");
                        sqlBulkCopy.ColumnMappings.Add("TenHang", "TenHang");
                        sqlBulkCopy.ColumnMappings.Add("SoLuong", "SoLuong");
                        sqlBulkCopy.ColumnMappings.Add("DonGia", "DonGia");
                        sqlBulkCopy.ColumnMappings.Add("ThanhTien", "ThanhTien");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();

                    }
                } 
                                    
            } 
            ViewBag.Success = "Thêm dữ liệu thành công";
            return View();
        }

        // GET: Client/HangHoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // GET: Client/HangHoas/Create
      
        public ActionResult Create()
        {
            if (db.HangHoas.OrderByDescending(m => m.MaHang).Count() == 0)
            {
                var newID = "MHH001";
                ViewBag.NewMHHID = newID;
            }
            else
            {
                var MHHID = db.HangHoas.OrderByDescending(m => m.MaHang).FirstOrDefault().MaHang;
                var newID = aukey.GenerateKey(MHHID);
                ViewBag.NewMHHID = newID;
            }
            return View();

        }

        // POST: Client/HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,TenHang,SoLuong,DonGia")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangHoa);
        }

        // GET: Client/HangHoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // POST: Client/HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,TenHang,SoLuong,DonGia")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangHoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangHoa);
        }

        // GET: Client/HangHoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // POST: Client/HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HangHoa hangHoa = db.HangHoas.Find(id);
            db.HangHoas.Remove(hangHoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        

    }
}
