﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class KetQuaController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: KetQua
        public ActionResult Index()
        {
            var ketQuas = db.KetQuas.Include(k => k.NhanVien);
            return View(ketQuas.ToList());
        }
        //Tìm kiếm kết quả của nhân viên
        public ActionResult TimKiemKQNV()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult TimKiemKQNV(string TenNV)
        {
            ViewBag.TenNV = TenNV;
            var nhanVien = db.NhanViens.FirstOrDefault(x => x.HoTenNV.Contains(TenNV));
            if (nhanVien == null) return View();
           
                var list = db.KetQuas.Where(x => x.MaNV == nhanVien.MaNV).ToList();
                return View(list);
  
        }
        // GET: KetQua/Details/5
        public ActionResult Details(int? id, string tenSP)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id, tenSP);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // GET: KetQua/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV");
            return View();
        }

        // POST: KetQua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenSP,DonGia,SoLuong_")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.KetQuas.Add(ketQua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", ketQua.MaNV);
            return View(ketQua);
        }

        // GET: KetQua/Edit/5
        public ActionResult Edit(int? id, string tenSP)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id, tenSP);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", ketQua.MaNV);
            return View(ketQua);
        }

        // POST: KetQua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenSP,DonGia,SoLuong_")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ketQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", ketQua.MaNV);
            return View(ketQua);
        }

        // GET: KetQua/Delete/5
        public ActionResult Delete(int? id, string tenSP)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id, tenSP);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // POST: KetQua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string tenSP)
        {
            KetQua ketQua = db.KetQuas.Find(id,tenSP);
            db.KetQuas.Remove(ketQua);
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
