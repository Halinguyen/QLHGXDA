using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHGXDA.Models;
namespace QLHGXDA.Controllers
{
    public class QLKhachhangController : Controller
    {
        // GET: QLKhachhang
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Khachhang khachhang = new tbl_Khachhang();
                DB db = new DB();
                List<tbl_Khachhang> dsKhachhang = db.tbl_Khachhang.ToList();
                List<tbl_Taikhoan> dsTaikhoan = db.tbl_Taikhoan.ToList();
                ViewBag.dsKhachhang = dsKhachhang;
                ViewBag.dsTaikhoan = dsTaikhoan;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}