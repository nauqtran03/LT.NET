using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _42_LTUDDN_TranQuangQuang_21103100304_DHTI15A5HN.Models;

namespace _42_LTUDDN_TranQuangQuang_21103100304_DHTI15A5HN.Controllers
{
    public class LichHensController : Controller
    {
        private TranQuangQuanEntities db = new TranQuangQuanEntities();

        // GET: LichHens
        public ActionResult Index()
        {
            var lichHens = db.LichHens.Include(l => l.BenhNhan);
            return View(lichHens.ToList());
        }
        

        // GET: LichHens/Details/5
        public ActionResult Details(int? id, int? MaBN)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHens.Find(id, MaBN);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            return View(lichHen);
        }

        // GET: LichHens/Create
        public ActionResult Create()
        {
            ViewBag.MaBN = new SelectList(db.BenhNhans, "MaBN", "HoTen");
            return View();
        }

        // POST: LichHens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLichHen,MaBN,NgayHen_,BacSi_,LyDo_")] LichHen lichHen)
        {
            if (ModelState.IsValid)
            {
                db.LichHens.Add(lichHen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBN = new SelectList(db.BenhNhans, "MaBN", "HoTen", lichHen.MaBN);
            return View(lichHen);
        }

        // GET: LichHens/Edit/5
        public ActionResult Edit(int? id, int? MaBN)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHens.Find(id, MaBN);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBN = new SelectList(db.BenhNhans, "MaBN", "HoTen", lichHen.MaBN);
            return View(lichHen);
        }

        // POST: LichHens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLichHen,MaBN,NgayHen_,BacSi_,LyDo_")] LichHen lichHen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichHen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBN = new SelectList(db.BenhNhans, "MaBN", "HoTen", lichHen.MaBN);
            return View(lichHen);
        }

        // GET: LichHens/Delete/5
        public ActionResult Delete(int? id, int? MaBN)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHens.Find(id, MaBN);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            return View(lichHen);
        }

        // POST: LichHens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int MaBN)
        {
            LichHen lichHen = db.LichHens.Find(id, MaBN);
            db.LichHens.Remove(lichHen);
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
