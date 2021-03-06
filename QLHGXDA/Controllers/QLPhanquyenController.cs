using QLHGXDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHGXDA.Controllers
{
    public class QLPhanquyenController : Controller
    {
        // GET: QLPhanquyen
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Phanquyen phanquyen = new tbl_Phanquyen();
                ViewBag.dsPhanquyen = phanquyen.GetPhanquyenByPK(0);
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}