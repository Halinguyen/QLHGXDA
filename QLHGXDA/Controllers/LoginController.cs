using QLHGXDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHGXDA.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Dangnhap()
        {
            string kq = "";
            tbl_Taikhoan tk = new tbl_Taikhoan();
            var tendangnhap = Request["tendangnhap"];
            var matkhau = Request["matkhau"];
            List<tbl_Taikhoan> dsTaikhoan = new List<tbl_Taikhoan>();
            dsTaikhoan = tk.GetTaikhoanByUsernameandPassword(tendangnhap, matkhau);
            if(dsTaikhoan.Count > 0)
            {
                Session["IsLogin"] = true;
                Session["username"] = tendangnhap;
                Session["password"] = matkhau;
                Session["userID"] = dsTaikhoan[0].PK_iTaikhoanID;
                tbl_Phanquyen phanquyen = new tbl_Phanquyen();
                List<tbl_Phanquyen> dsPhanquyen = phanquyen.GetPhanquyenByFK_iTaikhoanID(dsTaikhoan[0].PK_iTaikhoanID);
                if(dsPhanquyen.Count > 0)
                {
                    switch (dsPhanquyen[0].FK_iQuyenID)
                    {
                        case 1:
                            kq = "True1";
                            break;
                        case 2:
                            kq = "True2";
                            break;
                        case 3:
                            kq = "True3";
                            break;
                    }
                }
                else
                {
                    kq = "True3";
                }
                
            }
            else
            {
                Session["IsLogin"] = false;
                Session["username"] = "";
                Session["password"] = "";
                Session["userID"] = 0;
                kq = "Sai";
            }
            return kq;
        }
    }
}