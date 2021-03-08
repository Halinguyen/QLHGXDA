using QLHGXDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHGXDA.Controllers
{
    public class QLXeController : Controller
    {
        // GET: QLXe
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                TTXe ttxe = new TTXe();
                List<TTXe> dsThongtinxe = new List<TTXe>();
                dsThongtinxe = ttxe.GetTTXe();
                ViewBag.dsXe = dsThongtinxe;
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}