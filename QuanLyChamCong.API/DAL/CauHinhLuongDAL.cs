using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.DAL
{
    public class CauHinhLuongDAL
    {
        private readonly AppDbContext _context;

        public CauHinhLuongDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<VwDanhSachCauHinhLuong>>
            GetAllAsync()
        {
            return await _context
                .VwDanhSachCauHinhLuongs
                .OrderBy(x => x.ho_ten)
                .ToListAsync();
        }

        public async Task<bool> InsertAsync(
            CauHinhLuong model
        )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                    @"EXEC sp_them_cau_hinh_luong
                        @nhan_vien_id,
                        @luong_co_ban,
                        @luong_theo_gio,
                        @luong_tang_ca,
                        @phu_cap_mac_dinh",

                    new SqlParameter(
                        "@nhan_vien_id",
                        model.nhan_vien_id
                    ),

                    new SqlParameter(
                        "@luong_co_ban",
                        model.luong_co_ban
                    ),

                    new SqlParameter(
                        "@luong_theo_gio",
                        model.luong_theo_gio
                    ),

                    new SqlParameter(
                        "@luong_tang_ca",
                        model.luong_tang_ca
                    ),

                    new SqlParameter(
                        "@phu_cap_mac_dinh",
                        model.phu_cap_mac_dinh
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

        public async Task<bool> UpdateAsync(
            int id,
            CauHinhLuong model
        )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                    @"EXEC sp_cap_nhat_cau_hinh_luong
                        @id,
                        @nhan_vien_id,
                        @luong_co_ban,
                        @luong_theo_gio,
                        @luong_tang_ca,
                        @phu_cap_mac_dinh",

                    new SqlParameter("@id", id),

                    new SqlParameter(
                        "@nhan_vien_id",
                        model.nhan_vien_id
                    ),

                    new SqlParameter(
                        "@luong_co_ban",
                        model.luong_co_ban
                    ),

                    new SqlParameter(
                        "@luong_theo_gio",
                        model.luong_theo_gio
                    ),

                    new SqlParameter(
                        "@luong_tang_ca",
                        model.luong_tang_ca
                    ),

                    new SqlParameter(
                        "@phu_cap_mac_dinh",
                        model.phu_cap_mac_dinh
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

        public async Task<bool> DeleteAsync(
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
                    @"EXEC sp_xoa_cau_hinh_luong @id",
                    new SqlParameter("@id", id)
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