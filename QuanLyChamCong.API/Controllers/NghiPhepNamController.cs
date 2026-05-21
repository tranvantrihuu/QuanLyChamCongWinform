using Microsoft.AspNetCore.Mvc;
using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NghiPhepNamController : ControllerBase
    {
        private readonly NghiPhepNamBLL _bll;

        public NghiPhepNamController(
            NghiPhepNamBLL bll
        )
        {
            _bll = bll;
        }

        // =========================
        // LẤY DANH SÁCH
        // VIEW:
        // vw_danh_sach_nghi_phep_nam
        // =========================
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<NghiPhepNam> ds =
                    _bll.GetAll();

                return Ok(ds);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        message =
                            ex.Message
                    }
                );
            }
        }

        // =========================
        // LẤY THEO ID
        // =========================
        [HttpGet("{id}")]
        public IActionResult GetById(
            int id
        )
        {
            try
            {
                var item =
                    _bll.GetById(id);

                if (item == null)
                {
                    return NotFound(
                        new
                        {
                            message =
                                "Không tìm thấy dữ liệu"
                        }
                    );
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        message =
                            ex.Message
                    }
                );
            }
        }

        // =========================
        // THÊM
        // SP:
        // sp_them_nghi_phep_nam
        // =========================
        [HttpPost]
        public IActionResult Post(
            [FromBody] NghiPhepNam item
        )
        {
            try
            {
                bool success =
                    _bll.Insert(item);

                if (success)
                {
                    return Ok(
                        new
                        {
                            message =
                                "Thêm thành công"
                        }
                    );
                }

                return BadRequest(
                    new
                    {
                        message =
                            "Dữ liệu không hợp lệ"
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        message =
                            ex.Message
                    }
                );
            }
        }

        // =========================
        // CẬP NHẬT
        // SP:
        // sp_cap_nhat_nghi_phep_nam
        // =========================
        [HttpPut("{id}")]
        public IActionResult Put(
            int id,
            [FromBody] NghiPhepNam item
        )
        {
            try
            {
                item.id = id;

                bool success =
                    _bll.Update(item);

                if (success)
                {
                    return Ok(
                        new
                        {
                            message =
                                "Cập nhật thành công"
                        }
                    );
                }

                return BadRequest(
                    new
                    {
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
                        message =
                            ex.Message
                    }
                );
            }
        }

        // =========================
        // XÓA
        // SP:
        // sp_xoa_nghi_phep_nam
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
                            message =
                                "Xóa thành công"
                        }
                    );
                }

                return NotFound(
                    new
                    {
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
                        message =
                            ex.Message
                    }
                );
            }
        }
    }
}