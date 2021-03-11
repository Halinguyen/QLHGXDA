using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHGXDA.Models;

namespace QLHGXDA.Controllers
{
    public class QLVexeController : Controller
    {
        // GET: QLVexe
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Vexe vexe = new tbl_Vexe();
                DB db = new DB();
                List<tbl_Vexe> dsVexe = db.tbl_Vexe.ToList();
                ViewBag.dsVexe = dsVexe;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}