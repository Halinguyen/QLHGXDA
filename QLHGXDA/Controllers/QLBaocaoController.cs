using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHGXDA.Controllers
{
    public class QLBaocaoController : Controller
    {
        // GET: QLBaocao
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                 
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}