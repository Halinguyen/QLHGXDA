using QLHGXDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHGXDA.Controllers
{
    public class QLNhanvienController : Controller
    {
        // GET: QLNhanvien
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Nhanvien nhanvien = new tbl_Nhanvien();
                ViewBag.danhsachNhanvien = nhanvien.GetNhanvienByPK(0);
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}