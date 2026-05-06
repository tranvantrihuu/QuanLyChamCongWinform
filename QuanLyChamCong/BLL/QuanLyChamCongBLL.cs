// QuanLyChamCongBLL.cs

using DAL;
using System;
using System.Data;

namespace BLL
{
    public class QuanLyChamCongBLL
    {
        QuanLyChamCongDAL dal =
            new QuanLyChamCongDAL();

        public DataTable GetAll()
        {
            DataTable dt =
                dal.GetAll();

            XuLyTinhCong(dt);

            return dt;
        }

        public DataTable GetById(int id)
        {
            return dal.GetById(id);
        }

        public DataTable GetByNgay(
            string nhanVienId,
            DateTime tuNgay,
            DateTime denNgay
        )
        {
            DataTable dt =
                dal.GetByNgay(
                    nhanVienId,
                    tuNgay,
                    denNgay
                );

            XuLyTinhCong(dt);

            return dt;
        }

        public DataTable GetByNhanVienVaThang(
            string nhanVienId,
            int thang,
            int nam
        )
        {
            DataTable dt =
                dal.GetByNhanVienVaThang(
                    nhanVienId,
                    thang,
                    nam
                );

            XuLyTinhCong(dt);

            return dt;
        }

        private void XuLyTinhCong(
            DataTable dt
        )
        {
            if (!dt.Columns.Contains("so_phut_di_som"))
            {
                dt.Columns.Add(
                    "so_phut_di_som",
                    typeof(int)
                );
            }

            if (!dt.Columns.Contains("so_phut_di_tre"))
            {
                dt.Columns.Add(
                    "so_phut_di_tre",
                    typeof(int)
                );
            }

            if (!dt.Columns.Contains("so_phut_ve_som"))
            {
                dt.Columns.Add(
                    "so_phut_ve_som",
                    typeof(int)
                );
            }

            if (!dt.Columns.Contains("so_phut_ve_tre"))
            {
                dt.Columns.Add(
                    "so_phut_ve_tre",
                    typeof(int)
                );
            }

            if (!dt.Columns.Contains("so_phut_tang_ca"))
            {
                dt.Columns.Add(
                    "so_phut_tang_ca",
                    typeof(int)
                );
            }

            if (!dt.Columns.Contains("so_phut_bi_tru"))
            {
                dt.Columns.Add(
                    "so_phut_bi_tru",
                    typeof(int)
                );
            }

            if (!dt.Columns.Contains("trang_thai"))
            {
                dt.Columns.Add(
                    "trang_thai",
                    typeof(string)
                );
            }

            foreach (DataRow r in dt.Rows)
            {
                if (
                    r["check_in"] == DBNull.Value
                    || r["check_out"] == DBNull.Value
                )
                {
                    r["so_phut_di_som"] = 0;
                    r["so_phut_di_tre"] = 0;
                    r["so_phut_ve_som"] = 0;
                    r["so_phut_ve_tre"] = 0;
                    r["so_phut_tang_ca"] = 0;
                    r["so_phut_bi_tru"] = 0;
                    r["trang_thai"] = "Nghỉ";

                    continue;
                }

                DateTime ngayLam =
                    Convert.ToDateTime(
                        r["ngay_lam"]
                    );

                TimeSpan gioBatDau =
                    TimeSpan.Parse(
                        r["gio_bat_dau"].ToString()
                    );

                TimeSpan gioKetThuc =
                    TimeSpan.Parse(
                        r["gio_ket_thuc"].ToString()
                    );

                DateTime batDauCa =
                    ngayLam.Date.Add(
                        gioBatDau
                    );

                DateTime ketThucCa =
                    ngayLam.Date.Add(
                        gioKetThuc
                    );

                if (
                    ketThucCa < batDauCa
                )
                {
                    ketThucCa =
                        ketThucCa.AddDays(1);
                }

                DateTime checkIn =
                    Convert.ToDateTime(
                        r["check_in"]
                    );

                DateTime checkOut =
                    Convert.ToDateTime(
                        r["check_out"]
                    );

                int phutChoPhepDiTre =
                    Convert.ToInt32(
                        r["phut_cho_phep_di_tre"]
                    );

                int phutChoPhepVeSom =
                    Convert.ToInt32(
                        r["phut_cho_phep_ve_som"]
                    );

                int phutChoPhepCheckinSom =
                    Convert.ToInt32(
                        r["phut_cho_phep_checkin_som"]
                    );

                int phutChoPhepCheckoutTre =
                    Convert.ToInt32(
                        r["phut_cho_phep_checkout_tre"]
                    );

                int soPhutDiSom = 0;
                int soPhutDiTre = 0;
                int soPhutVeSom = 0;
                int soPhutVeTre = 0;

                int soPhutTangCa = 0;
                int soPhutBiTru = 0;

                if (checkIn < batDauCa)
                {
                    soPhutDiSom =
                        (int)(
                            batDauCa - checkIn
                        ).TotalMinutes;
                }

                if (checkIn > batDauCa)
                {
                    soPhutDiTre =
                        (int)(
                            checkIn - batDauCa
                        ).TotalMinutes;
                }

                if (checkOut < ketThucCa)
                {
                    soPhutVeSom =
                        (int)(
                            ketThucCa - checkOut
                        ).TotalMinutes;
                }

                if (checkOut > ketThucCa)
                {
                    soPhutVeTre =
                        (int)(
                            checkOut - ketThucCa
                        ).TotalMinutes;
                }

                int tangCaCheckin =
                    Math.Min(
                        soPhutDiSom,
                        phutChoPhepCheckinSom
                    );

                int tangCaCheckout =
                    Math.Min(
                        soPhutVeTre,
                        phutChoPhepCheckoutTre
                    );

                soPhutTangCa =
                    tangCaCheckin
                    + tangCaCheckout;

                int truDiTre = 0;

                if (
                    soPhutDiTre >
                    phutChoPhepDiTre
                )
                {
                    truDiTre =
                        soPhutDiTre
                        - phutChoPhepDiTre;
                }

                int truVeSom = 0;

                if (
                    soPhutVeSom >
                    phutChoPhepVeSom
                )
                {
                    truVeSom =
                        soPhutVeSom
                        - phutChoPhepVeSom;
                }

                soPhutBiTru =
                    truDiTre
                    + truVeSom;

                r["so_phut_di_som"] =
                    soPhutDiSom;

                r["so_phut_di_tre"] =
                    soPhutDiTre;

                r["so_phut_ve_som"] =
                    soPhutVeSom;

                r["so_phut_ve_tre"] =
                    soPhutVeTre;

                r["so_phut_tang_ca"] =
                    soPhutTangCa;

                r["so_phut_bi_tru"] =
                    soPhutBiTru;

                string trangThai = "";

                if (soPhutDiSom > 0)
                {
                    trangThai +=
                        "Đi sớm";
                }

                if (soPhutDiTre > 0)
                {
                    if (trangThai != "")
                    {
                        trangThai += ", ";
                    }

                    trangThai +=
                        "Đi trễ";
                }

                if (soPhutVeSom > 0)
                {
                    if (trangThai != "")
                    {
                        trangThai += ", ";
                    }

                    trangThai +=
                        "Về sớm";
                }

                if (soPhutVeTre > 0)
                {
                    if (trangThai != "")
                    {
                        trangThai += ", ";
                    }

                    trangThai +=
                        "Về trễ";
                }

                if (trangThai == "")
                {
                    trangThai =
                        "Đúng giờ";
                }

                r["trang_thai"] =
                    trangThai;
            }
        }

        public int Insert(
            string nhanVienId,
            DateTime ngayLam,
            int caLamId,
            DateTime checkIn,
            DateTime checkOut
        )
        {
            return dal.Insert(
                nhanVienId,
                ngayLam,
                caLamId,
                checkIn,
                checkOut
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
            return dal.Update(
                id,
                nhanVienId,
                ngayLam,
                caLamId,
                checkIn,
                checkOut
            );
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}