// ThuongPhatBLL.cs

using DAL;
using System;
using System.Data;

namespace BLL
{
    public class ThuongPhatBLL
    {
        ThuongPhatDAL dal =
            new ThuongPhatDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public DataTable GetById(int id)
        {
            return dal.GetById(id);
        }

        public int Insert(
            string nhanVienId,
            string loai,
            decimal soTien,
            string lyDo,
            DateTime ngay
        )
        {
            return dal.Insert(
                nhanVienId,
                loai,
                soTien,
                lyDo,
                ngay
            );
        }

        public int Update(
            int id,
            string nhanVienId,
            string loai,
            decimal soTien,
            string lyDo,
            DateTime ngay
        )
        {
            return dal.Update(
                id,
                nhanVienId,
                loai,
                soTien,
                lyDo,
                ngay
            );
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}