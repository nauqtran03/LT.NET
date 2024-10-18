using Controller_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controller_View.Controllers
{
    public class GiaiBaiToanController : Controller
    {
        // GET: GiaiBaiToan
        public ActionResult NhanDL(Users u)
        {
            string msg = $"{u.Id} <br/> {u.Name} <br/>{u.Address} <br/>{u.Email} <br/>{u.Password} <br/> ";
            return Content(msg);
        }
        
        public ActionResult TruyenDoiTuong() 
        {
            var user = new Users
            {
                Id = 1,
                Name = "Test",
                Address = "Thanh Hóa",
                Email = "Quan@gamil.com",
                Gender = true,
                Password = "password",
            };
            //ViewBag.Users = user;
            return View(user);//truyền dữ liệu qua hàm view
        }
        public ActionResult TruyenTapDoiTuong()
        {
            var users = new List<Users>{
        new Users
        {
            Id = 2,
            Name = "Ngân",
            Address = "Thanh Hóa",
            Email = "Ngan@gmail.com",
            Gender = true,
            Password = "123"
        },

        new Users
        {
            Id = 3,
            Name = "Khiem",
            Address = "Thai Nguyen",
            Email = "Khiem@gmail.com",
            Gender = true,
            Password = "123"
        },

        new Users
        {
            Id = 4,
            Name = "Ngoc",
            Address = "Hai Phong",
            Email = "Ngoc@gmail.com",
            Gender = true,
            Password = "123"
        }
    };
            //ViewBag.users = users;

            return View(users);
        }
        
        //public ActionResult NhapDLBT_UCLN()
        //{
        //    return View();
        //}
        public ActionResult TimUCLN()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TimUCLN(int? a, int? b)
        {
            string mess = $"UCLN của {a} và {b} là: ";
            while (a!=b)
            {
                if (a > b) a = a - b;
                else b = b - a;
            }
            mess += $"{a}";
            ViewBag.mess = mess ;
            return View();
            //return Content(mess);
        }
        public ActionResult TimUCLN2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TimUCLN2(UCLN u)
        {
            int a = u.a;
            int b = u.b;
            String msg = $"UCLN cua {a} va {b} la: ";
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }

            }
            msg += $"{a}";
            ViewBag.msg = msg;
            return View();

        }
    }
}