using System;

namespace QuanLyChamCong.Models
{
    public class CauHinhLuong
    {
        public int id { get; set; }

        public string nhan_vien_id { get; set; }

        public string ho_ten { get; set; }

        public string vi_tri { get; set; }

        public string loai_luong { get; set; }

        public decimal? luong_co_ban { get; set; }

        public decimal? luong_theo_gio { get; set; }

        public decimal? luong_tang_ca { get; set; }

        public decimal? phu_cap_mac_dinh { get; set; }
    }
}