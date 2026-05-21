using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.BLL
{
    public class NghiPhepNamBLL
    {
        private readonly NghiPhepNamDAL _dal;

        public NghiPhepNamBLL(
            NghiPhepNamDAL dal
        )
        {
            _dal = dal;
        }

        // =========================
        // LẤY DANH SÁCH
        // =========================
        public List<NghiPhepNam> GetAll()
        {
            return _dal.GetAll();
        }

        // =========================
        // LẤY THEO ID
        // =========================
        public NghiPhepNam? GetById(
            int id
        )
        {
            return _dal.GetById(id);
        }

        // =========================
        // THÊM
        // =========================
        public bool Insert(
            NghiPhepNam item
        )
        {
            // validate

            if (
                string.IsNullOrWhiteSpace(
                    item.nhan_vien_id
                )
            )
            {
                return false;
            }

            if (item.nam <= 0)
            {
                return false;
            }

            if (item.so_ca_duoc_nghi < 0)
            {
                return false;
            }

            return _dal.Insert(item);
        }

        // =========================
        // CẬP NHẬT
        // =========================
        public bool Update(
            NghiPhepNam item
        )
        {
            if (
                string.IsNullOrWhiteSpace(
                    item.nhan_vien_id
                )
            )
            {
                return false;
            }

            if (item.nam <= 0)
            {
                return false;
            }

            return _dal.Update(item);
        }

        // =========================
        // XÓA
        // =========================
        public bool Delete(
            int id
        )
        {
            return _dal.Delete(id);
        }
    }
}