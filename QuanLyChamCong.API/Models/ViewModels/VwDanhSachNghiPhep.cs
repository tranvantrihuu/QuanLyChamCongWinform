using Microsoft.EntityFrameworkCore;

namespace QuanLyChamCong.API.Models.ViewModels
{
    [Keyless]
    public class VwDanhSachNghiPhep
    {
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        public string? ho_ten { get; set; }

        public int? ca_lam_id { get; set; }

        public DateTime? ngay { get; set; }

        public string? loai { get; set; }

        public string? ly_do { get; set; }
    }
}