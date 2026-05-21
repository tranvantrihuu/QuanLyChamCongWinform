using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.DAL
{
    public class NghiPhepDAL
    {
        private readonly AppDbContext _context;

        public NghiPhepDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<VwDanhSachNghiPhep>>
            GetAllAsync()
        {
            return await _context
                .VwDanhSachNghiPheps
                .OrderByDescending(
                    x => x.ngay
                )
                .ToListAsync();
        }

        public async Task<VwDanhSachNghiPhep?>
            GetByIdAsync(
                int id
            )
        {
            return await _context
                .VwDanhSachNghiPheps
                .FromSqlRaw(
                    @"EXEC sp_lay_nghi_phep_theo_id
                        @id",

                    new SqlParameter(
                        "@id",
                        id
                    )
                )
                .FirstOrDefaultAsync();
        }

        public async Task<bool>
            InsertAsync(
                NghiPhep model
            )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                    @"EXEC sp_them_nghi_phep
                        @nhan_vien_id,
                        @ca_lam_id,
                        @ngay,
                        @loai,
                        @ly_do",

                    new SqlParameter(
                        "@nhan_vien_id",
                        (object?)model.nhan_vien_id
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@ca_lam_id",
                        (object?)model.ca_lam_id
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@ngay",
                        (object?)model.ngay
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@loai",
                        (object?)model.loai
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@ly_do",
                        (object?)model.ly_do
                        ?? DBNull.Value
                    )
                );

                await trans.CommitAsync();

                return true;
            }
            catch
            {
                await trans.RollbackAsync();

                return false;
            }
        }

        public async Task<bool>
            UpdateAsync(
                int id,
                NghiPhep model
            )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                    @"EXEC sp_cap_nhat_nghi_phep
                        @id,
                        @nhan_vien_id,
                        @ca_lam_id,
                        @ngay,
                        @loai,
                        @ly_do",

                    new SqlParameter(
                        "@id",
                        id
                    ),

                    new SqlParameter(
                        "@nhan_vien_id",
                        (object?)model.nhan_vien_id
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@ca_lam_id",
                        (object?)model.ca_lam_id
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@ngay",
                        (object?)model.ngay
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@loai",
                        (object?)model.loai
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@ly_do",
                        (object?)model.ly_do
                        ?? DBNull.Value
                    )
                );

                await trans.CommitAsync();

                return true;
            }
            catch
            {
                await trans.RollbackAsync();

                return false;
            }
        }

        public async Task<bool>
            DeleteAsync(
                int id
            )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                    @"EXEC sp_xoa_nghi_phep
                        @id",

                    new SqlParameter(
                        "@id",
                        id
                    )
                );

                await trans.CommitAsync();

                return true;
            }
            catch
            {
                await trans.RollbackAsync();

                return false;
            }
        }
    }
}