using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.API.Models
{
    [Table("phan_ca")]
    public class PhanCa
    {
        [Key]
        public int id { get; set; }

        public string nhan_vien_id { get; set; }

        public int   ca_lam_id { get; set; }

        public DateTime ngay_lam { get; set; }
    }
}