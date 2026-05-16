using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhanVienController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<NhanVien> ds = new List<NhanVien>();

            Db db = new Db();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        id,
                        ma_van_tay,
                        ho_ten,
                        so_dien_thoai,
                        ngay_sinh,
                        dia_chi,
                        vi_tri,
                        vai_tro,
                        trang_thai,
                        pin_code,
                        ngay_vao_lam,
                        loai_luong,
                        created_at,
                        updated_at
                    FROM nhan_vien";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime tempDate;

                    ds.Add(new NhanVien
                    {
                        id = reader["id"].ToString(),

                        ma_van_tay =
                            reader["ma_van_tay"].ToString(),

                        ho_ten =
                            reader["ho_ten"].ToString(),

                        so_dien_thoai =
                            reader["so_dien_thoai"].ToString(),

                        ngay_sinh =
                            DateTime.TryParse(
                                reader["ngay_sinh"].ToString(),
                                out tempDate)
                            ? tempDate
                            : null,

                        dia_chi =
                            reader["dia_chi"].ToString(),

                        vi_tri =
                            reader["vi_tri"].ToString(),

                        vai_tro =
                            reader["vai_tro"].ToString(),

                        trang_thai =
                            reader["trang_thai"].ToString(),

                        pin_code =
                            reader["pin_code"].ToString(),

                        ngay_vao_lam =
                            DateTime.TryParse(
                                reader["ngay_vao_lam"].ToString(),
                                out tempDate)
                            ? tempDate
                            : null,

                        loai_luong =
                            reader["loai_luong"].ToString(),

                        created_at =
                            DateTime.TryParse(
                                reader["created_at"].ToString(),
                                out tempDate)
                            ? tempDate
                            : null,

                        updated_at =
                            DateTime.TryParse(
                                reader["updated_at"].ToString(),
                                out tempDate)
                            ? tempDate
                            : null
                    });
                }
            }

            return Ok(ds);
        }


        [HttpGet("timkiem/{input}")]
        public IActionResult GetNhanVien(
            string input
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT TOP 1 *
            FROM nhan_vien
            WHERE
                pin_code = @input
                OR ma_van_tay = @input";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@input",
                    input
                );

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (!reader.Read())
                {
                    return NotFound();
                }

                DateTime tempDate;

                NhanVien nv =
                    new NhanVien
                    {
                        id =
                            reader["id"]
                            .ToString(),

                        ma_van_tay =
                            reader["ma_van_tay"]
                            .ToString(),

                        ho_ten =
                            reader["ho_ten"]
                            .ToString(),

                        so_dien_thoai =
                            reader["so_dien_thoai"]
                            .ToString(),

                        ngay_sinh =
                            DateTime.TryParse(
                                reader["ngay_sinh"]
                                .ToString(),
                                out tempDate
                            )
                            ? tempDate
                            : null,

                        dia_chi =
                            reader["dia_chi"]
                            .ToString(),

                        vi_tri =
                            reader["vi_tri"]
                            .ToString(),

                        vai_tro =
                            reader["vai_tro"]
                            .ToString(),

                        trang_thai =
                            reader["trang_thai"]
                            .ToString(),

                        pin_code =
                            reader["pin_code"]
                            .ToString(),

                        ngay_vao_lam =
                            DateTime.TryParse(
                                reader["ngay_vao_lam"]
                                .ToString(),
                                out tempDate
                            )
                            ? tempDate
                            : null,

                        loai_luong =
                            reader["loai_luong"]
                            .ToString(),

                        created_at =
                            DateTime.TryParse(
                                reader["created_at"]
                                .ToString(),
                                out tempDate
                            )
                            ? tempDate
                            : null,

                        updated_at =
                            DateTime.TryParse(
                                reader["updated_at"]
                                .ToString(),
                                out tempDate
                            )
                            ? tempDate
                            : null
                    };

                return Ok(nv);
            }
        }
        [HttpGet("adminpin/{pin}")]
        public IActionResult KiemTraAdmin(
            string pin
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT TOP 1 *
            FROM nhan_vien
            WHERE
                vai_tro = 'admin'
                AND pin_code = @pin";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@pin",
                    pin
                );

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (!reader.Read())
                {
                    return NotFound();
                }

                DateTime tempDate;

                NhanVien nv =
                    new NhanVien
                    {
                        id =
                            reader["id"]
                            .ToString(),

                        ma_van_tay =
                            reader["ma_van_tay"]
                            .ToString(),

                        ho_ten =
                            reader["ho_ten"]
                            .ToString(),

                        so_dien_thoai =
                            reader["so_dien_thoai"]
                            .ToString(),

                        ngay_sinh =
                            DateTime.TryParse(
                                reader["ngay_sinh"]
                                .ToString(),
                                out tempDate
                            )
                            ? tempDate
                            : null,

                        dia_chi =
                            reader["dia_chi"]
                            .ToString(),

                        vi_tri =
                            reader["vi_tri"]
                            .ToString(),

                        vai_tro =
                            reader["vai_tro"]
                            .ToString(),

                        trang_thai =
                            reader["trang_thai"]
                            .ToString(),

                        pin_code =
                            reader["pin_code"]
                            .ToString(),

                        ngay_vao_lam =
                            DateTime.TryParse(
                                reader["ngay_vao_lam"]
                                .ToString(),
                                out tempDate
                            )
                            ? tempDate
                            : null,

                        loai_luong =
                            reader["loai_luong"]
                            .ToString(),

                        created_at =
                            DateTime.TryParse(
                                reader["created_at"]
                                .ToString(),
                                out tempDate
                            )
                            ? tempDate
                            : null,

                        updated_at =
                            DateTime.TryParse(
                                reader["updated_at"]
                                .ToString(),
                                out tempDate
                            )
                            ? tempDate
                            : null
                    };

                return Ok(nv);
            }
        }

        [HttpPost]
        public IActionResult Insert(
            [FromBody] NhanVien nv
        )
        {

            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
                INSERT INTO nhan_vien
                (
                    id,
                    ma_van_tay,
                    ho_ten,
                    so_dien_thoai,
                    ngay_sinh,
                    dia_chi,
                    vi_tri,
                    vai_tro,
                    trang_thai,
                    pin_code,
                    ngay_vao_lam,
                    loai_luong,
                    created_at,
                    updated_at
                )
                VALUES
                (
                    @id,
                    @ma_van_tay,
                    @ho_ten,
                    @so_dien_thoai,
                    @ngay_sinh,
                    @dia_chi,
                    @vi_tri,
                    @vai_tro,
                    @trang_thai,
                    @pin_code,
                    @ngay_vao_lam,
                    @loai_luong,
                    GETDATE(),
                    GETDATE()
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    (object)nv.id ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@ma_van_tay",
                    (object)nv.ma_van_tay ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@ho_ten",
                    (object)nv.ho_ten ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@so_dien_thoai",
                    (object)nv.so_dien_thoai ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@ngay_sinh",
                    (object)nv.ngay_sinh ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@dia_chi",
                    (object)nv.dia_chi ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@vi_tri",
                    (object)nv.vi_tri ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@vai_tro",
                    (object)nv.vai_tro ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@trang_thai",
                    (object)nv.trang_thai ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@pin_code",
                    (object)nv.pin_code ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@ngay_vao_lam",
                    (object)nv.ngay_vao_lam ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@loai_luong",
                    (object)nv.loai_luong ?? DBNull.Value
                );

                int rows =
                    cmd.ExecuteNonQuery();

                return Ok(rows);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            string id,
            [FromBody] NhanVien nv
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
            UPDATE nhan_vien
            SET
                ma_van_tay = @ma_van_tay,
                ho_ten = @ho_ten,
                so_dien_thoai = @so_dien_thoai,
                ngay_sinh = @ngay_sinh,
                dia_chi = @dia_chi,
                vi_tri = @vi_tri,
                vai_tro = @vai_tro,
                trang_thai = @trang_thai,
                pin_code = @pin_code,
                ngay_vao_lam = @ngay_vao_lam,
                loai_luong = @loai_luong,
                updated_at = GETDATE()
            WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                cmd.Parameters.AddWithValue(
                    "@ma_van_tay",
                    (object)nv.ma_van_tay ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@ho_ten",
                    (object)nv.ho_ten ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@so_dien_thoai",
                    (object)nv.so_dien_thoai ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@ngay_sinh",
                    (object)nv.ngay_sinh ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@dia_chi",
                    (object)nv.dia_chi ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@vi_tri",
                    (object)nv.vi_tri ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@vai_tro",
                    (object)nv.vai_tro ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@trang_thai",
                    (object)nv.trang_thai ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@pin_code",
                    (object)nv.pin_code ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@ngay_vao_lam",
                    (object)nv.ngay_vao_lam ?? DBNull.Value
                );

                cmd.Parameters.AddWithValue(
                    "@loai_luong",
                    (object)nv.loai_luong ?? DBNull.Value
                );

                int rows =
                    cmd.ExecuteNonQuery();

                return Ok(rows);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(
            string id
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql =
                    @"DELETE FROM nhan_vien
              WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                int rows =
                    cmd.ExecuteNonQuery();

                return Ok(rows);
            }
        }
        [HttpPut("doipin/{id}")]
        public IActionResult DoiPin(
    string id,
    [FromBody] dynamic data
)
        {
            try
            {
                string pinMoi =
                    data.pinMoi.ToString();

                Db db = new Db();

                using (
                    SqlConnection conn =
                        db.GetConnection()
                )
                {
                    conn.Open();

                    string sql =
                        @"
                UPDATE nhan_vien
                SET
                    pin_code = @pin,
                    updated_at = GETDATE()
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

                    cmd.Parameters.AddWithValue(
                        "@pin",
                        pinMoi
                    );

                    int rows =
                        cmd.ExecuteNonQuery();

                    return Ok(rows);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ex.Message
                );
            }
        }
    }
}