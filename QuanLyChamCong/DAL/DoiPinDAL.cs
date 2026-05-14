using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.DAL
{
    public class DoiPinDAL
    {
        DataProvider dp =
            new DataProvider();

        // lấy nhân viên

        public DataTable GetNhanVien()
        {
            string query =
                @"
                SELECT
                    id,
                    ho_ten,
                    pin_code
                FROM nhan_vien
                ORDER BY ho_ten
                ";

            return dp.ExecuteQuery(query);
        }

        // đổi pin

        public bool DoiPin(
            string id,
            string pinMoi
        )
        {
            string query =
                @"
                UPDATE nhan_vien
                SET pin_code = @pin,
                    updated_at = GETDATE()
                WHERE id = @id
                ";

            int rows =
                dp.ExecuteNonQuery(
                    query,
                    new Dictionary<string, object>
                    {
                        { "@id", id },
                        { "@pin", pinMoi }
                    }
                );

            return rows > 0;
        }
    }
}