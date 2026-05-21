using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.API.Models
{
    [Table("cau_hinh_luong")]
    public class CauHinhLuong
    {
        [Key]
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        [NotMapped]
        public string? ho_ten { get; set; }

        [NotMapped]
        public string? vi_tri { get; set; }

        [NotMapped]
        public string? loai_luong { get; set; }

        public decimal? luong_co_ban { get; set; }

        public decimal? luong_theo_gio { get; set; }

        public decimal? luong_tang_ca { get; set; }

        public decimal? phu_cap_mac_dinh { get; set; }
    }
}