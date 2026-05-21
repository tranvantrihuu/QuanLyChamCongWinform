using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.DAL
{
    public class CaLamDAL
    {
        private readonly AppDbContext _context;

        public CaLamDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        // =========================
        // LẤY DANH SÁCH
        // =========================
        public List<CaLam> GetAll()
        {
            return _context.CaLams
                .FromSqlRaw(
                    "SELECT * FROM vw_danh_sach_ca_lam"
                )
                .ToList();
        }

        // =========================
        // THÊM
        // =========================
        public bool Insert(CaLam ca)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    @"
                    EXEC sp_them_ca_lam
                        @ten_ca,
                        @gio_bat_dau,
                        @gio_ket_thuc,
                        @phut_cho_phep_di_tre,
                        @phut_cho_phep_ve_som,
                        @phut_cho_phep_checkin_som,
                        @phut_cho_phep_checkout_tre
                    ",
                    new SqlParameter(
                        "@ten_ca",
                        ca.ten_ca ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@gio_bat_dau",
                        ca.gio_bat_dau ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@gio_ket_thuc",
                        ca.gio_ket_thuc ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@phut_cho_phep_di_tre",
                        ca.phut_cho_phep_di_tre ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@phut_cho_phep_ve_som",
                        ca.phut_cho_phep_ve_som ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@phut_cho_phep_checkin_som",
                        ca.phut_cho_phep_checkin_som ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@phut_cho_phep_checkout_tre",
                        ca.phut_cho_phep_checkout_tre ?? (object)DBNull.Value
                    )
                );

                return true;
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // CẬP NHẬT
        // =========================
        public bool Update(CaLam ca)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    @"
                    EXEC sp_cap_nhat_ca_lam
                        @id,
                        @ten_ca,
                        @gio_bat_dau,
                        @gio_ket_thuc,
                        @phut_cho_phep_di_tre,
                        @phut_cho_phep_ve_som,
                        @phut_cho_phep_checkin_som,
                        @phut_cho_phep_checkout_tre
                    ",
                    new SqlParameter("@id", ca.id),

                    new SqlParameter(
                        "@ten_ca",
                        ca.ten_ca ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@gio_bat_dau",
                        ca.gio_bat_dau ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@gio_ket_thuc",
                        ca.gio_ket_thuc ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@phut_cho_phep_di_tre",
                        ca.phut_cho_phep_di_tre ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@phut_cho_phep_ve_som",
                        ca.phut_cho_phep_ve_som ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@phut_cho_phep_checkin_som",
                        ca.phut_cho_phep_checkin_som ?? (object)DBNull.Value
                    ),

                    new SqlParameter(
                        "@phut_cho_phep_checkout_tre",
                        ca.phut_cho_phep_checkout_tre ?? (object)DBNull.Value
                    )
                );

                return true;
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // XÓA
        // =========================
        public bool Delete(int id)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    @"
                    EXEC sp_xoa_ca_lam
                        @id
                    ",
                    new SqlParameter(
                        "@id",
                        id
                    )
                );

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}