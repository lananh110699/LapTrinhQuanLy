﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NTLABaiTapThucHanh613.Models;

namespace NTLABaiTapThucHanh613.Areas.Admin.Controllers
{
    public class NhapKhoesController : Controller
    {
        private LTQLDB db = new LTQLDB();

        // GET: Admin/NhapKhoes
        public ActionResult Index()
        {
            var nhapKhos = db.NhapKhos.Include(n => n.HangHoa).Include(n => n.NCC);
            return View(nhapKhos.ToList());
        }

        // GET: Admin/NhapKhoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhos.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho);
        }

        // GET: Admin/NhapKhoes/Create
        public ActionResult Create()
        {
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang");
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Admin/NhapKhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuNhap,NgayNhap,MaNCC,MaHang,TenHang,SoLuong,DonGia,ThanhTien")] NhapKho nhapKho)
        {
            if (ModelState.IsValid)
            {
                db.NhapKhos.Add(nhapKho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", nhapKho.MaHang);
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", nhapKho.MaNCC);
            return View(nhapKho);
        }

        // GET: Admin/NhapKhoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhos.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", nhapKho.MaHang);
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", nhapKho.MaNCC);
            return View(nhapKho);
        }

        // POST: Admin/NhapKhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuNhap,NgayNhap,MaNCC,MaHang,TenHang,SoLuong,DonGia,ThanhTien")] NhapKho nhapKho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhapKho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHang = new SelectList(db.HangHoas, "MaHang", "TenHang", nhapKho.MaHang);
            ViewBag.MaNCC = new SelectList(db.NCCs, "MaNCC", "TenNCC", nhapKho.MaNCC);
            return View(nhapKho);
        }

        // GET: Admin/NhapKhoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapKho nhapKho = db.NhapKhos.Find(id);
            if (nhapKho == null)
            {
                return HttpNotFound();
            }
            return View(nhapKho);
        }

        // POST: Admin/NhapKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhapKho nhapKho = db.NhapKhos.Find(id);
            db.NhapKhos.Remove(nhapKho);
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