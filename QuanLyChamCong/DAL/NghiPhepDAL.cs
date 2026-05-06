// NghiPhepDAL.cs

using QuanLyChamCong.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class NghiPhepDAL
    {
        DataProvider dp =
            new DataProvider();

        public DataTable GetAll()
        {
            string sql = @"
                SELECT 
                    np.id,
                    np.nhan_vien_id,
                    nv.ho_ten,
                    np.ca_lam_id,
                    np.ngay,
                    np.loai,
                    np.ly_do,
                    np.created_at
                FROM nghi_phep np
                INNER JOIN nhan_vien nv
                    ON np.nhan_vien_id = nv.id
                ORDER BY np.id DESC";

            return dp.ExecuteQuery(sql);
        }

        public DataTable GetById(int id)
        {
            string sql = @"
                SELECT *
                FROM nghi_phep
                WHERE id = @id";

            var para =
                new Dictionary<string, object>();

            para.Add("@id", id);

            return dp.ExecuteQuery(
                sql,
                para
            );
        }

        public int Insert(
            string nhanVienId,
            int caLamId,
            DateTime ngay,
            string loai,
            string lyDo
        )
        {
            string sql = @"
                INSERT INTO nghi_phep
                (
                    nhan_vien_id,
                    ca_lam_id,
                    ngay,
                    loai,
                    ly_do,
                    created_at
                )
                VALUES
                (
                    @nhan_vien_id,
                    @ca_lam_id,
                    @ngay,
                    @loai,
                    @ly_do,
                    GETDATE()
                )";

            var para =
                new Dictionary<string, object>();

            para.Add(
                "@nhan_vien_id",
                nhanVienId
            );

            para.Add(
                "@ca_lam_id",
                caLamId
            );

            para.Add(
                "@ngay",
                ngay
            );

            para.Add(
                "@loai",
                loai
            );

            para.Add(
                "@ly_do",
                lyDo
            );

            return dp.ExecuteNonQuery(
                sql,
                para
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
            string sql = @"
                UPDATE nghi_phep
                SET
                    nhan_vien_id = @nhan_vien_id,
                    ca_lam_id = @ca_lam_id,
                    ngay = @ngay,
                    loai = @loai,
                    ly_do = @ly_do
                WHERE id = @id";

            var para =
                new Dictionary<string, object>();

            para.Add("@id", id);

            para.Add(
                "@nhan_vien_id",
                nhanVienId
            );

            para.Add(
                "@ca_lam_id",
                caLamId
            );

            para.Add(
                "@ngay",
                ngay
            );

            para.Add(
                "@loai",
                loai
            );

            para.Add(
                "@ly_do",
                lyDo
            );

            return dp.ExecuteNonQuery(
                sql,
                para
            );
        }

        public int Delete(int id)
        {
            string sql = @"
                DELETE FROM nghi_phep
                WHERE id = @id";

            var para =
                new Dictionary<string, object>();

            para.Add("@id", id);

            return dp.ExecuteNonQuery(
                sql,
                para
            );
        }
    }
}