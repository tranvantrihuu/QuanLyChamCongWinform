using System;

namespace QuanLyChamCong.Models.ViewModels
{
    public class VwChiTietBangLuong
    {
        public int id { get; set; }

        public string nhan_vien_id { get; set; }

        public string ho_ten { get; set; }

        public int? thang { get; set; }

        public int? nam { get; set; }

        public decimal? luong_chinh { get; set; }

        public decimal? luong_tang_ca { get; set; }

        public decimal? tong_thuong { get; set; }

        public decimal? tong_phat { get; set; }

        public decimal? tong_luong { get; set; }

        public decimal? tong_gio_lam { get; set; }

        public int? tong_phut_tang_ca { get; set; }

        public int? tong_phut_bi_tru { get; set; }
    }
}