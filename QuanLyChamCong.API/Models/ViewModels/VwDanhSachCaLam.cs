using System;

namespace QuanLyChamCong.API.Models.ViewModels
{
    public class VwDanhSachCaLam
    {
        public int id { get; set; }

        public string ten_ca { get; set; }

        public string gio_bat_dau { get; set; }

        public string gio_ket_thuc { get; set; }

        public int? phut_cho_phep_di_tre { get; set; }

        public int? phut_cho_phep_ve_som { get; set; }

        public int? phut_cho_phep_checkin_som { get; set; }

        public int? phut_cho_phep_checkout_tre { get; set; }
    }
}