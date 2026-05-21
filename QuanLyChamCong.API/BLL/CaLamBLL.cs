using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.BLL
{
    public class CaLamBLL
    {
        private readonly CaLamDAL _dal;

        public CaLamBLL(
            CaLamDAL dal
        )
        {
            _dal = dal;
        }

        // =========================
        // LẤY DANH SÁCH
        // =========================
        public List<CaLam> GetAll()
        {
            return _dal
                .GetAll()
                .OrderBy(x => x.id)
                .ToList();
        }

        // =========================
        // THÊM
        // =========================
        public bool Insert(CaLam ca)
        {
            try
            {
                if (ca == null)
                {
                    return false;
                }

                if (
                    string.IsNullOrWhiteSpace(
                        ca.ten_ca
                    )
                )
                {
                    return false;
                }

                return _dal.Insert(ca);
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // CẬP NHẬT
        // =========================
        public bool Update(CaLam ca)
        {
            try
            {
                if (ca == null)
                {
                    return false;
                }

                if (ca.id <= 0)
                {
                    return false;
                }

                if (
                    string.IsNullOrWhiteSpace(
                        ca.ten_ca
                    )
                )
                {
                    return false;
                }

                return _dal.Update(ca);
            }
            catch
            {
                return false;
            }
        }

        // =========================
        // XÓA
        // =========================
        public bool Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return false;
                }

                return _dal.Delete(id);
            }
            catch
            {
                return false;
            }
        }
    }
}