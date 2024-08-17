using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multiuserregistrartion.Models
{
    public class adminregistration
    {
        [Required(ErrorMessage = "Enter Name")]

        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        [EmailAddress(ErrorMessage ="Enter email")]
        public string email { get; set; }

        public string password { get; set; }
        [Compare("password",ErrorMessage ="COnfirm password")]

        public string confirmpassw { get; set; }
        public string adminmsg { get; set; }
    }
}