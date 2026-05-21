using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.BLL
{
    public class PhanCaBLL
    {
        private readonly PhanCaDAL _dal;

        public PhanCaBLL(
            PhanCaDAL dal
        )
        {
            _dal = dal;
        }

        // =====================================
        // LẤY DANH SÁCH PHÂN CA
        // =====================================

        public List<PhanCa> GetAll()
        {
            return _dal
                .GetAll()
                .OrderBy(x => x.ngay_lam)
                .ThenBy(x => x.ca_lam_id)
                .ToList();
        }

        // =====================================
        // KIỂM TRA TRÙNG CA
        // =====================================

        public bool Exists(
            string nvId,
            int caId,
            DateTime ngay
        )
        {
            return _dal.Exists(
                nvId,
                caId,
                ngay
            );
        }

        // =====================================
        // THÊM PHÂN CA
        // =====================================

        public bool Insert(
            PhanCa pc
        )
        {
            try
            {
                if (
                    string.IsNullOrWhiteSpace(
                        pc.nhan_vien_id
                    )
                )
                {
                    return false;
                }

                if (
                    pc.ca_lam_id <= 0
                )
                {
                    return false;
                }

                bool exists =
                    _dal.Exists(
                        pc.nhan_vien_id,
                        pc.ca_lam_id,
                        pc.ngay_lam.Date
                    );

                if (exists)
                {
                    return false;
                }

                return _dal.Insert(pc);
            }
            catch
            {
                return false;
            }
        }

        // =====================================
        // CẬP NHẬT PHÂN CA
        // =====================================

        public bool Update(
            PhanCa pc
        )
        {
            try
            {
                if (pc.id <= 0)
                {
                    return false;
                }

                if (
                    string.IsNullOrWhiteSpace(
                        pc.nhan_vien_id
                    )
                )
                {
                    return false;
                }

                if (
                    pc.ca_lam_id <= 0
                )
                {
                    return false;
                }

                return _dal.Update(pc);
            }
            catch
            {
                return false;
            }
        }

        // =====================================
        // XÓA PHÂN CA
        // =====================================

        public bool Delete(
            int id
        )
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