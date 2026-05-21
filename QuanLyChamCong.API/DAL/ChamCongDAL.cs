using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.DAL
{
    public class ChamCongDAL
    {
        private readonly AppDbContext _context;

        public ChamCongDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<VwBaoCaoChamCong>>
            GetAllAsync()
        {
            return await _context
                .VwBaoCaoChamCongs
                .OrderByDescending(x => x.ngay_lam)
                .ToListAsync();
        }

        public async Task<bool> CheckInAsync(
    string nhanVienId
)
        {
            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                        @"EXEC sp_check_in
                    @nhan_vien_id",

                        new SqlParameter(
                            "@nhan_vien_id",
                            nhanVienId
                        )
                    );

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CheckOutAsync(
            string nhanVienId
        )
        {
            try
            {
                await _context.Database
                    .ExecuteSqlRawAsync(
                        @"EXEC sp_check_out
                    @nhan_vien_id",

                        new SqlParameter(
                            "@nhan_vien_id",
                            nhanVienId
                        )
                    );

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ChamCong?>
            GetByIdAsync(
                int id
            )
        {
            return await _context
                .ChamCongs
                .FirstOrDefaultAsync(
                    x => x.id == id
                );
        }

        public async Task<bool> InsertAsync(
            ChamCong model
        )
        {
            _context.ChamCongs.Add(model);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(
            int id,
            ChamCong model
        )
        {
            var data =
                await _context.ChamCongs
                .FirstOrDefaultAsync(
                    x => x.id == id
                );

            if (data == null)
            {
                return false;
            }

            data.nhan_vien_id =
                model.nhan_vien_id;

            data.ngay_lam =
                model.ngay_lam;

            data.ca_lam_id =
                model.ca_lam_id;

            data.check_in =
                model.check_in;

            data.check_out =
                model.check_out;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(
            int id
        )
        {
            var data =
                await _context.ChamCongs
                .FirstOrDefaultAsync(
                    x => x.id == id
                );

            if (data == null)
            {
                return false;
            }

            _context.ChamCongs.Remove(data);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}