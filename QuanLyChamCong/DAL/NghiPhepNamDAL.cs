using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.DAL
{
    public class NghiPhepNamDAL
    {
        DataProvider dp = new DataProvider();

        public DataTable GetAll()
        {
            string sql = @"
                SELECT 
                    npn.id,
                    nv.ho_ten,
                    npn.nhan_vien_id,
                    npn.nam,
                    npn.so_ca_duoc_nghi,
                    npn.so_ca_da_nghi_co_phep,
                    npn.so_ca_da_nghi_khong_phep,
                    npn.created_at
                FROM nghi_phep_nam npn
                LEFT JOIN nhan_vien nv 
                    ON npn.nhan_vien_id = nv.id
                ORDER BY npn.id ASC
            ";

            return dp.ExecuteQuery(sql);
        }

        public void Insert(Dictionary<string, object> param)
        {
            string sql = @"
                INSERT INTO nghi_phep_nam
                (
                    nhan_vien_id,
                    nam,
                    so_ca_duoc_nghi,
                    so_ca_da_nghi_co_phep,
                    so_ca_da_nghi_khong_phep,
                    created_at
                )
                VALUES
                (
                    @nhanVienId,
                    @nam,
                    @duocNghi,
                    @coPhep,
                    @khongPhep,
                    GETDATE()
                )
            ";

            dp.ExecuteNonQuery(sql, param);
        }

        public void Update(Dictionary<string, object> param)
        {
            string sql = @"
                UPDATE nghi_phep_nam
                SET
                    nhan_vien_id = @nhanVienId,
                    nam = @nam,
                    so_ca_duoc_nghi = @duocNghi,
                    so_ca_da_nghi_co_phep = @coPhep,
                    so_ca_da_nghi_khong_phep = @khongPhep
                WHERE id = @id
            ";

            dp.ExecuteNonQuery(sql, param);
        }

        public void Delete(List<int> ids)
        {
            foreach (int id in ids)
            {
                string sql = "DELETE FROM nghi_phep_nam WHERE id = @id";

                var p = new Dictionary<string, object>()
                {
                    { "@id", id }
                };

                dp.ExecuteNonQuery(sql, p);
            }
        }

        public DataTable GetNhanVien()
        {
            string sql = @"
                SELECT id, ho_ten
                FROM nhan_vien
                ORDER BY ho_ten
            ";

            return dp.ExecuteQuery(sql);
        }
    }
}