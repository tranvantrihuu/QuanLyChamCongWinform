using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.API.Models
{
    [Table("bang_luong_chot")]
    public class BangLuongChot
    {
        [Key]
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        public int? thang { get; set; }

        public int? nam { get; set; }

        public int? tong_ca_duoc_phan { get; set; }

        public int? tong_ca_di_lam { get; set; }

        public int? tong_ca_nghi { get; set; }

        public int? tong_phut_di_tre { get; set; }

        public int? tong_phut_ve_som { get; set; }

        public int? tong_phut_bi_tru { get; set; }

        public int? tong_phut_tang_ca { get; set; }

        public decimal? tong_gio_lam { get; set; }

        public decimal? luong_co_ban { get; set; }

        public decimal? luong_theo_gio { get; set; }

        public decimal? luong_tang_ca_theo_gio { get; set; }

        public decimal? tong_luong_chinh { get; set; }

        public decimal? tong_luong_tang_ca { get; set; }

        public decimal? phu_cap { get; set; }

        public decimal? thuong { get; set; }

        public decimal? phat { get; set; }

        public decimal? tong_luong { get; set; }

        public string? ghi_chu { get; set; }

        public string? nguoi_chot { get; set; }
       
        public DateTime? ngay_chot { get; set; }
       
        public DateTime? created_at { get; set; }

        /*
         * VIEW DATA
         */

        [NotMapped]
        public string? ho_ten { get; set; }

        [NotMapped]
        public string? vi_tri { get; set; }

        [NotMapped]
        public string? loai_luong { get; set; }
    }
}