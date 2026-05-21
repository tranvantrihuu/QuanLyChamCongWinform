using Microsoft.AspNetCore.Mvc;

using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NghiPhepController :
        ControllerBase
    {
        private readonly
            NghiPhepBLL _bll;

        public NghiPhepController(
            NghiPhepBLL bll
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
                NghiPhep model
            )
        {
            bool result =
                await _bll.InsertAsync(
                    model
                );

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
            Update(
                int id,
                NghiPhep model
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
        public async Task<IActionResult>
            Delete(
                int id
            )
        {
            bool result =
                await _bll.DeleteAsync(id);

            return Ok(result);
        }
    }
}