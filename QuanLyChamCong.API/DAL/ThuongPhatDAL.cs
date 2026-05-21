using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.DAL
{
    public class ThuongPhatDAL
    {
        private readonly AppDbContext _context;

        public ThuongPhatDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<VwDanhSachThuongPhat>>
            GetAllAsync()
        {
            return await _context
                .VwDanhSachThuongPhats
                .OrderByDescending(
                    x => x.ngay
                )
                .ToListAsync();
        }

        public async Task<VwDanhSachThuongPhat?>
            GetByIdAsync(
                int id
            )
        {
            return await _context
                .VwDanhSachThuongPhats
                .FromSqlRaw(
                    @"EXEC sp_lay_thuong_phat_theo_id
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
                ThuongPhat model
            )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                .ExecuteSqlRawAsync(
                @"EXEC sp_them_thuong_phat
                    @nhan_vien_id,
                    @ngay,
                    @loai,
                    @so_tien,
                    @ly_do",

                new SqlParameter(
                    "@nhan_vien_id",
                    model.nhan_vien_id
                ),

                new SqlParameter(
                    "@ngay",
                    model.ngay
                ),

                new SqlParameter(
                    "@loai",
                    model.loai
                ),

                new SqlParameter(
                    "@so_tien",
                    model.so_tien
                ),

                new SqlParameter(
                    "@ly_do",
                    model.ly_do
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
                ThuongPhat model
            )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                .ExecuteSqlRawAsync(
                @"EXEC sp_cap_nhat_thuong_phat
                    @id,
                    @nhan_vien_id,
                    @ngay,
                    @loai,
                    @so_tien,
                    @ly_do",

                new SqlParameter(
                    "@id",
                    id
                ),

                new SqlParameter(
                    "@nhan_vien_id",
                    model.nhan_vien_id
                ),

                new SqlParameter(
                    "@ngay",
                    model.ngay
                ),

                new SqlParameter(
                    "@loai",
                    model.loai
                ),

                new SqlParameter(
                    "@so_tien",
                    model.so_tien
                ),

                new SqlParameter(
                    "@ly_do",
                    model.ly_do
                )
            );

                await trans.CommitAsync();

                return true;
            }
            catch( Exception ex ) 
            {
                await trans.RollbackAsync();

                throw new Exception(
                ex.Message
            );
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
                    @"EXEC sp_xoa_thuong_phat
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