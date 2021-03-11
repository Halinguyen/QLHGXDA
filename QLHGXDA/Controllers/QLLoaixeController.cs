using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHGXDA.Models;

namespace QLHGXDA.Controllers
{
    public class QLLoaixeController : Controller
    {
        // GET: QLLoaixe
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Loaixe loaixe = new tbl_Loaixe();
                DB db = new DB();
                List<tbl_Loaixe> dsLoaixe = db.tbl_Loaixe.ToList();
                ViewBag.dsLoaixe = dsLoaixe;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}