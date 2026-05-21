using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.BLL
{
    public class CauHinhLuongBLL
    {
        private readonly CauHinhLuongDAL _dal;

        public CauHinhLuongBLL(
            CauHinhLuongDAL dal
        )
        {
            _dal = dal;
        }

        public async Task<List<VwDanhSachCauHinhLuong>>
            GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }

        public async Task<bool> InsertAsync(
            CauHinhLuong model
        )
        {
            return await _dal.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(
            int id,
            CauHinhLuong model
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