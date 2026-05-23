using System;

namespace QuanLyChamCong.Models
{
    public class ThongKeChamCongNhanVien
    {
        public string nhan_vien_id { get; set; }

        public string ho_ten { get; set; }

        public int tong_so_ca_cong { get; set; }

        public int tong_ca_di_tre { get; set; }

        public int tong_ca_vang { get; set; }
        public DateTime? tu_ngay { get; set; }

        public DateTime? den_ngay { get; set; }
    }
}