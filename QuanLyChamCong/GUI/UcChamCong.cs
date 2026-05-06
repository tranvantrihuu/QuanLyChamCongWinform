using QuanLyChamCong.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcChamCong : UserControl
    {
        NhanVienBLL bll = new NhanVienBLL();
        private frmMain frm;
        public UcChamCong(frmMain f)
        {
            InitializeComponent();
            frm = f;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm dddd, dd/MM/yyyy");
        }

        private void UcChamCong_Load(object sender, EventArgs e)
        {
            timer1.Start();
            string placeholder = "Nhập mã PIN/vân tay";

            txtPin.Text = placeholder;
            txtPin.ForeColor = Color.Gray;

            txtPin.Enter += (_, __) =>
            {
                if (txtPin.Text == placeholder)
                {
                    txtPin.Text = "";
                    txtPin.ForeColor = Color.Black;
                }
            };

            txtPin.Leave += (_, __) =>
            {
                if (string.IsNullOrWhiteSpace(txtPin.Text))
                {
                    txtPin.Text = placeholder;
                    txtPin.ForeColor = Color.Gray;
                }
            };
        }

        // 🔥 Validate input
        private bool IsValidInput(string input)
        {
            // PIN: 4 số
            if (Regex.IsMatch(input, @"^\d{4}$"))
                return true;

            // Vân tay: IDFA + 4 số
            if (Regex.IsMatch(input, @"^IDFA\d{4}$"))
                return true;

            return false;
        }

        // 🔥 Lấy ID từ input (PIN hoặc vân tay)
        private string GetNhanVienId(string input)
        {
            // PIN
            if (Regex.IsMatch(input, @"^\d{4}$"))
                return bll.GetNhanVienIdByPin(input);

            // Vân tay
            return bll.GetNhanVienId(input);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string input = txtPin.Text.Trim();

            if (input == "")
            {
                MessageBox.Show("Vui lòng nhập mã");
                return;
            }

            var nv = bll.GetNhanVien(input);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên");
                return;
            }

            string id = nv["id"].ToString();
            string ten = nv["ho_ten"].ToString();
            string ca = "ca 1"; // tạm

            var cc = bll.GetChamCongHomNay(input);

            // 🔥 ĐÃ CÓ RECORD → KHÔNG CHO CHECK IN
            if (cc != null && cc["check_in"] != DBNull.Value)
            {
                MessageBox.Show("Ca làm đã Check In");
                return;
            }

            // ✅ CHƯA CÓ → CHECK IN
            bll.CheckIn(input);

            string time = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
            MessageBox.Show($"{id} - {ten} - {ca} đã check in lúc {time}");

            txtPin.Clear();
            txtPin.Focus();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string input = txtPin.Text.Trim();

            if (input == "")
            {
                MessageBox.Show("Vui lòng nhập mã");
                return;
            }

            var nv = bll.GetNhanVien(input);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên");
                return;
            }

            string id = nv["id"].ToString();
            string ten = nv["ho_ten"].ToString();
            string ca = "ca 1";

            var cc = bll.GetChamCongHomNay(input);

            // ❌ CHƯA CHECK IN
            if (cc == null || cc["check_in"] == DBNull.Value)
            {
                MessageBox.Show("Chưa check in");
                return;
            }

            // ❌ ĐÃ CHECK OUT
            if (cc["check_out"] != DBNull.Value)
            {
                MessageBox.Show("Ca làm đã Check Out");
                return;
            }

            // ✅ OK → CHECK OUT
            bll.CheckOut(input);

            string time = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
            MessageBox.Show($"{id} - {ten} - {ca} đã check out lúc {time}");

            txtPin.Clear();
            txtPin.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataRow admin =
            bll.KiemTraAdminByPin(
            txtPin.Text.Trim()
        );

            if (admin != null)
            {
                frm.MoKhoaChucNang();

                MessageBox.Show(
                    "Đăng nhập admin thành công"
                );
            }
            else
            {
                MessageBox.Show(
                    "PIN admin không đúng"
                );
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}