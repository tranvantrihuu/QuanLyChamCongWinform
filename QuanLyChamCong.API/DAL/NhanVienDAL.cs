
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuanLyChamCong.API.Data;
using QuanLyChamCong.API.DTO;
using QuanLyChamCong.API.Models;
using System.Data;

namespace QuanLyChamCong.API.DAL
{
    public class NhanVienDAL
    {
        private readonly AppDbContext _context;
        private readonly Db _db;

        public NhanVienDAL(
            AppDbContext context,
            Db db
        )
        {
            _context = context;
            _db = db;
        }

        // =========================
        // VIEW
        // vw_danh_sach_nhan_vien
        // =========================

        public async Task<List<NhanVien>>
            GetAll()
        {
            using SqlConnection conn =
                _db.GetConnection();

            await conn.OpenAsync();

            string sql =
                @"SELECT *
                  FROM vw_danh_sach_nhan_vien";

            SqlCommand cmd =
                new SqlCommand(sql, conn);

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            List<NhanVien> ds =
                new List<NhanVien>();

            while (await reader.ReadAsync())
            {
                ds.Add(new NhanVien
                {
                    id =
                        reader["id"]
                        .ToString() ?? "",

                    ma_van_tay =
                        reader["ma_van_tay"]
                        .ToString() ?? "",

                    ho_ten =
                        reader["ho_ten"]
                        .ToString() ?? "",

                    so_dien_thoai =
                        reader["so_dien_thoai"]
                        .ToString(),

                    ngay_sinh =
                        reader["ngay_sinh"]
                        == DBNull.Value
                        ? null
                        : Convert.ToDateTime(
                            reader["ngay_sinh"]
                        ),

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
                        reader["ngay_vao_lam"]
                        == DBNull.Value
                        ? null
                        : Convert.ToDateTime(
                            reader["ngay_vao_lam"]
                        ),

                    loai_luong =
                        reader["loai_luong"]
                        .ToString(),

                    created_at =
                        reader["created_at"]
                        == DBNull.Value
                        ? null
                        : Convert.ToDateTime(
                            reader["created_at"]
                        ),

                    updated_at =
                        reader["updated_at"]
                        == DBNull.Value
                        ? null
                        : Convert.ToDateTime(
                            reader["updated_at"]
                        )
                });
            }

            return ds;
        }

        // =========================
        // LINQ + EF
        // SEARCH
        // =========================

        public async Task<List<NhanVien>>
            Search(
                string keyword
            )
        {
            keyword =
                keyword.ToLower();

            return await _context
                .NhanViens
                .Where(x =>
                    (
                        x.ho_ten != null
                        &&
                        x.ho_ten.ToLower()
                            .Contains(keyword)
                    )
                    ||
                    (
                        x.id != null
                        &&
                        x.id.ToLower()
                            .Contains(keyword)
                    )
                    ||
                    (
                        x.so_dien_thoai != null
                        &&
                        x.so_dien_thoai
                            .Contains(keyword)
                    )
                    ||
                    (
                        x.ma_van_tay != null
                        &&
                        x.ma_van_tay.ToLower()
                            .Contains(keyword)
                    )
                )
                .OrderBy(x => x.ho_ten)
                .Take(10)
                .ToListAsync();
        }

        // =========================
        // LINQ + EF
        // EXISTS ID
        // =========================

        public async Task<bool>
            ExistsID(
                string id
            )
        {
            return await _context
                .NhanViens
                .AnyAsync(x =>
                    x.id == id);
        }

        // =========================
        // LINQ + EF
        // EXISTS FINGERPRINT
        // =========================

        public async Task<bool>
            ExistsMaVanTay(
                string ma
            )
        {
            return await _context
                .NhanViens
                .AnyAsync(x =>
                    x.ma_van_tay == ma);
        }

        // =========================
        // STORED PROCEDURE
        // sp_tim_nhan_vien_theo_pin_hoac_van_tay
        // =========================

        public async Task<NhanVien?>
            GetNhanVien(
                string input
            )
        {
            using SqlConnection conn =
                _db.GetConnection();

            await conn.OpenAsync();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_tim_nhan_vien_theo_pin_hoac_van_tay",
                    conn
                );

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@input",
                input
            );

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
            {
                return null;
            }

            return new NhanVien
            {
                id =
                    reader["id"]
                    .ToString() ?? "",

                ma_van_tay =
                    reader["ma_van_tay"]
                    .ToString() ?? "",

                ho_ten =
                    reader["ho_ten"]
                    .ToString() ?? "",

                so_dien_thoai =
                    reader["so_dien_thoai"]
                    .ToString(),

                ngay_sinh =
                    reader["ngay_sinh"]
                    == DBNull.Value
                    ? null
                    : Convert.ToDateTime(
                        reader["ngay_sinh"]
                    ),

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
                    reader["ngay_vao_lam"]
                    == DBNull.Value
                    ? null
                    : Convert.ToDateTime(
                        reader["ngay_vao_lam"]
                    ),

                loai_luong =
                    reader["loai_luong"]
                    .ToString(),

                created_at =
                    reader["created_at"]
                    == DBNull.Value
                    ? null
                    : Convert.ToDateTime(
                        reader["created_at"]
                    ),

                updated_at =
                    reader["updated_at"]
                    == DBNull.Value
                    ? null
                    : Convert.ToDateTime(
                        reader["updated_at"]
                    )
            };
        }

        // =========================
        // FUNCTION
        // fn_kiem_tra_admin_pin
        // =========================

        public async Task<bool>
            KiemTraAdminPin(
                string pin
            )
        {
            using SqlConnection conn =
                _db.GetConnection();

            await conn.OpenAsync();

            string sql =
                @"SELECT
                    dbo.fn_kiem_tra_admin_pin(@pin)";

            SqlCommand cmd =
                new SqlCommand(
                    sql,
                    conn
                );

            cmd.Parameters.AddWithValue(
                "@pin",
                pin);

            object? result =
                await cmd.ExecuteScalarAsync();

            if (
                result == null
                || result == DBNull.Value
            )
            {
                return false;
            }

            return Convert.ToBoolean(
                result
            );
        }

        // =========================
        // TRANSACTION PROCEDURE
        // trans_them_nhan_vien
        // =========================

        public async Task<bool>
            Insert(
                NhanVien nv
            )
        {
            using SqlConnection conn =
                _db.GetConnection();

            await conn.OpenAsync();

            SqlCommand cmd =
                new SqlCommand(
                    "trans_them_nhan_vien",
                    conn
                );

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id",
                nv.id
            );

            cmd.Parameters.AddWithValue(
                "@ma_van_tay",
                nv.ma_van_tay
            );

            cmd.Parameters.AddWithValue(
                "@ho_ten",
                nv.ho_ten
            );

            cmd.Parameters.AddWithValue(
                "@so_dien_thoai",
                (object?)nv.so_dien_thoai
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@ngay_sinh",
                (object?)nv.ngay_sinh
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@dia_chi",
                (object?)nv.dia_chi
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@vi_tri",
                (object?)nv.vi_tri
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@vai_tro",
                (object?)nv.vai_tro
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@trang_thai",
                (object?)nv.trang_thai
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@pin_code",
                (object?)nv.pin_code
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@ngay_vao_lam",
                (object?)nv.ngay_vao_lam
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@loai_luong",
                (object?)nv.loai_luong
                ?? DBNull.Value
            );

            await cmd.ExecuteNonQueryAsync();

            return true;
        }

        // =========================
        // TRANSACTION PROCEDURE
        // trans_cap_nhat_nhan_vien
        // =========================

        public async Task<bool>
            Update(
                NhanVien nv
            )
        {
            using SqlConnection conn =
                _db.GetConnection();

            await conn.OpenAsync();

            SqlCommand cmd =
                new SqlCommand(
                    "trans_cap_nhat_nhan_vien",
                    conn
                );

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id",
                nv.id
            );

            cmd.Parameters.AddWithValue(
                "@ma_van_tay",
                nv.ma_van_tay
            );

            cmd.Parameters.AddWithValue(
                "@ho_ten",
                nv.ho_ten
            );

            cmd.Parameters.AddWithValue(
                "@so_dien_thoai",
                (object?)nv.so_dien_thoai
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@ngay_sinh",
                (object?)nv.ngay_sinh
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@dia_chi",
                (object?)nv.dia_chi
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@vi_tri",
                (object?)nv.vi_tri
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@vai_tro",
                (object?)nv.vai_tro
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@trang_thai",
                (object?)nv.trang_thai
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@pin_code",
                (object?)nv.pin_code
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@ngay_vao_lam",
                (object?)nv.ngay_vao_lam
                ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue(
                "@loai_luong",
                (object?)nv.loai_luong
                ?? DBNull.Value
            );

            await cmd.ExecuteNonQueryAsync();

            return true;
        }

        // =========================
        // TRANSACTION PROCEDURE
        // trans_xoa_nhan_vien
        // =========================

        public async Task<bool>
            Delete(
                string id
            )
        {
            using SqlConnection conn =
                _db.GetConnection();

            await conn.OpenAsync();

            SqlCommand cmd =
                new SqlCommand(
                    "trans_xoa_nhan_vien",
                    conn
                );

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id",
                id
            );

            await cmd.ExecuteNonQueryAsync();

            return true;
        }

        // =========================
        // TRANSACTION PROCEDURE
        // trans_doi_pin_nhan_vien
        // =========================

        public async Task<bool>
            DoiPin(
                DoiPinDTO dto
            )
        {
            using SqlConnection conn =
                _db.GetConnection();

            await conn.OpenAsync();

            SqlCommand cmd =
                new SqlCommand(
                    "trans_doi_pin_nhan_vien",
                    conn
                );

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@id",
                dto.id
            );

            cmd.Parameters.AddWithValue(
                "@pin_moi",
                dto.pin_moi
            );

            await cmd.ExecuteNonQueryAsync();

            return true;
        }
        public async Task<bool>
        NhanVienDaNghi(
            string nhanVienId
        )
        {
            return await _context
                .NhanViens
                .AnyAsync(x =>
                    x.id == nhanVienId
                    &&
                    x.trang_thai == "Đã nghỉ"
                );
        }
    }
}

