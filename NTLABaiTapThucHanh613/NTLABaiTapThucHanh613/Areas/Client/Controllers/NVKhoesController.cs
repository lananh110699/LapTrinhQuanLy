using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NTLABaiTapThucHanh613.Models;

namespace NTLABaiTapThucHanh613.Areas.Client.Controllers
{
    public class NVKhoesController : Controller
    {
        private LTQLDB db = new LTQLDB();

        // GET: Client/NVKhoes
        public ActionResult Index()
        {
            return View(db.NVKhos.ToList());
        }

        // GET: Client/NVKhoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVKho nVKho = db.NVKhos.Find(id);
            if (nVKho == null)
            {
                return HttpNotFound();
            }
            return View(nVKho);
        }

        // GET: Client/NVKhoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/NVKhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenNV,SĐT,DiaChi,STK,NganHang")] NVKho nVKho)
        {
            if (ModelState.IsValid)
            {
                db.NVKhos.Add(nVKho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nVKho);
        }

        // GET: Client/NVKhoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVKho nVKho = db.NVKhos.Find(id);
            if (nVKho == null)
            {
                return HttpNotFound();
            }
            return View(nVKho);
        }

        // POST: Client/NVKhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,SĐT,DiaChi,STK,NganHang")] NVKho nVKho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nVKho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nVKho);
        }

        // GET: Client/NVKhoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVKho nVKho = db.NVKhos.Find(id);
            if (nVKho == null)
            {
                return HttpNotFound();
            }
            return View(nVKho);
        }

        // POST: Client/NVKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NVKho nVKho = db.NVKhos.Find(id);
            db.NVKhos.Remove(nVKho);
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
