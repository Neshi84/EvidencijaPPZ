using Dapper;
using EvidencijaPPZ.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;

namespace EvidencijaPPZ.Repository
{
    class AparatRepository
    {
        public bool Create(Aparat aparat)
        {
            string query = "INSERT INTO aparati(tip,barkod,korisnik_id,model) " +
                           "VALUES (@tip,@barkod,@korisnik_id,@model)"; ;

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var affectedRows = connection.Execute(query, aparat);

                return affectedRows > 0 ? true : false;
            }
        }

        public IEnumerable<Aparat> getAll()
        {
            string query = "SELECT * FROM aparati;";

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var aparati= connection.Query<Aparat>(query);
                return aparati;
            }
        }

        public Aparat getAparat(int id)
        {
            string query = "SELECT * FROM aparati WHERE id=@id;";

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var Id = connection.Query<Aparat>(query, new { id }).FirstOrDefault();

                return Id;
            }
        }

    }
}
