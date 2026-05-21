using Microsoft.AspNetCore.Mvc;

using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CauHinhLuongController :
        ControllerBase
    {
        private readonly
            CauHinhLuongBLL _bll;

        public CauHinhLuongController(
            CauHinhLuongBLL bll
        )
        {
            _bll = bll;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data =
                await _bll.GetAllAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            CauHinhLuong model
        )
        {
            bool result =
                await _bll.InsertAsync(model);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(
            int id,
            CauHinhLuong model
        )
        {
            bool result =
                await _bll.UpdateAsync(
                    id,
                    model
                );

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            int id
        )
        {
            bool result =
                await _bll.DeleteAsync(id);

            return Ok(result);
        }
    }
}