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
    public class ThuongPhatController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<ThuongPhat> ds =
                new List<ThuongPhat>();

            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        tp.id,
                        tp.nhan_vien_id,
                        nv.ho_ten,
                        tp.loai,
                        tp.so_tien,
                        tp.ly_do,
                        tp.ngay
                    FROM thuong_phat tp
                    LEFT JOIN nhan_vien nv
                        ON tp.nhan_vien_id = nv.id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    ds.Add(new ThuongPhat
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

                        loai =
                            reader["loai"]
                            .ToString(),

                        so_tien =
                            Convert.ToDecimal(
                                reader["so_tien"]),

                        ly_do =
                            reader["ly_do"]
                            .ToString(),

                        ngay =
                            Convert.ToDateTime(
                                reader["ngay"])
                    });
                }
            }

            return Ok(ds);
        }

        [HttpPost]
        public IActionResult Add(
            [FromBody] ThuongPhat tp)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO thuong_phat
                    (
                        nhan_vien_id,
                        loai,
                        so_tien,
                        ly_do,
                        ngay
                    )
                    VALUES
                    (
                        @nhan_vien_id,
                        @loai,
                        @so_tien,
                        @ly_do,
                        @ngay
                    )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    tp.nhan_vien_id);

                cmd.Parameters.AddWithValue(
                    "@loai",
                    tp.loai);

                cmd.Parameters.AddWithValue(
                    "@so_tien",
                    tp.so_tien);

                cmd.Parameters.AddWithValue(
                    "@ly_do",
                    tp.ly_do);

                cmd.Parameters.AddWithValue(
                    "@ngay",
                    tp.ngay);

                cmd.ExecuteNonQuery();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromBody] ThuongPhat tp)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE thuong_phat
                    SET
                        nhan_vien_id = @nhan_vien_id,
                        loai = @loai,
                        so_tien = @so_tien,
                        ly_do = @ly_do,
                        ngay = @ngay
                    WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    tp.id);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    tp.nhan_vien_id);

                cmd.Parameters.AddWithValue(
                    "@loai",
                    tp.loai);

                cmd.Parameters.AddWithValue(
                    "@so_tien",
                    tp.so_tien);

                cmd.Parameters.AddWithValue(
                    "@ly_do",
                    tp.ly_do);

                cmd.Parameters.AddWithValue(
                    "@ngay",
                    tp.ngay);

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
                    "DELETE FROM thuong_phat WHERE id = @id";

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