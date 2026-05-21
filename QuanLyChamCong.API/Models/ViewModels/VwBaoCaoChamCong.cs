using Microsoft.EntityFrameworkCore;

namespace QuanLyChamCong.API.Models.ViewModels
{
    [Keyless]
    public class VwBaoCaoChamCong
    {
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        public string? ho_ten { get; set; }

        public DateTime? ngay_lam { get; set; }

        public int? ca_lam_id { get; set; }

        public string? ten_ca { get; set; }

        public string? gio_bat_dau { get; set; }

        public string? gio_ket_thuc { get; set; }

        public DateTime? check_in { get; set; }

        public DateTime? check_out { get; set; }

        public int? phut_cho_phep_di_tre { get; set; }

        public int? phut_cho_phep_ve_som { get; set; }

        public int? phut_cho_phep_checkin_som { get; set; }

        public int? phut_cho_phep_checkout_tre { get; set; }
    }
}