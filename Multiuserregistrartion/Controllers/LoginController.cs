using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Multiuserregistrartion.Models;

namespace Multiuserregistrartion.Controllers
{
    public class LoginController : Controller
    {
        multiuserRegistrationEntities obj = new multiuserRegistrationEntities();
        // GET: Login
        public ActionResult Login_view()
        {
            return View();
        }
        public ActionResult User_home()
        {
            return View();
        }
        public ActionResult Adminhome()
        {
            return View();
        }
        public ActionResult LoginButton(Loginprocess objj)
        {

            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                obj.sp_login(objj.username, objj.password, op);
                int valu = Convert.ToInt32(op.Value);
                if (valu == 1)
                {
                    var uid = obj.sp_loginid(objj.username, objj.password).FirstOrDefault();
                    Session["uid"] = uid;
                    
                    var it = obj.sp_logintype(objj.username, objj.password).FirstOrDefault();
                    if ( it == "user")
                   {
                      return RedirectToAction("User_home");
                    }
                    else if( it == "admin")
                    {
                        return RedirectToAction("Adminhome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    objj.msg = "invalid Login";
                    return View("Login_view", objj);
                }
            }

                return View("Login_view",objj);
            }
          
        }
    }
