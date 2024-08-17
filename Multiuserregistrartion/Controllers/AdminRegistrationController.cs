using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multiuserregistrartion.Models;

namespace Multiuserregistrartion.Controllers
{
    public class AdminRegistrationController : Controller
    {
        multiuserRegistrationEntities obj = new multiuserRegistrationEntities();
        // GET: AdminRegistration
        public ActionResult Page_load()
        {
            return View();
        }
        public ActionResult admin_registration(adminregistration obbj)
        {
            if(ModelState.IsValid)
            {
                var maxid = obj.sp_max().FirstOrDefault();
                int maxxid = Convert.ToInt32(maxid);
                int reg_id = 0;
                if(maxxid ==0)
                {
                    reg_id = 1;
                }
                else
                {
                    reg_id = maxxid + 1;
                }
                obj.sp_adminRegistration(reg_id , obbj.name, obbj.address, obbj.phone, obbj.email);
                obj.sp_logininsert(reg_id, obbj.name, obbj.address, "admin");
                obbj.adminmsg = "login succesfulyy";
            }
            return View("Page_load", obbj);
        }
    }
}