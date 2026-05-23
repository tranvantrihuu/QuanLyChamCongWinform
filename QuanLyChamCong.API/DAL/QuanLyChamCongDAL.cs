using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.DAL
{
    public class QuanLyChamCongDAL
    {
        private readonly AppDbContext _context;

        public QuanLyChamCongDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<VwDanhSachChamCong>>
            GetAllAsync()
        {
            return await _context
                .VwDanhSachChamCongs
                .OrderByDescending(
                    x => x.ngay_lam
                )
                .ThenBy(
                    x => x.nhan_vien_id
                )
                .ToListAsync();
        }

        public async Task<VwDanhSachChamCong?>
            GetByIdAsync(
                int id
            )
        {
            return await _context
                .VwDanhSachChamCongs
                .FirstOrDefaultAsync(
                    x => x.id == id
                );
        }

        public async Task<bool>
            InsertAsync(
                ChamCong model
            )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                    @"EXEC sp_them_cham_cong
                        @nhan_vien_id,
                        @ngay_lam,
                        @ca_lam_id,
                        @check_in,
                        @check_out",

                    new SqlParameter(
                        "@nhan_vien_id",
                        model.nhan_vien_id
                    ),

                    new SqlParameter(
                        "@ngay_lam",
                        model.ngay_lam
                    ),

                    new SqlParameter(
                        "@ca_lam_id",
                        model.ca_lam_id
                    ),

                    new SqlParameter(
                        "@check_in",
                        (object?)model.check_in
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@check_out",
                        (object?)model.check_out
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
                ChamCong model
            )
        {
            using var trans =
            await _context.Database
            .BeginTransactionAsync();

            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                    @"EXEC sp_cap_nhat_cham_cong
                        @id,
                        @nhan_vien_id,
                        @ngay_lam,
                        @ca_lam_id,
                        @check_in,
                        @check_out",

                    new SqlParameter(
                        "@id",
                        id
                    ),

                    new SqlParameter(
                        "@nhan_vien_id",
                        model.nhan_vien_id
                    ),

                    new SqlParameter(
                        "@ngay_lam",
                        model.ngay_lam
                    ),

                    new SqlParameter(
                        "@ca_lam_id",
                        model.ca_lam_id
                    ),

                    new SqlParameter(
                        "@check_in",
                        (object?)model.check_in
                        ?? DBNull.Value
                    ),

                    new SqlParameter(
                        "@check_out",
                        (object?)model.check_out
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
                    @"EXEC sp_xoa_cham_cong
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


        /*
============================================
LỌC DANH SÁCH CHẤM CÔNG
============================================
*/

        public async Task<List<VwDanhSachChamCong>>
        GetDanhSachChamCongAsync(
            DateTime tuNgay,
            DateTime denNgay,
            string nhanVienId = null
        )
        {
            var query =
                _context
                .VwDanhSachChamCongs
                .AsQueryable();

            query =
                query.Where(x =>
                    x.ngay_lam >= tuNgay &&
                    x.ngay_lam <= denNgay);

            if (!string.IsNullOrEmpty(nhanVienId))
            {
                query =
                    query.Where(x =>
                        x.nhan_vien_id == nhanVienId);
            }

            return await query
                .OrderByDescending(x => x.ngay_lam)
                .ToListAsync();
        }

        /*
        ============================================
        THỐNG KÊ CHẤM CÔNG
        ============================================
        */

        public async Task<
            List<VwThongKeChamCongNhanVien>
        >
        ThongKeChamCongAsync(
            string? nhanVienId,
            DateTime tuNgay,
            DateTime denNgay
        )
        {
            var query =
                _context
                .VwThongKeChamCongNhanVien
                .AsQueryable();

            query =
                query.Where(x =>

                    x.tu_ngay <= denNgay &&
                    x.den_ngay >= tuNgay

                );

            if (!string.IsNullOrEmpty(nhanVienId))
            {
                query =
                    query.Where(x =>
                        x.nhan_vien_id == nhanVienId);
            }

            return await query.ToListAsync();
        }
    }
}