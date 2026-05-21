using Microsoft.EntityFrameworkCore;

namespace QuanLyChamCong.API.Models.ViewModels
{
    [Keyless]
    public class VwDanhSachChamCong
    {
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        public DateTime? ngay_lam { get; set; }

        public int? ca_lam_id { get; set; }

        public DateTime? check_in { get; set; }

        public DateTime? check_out { get; set; }

        public string? ho_ten { get; set; }

        public string? ten_ca { get; set; }

        /*
        ====================================================
        SQL TIME -> TimeSpan
        ====================================================
        */

        public TimeSpan? gio_bat_dau { get; set; }

        public TimeSpan? gio_ket_thuc { get; set; }

        /*
        ====================================================
        PHÚT
        ====================================================
        */

        public int? so_phut_di_som { get; set; }

        public int? so_phut_di_tre { get; set; }

        public int? so_phut_ve_som { get; set; }

        public int? so_phut_ve_tre { get; set; }

        public int? so_phut_tang_ca { get; set; }

        public int? so_phut_bi_tru { get; set; }

        /*
        ====================================================
        GIỜ LÀM
        ====================================================
        */

        public decimal? so_gio_lam { get; set; }

        /*
        ====================================================
        CẤU HÌNH CA
        ====================================================
        */

        public int? phut_cho_phep_di_tre { get; set; }

        public int? phut_cho_phep_ve_som { get; set; }

        public int? phut_cho_phep_checkin_som { get; set; }

        public int? phut_cho_phep_checkout_tre { get; set; }

        /*
        ====================================================
        TRẠNG THÁI
        ====================================================
        */

        public string? trang_thai { get; set; }
    }
}