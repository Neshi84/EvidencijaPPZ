using Dapper;
using EvidencijaPPZ.Models;
using System.Configuration;
using System.Data.SQLite;

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
    }
}
