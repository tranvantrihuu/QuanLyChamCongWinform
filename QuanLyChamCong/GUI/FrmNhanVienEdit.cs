using QuanLyChamCong.BLL;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmNhanVienEdit : BaseForm
    {
        NhanVienBLL bll = new NhanVienBLL();
        public bool isEdit = false;

        public FrmNhanVienEdit(bool edit = false)
        {
            InitializeComponent();
            isEdit = edit;
        }

        private void FrmNhanVienEdit_Load(object sender, EventArgs e)
        {
            cbVaiTro.Items.AddRange(new string[] { "Nhân viên", "Admin" });
            cbTrangThai.Items.AddRange(new string[] { "Đang làm", "Nghỉ" });
            cbLoaiLuong.Items.AddRange(new string[] { "Tháng", "Giờ" });

            if (isEdit)
            {
                txtIDNhanVien.Enabled = false;
            }
            else
            {
                int next = bll.GetNextAvailableSoNhanVien();

                txtIDNhanVien.Text = "ID" + next.ToString("D4");
                txtMaVanTay.Text = "IDFA" + next.ToString("D4");
            }
            SetupLayout();
            FixUI();

        }
        void FixUI()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                // 🔹 LABEL
                if (c is Label lb)
                {
                    lb.TextAlign = ContentAlignment.MiddleLeft;
                    lb.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lb.BackColor = Color.FromArgb(240, 240, 240);
                    lb.Padding = new Padding(5, 0, 0, 0);
                }

                // 🔹 TEXTBOX
                if (c is TextBox tb)
                {
                    tb.Font = new Font("Segoe UI", 10);
                    tb.BorderStyle = BorderStyle.FixedSingle;

                    // 🔥 FIX CHIỀU CAO GIẢ
                    tb.Margin = new Padding(3, 6, 3, 6);
                }

                // 🔹 COMBOBOX
                if (c is ComboBox cb)
                {
                    cb.Font = new Font("Segoe UI", 10);
                    cb.FlatStyle = FlatStyle.Standard;

                    // 🔥 QUAN TRỌNG
                    cb.Margin = new Padding(3, 6, 3, 6);
                }

                // 🔹 DATETIME
                if (c is DateTimePicker dt)
                {
                    dt.Font = new Font("Segoe UI", 10);
                    dt.Margin = new Padding(3, 6, 3, 6);
                }
            }
        }
        bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtIDNhanVien.Text))
            {
                MessageBox.Show("ID không được để trống");
                txtIDNhanVien.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaVanTay.Text))
            {
                MessageBox.Show("Mã vân tay không được để trống");
                txtMaVanTay.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống");
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("SĐT không được để trống");
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                txtDiaChi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtViTri.Text))
            {
                MessageBox.Show("Vị trí không được để trống");
                txtViTri.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPin.Text))
            {
                MessageBox.Show("PIN không được để trống");
                txtPin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbVaiTro.Text))
            {
                MessageBox.Show("Chọn vai trò");
                cbVaiTro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbTrangThai.Text))
            {
                MessageBox.Show("Chọn trạng thái");
                cbTrangThai.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbLoaiLuong.Text))
            {
                MessageBox.Show("Chọn loại lương");
                cbLoaiLuong.Focus();
                return false;
            }

            return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (!ValidateInput()) return;
            if (!isEdit)
            {
                if (bll.ExistsID(txtIDNhanVien.Text))
                {
                    MessageBox.Show("ID đã tồn tại");
                    txtIDNhanVien.Focus();
                    return;
                }

                if (bll.ExistsMaVanTay(txtMaVanTay.Text))
                {
                    MessageBox.Show("Mã vân tay đã tồn tại");
                    txtMaVanTay.Focus();
                    return;
                }
            }

            var result = MessageBox.Show(
                "Bạn có muốn nhập thông tin User?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;
            var p = new Dictionary<string, object>
            {
                { "@id", txtIDNhanVien.Text },
                { "@ma", txtMaVanTay.Text },
                { "@ten", txtHoTen.Text },
                { "@sdt", txtSDT.Text },
                { "@ngaysinh", dtNgaySinh.Value },
                { "@diachi", txtDiaChi.Text },
                { "@vitri", txtViTri.Text },
                { "@vaitro", cbVaiTro.Text },
                { "@trangthai", cbTrangThai.Text },
                { "@pin", txtPin.Text },
                { "@ngayvao", dtNgayVao.Value },
                { "@loai", cbLoaiLuong.Text }
            };

            if (isEdit)
            {
                bll.UpdateNhanVien(p);
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                bll.InsertNhanVien(p);
                MessageBox.Show("Thêm thành công");
            }
            

            this.Close();
        }
        void SetupLayout()
        {
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();

            // ================= DATA =================
            // ROW 0
            tableLayoutPanel1.Controls.Add(lblID, 0, 0);
            tableLayoutPanel1.Controls.Add(txtIDNhanVien, 1, 0);
            tableLayoutPanel1.Controls.Add(lblVaiTro, 2, 0);
            tableLayoutPanel1.Controls.Add(cbVaiTro, 3, 0);

            // ROW 1
            tableLayoutPanel1.Controls.Add(lblMaNhanVien, 0, 1);
            tableLayoutPanel1.Controls.Add(txtMaVanTay, 1, 1);
            tableLayoutPanel1.Controls.Add(lblTrangThai, 2, 1);
            tableLayoutPanel1.Controls.Add(cbTrangThai, 3, 1);

            // ROW 2
            tableLayoutPanel1.Controls.Add(lblHoTen, 0, 2);
            tableLayoutPanel1.Controls.Add(txtHoTen, 1, 2);
            tableLayoutPanel1.Controls.Add(lblPin, 2, 2);
            tableLayoutPanel1.Controls.Add(txtPin, 3, 2);

            // ROW 3
            tableLayoutPanel1.Controls.Add(lblSDT, 0, 3);
            tableLayoutPanel1.Controls.Add(txtSDT, 1, 3);
            tableLayoutPanel1.Controls.Add(lblNgayVao, 2, 3);
            tableLayoutPanel1.Controls.Add(dtNgayVao, 3, 3);

            // ROW 4
            tableLayoutPanel1.Controls.Add(lvlNgaySinh, 0, 4);
            tableLayoutPanel1.Controls.Add(dtNgaySinh, 1, 4);
            tableLayoutPanel1.Controls.Add(lblLoaiLuong, 2, 4);
            tableLayoutPanel1.Controls.Add(cbLoaiLuong, 3, 4);

            // ROW 5
            tableLayoutPanel1.Controls.Add(lblDiaChi, 0, 5);
            tableLayoutPanel1.Controls.Add(txtDiaChi, 1, 5);
            tableLayoutPanel1.Controls.Add(lblNgayTao, 2, 5);
            tableLayoutPanel1.Controls.Add(txtNgayTao, 3, 5);

            // ROW 6
            tableLayoutPanel1.Controls.Add(label1, 0, 6);
            tableLayoutPanel1.Controls.Add(txtViTri, 1, 6);
            tableLayoutPanel1.Controls.Add(lblNgaySua, 2, 6);
            tableLayoutPanel1.Controls.Add(txtNgaySua, 3, 6);

            // ================= BUTTON ROW =================
            // Layout căn giữa chuẩn (không lệch khi resize)
            TableLayoutPanel centerLayout = new TableLayoutPanel();
            centerLayout.Dock = DockStyle.Fill;
            centerLayout.ColumnCount = 3;
            centerLayout.RowCount = 1;

            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.AutoSize = true;
            flow.WrapContents = false;
            flow.FlowDirection = FlowDirection.LeftToRight;
            flow.Anchor = AnchorStyles.None;

            // size nút
            btnCancel.Width = 120;
            btnCancel.Height = 40;
            btnOk.Width = 120;
            btnOk.Height = 40;

            // thêm nút
            flow.Controls.Add(btnCancel);
            flow.Controls.Add(btnOk);

            centerLayout.Controls.Add(flow, 1, 0);

            // add vào row 7
            tableLayoutPanel1.Controls.Add(centerLayout, 0, 7);
            tableLayoutPanel1.SetColumnSpan(centerLayout, 4);

            // ================= STYLE =================
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TableLayoutPanel) continue; // bỏ qua layout nút
                c.Dock = DockStyle.Fill;
            }

            tableLayoutPanel1.ResumeLayout();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.CancelButton = btnCancel;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}