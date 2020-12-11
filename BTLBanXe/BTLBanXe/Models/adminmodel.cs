using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTLBanXe.Models
{

    public class adminmodel
    {
        [Required]
        public string User { set; get; }
        public string Password { set; get; }
        public string x { set; get; }
    }
}