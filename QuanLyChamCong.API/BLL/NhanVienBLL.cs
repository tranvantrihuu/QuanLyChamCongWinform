using QuanLyChamCong.API.DAL;
using QuanLyChamCong.API.DTO;
using QuanLyChamCong.API.Models;
using System.Text.RegularExpressions;

namespace QuanLyChamCong.API.BLL
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL _dal;

        public NhanVienBLL(
            NhanVienDAL dal
        )
        {
            _dal = dal;
        }

        // =========================
        // LẤY DANH SÁCH
        // VIEW
        // =========================

        public async Task<List<NhanVien>>
            GetAll()
        {
            return await _dal.GetAll();
        }

        // =========================
        // SEARCH
        // LINQ
        // =========================

        public async Task<List<NhanVien>>
            Search(
                string keyword
            )
        {
            if (
                string.IsNullOrWhiteSpace(
                    keyword
                )
            )
            {
                return new List<NhanVien>();
            }

            return await _dal.Search(
                keyword.Trim()
            );
        }

        // =========================
        // CHECK ADMIN PIN
        // FUNCTION
        // =========================

        public async Task<bool>
            KiemTraAdminPin(
                string pin
            )
        {
            if (
                string.IsNullOrWhiteSpace(
                    pin
                )
            )
            {
                return false;
            }

            return await _dal
                .KiemTraAdminPin(pin);
        }

        // =========================
        // LẤY NHÂN VIÊN
        // STORED PROCEDURE
        // =========================

        public async Task<NhanVien>
            GetNhanVien(
                string input
            )
        {
            if (
                string.IsNullOrWhiteSpace(
                    input
                )
            )
            {
                return null;
            }

            return await _dal
                .GetNhanVien(
                    input.Trim()
                );
        }

        // =========================
        // EXISTS ID
        // LINQ + EF
        // =========================

        public async Task<bool>
            ExistsID(
                string id
            )
        {
            if (
                string.IsNullOrWhiteSpace(
                    id
                )
            )
            {
                return false;
            }

            return await _dal
                .ExistsID(
                    id.Trim()
                );
        }

        // =========================
        // EXISTS FINGERPRINT
        // LINQ + EF
        // =========================

        public async Task<bool>
            ExistsMaVanTay(
                string ma
            )
        {
            if (
                string.IsNullOrWhiteSpace(
                    ma
                )
            )
            {
                return false;
            }

            return await _dal
                .ExistsMaVanTay(
                    ma.Trim()
                );
        }

        // =========================
        // INSERT
        // TRANSACTION PROCEDURE
        // =========================

        public async Task<bool>
            Insert(
                NhanVien nv
            )
        {
            if (nv == null)
            {
                return false;
            }

            // validate

            if (
                string.IsNullOrWhiteSpace(
                    nv.id
                )
            )
            {
                return false;
            }

            if (
                string.IsNullOrWhiteSpace(
                    nv.ma_van_tay
                )
            )
            {
                return false;
            }

            if (
                string.IsNullOrWhiteSpace(
                    nv.ho_ten
                )
            )
            {
                return false;
            }

            // check duplicate ID

            bool existsID =
                await _dal.ExistsID(
                    nv.id
                );

            if (existsID)
            {
                return false;
            }

            // check duplicate fingerprint

            bool existsFinger =
                await _dal.ExistsMaVanTay(
                    nv.ma_van_tay
                );

            if (existsFinger)
            {
                return false;
            }

            return await _dal.Insert(
                nv
            );
        }

        // =========================
        // UPDATE
        // TRANSACTION PROCEDURE
        // =========================

        public async Task<bool>
            Update(
                NhanVien nv
            )
        {
            if (nv == null)
            {
                return false;
            }

            if (
                string.IsNullOrWhiteSpace(
                    nv.id
                )
            )
            {
                return false;
            }

            return await _dal.Update(
                nv
            );
        }

        // =========================
        // DELETE
        // TRANSACTION PROCEDURE
        // =========================

        public async Task<bool>
            Delete(
                string id
            )
        {
            if (
                string.IsNullOrWhiteSpace(
                    id
                )
            )
            {
                return false;
            }

            return await _dal.Delete(
                id
            );
        }

        // =========================
        // ĐỔI PIN
        // FUNCTION + TRANSACTION
        // =========================

        public async Task<bool>
            DoiPin(
                DoiPinDTO dto
            )
        {
            if (dto == null)
            {
                return false;
            }

            if (
                string.IsNullOrWhiteSpace(
                    dto.id
                )
            )
            {
                return false;
            }

            if (
                string.IsNullOrWhiteSpace(
                    dto.pin_moi
                )
            )
            {
                return false;
            }

            // PIN 4 số

            bool isValidPin =
                Regex.IsMatch(
                    dto.pin_moi,
                    @"^\d{4}$"
                );

            if (!isValidPin)
            {
                return false;
            }

            return await _dal.DoiPin(
                dto
            );
        }
    }
}

