using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.Models;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamCongController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public ChamCongController(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<ChamCong> ds =
                new List<ChamCong>();

            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT
                cc.id,
                cc.nhan_vien_id,
                nv.ho_ten,
                cc.ngay_lam,
                cc.ca_lam_id,
                cl.ten_ca,
                cl.gio_bat_dau,
                cl.gio_ket_thuc,
                cc.check_in,
                cc.check_out,
                cl.phut_cho_phep_di_tre,
                cl.phut_cho_phep_ve_som,
                cl.phut_cho_phep_checkin_som,
                cl.phut_cho_phep_checkout_tre
            FROM cham_cong cc
            JOIN nhan_vien nv
                ON cc.nhan_vien_id = nv.id
            JOIN ca_lam cl
                ON cc.ca_lam_id = cl.id
        ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime tempDate;

                    ChamCong item =
                        new ChamCong
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

                            ho_ten =
                                reader["ho_ten"]
                                .ToString(),

                            ngay_lam =
                                DateTime.TryParse(
                                    reader["ngay_lam"].ToString(),
                                    out tempDate)
                                ? tempDate
                                : null,

                            ca_lam_id =
                                int.TryParse(
                                    reader["ca_lam_id"].ToString(),
                                    out int caLamId)
                                ? caLamId
                                : null,

                            ten_ca =
                                reader["ten_ca"]
                                .ToString(),

                            gio_bat_dau =
                                reader["gio_bat_dau"]
                                .ToString(),

                            gio_ket_thuc =
                                reader["gio_ket_thuc"]
                                .ToString(),

                            check_in =
                                DateTime.TryParse(
                                    reader["check_in"].ToString(),
                                    out tempDate)
                                ? tempDate
                                : null,

                            check_out =
                                DateTime.TryParse(
                                    reader["check_out"].ToString(),
                                    out tempDate)
                                ? tempDate
                                : null,

                            phut_cho_phep_di_tre =
                                int.TryParse(
                                    reader["phut_cho_phep_di_tre"].ToString(),
                                    out int diTre)
                                ? diTre
                                : 0,

                            phut_cho_phep_ve_som =
                                int.TryParse(
                                    reader["phut_cho_phep_ve_som"].ToString(),
                                    out int veSom)
                                ? veSom
                                : 0,

                            phut_cho_phep_checkin_som =
                                int.TryParse(
                                    reader["phut_cho_phep_checkin_som"].ToString(),
                                    out int checkinSom)
                                ? checkinSom
                                : 0,

                            phut_cho_phep_checkout_tre =
                                int.TryParse(
                                    reader["phut_cho_phep_checkout_tre"].ToString(),
                                    out int checkoutTre)
                                ? checkoutTre
                                : 0
                        };

                    DateTime ngayLam =
                        item.ngay_lam
                        ?? DateTime.Now;

                    TimeSpan gioBatDau =
                        TimeSpan.Parse(
                            item.gio_bat_dau
                        );

                    TimeSpan gioKetThuc =
                        TimeSpan.Parse(
                            item.gio_ket_thuc
                        );

                    DateTime batDauCa =
                        ngayLam.Date.Add(
                            gioBatDau
                        );

                    DateTime ketThucCa =
                        ngayLam.Date.Add(
                            gioKetThuc
                        );

                    if (ketThucCa < batDauCa)
                    {
                        ketThucCa =
                            ketThucCa.AddDays(1);
                    }

                    if (
                        item.check_in == null
                        ||
                        item.check_out == null
                    )
                    {
                        item.so_phut_di_som = 0;
                        item.so_phut_di_tre = 0;
                        item.so_phut_ve_som = 0;
                        item.so_phut_ve_tre = 0;
                        item.so_phut_tang_ca = 0;
                        item.so_phut_bi_tru = 0;
                        item.trang_thai = "Nghỉ";
                    }
                    else
                    {
                        DateTime checkIn =
                            item.check_in.Value;

                        DateTime checkOut =
                            item.check_out.Value;

                        int soPhutDiSom = 0;
                        int soPhutDiTre = 0;
                        int soPhutVeSom = 0;
                        int soPhutVeTre = 0;

                        if (checkIn < batDauCa)
                        {
                            soPhutDiSom =
                                (int)(
                                    batDauCa - checkIn
                                ).TotalMinutes;
                        }

                        if (checkIn > batDauCa)
                        {
                            soPhutDiTre =
                                (int)(
                                    checkIn - batDauCa
                                ).TotalMinutes;
                        }

                        if (checkOut < ketThucCa)
                        {
                            soPhutVeSom =
                                (int)(
                                    ketThucCa - checkOut
                                ).TotalMinutes;
                        }

                        if (checkOut > ketThucCa)
                        {
                            soPhutVeTre =
                                (int)(
                                    checkOut - ketThucCa
                                ).TotalMinutes;
                        }

                        item.so_phut_di_som =
                            soPhutDiSom;

                        item.so_phut_di_tre =
                            soPhutDiTre;

                        item.so_phut_ve_som =
                            soPhutVeSom;

                        item.so_phut_ve_tre =
                            soPhutVeTre;

                        item.so_phut_tang_ca =
                            soPhutVeTre;

                        item.so_phut_bi_tru =
                            soPhutDiTre
                            + soPhutVeSom;

                        if (
                            soPhutDiTre == 0
                            &&
                            soPhutVeSom == 0
                        )
                        {
                            item.trang_thai =
                                "Đúng giờ";
                        }
                        else
                        {
                            item.trang_thai =
                                "Không đúng giờ";
                        }
                    }

                    ds.Add(item);
                }
            }

            return Ok(ds);
        }

        [HttpPost("checkin/{nhanVienId}")]
        public IActionResult CheckIn(
            string nhanVienId
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sqlCheck =
                    @"
                    SELECT TOP 1 *
                    FROM cham_cong
                    WHERE nhan_vien_id =
                        @nhan_vien_id
                    AND CAST(ngay_lam AS DATE)
                        =
                        CAST(GETDATE() AS DATE)
                ";

                SqlCommand checkCmd =
                    new SqlCommand(
                        sqlCheck,
                        conn
                    );

                checkCmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    nhanVienId
                );

                SqlDataReader reader =
                    checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();

                    return BadRequest(
                        "Đã check in hôm nay"
                    );
                }

                reader.Close();

                string sqlCa =
                @"
                SELECT TOP 1
                    cl.id AS ca_lam_id
                FROM phan_ca pc
                JOIN ca_lam cl
                    ON pc.ca_lam_id = cl.id
                WHERE
                    pc.nhan_vien_id = @nhan_vien_id
                    AND
                    CAST(GETDATE() AS TIME)
                    BETWEEN
                        DATEADD(
                            MINUTE,
                            -cl.phut_cho_phep_checkin_som,
                            cl.gio_bat_dau
                        )
                    AND
                        cl.gio_ket_thuc
                ORDER BY cl.gio_bat_dau
                ";

                SqlCommand caCmd =
                    new SqlCommand(
                        sqlCa,
                        conn
                    );

                caCmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    nhanVienId
                );

                SqlDataReader caReader =
                    caCmd.ExecuteReader();

                if (!caReader.Read())
                {
                    caReader.Close();

                    return BadRequest(
                        "Nhân viên chưa được phân ca"
                    );
                }

                int caLamId =
                    Convert.ToInt32(
                        caReader["ca_lam_id"]
                    );

                caReader.Close();

                string insertSql =
                    @"
                    INSERT INTO cham_cong
                    (
                        nhan_vien_id,
                        ngay_lam,
                        ca_lam_id,
                        check_in
                    )
                    VALUES
                    (
                        @nhan_vien_id,
                        GETDATE(),
                        @ca_lam_id,
                        GETDATE()
                    )
                ";

                SqlCommand insertCmd =
                    new SqlCommand(
                        insertSql,
                        conn
                    );

                insertCmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    nhanVienId
                );

                insertCmd.Parameters.AddWithValue(
                    "@ca_lam_id",
                    caLamId
                );

                insertCmd.ExecuteNonQuery();

                return Ok(
                    "Check in thành công"
                );
            }
        }

        [HttpPost("checkout/{nhanVienId}")]
        public IActionResult CheckOut(
            string nhanVienId
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql =
                    @"
                    UPDATE cham_cong
                    SET check_out = GETDATE()
                    WHERE nhan_vien_id =
                        @nhan_vien_id
                    AND CAST(ngay_lam AS DATE)
                        =
                        CAST(GETDATE() AS DATE)
                    AND check_out IS NULL
                ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    nhanVienId
                );

                int row =
                    cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    return Ok(
                        "Check out thành công"
                    );
                }

                return BadRequest(
                    "Chưa check in"
                );
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            int id
        )
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql =
                    @"
            SELECT TOP 1 *
            FROM cham_cong
            WHERE id = @id
        ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@id",
                    id
                );

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (!reader.Read())
                {
                    return NotFound();
                }

                DateTime tempDate;

                ChamCong item =
                    new ChamCong
                    {
                        id =
                            Convert.ToInt32(
                                reader["id"]
                            ),

                        nhan_vien_id =
                            reader["nhan_vien_id"]
                            .ToString(),

                        ngay_lam =
                            DateTime.TryParse(
                                reader["ngay_lam"].ToString(),
                                out tempDate)
                            ? tempDate
                            : null,

                        ca_lam_id =
                            Convert.ToInt32(
                                reader["ca_lam_id"]
                            ),

                        check_in =
                            DateTime.TryParse(
                                reader["check_in"].ToString(),
                                out tempDate)
                            ? tempDate
                            : null,

                        check_out =
                            DateTime.TryParse(
                                reader["check_out"].ToString(),
                                out tempDate)
                            ? tempDate
                            : null
                    };

                return Ok(item);
            }
        }

        [HttpPost]
        public IActionResult Insert(
    [FromBody] ChamCong item
)
        {
            Db db = new Db();

            using (SqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                string sql =
                    @"
            INSERT INTO cham_cong
            (
                nhan_vien_id,
                ngay_lam,
                ca_lam_id,
                check_in,
                check_out
            )
            VALUES
            (
                @nhan_vien_id,
                @ngay_lam,
                @ca_lam_id,
                @check_in,
                @check_out
            )
        ";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@nhan_vien_id",
                    item.nhan_vien_id
                );

                cmd.Parameters.AddWithValue(
                    "@ngay_lam",
                    item.ngay_lam
                );

                cmd.Parameters.AddWithValue(
                    "@ca_lam_id",
                    item.ca_lam_id
                );

                cmd.Parameters.AddWithValue(
                    "@check_in",
                    item.check_in
                );

                cmd.Parameters.AddWithValue(
                    "@check_out",
                    item.check_out
                );

                cmd.ExecuteNonQuery();

                return Ok(new
                {
                    message = "Thêm thành công"
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(
        int id,
        [FromBody] ChamCong item
    )
            {
                Db db = new Db();

                using (SqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string sql =
                        @"
                UPDATE cham_cong
                SET
                    nhan_vien_id =
                        @nhan_vien_id,

                    ngay_lam =
                        @ngay_lam,

                    ca_lam_id =
                        @ca_lam_id,

                    check_in =
                        @check_in,

                    check_out =
                        @check_out
                WHERE id = @id
            ";

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
                        "@ngay_lam",
                        item.ngay_lam
                    );

                    cmd.Parameters.AddWithValue(
                        "@ca_lam_id",
                        item.ca_lam_id
                    );

                    cmd.Parameters.AddWithValue(
                        "@check_in",
                        item.check_in
                    );

                    cmd.Parameters.AddWithValue(
                        "@check_out",
                        item.check_out
                    );

                    int row =
                        cmd.ExecuteNonQuery();

                    if (row > 0)
                    {
                        return Ok(new
                        {
                            message = "Cập nhật thành công"
                        });
                    }

                    return NotFound();
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

                string sql =
                    "DELETE FROM cham_cong WHERE id = @id";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

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
                        message = "Xóa thành công"
                    });
                }

                return NotFound();
            }
        }

        [HttpGet("BaoCaoTongHop")]
        public IActionResult BaoCaoTongHop(
    string nhanVienId,
    DateTime tuNgay,
    DateTime denNgay
)
        {
            try
            {
                DataTable dt =
                    new DataTable();

                using (
                    SqlConnection conn =
                        new SqlConnection(
                            _configuration
                            .GetConnectionString(
                                "DefaultConnection"
                            )
                        )
                )
                {
                    conn.Open();

                    string sql =
                    @"
                    SELECT
                        nv.id,
                        nv.ho_ten,

                        COUNT(cc.id)
                            AS tong_ngay_cong,

                        SUM(
                            CASE
                                WHEN
                                    CAST(cc.check_in AS TIME)
                                    > '08:00:00'
                                THEN 1
                                ELSE 0
                            END
                        ) AS tong_di_tre,

                        SUM(
                            CASE
                                WHEN cc.check_in IS NULL
                                THEN 1
                                ELSE 0
                            END
                        ) AS tong_vang

                    FROM cham_cong cc

                    INNER JOIN nhan_vien nv
                        ON cc.nhan_vien_id = nv.id

                    WHERE
                        cc.ngay_lam >= @tuNgay
                        AND cc.ngay_lam <= @denNgay
                    ";

                    if (
                        nhanVienId
                        != "TATCA"
                    )
                    {
                        sql +=
                            @"
                    AND nv.id = @nhanVienId
                    ";
                    }

                    sql +=
                        @"
                GROUP BY
                    nv.id,
                    nv.ho_ten

                ORDER BY
                    nv.id
                ";

                    SqlCommand cmd =
                        new SqlCommand(
                            sql,
                            conn
                        );

                    cmd.Parameters.AddWithValue(
                        "@tuNgay",
                        tuNgay
                    );

                    cmd.Parameters.AddWithValue(
                        "@denNgay",
                        denNgay
                    );

                    if (
                        nhanVienId
                        != "TATCA"
                    )
                    {
                        cmd.Parameters.AddWithValue(
                            "@nhanVienId",
                            nhanVienId
                        );
                    }

                    SqlDataAdapter da =
                        new SqlDataAdapter(cmd);

                    da.Fill(dt);
                }

                return Ok(dt);
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