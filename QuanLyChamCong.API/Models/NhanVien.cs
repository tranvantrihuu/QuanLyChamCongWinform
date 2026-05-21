
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.API.Models
{
    [Table("nhan_vien")]
    public class NhanVien
    {
        // =========================
        // PRIMARY KEY
        // =========================

        [Key]
        [Column("id")]
        [StringLength(20)]
        public string id
        {
            get;
            set;
        } = string.Empty;

        // =========================
        // MÃ VÂN TAY
        // =========================

        [Column("ma_van_tay")]
        [StringLength(50)]
        public string ma_van_tay
        {
            get;
            set;
        } = string.Empty;

        // =========================
        // HỌ TÊN
        // =========================

        [Column("ho_ten")]
        [StringLength(255)]
        public string ho_ten
        {
            get;
            set;
        } = string.Empty;

        // =========================
        // SỐ ĐIỆN THOẠI
        // =========================

        [Column("so_dien_thoai")]
        [StringLength(20)]
        public string? so_dien_thoai
        {
            get;
            set;
        }

        // =========================
        // NGÀY SINH
        // =========================

        [Column("ngay_sinh")]
        public DateTime? ngay_sinh
        {
            get;
            set;
        }

        // =========================
        // ĐỊA CHỈ
        // =========================

        [Column("dia_chi")]
        [StringLength(500)]
        public string? dia_chi
        {
            get;
            set;
        }

        // =========================
        // VỊ TRÍ
        // =========================

        [Column("vi_tri")]
        [StringLength(100)]
        public string? vi_tri
        {
            get;
            set;
        }

        // =========================
        // VAI TRÒ
        // =========================

        [Column("vai_tro")]
        [StringLength(50)]
        public string? vai_tro
        {
            get;
            set;
        }

        // =========================
        // TRẠNG THÁI
        // =========================

        [Column("trang_thai")]
        [StringLength(50)]
        public string? trang_thai
        {
            get;
            set;
        }

        // =========================
        // PIN CODE
        // =========================

        [Column("pin_code")]
        [StringLength(10)]
        public string? pin_code
        {
            get;
            set;
        }

        // =========================
        // NGÀY VÀO LÀM
        // =========================

        [Column("ngay_vao_lam")]
        public DateTime? ngay_vao_lam
        {
            get;
            set;
        }

        // =========================
        // LOẠI LƯƠNG
        // =========================

        [Column("loai_luong")]
        [StringLength(50)]
        public string? loai_luong
        {
            get;
            set;
        }

        // =========================
        // CREATED
        // =========================

        [Column("created_at")]
        public DateTime? created_at
        {
            get;
            set;
        }

        // =========================
        // UPDATED
        // =========================

        [Column("updated_at")]
        public DateTime? updated_at
        {
            get;
            set;
        }
    }
}
