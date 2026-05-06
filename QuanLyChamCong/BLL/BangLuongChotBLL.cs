// BangLuongChotBLL.cs

using System;
using System.Data;
using QuanLyChamCong.DAL;

namespace QuanLyChamCong.BLL
{
    public class BangLuongChotBLL
    {
        BangLuongChotDAL dal =
            new BangLuongChotDAL();

        public DataTable TinhLuongThang(
            int thang,
            int nam
        )
        {
            DataTable dt =
                dal.LayDuLieuTinhLuong(
                    thang,
                    nam
                );

            if (dt == null)
            {
                return null;
            }

            if (
                !dt.Columns.Contains(
                    "tong_luong_chinh"
                )
            )
            {
                dt.Columns.Add(
                    "tong_luong_chinh",
                    typeof(decimal)
                );
            }

            if (
                !dt.Columns.Contains(
                    "tong_luong_tang_ca"
                )
            )
            {
                dt.Columns.Add(
                    "tong_luong_tang_ca",
                    typeof(decimal)
                );
            }

            if (
                !dt.Columns.Contains(
                    "tong_luong"
                )
            )
            {
                dt.Columns.Add(
                    "tong_luong",
                    typeof(decimal)
                );
            }

            foreach (DataRow r in dt.Rows)
            {
                string loaiLuong =
                    r["loai_luong"]
                        .ToString();

                int tongCaDiLam =
                    Convert.ToInt32(
                        r["tong_ca_di_lam"]
                    );

                int tongPhutTangCa =
                    Convert.ToInt32(
                        r["tong_phut_tang_ca"]
                    );

                decimal luongCoBan =
                    Convert.ToDecimal(
                        r["luong_co_ban"]
                    );

                decimal luongTheoGio =
                    Convert.ToDecimal(
                        r["luong_theo_gio"]
                    );

                decimal luongTangCaTheoGio =
                    Convert.ToDecimal(
                        r["luong_tang_ca_theo_gio"]
                    );

                decimal phuCap =
                    Convert.ToDecimal(
                        r["phu_cap_mac_dinh"]
                    );

                decimal thuong =
                    Convert.ToDecimal(
                        r["thuong"]
                    );

                decimal phat =
                    Convert.ToDecimal(
                        r["phat"]
                    );

                decimal tongLuongChinh =
                    0;

                if (
                    loaiLuong == "Tháng"
                )
                {
                    tongLuongChinh =
                        luongCoBan;
                }
                else
                {
                    tongLuongChinh =
                        tongCaDiLam
                        * 8
                        * luongTheoGio;
                }

                decimal tongLuongTangCa =
                    (
                        tongPhutTangCa
                        / 60m
                    )
                    * luongTangCaTheoGio;

                decimal tongLuong =
                    tongLuongChinh
                    + tongLuongTangCa
                    + phuCap
                    + thuong
                    - phat;

                r["tong_luong_chinh"] =
                    tongLuongChinh;

                r["tong_luong_tang_ca"] =
                    tongLuongTangCa;

                r["tong_luong"] =
                    tongLuong;
            }

            return dt;
        }

        public bool ChotLuong(
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
            int kq =
                dal.Insert(
                    nhanVienId,
                    thang,
                    nam,
                    tongCaDuocPhan,
                    tongCaDiLam,
                    tongCaNghi,
                    tongPhutDiTre,
                    tongPhutVeSom,
                    tongPhutBiTru,
                    tongPhutTangCa,
                    luongCoBan,
                    luongTheoGio,
                    luongTangCaTheoGio,
                    tongLuongChinh,
                    tongLuongTangCa,
                    phuCap,
                    thuong,
                    phat,
                    tongLuong,
                    ghiChu,
                    nguoiChot
                );

            return kq > 0;
        }
    }
}