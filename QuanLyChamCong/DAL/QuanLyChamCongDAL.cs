// QuanLyChamCongDAL.cs

using QuanLyChamCong.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class QuanLyChamCongDAL
    {
        DataProvider dp =
            new DataProvider();

        public DataTable GetAll()
        {
            string sql = @"
                SELECT
                    cc.id,
                    cc.nhan_vien_id,
                    nv.ho_ten,

                    cc.ngay_lam,
                    cc.ca_lam_id,

                    cl.ten_ca,
                    cl.gio_bat_dau,
                    cl.gio_ket_thuc,

                    cl.phut_cho_phep_di_tre,
                    cl.phut_cho_phep_ve_som,
                    cl.phut_cho_phep_checkin_som,
                    cl.phut_cho_phep_checkout_tre,

                    cc.check_in,
                    cc.check_out

                FROM cham_cong cc

                INNER JOIN nhan_vien nv
                    ON cc.nhan_vien_id = nv.id

                INNER JOIN ca_lam cl
                    ON cc.ca_lam_id = cl.id

                ORDER BY
                    cc.ngay_lam DESC,
                    cc.id DESC";

            return dp.ExecuteQuery(sql);
        }

        public DataTable GetByNgay(
            string nhanVienId,
            DateTime tuNgay,
            DateTime denNgay
        )
        {
            string sql = @"
                SELECT
                    cc.id,
                    cc.nhan_vien_id,
                    nv.ho_ten,

                    cc.ngay_lam,
                    cc.ca_lam_id,

                    cl.ten_ca,
                    cl.gio_bat_dau,
                    cl.gio_ket_thuc,

                    cl.phut_cho_phep_di_tre,
                    cl.phut_cho_phep_ve_som,
                    cl.phut_cho_phep_checkin_som,
                    cl.phut_cho_phep_checkout_tre,

                    cc.check_in,
                    cc.check_out

                FROM cham_cong cc

                INNER JOIN nhan_vien nv
                    ON cc.nhan_vien_id = nv.id

                INNER JOIN ca_lam cl
                    ON cc.ca_lam_id = cl.id

                WHERE
                    cc.ngay_lam >= @tu_ngay
                    AND
                    cc.ngay_lam <= @den_ngay

                    AND
                    (
                        @nhan_vien_id = ''
                        OR cc.nhan_vien_id = @nhan_vien_id
                    )

                ORDER BY
                    cc.ngay_lam DESC,
                    cc.id DESC";

            var para =
                new Dictionary<string, object>();

            para.Add(
                "@tu_ngay",
                tuNgay.Date
            );

            para.Add(
                "@den_ngay",
                denNgay.Date
            );

            para.Add(
                "@nhan_vien_id",
                nhanVienId
            );

            return dp.ExecuteQuery(
                sql,
                para
            );
        }

        public DataTable GetByNhanVienVaThang(
            string nhanVienId,
            int thang,
            int nam
        )
        {
            string sql = @"
                SELECT
                    cc.id,
                    cc.nhan_vien_id,
                    nv.ho_ten,

                    cc.ngay_lam,
                    cc.ca_lam_id,

                    cl.ten_ca,
                    cl.gio_bat_dau,
                    cl.gio_ket_thuc,

                    cl.phut_cho_phep_di_tre,
                    cl.phut_cho_phep_ve_som,
                    cl.phut_cho_phep_checkin_som,
                    cl.phut_cho_phep_checkout_tre,

                    cc.check_in,
                    cc.check_out

                FROM cham_cong cc

                INNER JOIN nhan_vien nv
                    ON cc.nhan_vien_id = nv.id

                INNER JOIN ca_lam cl
                    ON cc.ca_lam_id = cl.id

                WHERE
                    MONTH(cc.ngay_lam) = @thang
                    AND
                    YEAR(cc.ngay_lam) = @nam

                    AND
                    (
                        @nhan_vien_id = ''
                        OR cc.nhan_vien_id = @nhan_vien_id
                    )

                ORDER BY
                    cc.ngay_lam DESC,
                    cc.id DESC";

            var para =
                new Dictionary<string, object>();

            para.Add(
                "@thang",
                thang
            );

            para.Add(
                "@nam",
                nam
            );

            para.Add(
                "@nhan_vien_id",
                nhanVienId
            );

            return dp.ExecuteQuery(
                sql,
                para
            );
        }

        public DataTable GetById(int id)
        {
            string sql = @"
                SELECT
                    *
                FROM cham_cong
                WHERE id = @id";

            var para =
                new Dictionary<string, object>();

            para.Add(
                "@id",
                id
            );

            return dp.ExecuteQuery(
                sql,
                para
            );
        }

        public int Insert(
            string nhanVienId,
            DateTime ngayLam,
            int caLamId,
            DateTime checkIn,
            DateTime checkOut
        )
        {
            string sql = @"
                INSERT INTO cham_cong
                (
                    nhan_vien_id,
                    ngay_lam,
                    ca_lam_id,
                    check_in,
                    check_out
                )
                VALUES
                (
                    @nhan_vien_id,
                    @ngay_lam,
                    @ca_lam_id,
                    @check_in,
                    @check_out
                )";

            var para =
                new Dictionary<string, object>();

            para.Add(
                "@nhan_vien_id",
                nhanVienId
            );

            para.Add(
                "@ngay_lam",
                ngayLam.Date
            );

            para.Add(
                "@ca_lam_id",
                caLamId
            );

            para.Add(
                "@check_in",
                checkIn
            );

            para.Add(
                "@check_out",
                checkOut
            );

            return dp.ExecuteNonQuery(
                sql,
                para
            );
        }

        public int Update(
            int id,
            string nhanVienId,
            DateTime ngayLam,
            int caLamId,
            DateTime checkIn,
            DateTime checkOut
        )
        {
            string sql = @"
                UPDATE cham_cong
                SET
                    nhan_vien_id = @nhan_vien_id,
                    ngay_lam = @ngay_lam,
                    ca_lam_id = @ca_lam_id,
                    check_in = @check_in,
                    check_out = @check_out
                WHERE id = @id";

            var para =
                new Dictionary<string, object>();

            para.Add(
                "@id",
                id
            );

            para.Add(
                "@nhan_vien_id",
                nhanVienId
            );

            para.Add(
                "@ngay_lam",
                ngayLam.Date
            );

            para.Add(
                "@ca_lam_id",
                caLamId
            );

            para.Add(
                "@check_in",
                checkIn
            );

            para.Add(
                "@check_out",
                checkOut
            );

            return dp.ExecuteNonQuery(
                sql,
                para
            );
        }

        public int Delete(int id)
        {
            string sql = @"
                DELETE FROM cham_cong
                WHERE id = @id";

            var para =
                new Dictionary<string, object>();

            para.Add(
                "@id",
                id
            );

            return dp.ExecuteNonQuery(
                sql,
                para
            );
        }
    }
}