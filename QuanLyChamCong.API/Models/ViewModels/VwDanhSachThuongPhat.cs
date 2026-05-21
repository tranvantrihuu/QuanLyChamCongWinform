using Microsoft.EntityFrameworkCore;

namespace QuanLyChamCong.API.Models.ViewModels
{
    [Keyless]
    public class VwDanhSachThuongPhat
    {
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        public string? ho_ten { get; set; }

        public string? vi_tri { get; set; }

        public DateTime? ngay { get; set; }

        public string? loai { get; set; }

        public decimal? so_tien { get; set; }

        public string? ly_do { get; set; }
    }
}