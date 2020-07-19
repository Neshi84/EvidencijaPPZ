using Dapper;
using EvidencijaPPZ.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;

namespace EvidencijaPPZ.Repository
{
    class TipRepository
    {
        public bool Create(string tip)
        {
            string query = "INSERT INTO tip(tip) " +
                           "VALUES (@tip)"; ;

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var affectedRows = connection.Execute(query, new {tip});

                return affectedRows > 0 ? true : false;
            }
        }


        public IEnumerable<Tip> getAll()
        {
            string query = "SELECT * FROM tip;";

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var tip = connection.Query<Tip>(query).ToList();
                return tip;
            }
        }


        public Tip getTip(int id)
        {
            string query = "SELECT * FROM tip WHERE id=@id;";

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var Id = connection.Query<Tip>(query, new { id }).FirstOrDefault();

                return Id;
            }
        }
    }
}
