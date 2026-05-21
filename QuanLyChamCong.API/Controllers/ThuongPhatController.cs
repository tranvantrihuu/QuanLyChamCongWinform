using Microsoft.AspNetCore.Mvc;

using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThuongPhatController :
        ControllerBase
    {
        private readonly
            ThuongPhatBLL _bll;

        public ThuongPhatController(
            ThuongPhatBLL bll
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
            GetById(
                int id
            )
        {
            var data =
                await _bll.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>
            Insert(
                ThuongPhat model
            )
        {
            bool result =
                await _bll.InsertAsync(
                    model
                );

            if (!result)
            {
                return BadRequest(
                    "Thêm thất bại"
                );
            }

            return Ok(
                "Thêm thành công"
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
            Update(
                int id,
                ThuongPhat model
            )
        {
            bool result =
                await _bll.UpdateAsync(
                    id,
                    model
                );

            if (!result)
            {
                return BadRequest(
                    "Cập nhật thất bại"
                );
            }

            return Ok(
                "Cập nhật thành công"
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(
                int id
            )
        {
            bool result =
                await _bll.DeleteAsync(id);

            if (!result)
            {
                return BadRequest(
                    "Cập nhật thất bại"
                );
            }

            return Ok(
                "Cập nhật thành công"
            );
        }
    }
}