using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhanCaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<PhanCa> ds =
                new List<PhanCa>();

            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        id,
                        nhan_vien_id,
                        ca_lam_id,
                        ngay_lam
                    FROM phan_ca";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime tempDate;

                    ds.Add(new PhanCa
                    {
                        id =
                            int.TryParse(
                                reader["id"].ToString(),
                                out int idValue)
                            ? idValue
                            : 0,

                        nhan_vien_id =
                            reader["nhan_vien_id"]
                            .ToString(),

                        ca_lam_id =
                            int.TryParse(
                                reader["ca_lam_id"]
                                .ToString(),
                                out int caLamId)
                            ? caLamId
                            : 0,

                        ngay_lam =
                            DateTime.TryParse(
                                reader["ngay_lam"]
                                .ToString(),
                                out tempDate)
                            ? tempDate
                            : DateTime.Now
                    });
                }
            }

            return Ok(ds);
        }

        [HttpPost]
        public IActionResult Add(
            [FromBody] PhanCa pc)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO phan_ca
                    (
                        nhan_vien_id,
                        ca_lam_id,
                        ngay_lam
                    )
                    VALUES
                    (
                        @nhan_vien_id,
                        @ca_lam_id,
                        @ngay_lam
                    )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    pc.nhan_vien_id);

                cmd.Parameters.AddWithValue(
                    "@ca_lam_id",
                    pc.ca_lam_id);

                cmd.Parameters.AddWithValue(
                    "@ngay_lam",
                    pc.ngay_lam);

                cmd.ExecuteNonQuery();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            [FromBody] PhanCa pc)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE phan_ca
                    SET
                        nhan_vien_id = @nhan_vien_id,
                        ca_lam_id = @ca_lam_id,
                        ngay_lam = @ngay_lam
                    WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    pc.nhan_vien_id);

                cmd.Parameters.AddWithValue(
                    "@ca_lam_id",
                    pc.ca_lam_id);

                cmd.Parameters.AddWithValue(
                    "@ngay_lam",
                    pc.ngay_lam);

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
                    "DELETE FROM phan_ca WHERE id = @id";

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