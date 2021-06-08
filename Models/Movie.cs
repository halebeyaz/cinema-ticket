using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_technologies.Models
{
    public class Movie
    {

        public int Movie_id { get; set; }
        public string Movie_name { get; set; }
        public string Movie_description { get; set; }
        public DateTime Movie_date { get; set; }
        public int S_id { get; set; }
    }
}
