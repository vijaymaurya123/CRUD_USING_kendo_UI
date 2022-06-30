using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace te.ViewModels
{
    public class Usermodel
    {
        public int userid { get; set; }
        public string email { get; set; }
        public int mobile { get; set; }
        public string password { get; set; }
        public DateTime dob { get; set; }
    }
}