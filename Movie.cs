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

namespace Lab152MovieList
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string MainActor {get; set;} 
        public string Director { get; set; }

        
        public string Category { get; set; }

        const string server = "Server=9QP7Q13\\SQLEXPRESS;Database=Slack;user id=sa;password=abc123";  //Tyler Database


        public static List<Movie> SearchTitle(string search)
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> Q = db.Query<Movie>($"select * from Movies where Title LIKE '%{search}%'").AsList();

            return Q;
        }

        public static List<Movie> SearchMainActor(string search)
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> Q = db.Query<Movie>($"select * from Movies where MainActor LIKE '%{search}%'").AsList();

            return Q;
        }

        public static List<Movie> SearchDirector(string search)
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> Q = db.Query<Movie>($"select * from Movies where Director LIKE '%{search}%'").AsList();

            return Q;
        }

        public static List<Movie> SearchCategory(string search)
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> Q = db.Query<Movie>($"select * from Movies where Category LIKE '%{search}%'").AsList();

            return Q;
        }
    }
}
