using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QuanLyChamCong.API.Models;
using System.Data;
using System.Collections.Generic;

namespace QuanLyChamCong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangLuongChotController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public BangLuongChotController(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _connectionString =_configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection")
            );
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<BangLuongChot> ds =
                    new List<BangLuongChot>();

                using (
                    SqlConnection conn = GetConnection()
                )
                {
                    conn.Open();

                    string query =
                        @"SELECT * 
                          FROM bang_luong_chot
                          ORDER BY id DESC";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    SqlDataReader reader =
                        cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ds.Add(
                            MapBangLuongChot(reader)
                        );
                    }
                }

                return Ok(ds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                BangLuongChot item = null;

                using (
                    SqlConnection conn = GetConnection()
                )
                {
                    conn.Open();

                    string query =
                        @"SELECT *
                          FROM bang_luong_chot
                          WHERE id = @id";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@id",
                        id
                    );

                    SqlDataReader reader =
                        cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        item =
                            MapBangLuongChot(reader);
                    }
                }

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("thangnam")]
        public IActionResult GetByThangNam(
            int thang,
            int nam
        )
        {
            try
            {
                List<BangLuongChot> ds =
                    new List<BangLuongChot>();

                using (
                    SqlConnection conn = GetConnection()
                )
                {
                    conn.Open();

                    string query =
                        @"SELECT *
                          FROM bang_luong_chot
                          WHERE thang = @thang
                          AND nam = @nam
                          ORDER BY id DESC";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@thang",
                        thang
                    );

                    cmd.Parameters.AddWithValue(
                        "@nam",
                        nam
                    );

                    SqlDataReader reader =
                        cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ds.Add(
                            MapBangLuongChot(reader)
                        );
                    }
                }

                return Ok(ds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("nhanvien/{nhanVienId}")]
        public IActionResult GetByNhanVien(
            string nhanVienId
        )
        {
            try
            {
                List<BangLuongChot> ds =
                    new List<BangLuongChot>();

                using (
                    SqlConnection conn = GetConnection()
                )
                {
                    conn.Open();

                    string query =
                        @"SELECT *
                          FROM bang_luong_chot
                          WHERE nhan_vien_id = @nhanVienId
                          ORDER BY id DESC";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@nhanVienId",
                        nhanVienId
                    );

                    SqlDataReader reader =
                        cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ds.Add(
                            MapBangLuongChot(reader)
                        );
                    }
                }

                return Ok(ds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DaChotLuong")]
        public IActionResult DaChotLuong(
            int thang,
            int nam
        )
        {
            try
            {
                bool daChot = false;

                using (
                    SqlConnection conn =
                        GetConnection()
                )
                {
                    conn.Open();

                    string query =
                        @"
                SELECT COUNT(*)
                FROM bang_luong_chot
                WHERE thang = @thang
                AND nam = @nam";

                    SqlCommand cmd =
                        new SqlCommand(
                            query,
                            conn
                        );

                    cmd.Parameters.AddWithValue(
                        "@thang",
                        thang
                    );

                    cmd.Parameters.AddWithValue(
                        "@nam",
                        nam
                    );

                    int count =
                        Convert.ToInt32(
                            cmd.ExecuteScalar()
                        );

                    daChot =
                        count > 0;
                }

                return Ok(daChot);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ex.Message
                );
            }
        }
        [HttpGet("LayBangLuongDaChot")]
        public IActionResult LayBangLuongDaChot(
            int thang,
            int nam
        )
        {
            try
            {
                DataTable dt =
                    new DataTable();

                using (
                    SqlConnection conn =
                        GetConnection()
                )
                {
                    conn.Open();

                    string query =
                        @"
                SELECT
                    blc.nhan_vien_id,

                    nv.ho_ten,

                    nv.loai_luong,

                    blc.luong_co_ban,

                    blc.luong_theo_gio,

                    blc.phu_cap
                        AS phu_cap_mac_dinh,

                    blc.luong_tang_ca_theo_gio,

                    blc.tong_ca_duoc_phan,

                    blc.tong_ca_di_lam,

                    blc.tong_ca_nghi,

                    blc.tong_phut_di_tre,

                    blc.tong_phut_ve_som,

                    blc.tong_phut_bi_tru,

                    blc.tong_phut_tang_ca,

                    blc.tong_luong_chinh,

                    blc.tong_luong_tang_ca,

                    blc.tong_gio_lam AS tong_gio_lam,

                    blc.thuong,

                    blc.tong_luong,

                    blc.phat

                FROM bang_luong_chot blc

                LEFT JOIN nhan_vien nv
                ON blc.nhan_vien_id = nv.id

                WHERE blc.thang = @thang
                AND blc.nam = @nam

                ORDER BY blc.nhan_vien_id";

                    SqlCommand cmd =
                        new SqlCommand(
                            query,
                            conn
                        );

                    cmd.Parameters.AddWithValue(
                        "@thang",
                        thang
                    );

                    cmd.Parameters.AddWithValue(
                        "@nam",
                        nam
                    );

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

        [HttpGet("TinhLuongThang")]
        public IActionResult TinhLuongThang(
            int thang,
            int nam
        )
        {
            try
            {
                DataTable dt =
                    new DataTable();

                using (
                    SqlConnection conn =
                        GetConnection()
                )
                {
                    conn.Open();

                    string sql = @"
            SELECT
                nv.id AS nhan_vien_id,
                nv.ho_ten,
                nv.loai_luong,

                ISNULL(ch.luong_co_ban, 0)
                    AS luong_co_ban,

                ISNULL(ch.luong_theo_gio, 0)
                    AS luong_theo_gio,

                ISNULL(ch.phu_cap_mac_dinh, 0)
                    AS phu_cap_mac_dinh,

                ISNULL(ch.luong_tang_ca, 0)
                    AS luong_tang_ca_theo_gio,

                COUNT(DISTINCT pc.id)
                    AS tong_ca_duoc_phan,

                CONVERT(
                    BIGINT,
                    SUM(
                        CASE
                            WHEN cc.check_in IS NOT NULL
                             AND cc.check_out IS NOT NULL
                            THEN 1
                            ELSE 0
                        END
                    )
                ) AS tong_ca_di_lam,

                CONVERT(
                    BIGINT,
                    SUM(
                        CASE
                            WHEN cc.check_in IS NULL
                              OR cc.check_out IS NULL
                            THEN 1
                            ELSE 0
                        END
                    )
                ) AS tong_ca_nghi,

                CONVERT(
                    BIGINT,
                    ISNULL(
                        SUM(
                            CASE
                                WHEN CAST(cc.check_in AS TIME)
                                    > cl.gio_bat_dau
                                THEN DATEDIFF(
                                    MINUTE,
                                    DATEADD(
                                        DAY,
                                        DATEDIFF(
                                            DAY,
                                            0,
                                            cc.ngay_lam
                                        ),
                                        CAST(
                                            cl.gio_bat_dau
                                            AS DATETIME
                                        )
                                    ),
                                    cc.check_in
                                )
                                ELSE 0
                            END
                        ),
                        0
                    )
                ) AS tong_phut_di_tre,

                CONVERT(
                    BIGINT,
                    ISNULL(
                        SUM(
                            CASE
                                WHEN CAST(cc.check_out AS TIME)
                                    < cl.gio_ket_thuc
                                THEN DATEDIFF(
                                    MINUTE,
                                    cc.check_out,
                                    DATEADD(
                                        DAY,
                                        DATEDIFF(
                                            DAY,
                                            0,
                                            cc.ngay_lam
                                        ),
                                        CAST(
                                            cl.gio_ket_thuc
                                            AS DATETIME
                                        )
                                    )
                                )
                                ELSE 0
                            END
                        ),
                        0
                    )
                ) AS tong_phut_ve_som,

                CONVERT(
                    BIGINT,
                    ISNULL(
                        SUM(
                            CASE
                                WHEN CAST(cc.check_in AS TIME)
                                    > cl.gio_bat_dau
                                THEN DATEDIFF(
                                    MINUTE,
                                    DATEADD(
                                        DAY,
                                        DATEDIFF(
                                            DAY,
                                            0,
                                            cc.ngay_lam
                                        ),
                                        CAST(
                                            cl.gio_bat_dau
                                            AS DATETIME
                                        )
                                    ),
                                    cc.check_in
                                )
                                ELSE 0
                            END
                        ),
                        0
                    )
                    +
                    ISNULL(
                        SUM(
                            CASE
                                WHEN CAST(cc.check_out AS TIME)
                                    < cl.gio_ket_thuc
                                THEN DATEDIFF(
                                    MINUTE,
                                    cc.check_out,
                                    DATEADD(
                                        DAY,
                                        DATEDIFF(
                                            DAY,
                                            0,
                                            cc.ngay_lam
                                        ),
                                        CAST(
                                            cl.gio_ket_thuc
                                            AS DATETIME
                                        )
                                    )
                                )
                                ELSE 0
                            END
                        ),
                        0
                    )
                ) AS tong_phut_bi_tru,

                CONVERT(
                    BIGINT,
                    ISNULL(
                        SUM(
                            CASE
                                WHEN CAST(cc.check_out AS TIME)
                                    > cl.gio_ket_thuc
                                THEN DATEDIFF(
                                    MINUTE,
                                    DATEADD(
                                        DAY,
                                        DATEDIFF(
                                            DAY,
                                            0,
                                            cc.ngay_lam
                                        ),
                                        CAST(
                                            cl.gio_ket_thuc
                                            AS DATETIME
                                        )
                                    ),
                                    cc.check_out
                                )
                                ELSE 0
                            END
                        ),
                        0
                    )
                ) AS tong_phut_tang_ca,

                CONVERT(
                    DECIMAL(10,2),

                    (
                        ISNULL(
                            SUM(
                                CASE
                                    WHEN cc.check_in IS NOT NULL
                                     AND cc.check_out IS NOT NULL
                                    THEN DATEDIFF(
                                        MINUTE,
                                        cc.check_in,
                                        cc.check_out
                                    )
                                    ELSE 0
                                END
                            ),
                            0
                        ) / 60.0
                    )
                ) AS tong_gio_lam,
                    
                    CAST(0 AS DECIMAL(18,2))
                    AS tong_luong_chinh,

                    CAST(0 AS DECIMAL(18,2))
                        AS tong_luong_tang_ca,

                    CAST(0 AS DECIMAL(18,2))
                        AS tong_luong,
                ISNULL(
                    tp.tong_thuong,
                    0
                ) AS thuong,

                ISNULL(
                    tp.tong_phat,
                    0
                ) AS phat

            FROM nhan_vien nv

            LEFT JOIN cau_hinh_luong ch
                ON nv.id = ch.nhan_vien_id

            LEFT JOIN phan_ca pc
                ON nv.id = pc.nhan_vien_id
                AND MONTH(pc.ngay_lam) = @thang
                AND YEAR(pc.ngay_lam) = @nam

            LEFT JOIN ca_lam cl
                ON pc.ca_lam_id = cl.id

            LEFT JOIN cham_cong cc
                ON pc.nhan_vien_id = cc.nhan_vien_id
                AND pc.ca_lam_id = cc.ca_lam_id
                AND pc.ngay_lam = cc.ngay_lam

            LEFT JOIN
            (
                SELECT
                    nhan_vien_id,

                    SUM(
                        CASE
                            WHEN loai = N'Thưởng'
                            THEN so_tien
                            ELSE 0
                        END
                    ) AS tong_thuong,

                    SUM(
                        CASE
                            WHEN loai = N'Phạt'
                            THEN so_tien
                            ELSE 0
                        END
                    ) AS tong_phat

                FROM thuong_phat

                WHERE
                    MONTH(ngay) = @thang
                    AND YEAR(ngay) = @nam

                GROUP BY nhan_vien_id
            ) tp
            ON nv.id = tp.nhan_vien_id

            GROUP BY
                nv.id,
                nv.ho_ten,
                nv.loai_luong,
                ch.luong_co_ban,
                ch.luong_theo_gio,
                ch.phu_cap_mac_dinh,
                ch.luong_tang_ca,
                tp.tong_thuong,
                tp.tong_phat

            ORDER BY nv.ho_ten";

                    SqlCommand cmd =
                        new SqlCommand(
                            sql,
                            conn
                        );

                    cmd.Parameters.AddWithValue(
                        "@thang",
                        thang
                    );

                    cmd.Parameters.AddWithValue(
                        "@nam",
                        nam
                    );

                    SqlDataAdapter da =
                        new SqlDataAdapter(cmd);

                    da.Fill(dt);
                }

                foreach (DataRow r in dt.Rows)
                {
                    string loaiLuong =
                        r["loai_luong"]
                            .ToString();

                    decimal tongGioLam =
                        Convert.ToDecimal(
                            r["tong_gio_lam"]
                        );

                    int tongPhutTangCa =
                        Convert.ToInt32(
                            r["tong_phut_tang_ca"]
                        );

                    decimal luongCoBan =
                        Convert.ToDecimal(
                            r["luong_co_ban"]
                        );

                    decimal luongTheoGio =
                        Convert.ToDecimal(
                            r["luong_theo_gio"]
                        );

                    decimal luongTangCaTheoGio =
                        Convert.ToDecimal(
                            r["luong_tang_ca_theo_gio"]
                        );

                    decimal phuCap =
                        Convert.ToDecimal(
                            r["phu_cap_mac_dinh"]
                        );

                    decimal thuong =
                        Convert.ToDecimal(
                            r["thuong"]
                        );

                    decimal phat =
                        Convert.ToDecimal(
                            r["phat"]
                        );

                    decimal tongLuongChinh =
                        0;

                    if (
                        loaiLuong == "Tháng"
                    )
                    {
                        tongLuongChinh =
                            luongCoBan;
                    }
                    else
                    {
                        tongLuongChinh =
                            tongGioLam
                            * luongTheoGio;
                    }

                    decimal tongLuongTangCa =
                        (
                            tongPhutTangCa
                            / 60m
                        )
                        * luongTangCaTheoGio;

                    decimal tongLuong =
                        tongLuongChinh
                        + tongLuongTangCa
                        + phuCap
                        + thuong
                        - phat;

                    r["tong_luong_chinh"] =
                        tongLuongChinh;

                    r["tong_luong_tang_ca"] =
                        tongLuongTangCa;

                    r["tong_luong"] =
                        tongLuong;
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

        [HttpPost]
        public IActionResult Insert(
            BangLuongChot model
        )
        {
            try
            {
                using (
                    SqlConnection conn =
                        GetConnection()
                )
                {
                    conn.Open();

                    string checkSql =
                        @"
                SELECT COUNT(*)
                FROM bang_luong_chot
                WHERE
                    nhan_vien_id = @nhan_vien_id
                    AND thang = @thang
                    AND nam = @nam";

                    SqlCommand checkCmd =
                        new SqlCommand(
                            checkSql,
                            conn
                        );

                    checkCmd.Parameters.AddWithValue(
                        "@nhan_vien_id",
                        model.nhan_vien_id
                    );

                    checkCmd.Parameters.AddWithValue(
                        "@thang",
                        model.thang
                    );

                    checkCmd.Parameters.AddWithValue(
                        "@nam",
                        model.nam
                    );

                    int daTonTai =
                        Convert.ToInt32(
                            checkCmd.ExecuteScalar()
                        );

                    if (daTonTai > 0)
                    {
                        return BadRequest(
                            "Tháng này đã chốt lương"
                        );
                    }

                    string query =
                        @"INSERT INTO bang_luong_chot
                (
                    nhan_vien_id,
                    thang,
                    nam,
                    tong_ca_duoc_phan,
                    tong_ca_di_lam,
                    tong_ca_nghi,
                    tong_phut_di_tre,
                    tong_phut_ve_som,
                    tong_phut_bi_tru,
                    tong_phut_tang_ca,
                    luong_co_ban,
                    luong_theo_gio,
                    luong_tang_ca_theo_gio,
                    tong_luong_chinh,
                    tong_luong_tang_ca,
                    tong_gio_lam,
                    phu_cap,
                    thuong,
                    phat,
                    tong_luong,
                    nguoi_chot,
                    ngay_chot,
                    created_at
                )
                VALUES
                (
                    @nhan_vien_id,
                    @thang,
                    @nam,
                    @tong_ca_duoc_phan,
                    @tong_ca_di_lam,
                    @tong_ca_nghi,
                    @tong_phut_di_tre,
                    @tong_phut_ve_som,
                    @tong_phut_bi_tru,
                    @tong_phut_tang_ca,
                    @tong_gio_lam,
                    @luong_co_ban,
                    @luong_theo_gio,
                    @luong_tang_ca_theo_gio,
                    @tong_luong_chinh,
                    @tong_luong_tang_ca,
                    @phu_cap,
                    @thuong,
                    @phat,
                    @tong_luong,
                    @nguoi_chot,
                    @ngay_chot,
                    @created_at
                )";

                    SqlCommand cmd =
                        new SqlCommand(
                            query,
                            conn
                        );

                    AddParameters(
                        cmd,
                        model
                    );

                    cmd.ExecuteNonQuery();
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ex.Message
                );
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            BangLuongChot model
        )
        {
            try
            {
                using (
                    SqlConnection conn = GetConnection()
                )
                {
                    conn.Open();

                    string query =
                        @"UPDATE bang_luong_chot
                        SET
                            nhan_vien_id = @nhan_vien_id,
                            thang = @thang,
                            nam = @nam,
                            tong_ca_duoc_phan = @tong_ca_duoc_phan,
                            tong_ca_di_lam = @tong_ca_di_lam,
                            tong_ca_nghi = @tong_ca_nghi,
                            tong_phut_di_tre = @tong_phut_di_tre,
                            tong_phut_ve_som = @tong_phut_ve_som,
                            tong_phut_bi_tru = @tong_phut_bi_tru,
                            tong_phut_tang_ca = @tong_phut_tang_ca,
                            luong_co_ban = @luong_co_ban,
                            luong_theo_gio = @luong_theo_gio,
                            luong_tang_ca_theo_gio = @luong_tang_ca_theo_gio,
                            tong_luong_chinh = @tong_luong_chinh,
                            tong_luong_tang_ca = @tong_luong_tang_ca,
                            phu_cap = @phu_cap,
                            thuong = @thuong,
                            phat = @phat,
                            tong_luong = @tong_luong,
                            nguoi_chot = @nguoi_chot,
                            ngay_chot = @ngay_chot
                        WHERE id = @id";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    AddParameters(cmd, model);

                    cmd.Parameters.AddWithValue(
                        "@id",
                        id
                    );

                    cmd.ExecuteNonQuery();
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (
                    SqlConnection conn = GetConnection()
                )
                {
                    conn.Open();

                    string query =
                        @"DELETE FROM bang_luong_chot
                          WHERE id = @id";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@id",
                        id
                    );

                    cmd.ExecuteNonQuery();
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private BangLuongChot MapBangLuongChot(
            SqlDataReader reader
        )
        {
            return new BangLuongChot
            {
                id = Convert.ToInt32(reader["id"]),
                nhan_vien_id = reader["nhan_vien_id"].ToString(),
                thang = Convert.ToInt32(reader["thang"]),
                nam = Convert.ToInt32(reader["nam"]),
                tong_ca_duoc_phan = Convert.ToInt32(reader["tong_ca_duoc_phan"]),
                tong_ca_di_lam = Convert.ToInt32(reader["tong_ca_di_lam"]),
                tong_ca_nghi = Convert.ToInt32(reader["tong_ca_nghi"]),
                tong_phut_di_tre = Convert.ToInt32(reader["tong_phut_di_tre"]),
                tong_phut_ve_som = Convert.ToInt32(reader["tong_phut_ve_som"]),
                tong_phut_bi_tru = Convert.ToInt32(reader["tong_phut_bi_tru"]),
                tong_phut_tang_ca = Convert.ToInt32(reader["tong_phut_tang_ca"]),
                luong_co_ban = Convert.ToDecimal(reader["luong_co_ban"]),
                luong_theo_gio = Convert.ToDecimal(reader["luong_theo_gio"]),
                luong_tang_ca_theo_gio = Convert.ToDecimal(reader["luong_tang_ca_theo_gio"]),
                tong_luong_chinh = Convert.ToDecimal(reader["tong_luong_chinh"]),
                tong_luong_tang_ca = Convert.ToDecimal(reader["tong_luong_tang_ca"]),
                phu_cap = Convert.ToDecimal(reader["phu_cap"]),
                thuong = Convert.ToDecimal(reader["thuong"]),
                phat = Convert.ToDecimal(reader["phat"]),
                tong_luong = Convert.ToDecimal(reader["tong_luong"]),
                nguoi_chot = reader["nguoi_chot"].ToString(),
                ngay_chot = Convert.ToDateTime(reader["ngay_chot"]),
                created_at = Convert.ToDateTime(reader["created_at"])
            };
        }

        private void AddParameters(
            SqlCommand cmd,
            BangLuongChot model
        )
        {
            cmd.Parameters.AddWithValue("@nhan_vien_id", model.nhan_vien_id);
            cmd.Parameters.AddWithValue("@thang", model.thang);
            cmd.Parameters.AddWithValue("@nam", model.nam);
            cmd.Parameters.AddWithValue("@tong_ca_duoc_phan", model.tong_ca_duoc_phan);
            cmd.Parameters.AddWithValue("@tong_ca_di_lam", model.tong_ca_di_lam);
            cmd.Parameters.AddWithValue("@tong_ca_nghi", model.tong_ca_nghi);
            cmd.Parameters.AddWithValue("@tong_phut_di_tre", model.tong_phut_di_tre);
            cmd.Parameters.AddWithValue("@tong_phut_ve_som", model.tong_phut_ve_som);
            cmd.Parameters.AddWithValue("@tong_phut_bi_tru", model.tong_phut_bi_tru);
            cmd.Parameters.AddWithValue("@tong_phut_tang_ca", model.tong_phut_tang_ca);
            cmd.Parameters.AddWithValue("@tong_gio_lam",model.tong_gio_lam);
            cmd.Parameters.AddWithValue("@luong_co_ban", model.luong_co_ban);
            cmd.Parameters.AddWithValue("@luong_theo_gio", model.luong_theo_gio);
            cmd.Parameters.AddWithValue("@luong_tang_ca_theo_gio", model.luong_tang_ca_theo_gio);
            cmd.Parameters.AddWithValue("@tong_luong_chinh", model.tong_luong_chinh);
            cmd.Parameters.AddWithValue("@tong_luong_tang_ca", model.tong_luong_tang_ca);
            cmd.Parameters.AddWithValue("@phu_cap", model.phu_cap);
            cmd.Parameters.AddWithValue("@thuong", model.thuong);
            cmd.Parameters.AddWithValue("@phat", model.phat);
            cmd.Parameters.AddWithValue("@tong_luong", model.tong_luong);
            cmd.Parameters.AddWithValue("@nguoi_chot", model.nguoi_chot ?? "");
            cmd.Parameters.AddWithValue("@ngay_chot", model.ngay_chot);
            cmd.Parameters.AddWithValue("@created_at", model.created_at);
        }
    }
}