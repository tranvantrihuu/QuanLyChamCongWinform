using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.API.Models
{
    [Table("nghi_phep")]
    public class NghiPhep
    {
        [Key]
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        public int? ca_lam_id { get; set; }

        public DateTime? ngay { get; set; }

        public string? loai { get; set; }

        public string? ly_do { get; set; }

        /*
         * VIEW
         */

        [NotMapped]
        public string? ho_ten { get; set; }

        [NotMapped]
        public string? vi_tri { get; set; }
    }
}