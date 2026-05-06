using QuanLyChamCong.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyChamCong.BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL dal = new NhanVienDAL();

        // =========================
        // Lấy danh sách
        // =========================
        public DataTable GetAll()
        {
            return dal.GetAllNhanVien();
        }

        // =========================
        // Check PIN
        // =========================
        
        public DataRow KiemTraAdminByPin(string pin)
        {
            return dal.KiemTraAdminByPin(pin);
        }
        // =========================
        // Lấy ID theo PIN
        // =========================
        public string GetNhanVienIdByPin(string pin)
        {
            DataTable dt = dal.GetByPin(pin);

            if (dt == null || dt.Rows.Count == 0)
                return null;

            return dt.Rows[0]["id"].ToString();
        }

        // =========================
        // Lấy ID theo vân tay
        // =========================
        public string GetNhanVienIdByMaVanTay(string ma)
        {
            return dal.GetNhanVienIdByMaVanTay(ma);
        }
        public DataRow GetNhanVien(string input)
        {
            return dal.GetNhanVienByInput(input);
        }
        // =========================
        // 🔥 HÀM QUAN TRỌNG NHẤT
        // Tự nhận PIN hoặc vân tay
        // =========================
        public string GetNhanVienId(string input)
        {
            // PIN (4 số)
            if (Regex.IsMatch(input, @"^\d{4}$"))
            {
                return GetNhanVienIdByPin(input);
            }

            // vân tay
            if (Regex.IsMatch(input, @"^IDFA\d{4}$"))
            {
                return GetNhanVienIdByMaVanTay(input);
            }

            return null;
        }

        // =========================
        // Check In
        // =========================
        public bool CheckIn(string input)
        {
            string id = GetNhanVienId(input);

            if (id == null) return false;

            int result = dal.CheckIn(id);

            var cc = dal.GetChamCongHomNay(id);

            return cc != null && cc["check_in"] != DBNull.Value;
        }

        // =========================
        // Check Out
        // =========================
        public bool CheckOut(string input)
        {
            string id = GetNhanVienId(input);
            if (id == null) return false;

            return dal.CheckOut(id) > 0;
        }
        public DataRow GetChamCongHomNay(string input)
        {
            string id = GetNhanVienId(input);

            if (id == null) return null;

            return dal.GetChamCongHomNay(id);
        }
        // =========================
        // 🔥 Chấm công tự động (1 nút)
        // =========================
        public string ChamCong(string input)
        {
            string id = GetNhanVienId(input);

            if (id == null)
                return "Không tìm thấy nhân viên";

            var cc = dal.GetChamCongHomNay(id);

            if (cc == null)
            {
                dal.CheckIn(id);
                return "Check-in thành công";
            }
            else if (cc["check_out"] == DBNull.Value)
            {
                dal.CheckOut(id);
                return "Check-out thành công";
            }
            else
            {
                return "Hôm nay đã chấm công đủ";
            }
        }

        public bool InsertNhanVien(Dictionary<string, object> p)
        {
            return dal.InsertNhanVien(p) > 0;
        }

        public bool UpdateNhanVien(Dictionary<string, object> p)
        {
            return dal.UpdateNhanVien(p) > 0;
        }

        public bool DeleteNhanVien(List<string> ids)
        {
            return dal.DeleteNhanVien(ids) > 0;
        }

        public DataTable Search(string keyword)
        {
            return dal.SearchNhanVien(keyword);
        }
        public int GetNextAvailableSoNhanVien()
        {
            return dal.GetNextAvailableSoNhanVien();
        }
        public bool ExistsID(string id)
        {
            return dal.ExistsID(id);
        }

        public bool ExistsMaVanTay(string ma)
        {
            return dal.ExistsMaVanTay(ma);
        }
    }
}