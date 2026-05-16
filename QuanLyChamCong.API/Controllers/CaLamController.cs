using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaLamController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<CaLam> ds =
                new List<CaLam>();

            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql =
                    @"
                    SELECT *
                    FROM ca_lam
                ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    ds.Add(
                        new CaLam
                        {
                            id =
                                Convert.ToInt32(
                                    reader["id"]
                                ),

                            ten_ca =
                                reader["ten_ca"]
                                .ToString(),

                            gio_bat_dau =
                                TimeSpan.Parse(
                                    reader["gio_bat_dau"]
                                    .ToString()
                                ),

                            gio_ket_thuc =
                                TimeSpan.Parse(
                                    reader["gio_ket_thuc"]
                                    .ToString()
                                ),

                            phut_cho_phep_di_tre =
                                Convert.ToInt32(
                                    reader["phut_cho_phep_di_tre"]
                                ),

                            phut_cho_phep_ve_som =
                                Convert.ToInt32(
                                    reader["phut_cho_phep_ve_som"]
                                ),

                            phut_cho_phep_checkin_som =
                                Convert.ToInt32(
                                    reader["phut_cho_phep_checkin_som"]
                                ),

                            phut_cho_phep_checkout_tre =
                                Convert.ToInt32(
                                    reader["phut_cho_phep_checkout_tre"]
                                )
                        }
                    );
                }
            }

            return Ok(ds);
        }

        [HttpPost]
        public IActionResult Insert(
            [FromBody] CaLam ca
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql =
                    @"
                    INSERT INTO ca_lam
                    (
                        ten_ca,
                        gio_bat_dau,
                        gio_ket_thuc,
                        phut_cho_phep_di_tre,
                        phut_cho_phep_ve_som,
                        phut_cho_phep_checkin_som,
                        phut_cho_phep_checkout_tre
                    )
                    VALUES
                    (
                        @ten_ca,
                        @gio_bat_dau,
                        @gio_ket_thuc,
                        @phut_cho_phep_di_tre,
                        @phut_cho_phep_ve_som,
                        @phut_cho_phep_checkin_som,
                        @phut_cho_phep_checkout_tre
                    )
                ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@ten_ca",
                    ca.ten_ca
                );

                cmd.Parameters.AddWithValue(
                    "@gio_bat_dau",
                    ca.gio_bat_dau
                );

                cmd.Parameters.AddWithValue(
                    "@gio_ket_thuc",
                    ca.gio_ket_thuc
                );

                cmd.Parameters.AddWithValue(
                    "@phut_cho_phep_di_tre",
                    ca.phut_cho_phep_di_tre
                );

                cmd.Parameters.AddWithValue(
                    "@phut_cho_phep_ve_som",
                    ca.phut_cho_phep_ve_som
                );

                cmd.Parameters.AddWithValue(
                    "@phut_cho_phep_checkin_som",
                    ca.phut_cho_phep_checkin_som
                );

                cmd.Parameters.AddWithValue(
                    "@phut_cho_phep_checkout_tre",
                    ca.phut_cho_phep_checkout_tre
                );

                cmd.ExecuteNonQuery();

                return Ok(new
                {
                    message =
                        "Thêm thành công"
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            [FromBody] CaLam ca
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql =
                    @"
                    UPDATE ca_lam
                    SET
                        ten_ca =
                            @ten_ca,

                        gio_bat_dau =
                            @gio_bat_dau,

                        gio_ket_thuc =
                            @gio_ket_thuc,

                        phut_cho_phep_di_tre =
                            @phut_cho_phep_di_tre,

                        phut_cho_phep_ve_som =
                            @phut_cho_phep_ve_som,

                        phut_cho_phep_checkin_som =
                            @phut_cho_phep_checkin_som,

                        phut_cho_phep_checkout_tre =
                            @phut_cho_phep_checkout_tre
                    WHERE id = @id
                ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                cmd.Parameters.AddWithValue(
                    "@ten_ca",
                    ca.ten_ca
                );

                cmd.Parameters.AddWithValue(
                    "@gio_bat_dau",
                    ca.gio_bat_dau
                );

                cmd.Parameters.AddWithValue(
                    "@gio_ket_thuc",
                    ca.gio_ket_thuc
                );

                cmd.Parameters.AddWithValue(
                    "@phut_cho_phep_di_tre",
                    ca.phut_cho_phep_di_tre
                );

                cmd.Parameters.AddWithValue(
                    "@phut_cho_phep_ve_som",
                    ca.phut_cho_phep_ve_som
                );

                cmd.Parameters.AddWithValue(
                    "@phut_cho_phep_checkin_som",
                    ca.phut_cho_phep_checkin_som
                );

                cmd.Parameters.AddWithValue(
                    "@phut_cho_phep_checkout_tre",
                    ca.phut_cho_phep_checkout_tre
                );

                int row =
                    cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    return Ok(new
                    {
                        message =
                            "Cập nhật thành công"
                    });
                }

                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sqlPhanCa =
                    @"
            DELETE FROM phan_ca
            WHERE ca_lam_id = @id
        ";

                SqlCommand phanCaCmd =
                    new SqlCommand(
                        sqlPhanCa,
                        conn
                    );

                phanCaCmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                phanCaCmd.ExecuteNonQuery();

                string sqlChamCong =
                    @"
            DELETE FROM cham_cong
            WHERE ca_lam_id = @id
        ";

                SqlCommand chamCongCmd =
                    new SqlCommand(
                        sqlChamCong,
                        conn
                    );

                chamCongCmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                chamCongCmd.ExecuteNonQuery();

                string sql =
                    @"
                    DELETE FROM ca_lam
                    WHERE id = @id
                ";

                SqlCommand cmd =
                    new SqlCommand(
                        sql,
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                int row =
                    cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    return Ok(new
                    {
                        message =
                            "Xóa thành công"
                    });
                }

                return NotFound();
            }
        }
    }
}