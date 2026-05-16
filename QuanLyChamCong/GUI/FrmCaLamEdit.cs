using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Drawing;
using System.Windows.Forms;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace QuanLyChamCong.GUI
{
    public partial class FrmCaLamEdit : BaseForm
    {
        CaLamService service =
            new CaLamService();

        public bool isEdit = false;

        public int id = 0;

        public FrmCaLamEdit(
            bool edit = false
        )
        {
            InitializeComponent();

            numDiTre.Maximum = 1000;
            numVeSom.Maximum = 1000;
            numCheckinSom.Maximum = 1000;
            numCheckoutTre.Maximum = 1000;

            isEdit = edit;
        }

        private void FrmCaLamEdit_Load(
            object sender,
            EventArgs e
        )
        {
            FixUI();

            dtBatDau.Format =
                DateTimePickerFormat.Time;

            dtBatDau.ShowUpDown = true;

            dtKetThuc.Format =
                DateTimePickerFormat.Time;

            dtKetThuc.ShowUpDown = true;
        }

        void FixUI()
        {
            foreach (
                Control c
                in tableLayoutPanel1.Controls
            )
            {
                if (c is Label lb)
                {
                    lb.Font =
                        new Font(
                            "Segoe UI",
                            10,
                            FontStyle.Bold
                        );

                    lb.BackColor =
                        Color.FromArgb(
                            240,
                            240,
                            240
                        );
                }

                if (c is TextBox tb)
                {
                    tb.Font =
                        new Font(
                            "Segoe UI",
                            10
                        );
                }

                if (c is NumericUpDown num)
                {
                    num.Font =
                        new Font(
                            "Segoe UI",
                            10
                        );
                }

                if (c is DateTimePicker dt)
                {
                    dt.Font =
                        new Font(
                            "Segoe UI",
                            10
                        );
                }
            }
        }

        bool ValidateInput()
        {
            if (
                string.IsNullOrWhiteSpace(
                    txtTenCa.Text
                )
            )
            {
                MessageBox.Show(
                    "Tên ca không được để trống"
                );

                return false;
            }

            TimeSpan bd =
                dtBatDau.Value.TimeOfDay;

            TimeSpan kt =
                dtKetThuc.Value.TimeOfDay;

            if (bd == kt)
            {
                MessageBox.Show(
                    "Check In và Check Out không được trùng"
                );

                return false;
            }

            return true;
        }

        private async void btnOk_Click(
            object sender,
            EventArgs e
        )
        {
            if (!ValidateInput())
            {
                return;
            }

            var result =
                MessageBox.Show(
                    "Xác nhận lưu ca làm?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (
                result == DialogResult.No
            )
            {
                return;
            }

            CaLam ca =
                new CaLam
                {
                    id = id,

                    ten_ca =
                        txtTenCa.Text,

                    gio_bat_dau =
                        dtBatDau
                        .Value
                        .TimeOfDay,

                    gio_ket_thuc =
                        dtKetThuc
                        .Value
                        .TimeOfDay,

                    phut_cho_phep_di_tre =
                        (int)numDiTre.Value,

                    phut_cho_phep_ve_som =
                        (int)numVeSom.Value,

                    phut_cho_phep_checkin_som =
                        (int)numCheckinSom.Value,

                    phut_cho_phep_checkout_tre =
                        (int)numCheckoutTre.Value
                };

            bool success;

            if (isEdit)
            {
                success =
                    await service.Update(ca);

                if (success)
                {
                    MessageBox.Show(
                        "Sửa thành công"
                    );
                }
            }
            else
            {
                success =
                    await service.Add(ca);

                if (success)
                {
                    MessageBox.Show(
                        "Thêm thành công"
                    );
                }
            }

            Close();
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e
        )
        {
            Close();
        }
    }
}