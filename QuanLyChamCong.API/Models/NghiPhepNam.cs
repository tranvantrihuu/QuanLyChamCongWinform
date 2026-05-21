using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.API.Models
{
    [Table("nghi_phep_nam")]
    public class NghiPhepNam
    {
        [Key]
        public int id { get; set; }

        public string? nhan_vien_id { get; set; }

        // dùng cho VIEW
        [NotMapped]
        public string? ho_ten { get; set; }

        public int nam { get; set; }

        public int so_ca_duoc_nghi { get; set; }

        public int so_ca_da_nghi_co_phep { get; set; }

        public int so_ca_da_nghi_khong_phep { get; set; }

        public DateTime created_at { get; set; }
    }
}