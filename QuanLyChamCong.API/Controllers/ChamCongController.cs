using Microsoft.AspNetCore.Mvc;

using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamCongController :
        ControllerBase
    {
        private readonly
            ChamCongBLL _bll;

        private readonly
            QuanLyChamCongBLL _quanLyBLL;

        public ChamCongController(
            ChamCongBLL bll,
            QuanLyChamCongBLL quanLyBLL
        )
        {
            _bll = bll;

            _quanLyBLL = quanLyBLL;
        }

        /*
         * =====================================
         * CHẤM CÔNG
         * =====================================
         */

        [HttpPost("checkin/{nhanVienId}")]
        public async Task<IActionResult>
            CheckIn(
                string nhanVienId
            )
        {
            bool result =
                await _bll.CheckInAsync(
                    nhanVienId
                );

            return Ok(result);
        }

        [HttpPost("checkout/{nhanVienId}")]
        public async Task<IActionResult>
            CheckOut(
                string nhanVienId
            )
        {
            bool result =
                await _bll.CheckOutAsync(
                    nhanVienId
                );

            return Ok(result);
        }

        /*
         * =====================================
         * QUẢN LÝ CHẤM CÔNG
         * =====================================
         */

        [HttpGet]
        public async Task<IActionResult>
            Get()
        {
            var data =
                await _quanLyBLL
                .GetAllAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetById(
                int id
            )
        {
            var data =
                await _quanLyBLL
                .GetByIdAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>
            Insert(
                ChamCong model
            )
        {
            bool result =
                await _quanLyBLL
                .InsertAsync(model);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
            Update(
                int id,
                ChamCong model
            )
        {
            bool result =
                await _quanLyBLL
                .UpdateAsync(
                    id,
                    model
                );

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(
                int id
            )
        {
            bool result =
                await _quanLyBLL
                .DeleteAsync(id);

            return Ok(result);
        }

        /*
         * =====================================
         * LỌC CHẤM CÔNG
         * =====================================
         */

        [HttpGet("loc")]
        public async Task<IActionResult>
    LocChamCong(
        string? nhanVienId,
        DateTime tuNgay,
        DateTime denNgay
    )
        {
            try
            {
                var data =
                    await _quanLyBLL
                    .LocChamCongAsync(
                        nhanVienId,
                        tuNgay,
                        denNgay
                    );

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ex.ToString()
                );
            }
        }
    }
}