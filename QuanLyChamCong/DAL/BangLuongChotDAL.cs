// BangLuongChotDAL.cs

using System;
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
        public bool DaChotLuong(
            int thang,
            int nam
        )
        {
            string sql = @"
        SELECT COUNT(*)
        FROM bang_luong_chot
        WHERE thang = @thang
        AND nam = @nam";

            DataProvider provider =
                new DataProvider();

            Dictionary<string, object> p =
                new Dictionary<string, object>();

            p.Add("@thang", thang);
            p.Add("@nam", nam);

            object result =
                provider.ExecuteScalar(
                    sql,
                    p
                );

            return
                Convert.ToInt32(result) > 0;
        }
        public DataTable LayBangLuongDaChot(
    int thang,
    int nam
)
        {
            string sql = @"
            SELECT
                blc.nhan_vien_id,

                nv.ho_ten,

                nv.loai_luong,

                blc.luong_co_ban,

                blc.luong_theo_gio,

                blc.phu_cap AS phu_cap_mac_dinh,

                blc.luong_tang_ca_theo_gio,

                blc.tong_ca_duoc_phan,

                blc.tong_ca_di_lam,

                blc.tong_ca_nghi,

                blc.tong_phut_di_tre,

                blc.tong_phut_ve_som,

                blc.tong_phut_bi_tru,

                blc.tong_phut_tang_ca,

                blc.tong_luong_chinh,

                blc.tong_luong_tang_ca,

                CAST(0 AS FLOAT) AS tong_gio_lam,

                blc.thuong,

                blc.tong_luong,

                blc.phat

            FROM bang_luong_chot blc

            LEFT JOIN nhan_vien nv
            ON blc.nhan_vien_id = nv.id

            WHERE blc.thang = @thang
            AND blc.nam = @nam

            ORDER BY blc.nhan_vien_id";

            DataProvider provider =
                new DataProvider();

            Dictionary<string, object> p =
                new Dictionary<string, object>();

            p.Add("@thang", thang);
            p.Add("@nam", nam);

            return provider.ExecuteQuery(
                sql,
                p
            );
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
            string sql = @"
        INSERT INTO bang_luong_chot
        (
            nhan_vien_id,
            thang,
            nam,
            tong_ca_duoc_phan,
            tong_ca_di_lam,
            tong_ca_nghi,
            tong_phut_di_tre,
            tong_phut_ve_som,
            tong_phut_bi_tru,
            tong_phut_tang_ca,
            luong_co_ban,
            luong_theo_gio,
            luong_tang_ca_theo_gio,
            tong_luong_chinh,
            tong_luong_tang_ca,
            phu_cap,
            thuong,
            phat,
            tong_luong,
            ghi_chu,
            nguoi_chot,
            ngay_chot,
            created_at
        )
        VALUES
        (
            @nhanVienId,
            @thang,
            @nam,
            @tongCaDuocPhan,
            @tongCaDiLam,
            @tongCaNghi,
            @tongPhutDiTre,
            @tongPhutVeSom,
            @tongPhutBiTru,
            @tongPhutTangCa,
            @luongCoBan,
            @luongTheoGio,
            @luongTangCaTheoGio,
            @tongLuongChinh,
            @tongLuongTangCa,
            @phuCap,
            @thuong,
            @phat,
            @tongLuong,
            @ghiChu,
            @nguoiChot,
            GETDATE(),
            GETDATE()
        )";

            Dictionary<string, object> p =
                new Dictionary<string, object>();

            p.Add("@nhanVienId", nhanVienId);
            p.Add("@thang", thang);
            p.Add("@nam", nam);
            p.Add("@tongCaDuocPhan", tongCaDuocPhan);
            p.Add("@tongCaDiLam", tongCaDiLam);
            p.Add("@tongCaNghi", tongCaNghi);
            p.Add("@tongPhutDiTre", tongPhutDiTre);
            p.Add("@tongPhutVeSom", tongPhutVeSom);
            p.Add("@tongPhutBiTru", tongPhutBiTru);
            p.Add("@tongPhutTangCa", tongPhutTangCa);
            p.Add("@luongCoBan", luongCoBan);
            p.Add("@luongTheoGio", luongTheoGio);
            p.Add("@luongTangCaTheoGio", luongTangCaTheoGio);
            p.Add("@tongLuongChinh", tongLuongChinh);
            p.Add("@tongLuongTangCa", tongLuongTangCa);
            p.Add("@phuCap", phuCap);
            p.Add("@thuong", thuong);
            p.Add("@phat", phat);
            p.Add("@tongLuong", tongLuong);
            p.Add("@ghiChu", ghiChu);
            p.Add("@nguoiChot", nguoiChot);

            DataProvider provider =
                new DataProvider();

            return provider.ExecuteNonQuery(
                sql,
                p
            );
        }
    }
}