using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_technologies.Models
{
    public class User
    {

        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_password { get; set; }
        public string User_email { get; set; }
        public string User_phone     { get; set; }
    }
}
