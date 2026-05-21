using Microsoft.AspNetCore.Mvc;
using QuanLyChamCong.API.BLL;
using QuanLyChamCong.API.Models;

namespace QuanLyChamCong.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaLamController : ControllerBase
    {
        private readonly CaLamBLL _bll;

        public CaLamController(
            CaLamBLL bll
        )
        {
            _bll = bll;
        }

        // =========================
        // GET DANH SÁCH
        // VIEW:
        // vw_danh_sach_ca_lam
        // =========================
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<CaLam> ds =
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
        // THÊM
        // SP:
        // sp_them_ca_lam
        // =========================
        [HttpPost]
        public IActionResult Insert(
            [FromBody] CaLam ca
        )
        {
            try
            {
                bool success =
                    _bll.Insert(ca);

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
                            "Thêm thất bại"
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
        // sp_cap_nhat_ca_lam
        // =========================
        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            [FromBody] CaLam ca
        )
        {
            try
            {
                ca.id = id;

                bool success =
                    _bll.Update(ca);

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
        // sp_xoa_ca_lam
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