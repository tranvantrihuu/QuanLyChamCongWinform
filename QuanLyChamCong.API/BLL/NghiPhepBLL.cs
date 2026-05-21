using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.BLL
{
    public class NghiPhepBLL
    {
        private readonly
            NghiPhepDAL _dal;

        public NghiPhepBLL(
            NghiPhepDAL dal
        )
        {
            _dal = dal;
        }

        public async Task<List<VwDanhSachNghiPhep>>
            GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }

        public async Task<VwDanhSachNghiPhep?>
            GetByIdAsync(
                int id
            )
        {
            return await _dal.GetByIdAsync(id);
        }

        public async Task<bool>
            InsertAsync(
                NghiPhep model
            )
        {
            return await _dal.InsertAsync(
                model
            );
        }

        public async Task<bool>
            UpdateAsync(
                int id,
                NghiPhep model
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