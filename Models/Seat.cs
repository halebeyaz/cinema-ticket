using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_technologies.Models
{
    public class Seat
    {
        public int Seat_id { get; set; }
        public string Seat_name { get; set; }
        public bool Is_empty { get; set; }
    }
}
