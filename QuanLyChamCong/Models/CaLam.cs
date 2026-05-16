using System;

namespace QuanLyChamCong.Models
{
    public class CaLam
    {
        public int id { get; set; }

        public string ten_ca { get; set; }

        public TimeSpan gio_bat_dau { get; set; }

        public TimeSpan gio_ket_thuc { get; set; }

        public int phut_cho_phep_di_tre { get; set; }

        public int phut_cho_phep_ve_som { get; set; }

        public int phut_cho_phep_checkin_som { get; set; }

        public int phut_cho_phep_checkout_tre { get; set; }
    }
}