using System;

namespace QuanLyChamCong.Models
{
    public class PhanCa
    {
        public int id { get; set; }

        public string nhan_vien_id { get; set; }

        public int ca_lam_id { get; set; }

        public DateTime ngay_lam { get; set; }
    }
}