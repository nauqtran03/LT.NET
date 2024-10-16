using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bai1.Controllers
{
    public class BTVNController : Controller
    {
        // GET: BTVN
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PTB2(decimal a, decimal b, decimal c) 
        {
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;
            return View();
        }
        public ActionResult UCLN(decimal a, decimal b)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            return View();
        }
        public ActionResult SoNgayTrongThang (decimal thang, decimal nam)
        {
            ViewBag.nam = nam;
            ViewBag.thang = thang;
            return View();
        }
        private bool KiemTraSoNguyenTo(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; i < Math.Sqrt(n); i++) 
            {
                if(n%i==0)return false;
            }
            return true;
        }
        public ActionResult TongMang(string arr)
        {
            string[] arrStr = arr.Split(',');
            int[] a = Array.ConvertAll(arrStr,int.Parse);

            List<int> MangNguyenTo = new List<int>();
            int tongSoNguyenTo = 0;
            foreach (int num in a)
            {
                if (KiemTraSoNguyenTo(num))
                {
                    MangNguyenTo.Add(num);
                    tongSoNguyenTo += num;
                }
            }
            ViewBag.MangNguyenTo = MangNguyenTo;
            ViewBag.tongSoNguyenTo = tongSoNguyenTo;
            return View();
        }
    }
}