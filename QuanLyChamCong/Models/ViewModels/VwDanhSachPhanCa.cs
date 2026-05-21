using System;

namespace QuanLyChamCong.Models.ViewModels
{
    public class VwDanhSachPhanCa
    {
        public int id { get; set; }

        public string nhan_vien_id { get; set; }

        public string ho_ten { get; set; }

        public int? ca_lam_id { get; set; }

        public string ten_ca { get; set; }

        public DateTime? ngay_lam { get; set; }

        public string ghi_chu { get; set; }
    }
}