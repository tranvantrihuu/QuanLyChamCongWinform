using Microsoft.AspNetCore.Mvc;

using QuanLyChamCong.API.BLL;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BangLuongChotController :
        ControllerBase
    {
        private readonly
            BangLuongChotBLL _bll;

        public BangLuongChotController(
            BangLuongChotBLL bll
        )
        {
            _bll = bll;
        }

        [HttpGet]
        public async Task<IActionResult>
            Get()
        {
            var data =
                await _bll.GetAllAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetChiTiet(
                int id
            )
        {
            var data =
                await _bll.GetChiTietAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost("tinh-luong")]
        public async Task<IActionResult>
            TinhBangLuong(
                int thang,
                int nam
            )
        {
            bool result =
                await _bll
                .TinhBangLuongAsync(
                    thang,
                    nam
                );

            return Ok(result);
        }

        [HttpPost("chot-luong/{id}")]
        public async Task<IActionResult>
            ChotBangLuong(
                int id
            )
        {
            bool result =
                await _bll
                .ChotBangLuongAsync(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(
                int id
            )
        {
            bool result =
                await _bll.DeleteAsync(id);

            return Ok(result);
        }

        [HttpGet("loc")]
        public async Task<IActionResult>
            LocTheoThangNam(
                int thang,
                int nam
            )
        {
            var data =
                await _bll
                .LocTheoThangNamAsync(
                    thang,
                    nam
                );

            return Ok(data);
        }
    }
}