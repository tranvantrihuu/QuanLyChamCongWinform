using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLyChamCong.DAL
{
    public class CaLamDAL
    {
        DataProvider dp = new DataProvider();

        // =========================
        // LẤY DANH SÁCH
        // =========================
        public DataTable GetAll()
        {
            string query = "SELECT * FROM ca_lam";
            return dp.ExecuteQuery(query);
        }

        // =========================
        // THÊM
        // =========================
        public int Insert(Dictionary<string, object> p)
        {
            string query = @"
            INSERT INTO ca_lam
            (ten_ca, gio_bat_dau, gio_ket_thuc,
             phut_cho_phep_di_tre, phut_cho_phep_ve_som,
             phut_cho_phep_checkin_som, phut_cho_phep_checkout_tre)
            VALUES
            (@ten, @bd, @kt, @tre, @som, @checkin, @checkout)
            ";

            return dp.ExecuteNonQuery(query, p);
        }

        // =========================
        // SỬA
        // =========================
        public int Update(Dictionary<string, object> p)
        {
            string query = @"
            UPDATE ca_lam SET
                ten_ca = @ten,
                gio_bat_dau = @bd,
                gio_ket_thuc = @kt,
                phut_cho_phep_di_tre = @tre,
                phut_cho_phep_ve_som = @som,
                phut_cho_phep_checkin_som = @checkin,
                phut_cho_phep_checkout_tre = @checkout
            WHERE id = @id
            ";

            return dp.ExecuteNonQuery(query, p);
        }

        // =========================
        // XÓA
        // =========================
        public int Delete(List<int> ids)
        {
            string query = $"DELETE FROM ca_lam WHERE id IN ({string.Join(",", ids)})";
            return dp.ExecuteNonQuery(query);
        }

        // =========================
        // CHECK TRÙNG TÊN CA (OPTIONAL)
        // =========================
        public bool ExistsTenCa(string ten)
        {
            string query = "SELECT COUNT(*) FROM ca_lam WHERE ten_ca = @ten";

            object result = dp.ExecuteScalar(query, new Dictionary<string, object>
            {
                { "@ten", ten }
            });

            return Convert.ToInt32(result) > 0;
        }
    }
}