using QLHGXDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHGXDA.Controllers
{
    public class QLGiaveController : Controller
    {
        // GET: QLGiave
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Giave giave = new tbl_Giave();
                DB db = new DB();
                List<tbl_Giave> dsGiave = db.tbl_Giave.ToList();
                List<tbl_Loaixe> dsLoaixe = db.tbl_Loaixe.ToList();
                List<tbl_Loaive> dsLoaive = db.tbl_Loaive.ToList();
                List<tbl_Khunggio> dsKhunggio = db.tbl_Khunggio.ToList();
                ViewBag.dsGiave = dsGiave;
                ViewBag.dsloaixe = dsLoaixe;
                ViewBag.dsLoaive = dsLoaive;
                ViewBag.dsKhunggio = dsKhunggio;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}