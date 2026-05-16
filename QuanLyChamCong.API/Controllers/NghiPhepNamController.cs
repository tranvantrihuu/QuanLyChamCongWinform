using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NghiPhepNamController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<object> ds = new List<object>();

            Db db = new Db();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql =
                @"
                SELECT
                    npn.id,
                    npn.nhan_vien_id,
                    nv.ho_ten,
                    npn.nam,
                    npn.so_ca_duoc_nghi,

                    ISNULL
                    (
                        (
                            SELECT COUNT(*)
                            FROM nghi_phep dxn
                            WHERE
                                dxn.nhan_vien_id =
                                    npn.nhan_vien_id
                                AND YEAR(dxn.ngay)
                                    = npn.nam
                                AND dxn.loai =
                                    N'Có phép'
                        ),
                        0
                    )
                    AS so_ca_da_nghi_co_phep,
                    ISNULL
                    (
                        (
                            SELECT COUNT(*)
                            FROM nghi_phep dxn
                            WHERE
                                dxn.nhan_vien_id =
                                    npn.nhan_vien_id
                                AND YEAR(dxn.ngay)
                                    = npn.nam
                                AND dxn.loai =
                                    N'Không phép'
                        ),
                        0
                    )
                    AS so_ca_da_nghi_khong_phep
                FROM nghi_phep_nam npn

                LEFT JOIN nhan_vien nv
                    ON npn.nhan_vien_id = nv.id

                ORDER BY npn.id DESC
            ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    ds.Add(new
                    {
                        id = Convert.ToInt32(reader["id"]),
                        nhan_vien_id =
                            reader["nhan_vien_id"]
                            .ToString(),

                        ho_ten =
                            reader["ho_ten"].ToString(),

                        nam =
                            reader["nam"],

                        so_ca_duoc_nghi =
                            reader["so_ca_duoc_nghi"],

                        so_ca_da_nghi_co_phep =
                            reader["so_ca_da_nghi_co_phep"],

                        so_ca_da_nghi_khong_phep =
                            reader["so_ca_da_nghi_khong_phep"]
                    });
                }
            }

            return Ok(ds);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT *
                    FROM nghi_phep_nam
                    WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    NghiPhepNam item =
                        new NghiPhepNam
                        {
                            id =
                                Convert.ToInt32(
                                    reader["id"]
                                ),

                            nhan_vien_id =
                                reader["nhan_vien_id"]
                                .ToString(),

                            nam =
                                Convert.ToInt32(
                                    reader["nam"]
                                ),

                            so_ca_duoc_nghi =
                                Convert.ToInt32(
                                    reader["so_ca_duoc_nghi"]
                                ),

                            so_ca_da_nghi_co_phep =
                                Convert.ToInt32(
                                    reader["so_ca_da_nghi_co_phep"]
                                ),

                            so_ca_da_nghi_khong_phep =
                                Convert.ToInt32(
                                    reader["so_ca_da_nghi_khong_phep"]
                                )
                        };

                    return Ok(item);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] NghiPhepNam item
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

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
                        @nhan_vien_id,
                        @nam,
                        @so_ca_duoc_nghi,
                        @so_ca_da_nghi_co_phep,
                        @so_ca_da_nghi_khong_phep,
                        GETDATE()
                    )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    item.nhan_vien_id
                );

                cmd.Parameters.AddWithValue(
                    "@nam",
                    item.nam
                );

                cmd.Parameters.AddWithValue(
                    "@so_ca_duoc_nghi",
                    item.so_ca_duoc_nghi
                );

                cmd.Parameters.AddWithValue(
                    "@so_ca_da_nghi_co_phep",
                    item.so_ca_da_nghi_co_phep
                );

                cmd.Parameters.AddWithValue(
                    "@so_ca_da_nghi_khong_phep",
                    item.so_ca_da_nghi_khong_phep
                );

                cmd.ExecuteNonQuery();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            int id,
            [FromBody] NghiPhepNam item
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE nghi_phep_nam
                    SET
                        nhan_vien_id =
                            @nhan_vien_id,

                        nam = @nam,

                        so_ca_duoc_nghi =
                            @so_ca_duoc_nghi,

                        so_ca_da_nghi_co_phep =
                            @so_ca_da_nghi_co_phep,

                        so_ca_da_nghi_khong_phep =
                            @so_ca_da_nghi_khong_phep
                    WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    item.nhan_vien_id
                );

                cmd.Parameters.AddWithValue(
                    "@nam",
                    item.nam
                );

                cmd.Parameters.AddWithValue(
                    "@so_ca_duoc_nghi",
                    item.so_ca_duoc_nghi
                );

                cmd.Parameters.AddWithValue(
                    "@so_ca_da_nghi_co_phep",
                    item.so_ca_da_nghi_co_phep
                );

                cmd.Parameters.AddWithValue(
                    "@so_ca_da_nghi_khong_phep",
                    item.so_ca_da_nghi_khong_phep
                );

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

                string sql = @"
                    DELETE FROM nghi_phep_nam
                    WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                cmd.ExecuteNonQuery();
            }

            return Ok();
        }
    }
}