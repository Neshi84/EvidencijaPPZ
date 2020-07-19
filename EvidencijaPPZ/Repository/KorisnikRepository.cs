using Dapper;
using EvidencijaPPZ.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;

namespace EvidencijaPPZ.Repository
{
    class KorisnikRepository
    {
        public bool Create(Korisnik korisnik)
        {
            string query = "INSERT INTO korisnik(firma,ime,prezime,mobilni,fiksni,email) " +
                           "VALUES (@firma,@ime,@prezime,@mobilni,@fiksni,@email)"; ;

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var affectedRows = connection.Execute(query, korisnik);

                return affectedRows > 0 ? true : false;
            }
        }


        public IEnumerable<Korisnik> getAll()
        {
            string query = "SELECT * FROM korisnik;";

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var korisnik = connection.Query<Korisnik>(query);
                return korisnik;
            }
        }


        public Korisnik getTip(int id)
        {
            string query = "SELECT * FROM korisnik WHERE id=@id;";

            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                var Id = connection.Query<Korisnik>(query, new { id }).FirstOrDefault();

                return Id;
            }
        }
    }
}
