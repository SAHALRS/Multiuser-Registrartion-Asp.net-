using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multiuserregistrartion.Models
{
    public class Loginprocess
    {
      public string username { set; get; }
        public string password { set; get; }
        public string confirmpassword { set; get; }

        public string msg { set; get; }
        public string usertype { set; get; }
    }
}