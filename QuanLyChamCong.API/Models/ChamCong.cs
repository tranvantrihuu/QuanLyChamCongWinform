using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.API.Models
{
    [Table("cham_cong")]
    public class ChamCong
    {
        [Key]
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        public DateTime? ngay_lam { get; set; }

        public int? ca_lam_id { get; set; }

        public DateTime? check_in { get; set; }

        public DateTime? check_out { get; set; }

        /*
         * DÙNG CHUNG
         * CHO:
         * - CHẤM CÔNG
         * - QUẢN LÝ CHẤM CÔNG
         * - VIEW
         * - BÁO CÁO
         */

        [NotMapped]
        public string? ho_ten { get; set; }

        [NotMapped]
        public string? ten_ca { get; set; }

        [NotMapped]
        public TimeSpan? gio_bat_dau { get; set; }

        [NotMapped]
        public TimeSpan? gio_ket_thuc { get; set; }

        [NotMapped]
        public int? so_phut_di_som { get; set; }

        [NotMapped]
        public int? so_phut_di_tre { get; set; }

        [NotMapped]
        public int? so_phut_ve_som { get; set; }

        [NotMapped]
        public int? so_phut_ve_tre { get; set; }

        [NotMapped]
        public decimal? so_gio_lam { get; set; }

        [NotMapped]
        public int? so_phut_tang_ca { get; set; }

        [NotMapped]
        public int? so_phut_bi_tru { get; set; }

        [NotMapped]
        public int? phut_cho_phep_di_tre { get; set; }

        [NotMapped]
        public int? phut_cho_phep_ve_som { get; set; }

        [NotMapped]
        public int? phut_cho_phep_checkin_som { get; set; }

        [NotMapped]
        public int? phut_cho_phep_checkout_tre { get; set; }

        [NotMapped]
        public string? trang_thai { get; set; }
    }
}