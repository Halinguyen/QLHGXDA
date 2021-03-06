using QLHGXDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHGXDA.Controllers
{
    public class QLKhudexeController : Controller
    {
        // GET: QLKhudexe
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Khudexe khudexe = new tbl_Khudexe();
                DB db = new DB();
                List<tbl_Khudexe> dsKhudexe = db.tbl_Khudexe.ToList();
                List<tbl_Loaixe> dsLoaixe = db.tbl_Loaixe.ToList();
                ViewBag.dskhudexe = dsKhudexe;
                ViewBag.dsloaixe = dsLoaixe;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}