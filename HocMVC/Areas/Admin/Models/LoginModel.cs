using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HocMVC.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập password")]
        public string PassWord { set; get; }

        public bool Remmember { set; get; }
    }
}