// NghiPhepBLL.cs

using DAL;
using System;
using System.Data;

namespace BLL
{
    public class NghiPhepBLL
    {
        NghiPhepDAL dal =
            new NghiPhepDAL();

        public DataTable GetAll()
        {
            DataTable dt =
                dal.GetAll();

            foreach (DataRow r in dt.Rows)
            {
                string loai =
                    r["loai"].ToString();

                if (loai == "co_phep")
                {
                    r["loai"] =
                        "Có phép";
                }
                else if (
                    loai == "khong_phep"
                )
                {
                    r["loai"] =
                        "Không phép";
                }
            }

            return dt;
        }

        public DataTable GetById(int id)
        {
            return dal.GetById(id);
        }

        public int Insert(
            string nhanVienId,
            int caLamId,
            DateTime ngay,
            string loai,
            string lyDo
        )
        {
            return dal.Insert(
                nhanVienId,
                caLamId,
                ngay,
                loai,
                lyDo
            );
        }

        public int Update(
            int id,
            string nhanVienId,
            int caLamId,
            DateTime ngay,
            string loai,
            string lyDo
        )
        {
            return dal.Update(
                id,
                nhanVienId,
                caLamId,
                ngay,
                loai,
                lyDo
            );
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}