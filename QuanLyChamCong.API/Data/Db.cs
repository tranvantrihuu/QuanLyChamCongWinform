using System.Data.SqlClient;

namespace QuanLyChamCong.API.Data
{
    public class Db
    {
        private readonly string connectionString =
            "Server=.;Database=ChamCongDB;Trusted_Connection=True;TrustServerCertificate=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}