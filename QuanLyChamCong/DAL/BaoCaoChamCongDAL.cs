using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.DAL
{
    public class BaoCaoChamCongDAL
    {
        DataProvider provider =
            new DataProvider();

        public DataTable BaoCaoTongHop(
            string nhanVienId,
            DateTime tuNgay,
            DateTime denNgay
        )
        {
            string sql = @"
SELECT
    nv.id AS [Mã NV],

    nv.ho_ten AS [Họ tên],

    COUNT(DISTINCT pc.id)
        AS [Tổng số ca được phân],

    CONVERT(
        BIGINT,
        SUM(
            CASE
                WHEN cc.check_in IS NOT NULL
                 AND cc.check_out IS NOT NULL
                THEN 1
                ELSE 0
            END
        )
    ) AS [Tổng ca đi làm],

    CONVERT(
        BIGINT,
        SUM(
            CASE
                WHEN cc.check_in IS NULL
                  OR cc.check_out IS NULL
                THEN 1
                ELSE 0
            END
        )
    ) AS [Tổng ca nghỉ],

    CONVERT(
        BIGINT,
        ISNULL(
            SUM(
                CASE
                    WHEN CAST(cc.check_in AS TIME)
                        > cl.gio_bat_dau
                    THEN DATEDIFF(
                        MINUTE,
                        DATEADD(
                            DAY,
                            DATEDIFF(
                                DAY,
                                0,
                                cc.ngay_lam
                            ),
                            CAST(
                                cl.gio_bat_dau
                                AS DATETIME
                            )
                        ),
                        cc.check_in
                    )
                    ELSE 0
                END
            ),
            0
        )
    ) AS [Tổng phút đi trễ],

    CONVERT(
        BIGINT,
        ISNULL(
            SUM(
                CASE
                    WHEN CAST(cc.check_out AS TIME)
                        < cl.gio_ket_thuc
                    THEN DATEDIFF(
                        MINUTE,
                        cc.check_out,
                        DATEADD(
                            DAY,
                            DATEDIFF(
                                DAY,
                                0,
                                cc.ngay_lam
                            ),
                            CAST(
                                cl.gio_ket_thuc
                                AS DATETIME
                            )
                        )
                    )
                    ELSE 0
                END
            ),
            0
        )
    ) AS [Tổng phút về sớm],

    CONVERT(
        DECIMAL(10,2),

        (
            ISNULL(
                SUM(
                    CASE
                        WHEN CAST(cc.check_out AS TIME)
                            > cl.gio_ket_thuc
                        THEN DATEDIFF(
                            MINUTE,
                            DATEADD(
                                DAY,
                                DATEDIFF(
                                    DAY,
                                    0,
                                    cc.ngay_lam
                                ),
                                CAST(
                                    cl.gio_ket_thuc
                                    AS DATETIME
                                )
                            ),
                            cc.check_out
                        )
                        ELSE 0
                    END
                ),
                0
            ) / 60.0
        )
    ) AS [Tổng giờ tăng ca],

    CONVERT(
        DECIMAL(10,2),

        (
            SUM(
                CASE
                    WHEN cc.check_in IS NOT NULL
                     AND cc.check_out IS NOT NULL
                    THEN 1
                    ELSE 0
                END
            ) * 100.0
        )
        /
        NULLIF(
            COUNT(DISTINCT pc.id),
            0
        )
    ) AS [Tỷ lệ chuyên cần (%)]

FROM nhan_vien nv

LEFT JOIN phan_ca pc
    ON nv.id = pc.nhan_vien_id
    AND pc.ngay_lam
        BETWEEN @tuNgay AND @denNgay

LEFT JOIN ca_lam cl
    ON pc.ca_lam_id = cl.id

LEFT JOIN cham_cong cc
    ON pc.nhan_vien_id = cc.nhan_vien_id
    AND pc.ca_lam_id = cc.ca_lam_id
    AND pc.ngay_lam = cc.ngay_lam

WHERE 1 = 1
";

            Dictionary<string, object> p =
                new Dictionary<string, object>();

            p.Add("@tuNgay", tuNgay.Date);

            p.Add("@denNgay", denNgay.Date);

            if (
                !string.IsNullOrEmpty(nhanVienId)
                && nhanVienId != "TATCA"
            )
            {
                sql += " AND nv.id = @nhanVienId ";

                p.Add("@nhanVienId", nhanVienId);
            }

            sql += @"

GROUP BY
    nv.id,
    nv.ho_ten

ORDER BY
    nv.ho_ten
";

            return provider.ExecuteQuery(sql, p);
        }
    }
}