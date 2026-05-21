using Microsoft.Data.SqlClient;

namespace QuanLyChamCong.API.Data
{
    public class Db
    {
        private readonly IConfiguration _config;

        public Db(
            IConfiguration config
        )
        {
            _config = config;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(
                _config.GetConnectionString(
                    "DefaultConnection"
                )
            );
        }
    }
}