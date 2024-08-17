using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multiuserregistrartion.Models;

namespace Multiuserregistrartion.Controllers
{
    public class UserRegistrationController : Controller
    {
        multiuserRegistrationEntities obj = new multiuserRegistrationEntities();
        // GET: UserRegistration
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult user_registration(userRegistration objj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photo");
                    string fullpath = Path.Combine(s, fname);
                    file.SaveAs(fullpath);


                    var fullpath1 = Path.Combine("~\\Photo", fname);
                    objj.photo = (fullpath);

                }
                if (ModelState.IsValid)
                {
                    var maxid = obj.sp_max().FirstOrDefault();
                    int maxxid = Convert.ToInt32(maxid);
                    int reg_id = 0;
                    if (maxxid == 0)
                    {
                        reg_id = 1;
                    }
                    else
                    {
                        reg_id = maxxid + 1;
                    }
                    obj.sp_UserRegistration(reg_id, objj.name, objj.age, objj.address, objj.email, objj.photo);
                    obj.sp_logininsert(reg_id, objj.name, objj.address, "user");
                    objj.adminmsg = "login succesfulyy";


                }
                else
                {
                    ModelState.Clear();
                    return View("Index", objj);
                }
               
            }
            return View("Index", objj);

        }
    }
}
    




