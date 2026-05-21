using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.BLL
{
    public class BangLuongChotBLL
    {
        private readonly
            BangLuongChotDAL _dal;

        public BangLuongChotBLL(
            BangLuongChotDAL dal
        )
        {
            _dal = dal;
        }

        public async Task<List<VwBangLuongChot>>
            GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }

        public async Task<VwChiTietBangLuong?>
            GetChiTietAsync(
                int id
            )
        {
            return await _dal.GetChiTietAsync(id);
        }

        public async Task<bool>
            TinhBangLuongAsync(
                int thang,
                int nam
            )
        {
            return await _dal
                .TinhBangLuongAsync(
                    thang,
                    nam
                );
        }

        public async Task<bool>
            ChotBangLuongAsync(
                int id
            )
        {
            return await _dal
                .ChotBangLuongAsync(id);
        }

        public async Task<bool>
            DeleteAsync(
                int id
            )
        {
            return await _dal.DeleteAsync(id);
        }

        public async Task<List<VwBangLuongChot>>
            LocTheoThangNamAsync(
                int thang,
                int nam
            )
        {
            return await _dal
                .LocTheoThangNamAsync(
                    thang,
                    nam
                );
        }
    }
}