using Microsoft.AspNetCore.Mvc;
using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.BLL
{
    public class QuanLyChamCongBLL
    {
        private readonly
            QuanLyChamCongDAL _dal;

        public QuanLyChamCongBLL(
            QuanLyChamCongDAL dal
        )
        {
            _dal = dal;
        }

        public async Task<List<VwDanhSachChamCong>>
            GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }

        public async Task<VwDanhSachChamCong?>
            GetByIdAsync(
                int id
            )
        {
            return await _dal.GetByIdAsync(id);
        }

        public async Task<bool>
            InsertAsync(
                ChamCong model
            )
        {
            return await _dal.InsertAsync(
                model
            );
        }

        public async Task<bool>
            UpdateAsync(
                int id,
                ChamCong model
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

        public async Task<List<VwDanhSachChamCong>>
        GetDanhSachChamCongAsync(
            DateTime tuNgay,
            DateTime denNgay,
            string nhanVienId = null
        )
        {
            return await _dal
                .GetDanhSachChamCongAsync(
                    tuNgay,
                    denNgay,
                    nhanVienId
                );
        }

        public async Task<
            List<VwThongKeChamCongNhanVien>
        >
        ThongKeChamCongAsync(
            string? nhanVienId,
            DateTime tuNgay,
            DateTime denNgay
        )
        {
            return await _dal
                .ThongKeChamCongAsync(
                    nhanVienId,
                    tuNgay,
                    denNgay
                );
        }
    }
}