// BangLuongChotDAL.cs

using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.DAL
{
    public class BangLuongChotDAL
    {
        DataProvider provider =
            new DataProvider();

        public DataTable LayDuLieuTinhLuong(
            int thang,
            int nam
        )
        {
            string sql = @"
SELECT
    nv.id AS nhan_vien_id,
    nv.ho_ten,
    nv.loai_luong,

    ISNULL(ch.luong_co_ban, 0)
        AS luong_co_ban,

    ISNULL(ch.luong_theo_gio, 0)
        AS luong_theo_gio,

    ISNULL(ch.phu_cap_mac_dinh, 0)
        AS phu_cap_mac_dinh,

    ISNULL(ch.luong_tang_ca, 0)
        AS luong_tang_ca_theo_gio,

    COUNT(DISTINCT pc.id)
        AS tong_ca_duoc_phan,

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
    ) AS tong_ca_di_lam,

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
    ) AS tong_ca_nghi,

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
    ) AS tong_phut_di_tre,

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
    ) AS tong_phut_ve_som,

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
        +
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
    ) AS tong_phut_bi_tru,

    CONVERT(
        BIGINT,
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
        )
    ) AS tong_phut_tang_ca,
    CONVERT(
    DECIMAL(10,2),

    (
        ISNULL(
            SUM(
                CASE
                    WHEN cc.check_in IS NOT NULL
                     AND cc.check_out IS NOT NULL
                    THEN DATEDIFF(
                        MINUTE,
                        cc.check_in,
                        cc.check_out
                    )
                    ELSE 0
                END
            ),
            0
        ) / 60.0
    )
    ) AS tong_gio_lam,
    ISNULL(
        tp.tong_thuong,
        0
        ) AS thuong,

    ISNULL(
        tp.tong_phat,
        0
    ) AS phat

FROM nhan_vien nv

LEFT JOIN cau_hinh_luong ch
    ON nv.id = ch.nhan_vien_id

LEFT JOIN phan_ca pc
    ON nv.id = pc.nhan_vien_id
    AND MONTH(pc.ngay_lam) = @thang
    AND YEAR(pc.ngay_lam) = @nam

LEFT JOIN ca_lam cl
    ON pc.ca_lam_id = cl.id

LEFT JOIN cham_cong cc
    ON pc.nhan_vien_id = cc.nhan_vien_id
    AND pc.ca_lam_id = cc.ca_lam_id
    AND pc.ngay_lam = cc.ngay_lam

LEFT JOIN
(
    SELECT
        nhan_vien_id,

        SUM(
            CASE
                WHEN loai = 'Thuong'
                THEN so_tien
                ELSE 0
            END
        ) AS tong_thuong,

        SUM(
            CASE
                WHEN loai = 'Phat'
                THEN so_tien
                ELSE 0
            END
        ) AS tong_phat

    FROM thuong_phat

    WHERE
        MONTH(ngay) = @thang
        AND YEAR(ngay) = @nam

    GROUP BY nhan_vien_id
) tp
ON nv.id = tp.nhan_vien_id

GROUP BY
    nv.id,
    nv.ho_ten,
    nv.loai_luong,
    ch.luong_co_ban,
    ch.luong_theo_gio,
    ch.phu_cap_mac_dinh,
    ch.luong_tang_ca,
    tp.tong_thuong,
    tp.tong_phat

ORDER BY nv.ho_ten";

            Dictionary<string, object> p =
                new Dictionary<string, object>();

            p.Add("@thang", thang);
            p.Add("@nam", nam);

            return provider.ExecuteQuery(sql, p);
        }
        public int Insert(
    string nhanVienId,
    int thang,
    int nam,
    int tongCaDuocPhan,
    int tongCaDiLam,
    int tongCaNghi,
    int tongPhutDiTre,
    int tongPhutVeSom,
    int tongPhutBiTru,
    int tongPhutTangCa,
    decimal luongCoBan,
    decimal luongTheoGio,
    decimal luongTangCaTheoGio,
    decimal tongLuongChinh,
    decimal tongLuongTangCa,
    decimal phuCap,
    decimal thuong,
    decimal phat,
    decimal tongLuong,
    string ghiChu,
    string nguoiChot
)
        {
            return 1;
        }
    }

}