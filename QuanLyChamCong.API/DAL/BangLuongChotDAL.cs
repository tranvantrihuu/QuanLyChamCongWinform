using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.DAL
{
    public class BangLuongChotDAL
    {
        private readonly AppDbContext _context;
        public BangLuongChotDAL(
            AppDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<VwBangLuongChot>>
            GetAllAsync()
        {
            return await _context
                .VwBangLuongChots
                .OrderByDescending(
                    x => x.nam
                )
                .ThenByDescending(
                    x => x.thang
                )
                .ToListAsync();
        }

        public async Task<VwChiTietBangLuong?>
            GetChiTietAsync(
                int id
            )
        {
            return _context
                .VwChiTietBangLuongs
                .FromSqlRaw(
                    @"EXEC sp_lay_chi_tiet_bang_luong
                @id",

                    new SqlParameter(
                        "@id",
                        id
                    )
                )
                .AsEnumerable()
                .FirstOrDefault();
        }

        public async Task<bool>
        TinhBangLuongAsync(
        int thang,
        int nam
        )
        {
            using var trans =
            await _context.Database
            .BeginTransactionAsync();

            try
            {
                List<NhanVien> nhanViens =
                    await _context.NhanViens
                    .ToListAsync();

                foreach (NhanVien nv in nhanViens)
                {
                    await _context.Database
                        .ExecuteSqlInterpolatedAsync(
                            $@"
                EXEC sp_tinh_bang_luong
                    @nhan_vien_id={nv.id},
                    @thang={thang},
                    @nam={nam}
                "
                        );
                }

                await trans.CommitAsync();

                return true;
            }
            catch
            {
                await trans.RollbackAsync();

                throw;
            }

        }


        public async Task<bool>
            ChotBangLuongAsync(
                int id
            )
        {
            using var trans =
                await _context.Database
                .BeginTransactionAsync();

            try
            {
                await _context.Database
                .ExecuteSqlInterpolatedAsync(
                    $@"EXEC sp_chot_bang_luong
                        @id={id}"
                );

                await trans.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();

                throw;
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
                .ExecuteSqlInterpolatedAsync(
                    $@"EXEC sp_chot_bang_luong
                        @id={id}"
                );

                await trans.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();

                throw;
            }
        }

    public async Task<List<VwBangLuongChot>>
    LocTheoThangNamAsync(
        int thang,
        int nam
    )
        {
            /*
             * KIỂM TRA ĐÃ CHỐT CHƯA
             */

            bool daChot =
                await _context.BangLuongChots
                .AnyAsync(x =>
                    x.thang == thang
                    && x.nam == nam);

            /*
             * ĐÃ CHỐT
             * -> LOAD DỮ LIỆU ĐÃ LƯU
             */

            if (daChot)
            {
                return await _context
                    .VwBangLuongChots
                    .Where(x =>
                        x.thang == thang
                        && x.nam == nam)
                    .AsNoTracking()
                    .ToListAsync();
            }

            /*
             * CHƯA CHỐT
             * -> TÍNH REALTIME
             */

            List<VwBangLuongChot> result =
                new List<VwBangLuongChot>();

            List<NhanVien> nhanViens =
                await _context.NhanViens
                .AsNoTracking()
                .ToListAsync();

            foreach (NhanVien nv in nhanViens)
            {
                List<VwBangLuongRealtime> temp =
                    await _context
                    .Set<VwBangLuongRealtime>()
                    .FromSqlRaw(
                        @"EXEC sp_tinh_bang_luong_realtime
                    @nhan_vien_id,
                    @thang,
                    @nam",

                        new SqlParameter(
                            "@nhan_vien_id",
                            nv.id
                        ),

                        new SqlParameter(
                            "@thang",
                            thang
                        ),

                        new SqlParameter(
                            "@nam",
                            nam
                        )
                    )
                    .AsNoTracking()
                    .ToListAsync();

                VwBangLuongRealtime item =
                    temp.FirstOrDefault();

                if (item != null)
                {
                    result.Add(
                        new VwBangLuongChot
                        {
                            id = item.id,
                            nhan_vien_id =
                                item.nhan_vien_id,

                            ho_ten =
                                item.ho_ten,

                            vi_tri =
                                item.vi_tri,

                            loai_luong =
                                item.loai_luong,

                            thang =
                                item.thang,

                            nam =
                                item.nam,

                            tong_ca_duoc_phan =
                                item.tong_ca_duoc_phan,

                            tong_ca_di_lam =
                                item.tong_ca_di_lam,

                            tong_ca_nghi =
                                item.tong_ca_nghi,

                            tong_phut_di_tre =
                                item.tong_phut_di_tre,

                            tong_phut_ve_som =
                                item.tong_phut_ve_som,

                            tong_phut_bi_tru =
                                item.tong_phut_bi_tru,

                            tong_phut_tang_ca =
                                item.tong_phut_tang_ca,

                            tong_gio_lam =
                                item.tong_gio_lam,

                            luong_co_ban =
                                item.luong_co_ban,

                            luong_theo_gio =
                                item.luong_theo_gio,

                            luong_tang_ca_theo_gio =
                                item.luong_tang_ca_theo_gio,

                            tong_luong_chinh =
                                item.tong_luong_chinh,

                            tong_luong_tang_ca =
                                item.tong_luong_tang_ca,

                            phu_cap =
                                item.phu_cap,

                            thuong =
                                item.thuong,

                            phat =
                                item.phat,

                            tong_luong =
                                item.tong_luong
                        }
                    );
                }
            }

            return result;
        }

    }
}