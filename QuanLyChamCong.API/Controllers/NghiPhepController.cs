using Microsoft.AspNetCore.Mvc;
using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NghiPhepController : ControllerBase
    {
      
        [HttpGet]
        public IActionResult Get()
        {
            List<NghiPhep> ds =
                new List<NghiPhep>();

            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        np.id,
                        np.nhan_vien_id,
                        nv.ho_ten,
                        np.ca_lam_id,
                        np.ngay,
                        np.loai,
                        np.ly_do,
                        np.created_at
                    FROM nghi_phep np
                    LEFT JOIN nhan_vien nv
                        ON np.nhan_vien_id = nv.id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    ds.Add(new NghiPhep
                    {
                        id =
                            Convert.ToInt32(
                                reader["id"]),

                        nhan_vien_id =
                            reader["nhan_vien_id"]
                            .ToString(),

                        ho_ten =
                            reader["ho_ten"]
                            .ToString(),

                        ca_lam_id =
                            Convert.ToInt32(
                                reader["ca_lam_id"]),

                        ngay =
                            Convert.ToDateTime(
                                reader["ngay"]),

                        loai =
                            reader["loai"]
                            .ToString(),

                        ly_do =
                            reader["ly_do"]
                            .ToString(),

                        created_at =
                            Convert.ToDateTime(
                                reader["created_at"])
                    });
                }
            }

            return Ok(ds);
        }

        [HttpPost]
        public IActionResult Add(
            [FromBody] NghiPhep item)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO nghi_phep
                    (
                        nhan_vien_id,
                        ca_lam_id,
                        ngay,
                        loai,
                        ly_do
                    )
                    VALUES
                    (
                        @nhan_vien_id,
                        @ca_lam_id,
                        @ngay,
                        @loai,
                        @ly_do
                    )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    item.nhan_vien_id);

                cmd.Parameters.AddWithValue(
                    "@ca_lam_id",
                    item.ca_lam_id);

                cmd.Parameters.AddWithValue(
                    "@ngay",
                    item.ngay);

                cmd.Parameters.AddWithValue(
                    "@loai",
                    item.loai);

                cmd.Parameters.AddWithValue(
                    "@ly_do",
                    item.ly_do);

                cmd.ExecuteNonQuery();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromBody] NghiPhep item)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE nghi_phep
                    SET
                        nhan_vien_id = @nhan_vien_id,
                        ca_lam_id = @ca_lam_id,
                        ngay = @ngay,
                        loai = @loai,
                        ly_do = @ly_do
                    WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    item.id);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    item.nhan_vien_id);

                cmd.Parameters.AddWithValue(
                    "@ca_lam_id",
                    item.ca_lam_id);

                cmd.Parameters.AddWithValue(
                    "@ngay",
                    item.ngay);

                cmd.Parameters.AddWithValue(
                    "@loai",
                    item.loai);

                cmd.Parameters.AddWithValue(
                    "@ly_do",
                    item.ly_do);

                cmd.ExecuteNonQuery();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql =
                    "DELETE FROM nghi_phep WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id);

                cmd.ExecuteNonQuery();
            }

            return Ok();
        }
    }
}