using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_technologies.Models
{
    public class Admin
    {

        public int Admin_id { get; set; }
        public string Admin_name { get; set; }
        public string Admin_password { get; set; }
    }
}
