using Microsoft.AspNetCore.Mvc;
using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhanCaController : ControllerBase
    {
        private readonly PhanCaBLL _bll;

        public PhanCaController(
            PhanCaBLL bll
        )
        {
            _bll = bll;
        }

        // =========================
        // LẤY DANH SÁCH PHÂN CA
        // =========================
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<PhanCa> ds =
                    _bll.GetAll();

                if (ds == null)
                {
                    ds = new List<PhanCa>();
                }

                return Ok(ds);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        success = false,
                        message = ex.Message
                    }
                );
            }
        }

        // =========================
        // THÊM PHÂN CA
        // =========================
        [HttpPost]
        public IActionResult Add(
            [FromBody] PhanCa pc
        )
        {
            try
            {
                if (pc == null)
                {
                    return BadRequest(
                        new
                        {
                            success = false,
                            message =
                                "Dữ liệu không hợp lệ"
                        }
                    );
                }

                bool success =
                    _bll.Insert(pc);

                if (success)
                {
                    return Ok(
                        new
                        {
                            success = true,
                            message =
                                "Phân ca thành công"
                        }
                    );
                }

                return BadRequest(
                    new
                    {
                        success = false,
                        message =
                            "Ca làm đã tồn tại hoặc dữ liệu không hợp lệ"
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        success = false,
                        message = ex.Message
                    }
                );
            }
        }

        // =========================
        // CẬP NHẬT PHÂN CA
        // =========================
        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            [FromBody] PhanCa pc
        )
        {
            try
            {
                if (pc == null)
                {
                    return BadRequest(
                        new
                        {
                            success = false,
                            message =
                                "Dữ liệu không hợp lệ"
                        }
                    );
                }

                pc.id = id;

                bool success =
                    _bll.Update(pc);

                if (success)
                {
                    return Ok(
                        new
                        {
                            success = true,
                            message =
                                "Cập nhật thành công"
                        }
                    );
                }

                return BadRequest(
                    new
                    {
                        success = false,
                        message =
                            "Cập nhật thất bại"
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        success = false,
                        message = ex.Message
                    }
                );
            }
        }

        // =========================
        // XÓA PHÂN CA
        // =========================
        [HttpDelete("{id}")]
        public IActionResult Delete(
            int id
        )
        {
            try
            {
                bool success =
                    _bll.Delete(id);

                if (success)
                {
                    return Ok(
                        new
                        {
                            success = true,
                            message =
                                "Xóa thành công"
                        }
                    );
                }

                return NotFound(
                    new
                    {
                        success = false,
                        message =
                            "Không tìm thấy dữ liệu"
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        success = false,
                        message = ex.Message
                    }
                );
            }
        }
    }
}