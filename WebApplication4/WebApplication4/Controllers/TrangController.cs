using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TrangController : Controller
    {
        // GET: Trang
        public ActionResult Trang()
        {
            var list = new DbLamNghiepConnectApp().ChuongMucs.ToList();
            var total = new Total();
            total.ChuongMuc1 = list;
            var list1 = new DbLamNghiepConnectApp().DieuKhoans.ToList();
            total.DieuKhoan1 = list1;
            return View(total) ;
        }
    }
}