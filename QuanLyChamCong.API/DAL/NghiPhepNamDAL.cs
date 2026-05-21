using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.DAL
{
    public class NghiPhepNamDAL
    {
        private readonly AppDbContext _context;

        public NghiPhepNamDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        // =========================
        // LẤY DANH SÁCH
        // VIEW:
        // vw_danh_sach_nghi_phep_nam
        // =========================
        public List<NghiPhepNam> GetAll()
        {
            return _context.NghiPhepNams
                .FromSqlRaw(
                    "SELECT * FROM vw_danh_sach_nghi_phep_nam"
                )
                .ToList();
        }

        // =========================
        // LẤY THEO ID
        // LINQ + EF
        // =========================
        public NghiPhepNam? GetById(
            int id
        )
        {
            return _context.NghiPhepNams
                .FirstOrDefault(
                    x => x.id == id
                );
        }

        // =========================
        // THÊM
        // SP:
        // sp_them_nghi_phep_nam
        // =========================
        public bool Insert(
    NghiPhepNam item
)
        {
            _context.Database.ExecuteSqlRaw(
                @"
                EXEC sp_them_nghi_phep_nam
                    @nhan_vien_id,
                    @nam,
                    @so_ca_duoc_nghi
                ",
                new SqlParameter(
                    "@nhan_vien_id",
                    item.nhan_vien_id
                ),

                new SqlParameter(
                    "@nam",
                    item.nam
                ),

                new SqlParameter(
                    "@so_ca_duoc_nghi",
                    item.so_ca_duoc_nghi
                )
            );

            return true;
        }

        // =========================
        // CẬP NHẬT
        // SP:
        // sp_cap_nhat_nghi_phep_nam
        // =========================
        public bool Update(
            NghiPhepNam item
        )
        {
            _context.Database.ExecuteSqlRaw(
                @"
            EXEC sp_cap_nhat_nghi_phep_nam
                @id,
                @nhan_vien_id,
                @nam,
                @so_ca_duoc_nghi
            ",
                new SqlParameter(
                    "@id",
                    item.id
                ),

                new SqlParameter(
                    "@nhan_vien_id",
                    item.nhan_vien_id
                ),

                new SqlParameter(
                    "@nam",
                    item.nam
                ),

                new SqlParameter(
                    "@so_ca_duoc_nghi",
                    item.so_ca_duoc_nghi
                )
            );

            return true;
        }

        // =========================
        // XÓA
        // SP:
        // sp_xoa_nghi_phep_nam
        // =========================
        public bool Delete(
            int id
        )
        {
            _context.Database.ExecuteSqlRaw(
                @"
        EXEC sp_xoa_nghi_phep_nam
            @id
        ",
                new SqlParameter(
                    "@id",
                    id
                )
            );

            return true;
        }
    }
}