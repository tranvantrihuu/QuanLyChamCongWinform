using QuanLyChamCong.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmCaLamEdit : Form
    {
        CaLamBLL bll = new CaLamBLL();
        public bool isEdit = false;
        public int id = 0;

        public FrmCaLamEdit(bool edit = false)
        {
            InitializeComponent();
            numDiTre.Maximum = 1000;
            numVeSom.Maximum = 1000;
            numCheckinSom.Maximum = 1000;
            numCheckoutTre.Maximum = 1000;
            isEdit = edit;
        }

        private void FrmCaLamEdit_Load(object sender, EventArgs e)
        {
            FixUI();
            // chỉ cho chọn giờ
            dtBatDau.Format = DateTimePickerFormat.Time;
            dtBatDau.ShowUpDown = true;

            dtKetThuc.Format = DateTimePickerFormat.Time;
            dtKetThuc.ShowUpDown = true;
        }

        void FixUI()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is Label lb)
                {
                    lb.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lb.BackColor = Color.FromArgb(240, 240, 240);
                }

                if (c is TextBox tb)
                {
                    tb.Font = new Font("Segoe UI", 10);
                }

                if (c is NumericUpDown num)
                {
                    num.Font = new Font("Segoe UI", 10);
                }

                if (c is DateTimePicker dt)
                {
                    dt.Font = new Font("Segoe UI", 10);
                }
            }
        }

        bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenCa.Text))
            {
                MessageBox.Show("Tên ca không được để trống");
                return false;
            }

            TimeSpan bd = dtBatDau.Value.TimeOfDay;
            TimeSpan kt = dtKetThuc.Value.TimeOfDay;

            if (bd == kt)
            {
                MessageBox.Show("Check In và Check Out không được trùng");
                return false;
            }


            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var result = MessageBox.Show(
                "Xác nhận lưu ca làm?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            var p = new Dictionary<string, object>
            {
                { "@id", id },
                { "@ten", txtTenCa.Text },
                { "@bd", dtBatDau.Value.TimeOfDay },
                { "@kt", dtKetThuc.Value.TimeOfDay },
                { "@tre", numDiTre.Value },
                { "@som", numVeSom.Value },
                { "@checkin", numCheckinSom.Value },
                { "@checkout", numCheckoutTre.Value }
            };

            if (isEdit)
            {
                bll.Update(p);
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                bll.Insert(p);
                MessageBox.Show("Thêm thành công");
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}