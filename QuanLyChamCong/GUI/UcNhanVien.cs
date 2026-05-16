using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace QuanLyChamCong.GUI
{
    public partial class UcNhanVien : BaseUserControl
    {
        NhanVienService service = new NhanVienService();

        public UcNhanVien()
        {
            InitializeComponent();
            this.Resize += (s, e) => AdjustGrid();
        }
        void AdjustGrid()
        {
            if (dgvNhanVien.Columns.Count == 0) return;

            if (this.Width > 1000)
            {
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvNhanVien.Columns["colCheck"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvNhanVien.Columns["colCheck"].Width = 35;
                dgvNhanVien.Columns["colCheck"].Resizable = DataGridViewTriState.False;
               
                dgvNhanVien.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvNhanVien.Columns["id"].Width = 80;

                dgvNhanVien.Columns["ma_van_tay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvNhanVien.Columns["ma_van_tay"].Width = 120;

                dgvNhanVien.Columns["so_dien_thoai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvNhanVien.Columns["so_dien_thoai"].Width = 120;

                dgvNhanVien.Columns["ngay_sinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvNhanVien.Columns["ngay_sinh"].Width = 110;

                dgvNhanVien.Columns["ngay_vao_lam"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvNhanVien.Columns["ngay_vao_lam"].Width = 110;

                dgvNhanVien.Columns["loai_luong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvNhanVien.Columns["loai_luong"].Width = 80;

               
                dgvNhanVien.Columns["ho_ten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvNhanVien.Columns["ho_ten"].FillWeight = 200;

                dgvNhanVien.Columns["dia_chi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvNhanVien.Columns["dia_chi"].FillWeight = 150;

                dgvNhanVien.Columns["vi_tri"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvNhanVien.Columns["vi_tri"].FillWeight = 120;

                dgvNhanVien.Columns["vai_tro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvNhanVien.Columns["vai_tro"].FillWeight = 120;

                dgvNhanVien.Columns["trang_thai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvNhanVien.Columns["trang_thai"].FillWeight = 120;
            }
            else
            {
                
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn col in dgvNhanVien.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = 120;
                }

                dgvNhanVien.Columns["ho_ten"].Width = 180;
                dgvNhanVien.Columns["dia_chi"].Width = 200;
            }
        }
        private async void UcNhanVien_Load(object sender, EventArgs e)
        {
            await LoadData();
            string placeholderSearch = "Nhập ID Nhân viên/Mã vân tay/tên";

            txtSearch.Text = placeholderSearch;
            txtSearch.ForeColor = Color.Gray;

            txtSearch.Enter += (_, __) =>
            {
                if (txtSearch.Text == placeholderSearch)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.Leave += (_, __) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = placeholderSearch;
                    txtSearch.ForeColor = Color.Gray;
                }
            };
        }

        private async Task LoadData()
        {
            NhanVienService service = new NhanVienService();

            dgvNhanVien.DataSource = await service.GetAll();

            
            if (!dgvNhanVien.Columns.Contains("colCheck"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "colCheck";
                chk.HeaderText = "";
                chk.Width = 40;
                dgvNhanVien.Columns.Insert(0, chk);
            }

            
            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
                col.ReadOnly = true;

            dgvNhanVien.Columns["colCheck"].ReadOnly = false;
            dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvNhanVien.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvNhanVien.ScrollBars = ScrollBars.Both;

            dgvNhanVien.Columns["id"].HeaderText = "ID";
            dgvNhanVien.Columns["ma_van_tay"].HeaderText = "MÃ VÂN TAY";
            dgvNhanVien.Columns["ho_ten"].HeaderText = "HỌ VÀ TÊN";
            dgvNhanVien.Columns["so_dien_thoai"].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvNhanVien.Columns["ngay_sinh"].HeaderText = "NGÀY SINH";
            dgvNhanVien.Columns["dia_chi"].HeaderText = "ĐỊA CHỈ";
            dgvNhanVien.Columns["vi_tri"].HeaderText = "VỊ TRÍ";
            dgvNhanVien.Columns["vai_tro"].HeaderText = "VAI TRÒ";
            dgvNhanVien.Columns["trang_thai"].HeaderText = "TRẠNG THÁI";
            dgvNhanVien.Columns["pin_code"].HeaderText = "PIN CODE";
            dgvNhanVien.Columns["ngay_vao_lam"].HeaderText = "NGÀY VÀO LÀM";
            dgvNhanVien.Columns["loai_luong"].HeaderText = "LOẠI LƯƠNG";
            dgvNhanVien.Columns["created_at"].HeaderText = "NGÀY TẠO";
            dgvNhanVien.Columns["updated_at"].HeaderText = "NGÀY CHỈNH SỬA";

            if (dgvNhanVien.Columns.Contains("pin_code"))
                dgvNhanVien.Columns["pin_code"].Visible = false;

            dgvNhanVien.Columns["ngay_sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["ngay_vao_lam"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["created_at"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvNhanVien.Columns["updated_at"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvNhanVien.EnableHeadersVisualStyles = false;

            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNhanVien.RowHeadersVisible = false;

            dgvNhanVien.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvNhanVien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgvNhanVien.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvNhanVien.RowsDefaultCellStyle.BackColor = Color.White;
            dgvNhanVien.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvNhanVien.GridColor = Color.LightGray;
            dgvNhanVien.BorderStyle = BorderStyle.None;

            dgvNhanVien.RowTemplate.Height = 32;

            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvNhanVien.Columns["colCheck"].ReadOnly = false;

            AdjustGrid();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            FrmNhanVienEdit f = new FrmNhanVienEdit(false);
            f.ShowDialog();
            LoadData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim();

            if (key == "" || key == "Nhập ID Nhân viên/Mã vân tay/tên")
            {
                LoadData();
                return;
            }

            dgvNhanVien.DataSource = await service.Search(key);
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            txtSearch.Left = (panel1.Width - txtSearch.Width - btnSearch.Width - 10) / 2;
            btnSearch.Left = txtSearch.Right + 10;

            txtSearch.Top = (panel1.Height - txtSearch.Height) / 2;
            btnSearch.Top = (panel1.Height - btnSearch.Height) / 2;
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Double Click dòng bạn muốn sửa!");
        }

        private async void dgvNhanVien_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvNhanVien.Rows[e.RowIndex];

            FrmNhanVienEdit f = new FrmNhanVienEdit();
            f.txtIDNhanVien.Text = row.Cells["id"].Value?.ToString();
            f.txtMaVanTay.Text = row.Cells["ma_van_tay"].Value?.ToString();
            f.txtHoTen.Text = row.Cells["ho_ten"].Value?.ToString();
            f.txtSDT.Text = row.Cells["so_dien_thoai"].Value?.ToString();
            f.txtDiaChi.Text = row.Cells["dia_chi"].Value?.ToString();
            f.txtViTri.Text = row.Cells["vi_tri"].Value?.ToString();
            f.txtPin.Text = row.Cells["pin_code"].Value?.ToString();

            f.dtNgaySinh.Value = Convert.ToDateTime(row.Cells["ngay_sinh"].Value);
            f.dtNgayVao.Value = Convert.ToDateTime(row.Cells["ngay_vao_lam"].Value);

            f.cbVaiTro.Text = row.Cells["vai_tro"].Value?.ToString();
            f.cbTrangThai.Text = row.Cells["trang_thai"].Value?.ToString();
            f.cbLoaiLuong.Text = row.Cells["loai_luong"].Value?.ToString();
            f.txtNgayTao.Text = row.Cells["created_at"].Value?.ToString();
            f.txtNgaySua.Text = row.Cells["updated_at"].Value?.ToString();
            f.ShowDialog();

            LoadData();
        }

        private async void btnXoa_Click_1(object sender, EventArgs e)
        {
            List<string> ids = new List<string>();

            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                bool isChecked = row.Cells["colCheck"].Value != null
                 && Convert.ToBoolean(row.Cells["colCheck"].Value);

                if (isChecked)
                {
                    ids.Add(row.Cells["id"].Value.ToString());
                }
            }

            if (ids.Count == 0)
            {
                MessageBox.Show("Tick chọn dòng muốn xóa!");
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa các nhân viên đã chọn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No) return;
            NhanVienService service = new NhanVienService();

            foreach (string id in ids)
            {
                await service.Delete(id);
            }
            MessageBox.Show("Xóa thành công!");

            LoadData();
        }

        private void dgvNhanVien_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.IsCurrentCellDirty)
            {
                dgvNhanVien.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvNhanVien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvNhanVien.Columns["colCheck"].Index)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                bool isChecked = Convert.ToBoolean(row.Cells["colCheck"].Value);

                row.DefaultCellStyle.BackColor = isChecked ? Color.LightPink : Color.White;
            }
        }

    }
}