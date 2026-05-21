using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.BLL
{
    public class ThuongPhatBLL
    {
        private readonly
            ThuongPhatDAL _dal;

        public ThuongPhatBLL(
            ThuongPhatDAL dal
        )
        {
            _dal = dal;
        }

        public async Task<List<VwDanhSachThuongPhat>>
            GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }

        public async Task<VwDanhSachThuongPhat?>
            GetByIdAsync(
                int id
            )
        {
            return await _dal.GetByIdAsync(id);
        }

        public async Task<bool>
            InsertAsync(
                ThuongPhat model
            )
        {
            return await _dal.InsertAsync(
                model
            );
        }

        public async Task<bool>
            UpdateAsync(
                int id,
                ThuongPhat model
            )
        {
            return await _dal.UpdateAsync(
                id,
                model
            );
        }

        public async Task<bool>
            DeleteAsync(
                int id
            )
        {
            return await _dal.DeleteAsync(id);
        }
    }
}