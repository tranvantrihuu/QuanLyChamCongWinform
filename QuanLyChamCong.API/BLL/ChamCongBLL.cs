using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;
using QuanLyChamCong.API.Models.ViewModels;

namespace QuanLyChamCong.API.BLL
{
    public class ChamCongBLL
    {
        private readonly QuanLyChamCongDAL _QLCCdal;
        private readonly ChamCongDAL _dal;
        private readonly NhanVienDAL _nvDal;
        public ChamCongBLL(
            ChamCongDAL dal,
            NhanVienDAL nvDal,
            QuanLyChamCongDAL QLCCdal
        )
        {
            _dal = dal;
            _QLCCdal = QLCCdal;
            _nvDal = nvDal;
        }

        public async Task<List<VwBaoCaoChamCong>>
            GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }

        public async Task<string> CheckInAsync(
    string nhanVienId
)
        {
            if (
                await _nvDal.NhanVienDaNghi(
                    nhanVienId
                )
            )
            {
                return "Nhân viên đã nghỉ việc";
            }

            return await _dal.CheckInAsync(
                nhanVienId
            );
        }

        public async Task<string> CheckOutAsync(
    string nhanVienId
)
        {
            if (
                await _nvDal.NhanVienDaNghi(
                    nhanVienId
                )
            )
            {
                return "Nhân viên đã nghỉ việc";
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
        public async Task<
        List<VwThongKeChamCongNhanVien>
        >
        ThongKeChamCongAsync(
            string? nhanVienId,
            DateTime tuNgay,
            DateTime denNgay
        )
        {
            return await _QLCCdal
                .ThongKeChamCongAsync(
                    nhanVienId,
                    tuNgay,
                    denNgay
                );
        }
    }
}