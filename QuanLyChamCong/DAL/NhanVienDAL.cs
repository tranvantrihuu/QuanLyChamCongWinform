using QuanLyChamCong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.DAL
{
    internal class NhanVienDAL
    {
        DataProvider dp = new DataProvider();

        // Lấy tất cả nhân viên
        public DataTable GetAllNhanVien()
        {
            string query = "SELECT * FROM nhan_vien";
            return dp.ExecuteQuery(query);
        }

        // Tìm theo PIN
        public DataTable GetByPin(string pin)
        {
            string query = "SELECT * FROM nhan_vien WHERE pin_code = @pin";
            return dp.ExecuteQuery(query, new Dictionary<string, object>
                {
                    { "@pin", pin }
                });
        }
        public DataRow KiemTraAdminByPin(string pin)
        {
            string query = @"
            SELECT TOP 1 *
            FROM nhan_vien
            WHERE vai_tro = 'admin'
            AND pin_code = @pin";

            DataTable dt = dp.ExecuteQuery(
                query,
                new Dictionary<string, object>
                {
            { "@pin", pin }
                }
            );

            if (dt == null || dt.Rows.Count == 0)
                return null;

            return dt.Rows[0];
        }
        public string GetNhanVienIdByMaVanTay(string ma)
        {
            string query = "SELECT id FROM nhan_vien WHERE ma_van_tay = @ma";

            DataTable dt = dp.ExecuteQuery(query, new Dictionary<string, object>
            {
                { "@ma", ma }
            });

            if (dt == null || dt.Rows.Count == 0)
                return null;

            return dt.Rows[0]["id"].ToString();
        }
        public DataRow GetNhanVienByInput(string input)
        {
            string query = @"
            SELECT TOP 1 * FROM nhan_vien 
            WHERE pin_code = @input OR ma_van_tay = @input";

                    DataTable dt = dp.ExecuteQuery(query, new Dictionary<string, object>
            {
                { "@input", input }
            });

            if (dt == null || dt.Rows.Count == 0)
                return null;

            return dt.Rows[0];
        }
        public int CheckIn(string nhanVienId)
        {
            string query = @"
            IF NOT EXISTS (
                SELECT 1 FROM cham_cong 
                WHERE nhan_vien_id = @id 
                AND ngay_lam = CAST(GETDATE() AS DATE)
            )
            BEGIN
                INSERT INTO cham_cong(nhan_vien_id, ngay_lam, check_in, trang_thai)
                VALUES (@id, CAST(GETDATE() AS DATE), GETDATE(), N'đi làm')
            END
            ELSE
            BEGIN
                -- Nếu có nhưng chưa check-in → update
                UPDATE cham_cong
                SET check_in = GETDATE()
                WHERE nhan_vien_id = @id
                AND ngay_lam = CAST(GETDATE() AS DATE)
                AND check_in IS NULL
            END
            SELECT 1
            ";
            return dp.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                { "@id", nhanVienId }
            });
        }
        public int CheckOut(string nhanVienId)
        {
            string query = @"
            UPDATE cham_cong
            SET check_out = GETDATE()
            WHERE nhan_vien_id = @id
            AND ngay_lam = CAST(GETDATE() AS DATE)
            AND check_in IS NOT NULL
            AND check_out IS NULL";

                    return dp.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                { "@id", nhanVienId }
            });
        }
        public DataRow GetChamCongHomNay(string nhanVienId)
        {
            string query = @"
        SELECT * FROM cham_cong
        WHERE nhan_vien_id = @id
        AND ngay_lam = CAST(GETDATE() AS DATE)";

            DataTable dt = dp.ExecuteQuery(query, new Dictionary<string, object>
            {
                { "@id", nhanVienId }
            });

            if (dt == null || dt.Rows.Count == 0)
                return null;

            return dt.Rows[0];
        }
        public int InsertNhanVien(Dictionary<string, object> p)
        {
            string query = @"
            INSERT INTO nhan_vien
            (id, ma_van_tay, ho_ten, so_dien_thoai, ngay_sinh, dia_chi,
             vi_tri, vai_tro, trang_thai, pin_code, ngay_vao_lam, loai_luong, created_at, updated_at)
            VALUES
            (@id, @ma, @ten, @sdt, @ngaysinh, @diachi,
             @vitri, @vaitro, @trangthai, @pin, @ngayvao, @loai, GETDATE(), GETDATE())";

            return dp.ExecuteNonQuery(query, p);
        }
        public int UpdateNhanVien(Dictionary<string, object> p)
        {
            string query = @"
            UPDATE nhan_vien SET
                ma_van_tay = @ma,
                ho_ten = @ten,
                so_dien_thoai = @sdt,
                ngay_sinh = @ngaysinh,
                dia_chi = @diachi,
                vi_tri = @vitri,
                vai_tro = @vaitro,
                trang_thai = @trangthai,
                pin_code = @pin,
                ngay_vao_lam = @ngayvao,
                loai_luong = @loai,
                updated_at = GETDATE()
            WHERE id = @id";

            return dp.ExecuteNonQuery(query, p);
        }
        public int DeleteNhanVien(List<string> ids)
        {
            string query = $"DELETE FROM nhan_vien WHERE id IN ({string.Join(",", ids.Select(x => $"'{x}'"))})";
            return dp.ExecuteNonQuery(query);
        }
        public DataTable SearchNhanVien(string keyword)
        {
            string query = @"
            SELECT* FROM nhan_vien
            WHERE id COLLATE Latin1_General_CI_AI LIKE @kw
               OR ma_van_tay COLLATE Latin1_General_CI_AI LIKE @kw
               OR ho_ten COLLATE Latin1_General_CI_AI LIKE @kw";

                    return dp.ExecuteQuery(query, new Dictionary<string, object>
            {
                { "@kw", "%" + keyword + "%" }
            });
        }
        public int GetNextAvailableSoNhanVien()
        {
            string query = @"
            SELECT MIN(t1.num + 1)
            FROM (
                SELECT CAST(SUBSTRING(id, 3, 10) AS INT) AS num
                FROM nhan_vien
            ) t1
            WHERE NOT EXISTS (
                SELECT 1 FROM (
                    SELECT CAST(SUBSTRING(id, 3, 10) AS INT) AS num
                    FROM nhan_vien
                ) t2
                WHERE t2.num = t1.num + 1
            )";

            object result = dp.ExecuteScalar(query);

            if (result == DBNull.Value || result == null)
                return 1;

            return Convert.ToInt32(result);
        }
        public bool ExistsID(string id)
        {
            string query = "SELECT COUNT(*) FROM nhan_vien WHERE id = @id";

            object result = dp.ExecuteScalar(query, new Dictionary<string, object>
            {
                { "@id", id }
            });

            return Convert.ToInt32(result) > 0;
        }
        public bool ExistsMaVanTay(string ma)
        {
            string query = "SELECT COUNT(*) FROM nhan_vien WHERE ma_van_tay = @ma";

            object result = dp.ExecuteScalar(query, new Dictionary<string, object>
            {
                { "@ma", ma }
            });

            return Convert.ToInt32(result) > 0;
        }

    }
}
