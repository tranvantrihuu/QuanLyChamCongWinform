using Microsoft.AspNetCore.Mvc;
using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.DTO;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhanVienController : ControllerBase
    {
        private readonly NhanVienBLL _bll;

        public NhanVienController(
            NhanVienBLL bll
        )
        {
            _bll = bll;
        }

        // =========================
        // GET ALL
        // VIEW
        // =========================

        [HttpGet]
        public async Task<IActionResult>
            Get()
        {
            var ds =
                await _bll.GetAll();

            return Ok(ds);
        }

        // =========================
        // SEARCH
        // LINQ + EF
        // =========================

        [HttpGet("search/{keyword}")]
        public async Task<IActionResult>
            Search(
                string keyword
            )
        {
            var ds =
                await _bll.Search(
                    keyword
                );

            return Ok(ds);
        }

        // =========================
        // GET NHÂN VIÊN
        // STORED PROCEDURE
        // =========================

        [HttpGet("timkiem/{input}")]
        public async Task<IActionResult>
            GetNhanVien(
                string input
            )
        {
            var nv =
                await _bll.GetNhanVien(
                    input
                );

            if (nv == null)
            {
                return NotFound(
                    "Không tìm thấy nhân viên"
                );
            }

            return Ok(nv);
        }

        // =========================
        // CHECK ADMIN PIN
        // FUNCTION
        // =========================

        [HttpGet("adminpin/{pin}")]
        public async Task<IActionResult>
            KiemTraAdminPin(
                string pin
            )
        {
            bool isAdmin =
                await _bll
                    .KiemTraAdminPin(
                        pin
                    );

            return Ok(isAdmin);
        }

        // =========================
        // INSERT
        // TRANSACTION PROCEDURE
        // =========================

        [HttpPost]
        public async Task<IActionResult>
            Insert(
                [FromBody]
                NhanVien nv
            )
        {
            bool success =
                await _bll.Insert(
                    nv
                );

            if (!success)
            {
                return BadRequest(
                    "Thêm nhân viên thất bại"
                );
            }

            return Ok(
                "Thêm nhân viên thành công"
            );
        }

        // =========================
        // UPDATE
        // TRANSACTION PROCEDURE
        // =========================

        [HttpPut("{id}")]
        public async Task<IActionResult>
            Update(
                string id,
                [FromBody]
                NhanVien nv
            )
        {
            nv.id = id;

            bool success =
                await _bll.Update(
                    nv
                );

            if (!success)
            {
                return BadRequest(
                    "Cập nhật thất bại"
                );
            }

            return Ok(
                "Cập nhật thành công"
            );
        }

        // =========================
        // DELETE
        // TRANSACTION PROCEDURE
        // =========================

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(
                string id
            )
        {
            bool success =
                await _bll.Delete(
                    id
                );

            if (!success)
            {
                return BadRequest(
                    "Xóa thất bại"
                );
            }

            return Ok(
                "Xóa thành công"
            );
        }

        // =========================
        // ĐỔI PIN
        // FUNCTION + TRANSACTION
        // =========================

        [HttpPut("doipin/{id}")]
        public async Task<IActionResult>
            DoiPin(
                string id,
                [FromBody]
                DoiPinDTO dto
            )
        {
            dto.id = id;

            bool success =
                await _bll.DoiPin(
                    dto
                );

            if (!success)
            {
                return BadRequest(
                    "Đổi PIN thất bại"
                );
            }

            return Ok(
                "Đổi PIN thành công"
            );
        }
    }
}

