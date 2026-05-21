using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.DAL
{
    public class PhanCaDAL
    {
        private readonly AppDbContext _context;

        public PhanCaDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        // =========================
        // LẤY DANH SÁCH PHÂN CA
        // =========================
        public List<PhanCa> GetAll()
        {
            return _context.PhanCas
                .FromSqlRaw(
                    @"
                    SELECT *
                    FROM phan_ca
                    ORDER BY
                        ngay_lam,
                        ca_lam_id
                    "
                )
                .ToList();
        }

        // =========================
        // KIỂM TRA TRÙNG CA
        // FUNCTION:
        // fn_kiem_tra_trung_ca_lam
        // =========================
        public bool Exists(
            string nvId,
            int caId,
            DateTime ngay
        )
        {
            try
            {
                int result =
                    _context.Database
                    .SqlQueryRaw<int>(
                        @"
                        SELECT
                        dbo.fn_kiem_tra_trung_ca_lam
                        (
                            @nvId,
                            @caId,
                            @ngay
                        )
                        ",
                        new SqlParameter(
                            "@nvId",
                            nvId
                        ),

                        new SqlParameter(
                            "@caId",
                            caId
                        ),

                        new SqlParameter(
                            "@ngay",
                            ngay.Date
                        )
                    )
                    .FirstOrDefault();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // THÊM PHÂN CA
        // SP:
        // sp_phan_ca_lam_viec
        // =========================
        public bool Insert(
            PhanCa pc
        )
        {
            try
            {
                int row =
                    _context.Database
                    .ExecuteSqlRaw(
                        @"
                        EXEC sp_phan_ca_lam_viec
                            @nhan_vien_id,
                            @ca_lam_id,
                            @ngay_lam
                        ",
                        new SqlParameter(
                            "@nhan_vien_id",
                            pc.nhan_vien_id
                        ),

                        new SqlParameter(
                            "@ca_lam_id",
                            pc.ca_lam_id
                        ),

                        new SqlParameter(
                            "@ngay_lam",
                            pc.ngay_lam.Date
                        )
                    );

                return row > 0;
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // CẬP NHẬT PHÂN CA
        // SP:
        // sp_cap_nhat_phan_ca
        // =========================
        public bool Update(
            PhanCa pc
        )
        {
            try
            {
                int row =
                    _context.Database
                    .ExecuteSqlRaw(
                        @"
                        EXEC sp_cap_nhat_phan_ca
                            @id,
                            @nhan_vien_id,
                            @ca_lam_id,
                            @ngay_lam
                        ",
                        new SqlParameter(
                            "@id",
                            pc.id
                        ),

                        new SqlParameter(
                            "@nhan_vien_id",
                            pc.nhan_vien_id
                        ),

                        new SqlParameter(
                            "@ca_lam_id",
                            pc.ca_lam_id
                        ),

                        new SqlParameter(
                            "@ngay_lam",
                            pc.ngay_lam.Date
                        )
                    );

                return row > 0;
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // XÓA PHÂN CA
        // SP:
        // sp_xoa_phan_ca
        // =========================
        public bool Delete(
            int id
        )
        {
            try
            {
                _context.Database
                    .ExecuteSqlRaw(
                        @"
                EXEC sp_xoa_phan_ca
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