using Dapper;
using EvidencijaPPZ.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;

namespace EvidencijaPPZ.Repository
{
    class ServisRepository
    {
        public bool Create(Servis servis)
        {
            string query = "INSERT INTO servis(datum,aparat_id,napomena) " +
                           "VALUES (@datum,@aparat_id,@napomena)"; ;

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var affectedRows = connection.Execute(query, servis);

                return affectedRows > 0 ? true : false;
            }
        }

        public List<ServisReport> getServisReport()
        {
            string query = "SELECT * FROM(SELECT max(servis.datum)AS Datum, aparati.model, korisnik.firma FROM servis INNER JOIN aparati on servis.aparat_id = aparati.id INNER JOIN korisnik on aparati.korisnik_id = korisnik.id GROUP BY servis.aparat_id) WHERE julianday('now')-julianday(Datum) > 175";

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var servisi = connection.Query<ServisReport>(query);

                return servisi.ToList();
            }
        }

    }
}
