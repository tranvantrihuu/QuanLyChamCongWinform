using System;

namespace QuanLyChamCong.Models
{
    public class ChamCong
    {
        public int id { get; set; }

        public string nhan_vien_id { get; set; }

        public DateTime? ngay_lam { get; set; }

        public int? ca_lam_id { get; set; }

        public DateTime? check_in { get; set; }

        public DateTime? check_out { get; set; }

        // VIEW / BÁO CÁO

        public string ho_ten { get; set; }

        public string ten_ca { get; set; }

        public string gio_bat_dau { get; set; }

        public string gio_ket_thuc { get; set; }

        public int? so_phut_di_som { get; set; }

        public int? so_phut_di_tre { get; set; }

        public int? so_phut_ve_som { get; set; }

        public int? so_phut_ve_tre { get; set; }

        public decimal? so_gio_lam { get; set; }

        public int? so_phut_tang_ca { get; set; }

        public int? so_phut_bi_tru { get; set; }

        public int? phut_cho_phep_di_tre { get; set; }

        public int? phut_cho_phep_ve_som { get; set; }

        public int? phut_cho_phep_checkin_som { get; set; }

        public int? phut_cho_phep_checkout_tre { get; set; }

        public string trang_thai { get; set; }
    }
}