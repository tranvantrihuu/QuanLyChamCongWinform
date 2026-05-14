// UcNghiPhep.cs

using BLL;
using QuanLyChamCong.BLL;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcNghiPhep : BaseUserControl
    {
        NghiPhepBLL bll = new NghiPhepBLL();

        public UcNghiPhep()
        {
            InitializeComponent();
        }

        private void UcNghiPhep_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            DataTable dt = bll.GetAll();

            dgvNghiPhep.DataSource = dt;

            if (!dgvNghiPhep.Columns.Contains("colCheck"))
            {
                DataGridViewCheckBoxColumn chk =
                    new DataGridViewCheckBoxColumn();

                chk.Name = "colCheck";
                chk.HeaderText = "Chọn";
                chk.Width = 50;

                dgvNghiPhep.Columns.Insert(0, chk);
            }

            dgvNghiPhep.Columns["id"].HeaderText = "ID";
            dgvNghiPhep.Columns["ho_ten"].HeaderText = "NHÂN VIÊN";
            dgvNghiPhep.Columns["ca_lam_id"].HeaderText = "CA LÀM";
            dgvNghiPhep.Columns["ngay"].HeaderText = "NGÀY";
            dgvNghiPhep.Columns["loai"].HeaderText = "LOẠI";
            dgvNghiPhep.Columns["ly_do"].HeaderText = "LÝ DO";

            dgvNghiPhep.Columns["created_at"].Visible = false;
            dgvNghiPhep.Columns["nhan_vien_id"].Visible = false;
            dgvNghiPhep.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvNghiPhep.AllowUserToAddRows = false;

            dgvNghiPhep.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvNghiPhep.RowHeadersVisible = false;
            foreach (DataGridViewColumn col in dgvNghiPhep.Columns)
            {
                col.ReadOnly = true;
            }

            dgvNghiPhep.Columns["colCheck"].ReadOnly = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmNghiPhepEdit f =
                new FrmNghiPhepEdit();

            f.ShowDialog();

            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNghiPhep.CurrentRow == null)
            {
                MessageBox.Show("Chọn dòng muốn sửa");
                return;
            }

            DataGridViewRow row = dgvNghiPhep.CurrentRow;

            FrmNghiPhepEdit f =
                new FrmNghiPhepEdit();

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.cbNhanVien.Text =
                row.Cells["nhan_vien_id"]
                .Value.ToString();

            f.cbCaLam.SelectedValue =
                row.Cells["ca_lam_id"].Value;

            f.dtNgay.Value =
                Convert.ToDateTime(
                    row.Cells["ngay"].Value
                );

            f.cbLoai.Text =
                row.Cells["loai"]
                .Value.ToString();

            f.txtLyDo.Text =
                row.Cells["ly_do"]
                .Value.ToString();

            f.ShowDialog();

            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();

            foreach (DataGridViewRow row in dgvNghiPhep.Rows)
            {
                bool isChecked =
                    row.Cells["colCheck"].Value != null
                    && Convert.ToBoolean(
                        row.Cells["colCheck"].Value
                    );

                if (isChecked)
                {
                    ids.Add(
                        Convert.ToInt32(
                            row.Cells["id"].Value
                        )
                    );
                }
            }

            if (ids.Count == 0)
            {
                MessageBox.Show(
                    "Tick chọn dòng muốn xóa!"
                );

                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            foreach (int id in ids)
            {
                bll.Delete(id);
            }

            MessageBox.Show("Xóa thành công!");

            LoadData();
        }

        private void dgvNghiPhep_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {
            if (dgvNghiPhep.IsCurrentCellDirty)
            {
                dgvNghiPhep.CommitEdit(
                    DataGridViewDataErrorContexts.Commit
                );
            }
        }

        private void dgvNghiPhep_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }

        private void dgvNghiPhep_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvNghiPhep.Rows[e.RowIndex];

            FrmNghiPhepEdit f =
                new FrmNghiPhepEdit();

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.cbNhanVien.Text =
                row.Cells["nhan_vien_id"]
                .Value.ToString();

            f.cbCaLam.SelectedValue =
                row.Cells["ca_lam_id"].Value;

            f.dtNgay.Value =
                Convert.ToDateTime(
                    row.Cells["ngay"].Value
                );

            f.cbLoai.Text =
                row.Cells["loai"]
                .Value.ToString();

            f.txtLyDo.Text =
                row.Cells["ly_do"]
                .Value.ToString();

            f.ShowDialog();

            LoadData();
        }
    }
}