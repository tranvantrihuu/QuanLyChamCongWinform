using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.DAL
{
    public class PhanCaDAL
    {
        DataProvider dp = new DataProvider();

        // ===== LẤY THEO TUẦN =====
        public DataTable GetByWeek(DateTime from, DateTime to)
        {
            string query = @"
            SELECT pc.*, nv.ho_ten
            FROM phan_ca pc
            JOIN nhan_vien nv ON pc.nhan_vien_id = nv.id
            WHERE pc.ngay_lam BETWEEN @from AND @to";

            return dp.ExecuteQuery(query, new Dictionary<string, object>
            {
                { "@from", from },
                { "@to", to }
            });
        }

        // ===== INSERT =====
        public int Insert(string nvId, int caId, DateTime ngay)
        {
            string query = @"
            INSERT INTO phan_ca(nhan_vien_id, ca_lam_id, ngay_lam)
            VALUES (@nv, @ca, @ngay)";

            return dp.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                { "@nv", nvId },
                { "@ca", caId },
                { "@ngay", ngay }
            });
        }

        // ===== CHECK TRÙNG =====
        public bool Exists(string nvId, int caId, DateTime ngay)
        {
            string query = @"
            SELECT COUNT(*) FROM phan_ca
            WHERE nhan_vien_id = @nv
            AND ca_lam_id = @ca
            AND ngay_lam = @ngay";

            object result = dp.ExecuteScalar(query, new Dictionary<string, object>
            {
                { "@nv", nvId },
                { "@ca", caId },
                { "@ngay", ngay }
            });

            return Convert.ToInt32(result) > 0;
        }

        // ===== XÓA THEO NGÀY + CA =====
        public int DeleteByDateAndCa(DateTime ngay, int caId)
        {
            string query = @"
            DELETE FROM phan_ca
            WHERE ngay_lam = @ngay
            AND ca_lam_id = @ca";

            return dp.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                { "@ngay", ngay },
                { "@ca", caId }
            });
        }

        public int Delete(string nvId, int caId, DateTime ngay)
        {
            string sql = @"
        DELETE FROM phan_ca
        WHERE nhan_vien_id = @nv
        AND ca_lam_id = @ca
        AND CAST(ngay_lam AS DATE) = @ngay
        ";

                var param = new Dictionary<string, object>()
        {
            { "@nv", nvId },
            { "@ca", caId },
            { "@ngay", ngay.Date }
        };

            return dp.ExecuteNonQuery(sql, param);
        }
    }
}