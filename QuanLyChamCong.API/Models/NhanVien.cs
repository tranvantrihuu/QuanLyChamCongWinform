namespace QuanLyChamCong.API.Models
{
    public class NhanVien
    {
        public string id { get; set; }

        public string? ma_van_tay { get; set; }

        public string? ho_ten { get; set; }

        public string? so_dien_thoai { get; set; }

        public DateTime? ngay_sinh { get; set; }

        public string? dia_chi { get; set; }

        public string? vi_tri { get; set; }

        public string? vai_tro { get; set; }

        public string? trang_thai { get; set; }

        public string? pin_code { get; set; }

        public DateTime? ngay_vao_lam { get; set; }

        public string? loai_luong { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}