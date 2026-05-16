using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CauHinhLuongController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<CauHinhLuong> ds =
                new List<CauHinhLuong>();

            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        chl.id,
                        chl.nhan_vien_id,
                        nv.ho_ten,
                        nv.vi_tri,
                        nv.loai_luong,
                        chl.luong_co_ban,
                        chl.luong_theo_gio,
                        chl.luong_tang_ca,
                        chl.phu_cap_mac_dinh
                    FROM cau_hinh_luong chl
                    INNER JOIN nhan_vien nv
                        ON chl.nhan_vien_id = nv.id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    ds.Add(new CauHinhLuong
                    {
                        id =
                            Convert.ToInt32(
                                reader["id"]
                            ),

                        nhan_vien_id =
                            reader["nhan_vien_id"]
                            .ToString(),

                        ho_ten =
                            reader["ho_ten"]
                            .ToString(),

                        vi_tri =
                            reader["vi_tri"]
                            .ToString(),

                        loai_luong =
                            reader["loai_luong"]
                            .ToString(),
                        luong_co_ban =
                            reader["luong_co_ban"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(
                                reader["luong_co_ban"]
                            ),

                                                luong_theo_gio =
                            reader["luong_theo_gio"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(
                                reader["luong_theo_gio"]
                            ),

                                                luong_tang_ca =
                            reader["luong_tang_ca"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(
                                reader["luong_tang_ca"]
                            ),

                                                phu_cap_mac_dinh =
                            reader["phu_cap_mac_dinh"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(
                                reader["phu_cap_mac_dinh"]
                            )
                    });
                }
            }

            return Ok(ds);
        }

        [HttpPost]
        public IActionResult Post(
            CauHinhLuong model
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO cau_hinh_luong
                    (
                        nhan_vien_id,
                        luong_co_ban,
                        luong_theo_gio,
                        luong_tang_ca,
                        phu_cap_mac_dinh
                    )
                    VALUES
                    (
                        @nhan_vien_id,
                        @luong_co_ban,
                        @luong_theo_gio,
                        @luong_tang_ca,
                        @phu_cap_mac_dinh
                    )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    model.nhan_vien_id
                );

                cmd.Parameters.AddWithValue(
                    "@luong_co_ban",
                    model.luong_co_ban
                );

                cmd.Parameters.AddWithValue(
                    "@luong_theo_gio",
                    model.luong_theo_gio
                );

                cmd.Parameters.AddWithValue(
                    "@luong_tang_ca",
                    model.luong_tang_ca
                );

                cmd.Parameters.AddWithValue(
                    "@phu_cap_mac_dinh",
                    model.phu_cap_mac_dinh
                );

                cmd.ExecuteNonQuery();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(
    int id,
    CauHinhLuong model
)
        {
            try
            {
                Db db = new Db();

                using (SqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                UPDATE cau_hinh_luong
                SET
                    nhan_vien_id = @nhan_vien_id,
                    luong_co_ban = @luong_co_ban,
                    luong_theo_gio = @luong_theo_gio,
                    luong_tang_ca = @luong_tang_ca,
                    phu_cap_mac_dinh = @phu_cap_mac_dinh
                WHERE id = @id";

                    SqlCommand cmd =
                        new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue(
                        "@id",
                        id
                    );

                    cmd.Parameters.AddWithValue(
                        "@nhan_vien_id",
                        model.nhan_vien_id
                    );

                    cmd.Parameters.AddWithValue(
                        "@luong_co_ban",
                        model.luong_co_ban
                    );

                    cmd.Parameters.AddWithValue(
                        "@luong_theo_gio",
                        model.luong_theo_gio
                    );

                    cmd.Parameters.AddWithValue(
                        "@luong_tang_ca",
                        model.luong_tang_ca
                    );

                    cmd.Parameters.AddWithValue(
                        "@phu_cap_mac_dinh",
                        model.phu_cap_mac_dinh
                    );

                    int rows =
                        cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return BadRequest(
                            "Không update được dòng nào!"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ex.Message
                );
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            int id
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    DELETE FROM cau_hinh_luong
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