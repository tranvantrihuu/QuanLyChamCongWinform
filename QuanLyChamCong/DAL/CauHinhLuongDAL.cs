using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.DAL
{
    public class CauHinhLuongDAL
    {
        DataProvider dp = new DataProvider();

        // =========================
        // LẤY DANH SÁCH
        // =========================
        public DataTable GetAll()
        {
            string query = @"
            SELECT 
                c.id,
                c.nhan_vien_id,

                n.ma_van_tay,
                n.ho_ten,
                n.vi_tri,
                n.loai_luong,

                c.luong_co_ban,
                c.luong_theo_gio,
                c.luong_tang_ca,
                c.phu_cap_mac_dinh

            FROM cau_hinh_luong c
            JOIN nhan_vien n ON c.nhan_vien_id = n.id
            ORDER BY c.nhan_vien_id ASC
            ";

            return dp.ExecuteQuery(query);
        }

        // =========================
        // THÊM
        // =========================
        public int Insert(Dictionary<string, object> p)
        {
            string query = @"
            INSERT INTO cau_hinh_luong
            (nhan_vien_id, luong_co_ban, luong_theo_gio,
             luong_tang_ca, phu_cap_mac_dinh)
            VALUES
            (@nhan_vien_id, @luong_co_ban, @luong_theo_gio,
             @luong_tang_ca, @phu_cap_mac_dinh)
            ";

            return dp.ExecuteNonQuery(query, p);
        }

        // =========================
        // SỬA
        // =========================
        public int Update(Dictionary<string, object> p)
        {
            string query = @"
            UPDATE cau_hinh_luong SET
                nhan_vien_id = @nhan_vien_id,
                luong_co_ban = @luong_co_ban,
                luong_theo_gio = @luong_theo_gio,
                luong_tang_ca = @luong_tang_ca,
                phu_cap_mac_dinh = @phu_cap_mac_dinh
            WHERE id = @id
            ";

            return dp.ExecuteNonQuery(query, p);
        }

        // =========================
        // XÓA
        // =========================
        public int Delete(List<int> ids)
        {
            string query = $"DELETE FROM cau_hinh_luong WHERE id IN ({string.Join(",", ids)})";
            return dp.ExecuteNonQuery(query);
        }

        // =========================
        // LOAD NHÂN VIÊN (CHO COMBOBOX)
        // =========================
        public DataTable GetNhanVien()
        {
            string query = @"
            SELECT id, ho_ten, loai_luong
            FROM nhan_vien
            ";
            return dp.ExecuteQuery(query);
        }

        // =========================
        // CHECK ĐÃ TỒN TẠI (OPTIONAL)
        // =========================
        public bool ExistsByNhanVien(int nhanVienId)
        {
            string query = @"
            SELECT COUNT(*) 
            FROM cau_hinh_luong 
            WHERE nhan_vien_id = @id
            ";

            object result = dp.ExecuteScalar(query, new Dictionary<string, object>
            {
                { "@id", nhanVienId }
            });

            return Convert.ToInt32(result) > 0;
        }
        public void SyncNhanVien()
        {
            string query = @"
            INSERT INTO cau_hinh_luong (nhan_vien_id, luong_co_ban, luong_theo_gio, luong_tang_ca, phu_cap_mac_dinh)
            SELECT n.id, 0, 0, 0, 0
            FROM nhan_vien n
            WHERE NOT EXISTS (
                SELECT 1 FROM cau_hinh_luong c WHERE c.nhan_vien_id = n.id
            )
            ";

            dp.ExecuteNonQuery(query);
        }
        public bool ExistsByNhanVien(object nhanVienId)
        {
            string query = "SELECT COUNT(*) FROM cau_hinh_luong WHERE nhan_vien_id = @id";

            object result = dp.ExecuteScalar(query, new Dictionary<string, object>
            {
                { "@id", nhanVienId }
            });

            return Convert.ToInt32(result) > 0;
        }
        public DataRow GetByNhanVien(object nhanVienId)
        {
            string query = @"
            SELECT *
            FROM cau_hinh_luong
            WHERE nhan_vien_id = @id
            ";

                    var dt = dp.ExecuteQuery(query, new Dictionary<string, object>
            {
                { "@id", nhanVienId }
            });

            if (dt.Rows.Count > 0)
                return dt.Rows[0];

            return null;
        }
    }
}