using System;

namespace QuanLyChamCong.Models
{
    public class BaoCaoChamCong
    {
        public int id { get; set; }

        public string nhan_vien_id { get; set; }

        public string ho_ten { get; set; }

        public string ten_ca { get; set; }

        public DateTime? ngay_lam { get; set; }

        public DateTime? check_in { get; set; }

        public DateTime? check_out { get; set; }

        public decimal? so_gio_lam { get; set; }

        public int? so_phut_di_tre { get; set; }

        public int? so_phut_ve_som { get; set; }

        public int? so_phut_tang_ca { get; set; }

        public string trang_thai { get; set; }
    }
}