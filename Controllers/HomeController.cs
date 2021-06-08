using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_technologies.Models;

namespace web_technologies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Movie> movies = new List<Movie>();

            //connect to mysql

            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=cinema;port=3306;password=root") )
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from movies", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //extract data
                    Movie m = new Movie();
                    m.S_id= Convert.ToInt32(reader["s_id"]);
                    m.Movie_id= Convert.ToInt32(reader["movie_id"]);
                    m.Movie_name= reader["movie_name"].ToString();
                    m.Movie_description = reader["movie_description"].ToString();
                    m.Movie_date = (DateTime)reader["movie_date"];
                    movies.Add(m);


                }
                reader.Close();
            }
            return View(movies);
        }

    }
}
