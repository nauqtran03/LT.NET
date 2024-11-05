using ngay_30_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ngay_30_10.Controllers
{
    public class UsersController : Controller
    {
        public static List<Users> users = new List<Users>
        {
            new Users{Id = 1, Name = "Tran Quang Quan", Address="Thanh Hoa", Email="Quantranhk3@gmail.com", Password="1234", Age =18, Gender = true},
            new Users{Id = 2, Name = "Le Thi Ngan", Address="Thanh Hoa", Email="Nganle@gmail.com", Password="1234", Age =18, Gender = true},
            new Users{Id = 3, Name = "Tran Quang Huy", Address="Thanh Hoa", Email="Huytran@gmail.com", Password="1234", Age =18, Gender = true}

        };
        // GET: Users
        public ActionResult Index()
        {
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u=>u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
