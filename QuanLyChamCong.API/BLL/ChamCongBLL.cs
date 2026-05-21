using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.BLL
{
    public class ChamCongBLL
    {
        private readonly ChamCongDAL _dal;
        private readonly NhanVienDAL _nvDal;
        public ChamCongBLL(
            ChamCongDAL dal,
            NhanVienDAL nvDal
        )
        {
            _dal = dal;

            _nvDal = nvDal;
        }

        public async Task<List<VwBaoCaoChamCong>>
            GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }

        public async Task<bool> CheckInAsync(
            string nhanVienId
        )
        {
            if (
                await _nvDal.NhanVienDaNghi(
                    nhanVienId
                )
            )
            {
                return false;
            }

            return await _dal.CheckInAsync(
                nhanVienId
            );
        }

        public async Task<bool> CheckOutAsync(
            string nhanVienId
        )
        {
            if (
                await _nvDal.NhanVienDaNghi(
                    nhanVienId
                )
            )
            {
                return false;
            }

            return await _dal.CheckOutAsync(
                nhanVienId
            );
        }

        public async Task<ChamCong?>
            GetByIdAsync(
                int id
            )
        {
            return await _dal.GetByIdAsync(id);
        }

        public async Task<bool> InsertAsync(
            ChamCong model
        )
        {
            return await _dal.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(
            int id,
            ChamCong model
        )
        {
            return await _dal.UpdateAsync(
                id,
                model
            );
        }

        public async Task<bool> DeleteAsync(
            int id
        )
        {
            return await _dal.DeleteAsync(id);
        }
    }
}