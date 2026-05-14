using QuanLyChamCong.BLL;
using QuanLyChamCong.DTO;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmCauHinhLuongEdit : BaseForm
    {
        CauHinhLuongBLL bll = new CauHinhLuongBLL();

        public bool isEdit = false;
        public int id = 0;
        public string nhanVienId = "";
        public FrmCauHinhLuongEdit(bool edit = false)
        {
            InitializeComponent();

            // set max giống style bạn
            numLuongCoBan.Maximum = 1000000000;
            numLuongTheoGio.Maximum = 1000000000;
            numTangCa.Maximum = 1000000000;
            numPhuCap.Maximum = 1000000000;

            isEdit = edit;
        }

        private void FrmCauHinhLuongEdit_Load(object sender, EventArgs e)
        {
            FixUI();
            LoadNhanVien();

            cbNhanVien.SelectedIndexChanged += cbNhanVien_SelectedIndexChanged;

            if (isEdit && !string.IsNullOrEmpty(nhanVienId))
            {
                cbNhanVien.SelectedValue = nhanVienId;
            }

            cbNhanVien_SelectedIndexChanged(null, null);
        }

        // load combobox nhân viên
        void LoadNhanVien()
        {
            var dt = bll.GetNhanVien(); 

            cbNhanVien.DataSource = dt;
            cbNhanVien.DisplayMember = "ho_ten";   
            cbNhanVien.ValueMember = "id";
        }

        // style UI giống form ca làm
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

                if (c is ComboBox cb)
                {
                    cb.Font = new Font("Segoe UI", 10);
                }
            }
        }

        bool ValidateInput()
        {
            if (cbNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Chọn nhân viên!");
                return false;
            }

            DataRowView row = cbNhanVien.SelectedItem as DataRowView;
            if (row == null) return false;

            string loaiLuong = row["loai_luong"].ToString();

            if (loaiLuong == "Tháng")
            {
                if (numLuongCoBan.Value <= 0)
                {
                    MessageBox.Show("Lương cơ bản phải > 0");
                    return false;
                }
            }
            else if (loaiLuong == "Giờ")
            {
                if (numLuongTheoGio.Value <= 0)
                {
                    MessageBox.Show("Lương theo giờ phải > 0");
                    return false;
                }
            }

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var result = MessageBox.Show(
                "Xác nhận lưu cấu hình lương?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            var p = new Dictionary<string, object>
            {
                { "@id", id },
                { "@nhan_vien_id", cbNhanVien.SelectedValue },
                { "@luong_co_ban", numLuongCoBan.Value },
                { "@luong_theo_gio", numLuongTheoGio.Value },
                { "@luong_tang_ca", numTangCa.Value },
                { "@phu_cap_mac_dinh", numPhuCap.Value }
            };

            if (isEdit)
            {
                bll.Update(p);
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                bool ok = bll.InsertSafe(p);

                if (!ok)
                {
                    MessageBox.Show("Nhân viên đã có cấu hình lương!");
                    return;
                }

                MessageBox.Show("Thêm thành công");
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.SelectedValue == null) return;

            DataRowView row = cbNhanVien.SelectedItem as DataRowView;
            if (row == null) return;

            string loaiLuong = row["loai_luong"].ToString();

            ApplyLoaiLuong(loaiLuong);

            // 🔥 LOAD LƯƠNG THEO NHÂN VIÊN
            var data = bll.GetByNhanVien(cbNhanVien.SelectedValue);

            if (data != null)
            {
                numLuongCoBan.Value = data["luong_co_ban"] == DBNull.Value ? 0 : Convert.ToDecimal(data["luong_co_ban"]);
                numLuongTheoGio.Value = data["luong_theo_gio"] == DBNull.Value ? 0 : Convert.ToDecimal(data["luong_theo_gio"]);
                numTangCa.Value = data["luong_tang_ca"] == DBNull.Value ? 0 : Convert.ToDecimal(data["luong_tang_ca"]);
                numPhuCap.Value = data["phu_cap_mac_dinh"] == DBNull.Value ? 0 : Convert.ToDecimal(data["phu_cap_mac_dinh"]);
            }
            else
            {
                // 🔥 nếu chưa có thì reset
                numLuongCoBan.Value = 0;
                numLuongTheoGio.Value = 0;
                numTangCa.Value = 0;
                numPhuCap.Value = 0;
            }
        }
        void ApplyLoaiLuong(string loaiLuong)
        {
            if (loaiLuong == "Tháng")
            {
                numLuongCoBan.Enabled = true;
                numLuongTheoGio.Enabled = false;

                numLuongTheoGio.Value = 0;
            }
            else if (loaiLuong == "Giờ")
            {
                numLuongCoBan.Enabled = false;
                numLuongTheoGio.Enabled = true;

                numLuongCoBan.Value = 0;
            }

            numTangCa.Enabled = true;
            numPhuCap.Enabled = true;
        }
    }
}