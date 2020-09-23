using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper.Contrib;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab152MovieList.Controllers
{
    [Route("Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        const string server = "Server=9QP7Q13\\SQLEXPRESS;Database=Slack;user id=sa;password=abc123";  //Tyler Database


        [HttpGet]
        public List<Movie> ReadAllMovies()
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> A = db.Query<Movie>($"select * from [Movies]").AsList<Movie>();
            return A;

        }

        [HttpGet("Category/{Search}")]
        public List<Movie> SearchCategory(string Search)
        {

            List<Movie> q;
            q = Movie.SearchCategory(Search);
            return q;
        }

        [HttpGet("MainActor/{Search}")]
        public List<Movie> SearchMainActor(string Search)
        {

            List<Movie> q;
            q = Movie.SearchMainActor(Search);
            return q;
        }

        [HttpGet("Title/{Search}")]
        public List<Movie> SearchTitle(string Search)
        {

            List<Movie> q;
            q = Movie.SearchTitle(Search);
            return q;
        }

        [HttpGet("Director/{Search}")]
        public List<Movie> SearchDirector(string Search)
        {

            List<Movie> q;
            q = Movie.SearchDirector(Search);
            return q;
        }

        /*
        [HttpGet("Search/{enter}")]
        public List<Movie> Search(string Category, string enter)
        {
            
            List<Movie> q;
            if (Category.ToLower() == "director")
            {
                q = Movie.SearchDirector(enter);
            }
            else if (Category.ToLower() == "mainactor")
            {
                q = Movie.SearchMainActor(enter);
            }
            else
            {
                q = Movie.SearchTitle(enter);
            }

            return q;
        }
        */

        [HttpGet("{ID}")]
        public static Movie Read(int ID)
        {
            IDbConnection db = new SqlConnection(server);
            Movie A = db.Get<Movie>(ID);
            return A;
        }


        [HttpGet("Random")]
        public static Movie RandomMovie()
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> A = db.Query<Movie>($"select * from [Movies]").AsList<Movie>();

            Random rand = new Random();
            int result = rand.Next(0, A.Count);
            return A[result];
        }

    }
}
