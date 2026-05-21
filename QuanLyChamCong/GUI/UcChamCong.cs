using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;

using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using MessageBox =
    QuanLyChamCong.THEME.CustomMessageBox;

namespace QuanLyChamCong.GUI
{
    public partial class UcChamCong :
        BaseUserControl
    {
        private readonly
            NhanVienService nhanVienService =
                new NhanVienService();

        private readonly
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

            KhoiTaoPlaceholder();
        }

        private void KhoiTaoPlaceholder()
        {
            txtPin.Text =
                "Nhập PIN hoặc mã vân tay";

            txtPin.ForeColor =
                Color.Gray;

            txtPin.Enter += (_, __) =>
            {
                if (
                    txtPin.Text ==
                    "Nhập PIN hoặc mã vân tay"
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
                    "HH:mm:ss\n" +
                    "dddd, dd/MM/yyyy"
                );
        }

        private bool IsValidInput(
            string input
        )
        {
            // PIN 4 số

            if (
                Regex.IsMatch(
                    input,
                    @"^\d{4}$"
                )
            )
            {
                return true;
            }

            // Mã vân tay

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

        private async Task<NhanVien>
            TimNhanVien()
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

                return null;
            }

            if (!IsValidInput(input))
            {
                MessageBox.Show(
                    "Mã không hợp lệ"
                );

                return null;
            }

            NhanVien nv =
                await nhanVienService
                .GetNhanVien(input);

            if (nv == null)
            {
                MessageBox.Show(
                    "Không tìm thấy nhân viên"
                );

                return null;
            }

            return nv;
        }

        private async void btnCheckIn_Click(
    object sender,
    EventArgs e
)
        {
            try
            {
                NhanVien nv =
                    await TimNhanVien();

                if (nv == null)
                {
                    return;
                }

                bool result =
                    await chamCongService
                    .CheckIn(nv.id);

                if (result)
                {
                    MessageBox.Show(
                        $"{nv.ho_ten} CHECK IN thành công"
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"{nv.ho_ten} đã CHECK IN rồi " 
                    );
                }

                txtPin.Clear();

                txtPin.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private async void btnCheckOut_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                NhanVien nv =
                    await TimNhanVien();

                if (nv == null)
                {
                    return;
                }

                bool result =
                    await chamCongService
                    .CheckOut(nv.id);

                if (result)
                {
                    MessageBox.Show(
                        $"{nv.ho_ten} CHECK OUT thành công"
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"{nv.ho_ten} chưa CHECK IN " +
                        "hoặc đã CHECK OUT"
                    );
                }

                txtPin.Clear();

                txtPin.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private async void btnLogin_Click(
            object sender,
            EventArgs e
        )
        {
            try
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
                        "Vui lòng nhập PIN admin"
                    );

                    return;
                }

                bool isAdmin =
                    await nhanVienService
                    .KiemTraAdminByPin(
                        pin
                    );

                if (isAdmin)
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
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