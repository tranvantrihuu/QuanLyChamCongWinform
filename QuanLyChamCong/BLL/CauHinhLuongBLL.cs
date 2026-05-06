using QuanLyChamCong.DAL;
using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.BLL
{
    public class CauHinhLuongBLL
    {
        CauHinhLuongDAL dal = new CauHinhLuongDAL();

        // lấy danh sách cấu hình lương
        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        // thêm
        public bool Insert(Dictionary<string, object> p)
        {
            return dal.Insert(p) > 0;
        }

        // sửa
        public bool Update(Dictionary<string, object> p)
        {
            return dal.Update(p) > 0;
        }

        // xóa
        public bool Delete(List<int> ids)
        {
            return dal.Delete(ids) > 0;
        }

        // 🔥 QUAN TRỌNG: load combobox nhân viên
        public DataTable GetNhanVien()
        {
            return dal.GetNhanVien();
        }
        public void SyncNhanVien()
        {
            dal.SyncNhanVien();
        }
        public bool InsertSafe(Dictionary<string, object> p)
        {
            var nhanVienId = p["@nhan_vien_id"];

            // check trùng
            if (dal.ExistsByNhanVien(nhanVienId))
            {
                return false;
            }

            return dal.Insert(p) > 0;
        }
        public DataRow GetByNhanVien(object nhanVienId)
        {
            return dal.GetByNhanVien(nhanVienId);
        }

    }
}