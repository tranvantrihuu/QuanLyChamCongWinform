using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace QuanLyChamCong.GUI
{
    public partial class UcChamCong : BaseUserControl
    {
        NhanVienService nhanVienService =
            new NhanVienService();

        QuanLyChamCongService chamCongService =
            new QuanLyChamCongService();

        private frmMain frm;

        public UcChamCong(
            frmMain f
        )
        {
            InitializeComponent();

            frm = f;
        }

        private void UcChamCong_Load(
            object sender,
            EventArgs e
        )
        {
            timer1.Start();

            txtPin.Text =
                "Nhập PIN hoặc mã vân tay";

            txtPin.ForeColor =
                Color.Gray;

            txtPin.Enter += (_, __) =>
            {
                if (
                    txtPin.Text
                    == "Nhập PIN hoặc mã vân tay"
                )
                {
                    txtPin.Text = "";

                    txtPin.ForeColor =
                        Color.Black;
                }
            };

            txtPin.Leave += (_, __) =>
            {
                if (
                    string.IsNullOrWhiteSpace(
                        txtPin.Text
                    )
                )
                {
                    txtPin.Text =
                        "Nhập PIN hoặc mã vân tay";

                    txtPin.ForeColor =
                        Color.Gray;
                }
            };
        }

        private void timer1_Tick(
            object sender,
            EventArgs e
        )
        {
            lblTime.Text =
                DateTime.Now.ToString(
                    "HH:mm:ss\ndddd, dd/MM/yyyy"
                );
        }

        private bool IsValidInput(
            string input
        )
        {
            if (
                Regex.IsMatch(
                    input,
                    @"^\d{4}$"
                )
            )
            {
                return true;
            }

            if (
                Regex.IsMatch(
                    input,
                    @"^[A-Za-z0-9]+$"
                )
            )
            {
                return true;
            }

            return false;
        }

        private async void btnCheckIn_Click(
            object sender,
            EventArgs e
        )
        {
            string input =
                txtPin.Text.Trim();

            if (
                input == ""
                ||
                input ==
                "Nhập PIN hoặc mã vân tay"
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập mã"
                );

                return;
            }

            if (!IsValidInput(input))
            {
                MessageBox.Show(
                    "Mã không hợp lệ"
                );

                return;
            }

            NhanVien nv =
                await nhanVienService
                .GetNhanVien(input);

            if (nv == null)
            {
                MessageBox.Show(
                    "Không tìm thấy nhân viên"
                );

                return;
            }

            bool result =
                await chamCongService
                .CheckIn(nv.id);

            if (result)
            {
                MessageBox.Show(
                    $"{nv.ho_ten} check in thành công"
                );
            }
            else
            {
                MessageBox.Show(
                    "Check in thất bại hoặc đã check in"
                );
            }

            txtPin.Clear();

            txtPin.Focus();
        }

        private async void btnCheckOut_Click(
            object sender,
            EventArgs e
        )
        {
            string input =
                txtPin.Text.Trim();

            if (
                input == ""
                ||
                input ==
                "Nhập PIN hoặc mã vân tay"
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập mã"
                );

                return;
            }

            if (!IsValidInput(input))
            {
                MessageBox.Show(
                    "Mã không hợp lệ"
                );

                return;
            }

            NhanVien nv =
                await nhanVienService
                .GetNhanVien(input);

            if (nv == null)
            {
                MessageBox.Show(
                    "Không tìm thấy nhân viên"
                );

                return;
            }

            bool result =
                await chamCongService
                .CheckOut(nv.id);

            if (result)
            {
                MessageBox.Show(
                    $"{nv.ho_ten} check out thành công"
                );
            }
            else
            {
                MessageBox.Show(
                    "Check out thất bại"
                );
            }

            txtPin.Clear();

            txtPin.Focus();
        }

        private async void btnLogin_Click(
            object sender,
            EventArgs e
        )
        {
            string pin =
                txtPin.Text.Trim();

            if (
                pin == ""
                ||
                pin ==
                "Nhập PIN hoặc mã vân tay"
            )
            {
                MessageBox.Show(
                    "Nhập PIN admin"
                );

                return;
            }

            NhanVien admin =
                await nhanVienService
                .KiemTraAdminByPin(pin);

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

        private void tableLayoutPanel1_Paint(
            object sender,
            PaintEventArgs e
        )
        {

        }
    }
}