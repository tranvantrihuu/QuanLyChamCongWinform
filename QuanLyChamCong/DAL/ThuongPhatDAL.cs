// ThuongPhatDAL.cs

using QuanLyChamCong.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ThuongPhatDAL
    {
        DataProvider dp =
            new DataProvider();

        public DataTable GetAll()
        {
            string sql = @"
            SELECT 
                tp.id,
                tp.nhan_vien_id,
                nv.ho_ten,

                CASE 
                    WHEN tp.loai = 'thuong' THEN N'Thưởng'
                    WHEN tp.loai = 'phat' THEN N'Phạt'
                    ELSE tp.loai
                END AS loai,

                tp.so_tien,
                tp.ly_do,
                tp.ngay
            FROM thuong_phat tp
            INNER JOIN nhan_vien nv
                ON tp.nhan_vien_id = nv.id
            ORDER BY tp.id DESC";

            return dp.ExecuteQuery(sql);
        }

        public DataTable GetById(int id)
        {
            string sql = @"
                SELECT *
                FROM thuong_phat
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
            string loai,
            decimal soTien,
            string lyDo,
            DateTime ngay
        )
        {
            string sql = @"
                INSERT INTO thuong_phat
                (
                    nhan_vien_id,
                    loai,
                    so_tien,
                    ly_do,
                    ngay
                )
                VALUES
                (
                    @nhan_vien_id,
                    @loai,
                    @so_tien,
                    @ly_do,
                    @ngay
                )";

            var para =
                new Dictionary<string, object>();

            para.Add(
                "@nhan_vien_id",
                nhanVienId
            );

            para.Add(
                "@loai",
                loai
            );

            para.Add(
                "@so_tien",
                soTien
            );

            para.Add(
                "@ly_do",
                lyDo
            );

            para.Add(
                "@ngay",
                ngay
            );

            return dp.ExecuteNonQuery(
                sql,
                para
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
            string sql = @"
                UPDATE thuong_phat
                SET
                    nhan_vien_id = @nhan_vien_id,
                    loai = @loai,
                    so_tien = @so_tien,
                    ly_do = @ly_do,
                    ngay = @ngay
                WHERE id = @id";

            var para =
                new Dictionary<string, object>();

            para.Add("@id", id);

            para.Add(
                "@nhan_vien_id",
                nhanVienId
            );

            para.Add(
                "@loai",
                loai
            );

            para.Add(
                "@so_tien",
                soTien
            );

            para.Add(
                "@ly_do",
                lyDo
            );

            para.Add(
                "@ngay",
                ngay
            );

            return dp.ExecuteNonQuery(
                sql,
                para
            );
        }

        public int Delete(int id)
        {
            string sql = @"
                DELETE FROM thuong_phat
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