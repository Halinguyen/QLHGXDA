using QLHGXDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHGXDA.Controllers
{
    public class QLQuyenController : Controller
    {
        // GET: QLQuyen
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Quyen quyen = new tbl_Quyen();
                DB db = new DB();
                List<tbl_Quyen> dsQuyen = db.tbl_Quyen.ToList();
                ViewBag.dsQuyen = dsQuyen;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}