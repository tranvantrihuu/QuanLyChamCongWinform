
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcNghiPhep : BaseUserControl
    {
        NghiPhepService service =
            new NghiPhepService();

        public UcNghiPhep()
        {
            InitializeComponent();
        }

        private async void UcNghiPhep_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadData();
        }

        async Task LoadData()
        {
            List<NghiPhep> ds =
                await service.GetAll();

            dgvNghiPhep.DataSource =
                ds;

            if (!dgvNghiPhep.Columns.Contains("colCheck"))
            {
                DataGridViewCheckBoxColumn chk =
                    new DataGridViewCheckBoxColumn();

                chk.Name = "colCheck";
                chk.HeaderText = "Chọn";
                chk.Width = 50;

                dgvNghiPhep.Columns.Insert(0, chk);
            }

            dgvNghiPhep.Columns["id"].HeaderText =
                "ID";

            dgvNghiPhep.Columns["ho_ten"].HeaderText =
                "NHÂN VIÊN";

            dgvNghiPhep.Columns["ca_lam_id"].HeaderText =
                "CA LÀM";

            dgvNghiPhep.Columns["ngay"].HeaderText =
                "NGÀY";

            dgvNghiPhep.Columns["loai"].HeaderText =
                "LOẠI";

            dgvNghiPhep.Columns["ly_do"].HeaderText =
                "LÝ DO";

            dgvNghiPhep.Columns["nhan_vien_id"].Visible =
                false;

            dgvNghiPhep.Columns["created_at"].Visible =
                false;

            dgvNghiPhep.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            
            dgvNghiPhep.EditMode =
                DataGridViewEditMode.EditOnEnter;

            dgvNghiPhep.AllowUserToAddRows =
                false;

            dgvNghiPhep.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvNghiPhep.RowHeadersVisible =
                false;

            dgvNghiPhep.ReadOnly = false;

            foreach (
                DataGridViewColumn col
                in dgvNghiPhep.Columns
            )
            {
                if (col.Name != "colCheck")
                {
                    col.ReadOnly = true;
                }
            }

            dgvNghiPhep.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvNghiPhep.EnableHeadersVisualStyles =
                false;

            dgvNghiPhep.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            dgvNghiPhep.ColumnHeadersDefaultCellStyle.BackColor =
                Color.RoyalBlue;

            dgvNghiPhep.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvNghiPhep.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            dgvNghiPhep.ColumnHeadersHeight =
                42;

            foreach (
                DataGridViewColumn col
                in dgvNghiPhep.Columns
            )
            {
                col.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                col.DefaultCellStyle.Font =
                    new Font(
                        "Segoe UI",
                        10
                    );

                col.HeaderText =
                    col.HeaderText.ToUpper();
            }

            dgvNghiPhep.Columns["ho_ten"]
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            dgvNghiPhep.Columns["colCheck"].ReadOnly =
                false;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmNghiPhepEdit f =
                new FrmNghiPhepEdit();

            f.ShowDialog();

            await LoadData();
        }

        private async void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            if (dgvNghiPhep.CurrentRow == null)
            {
                MessageBox.Show(
                    "Chọn dòng muốn sửa"
                );

                return;
            }

            DataGridViewRow row =
                dgvNghiPhep.CurrentRow;

            FrmNghiPhepEdit f =
                new FrmNghiPhepEdit();

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.nhanVienId =
                row.Cells["nhan_vien_id"]
                .Value.ToString();

            f.caLamId =
                Convert.ToInt32(
                    row.Cells["ca_lam_id"].Value
                );

            f.loai =
                row.Cells["loai"]
                .Value.ToString();

            f.lyDo =
                row.Cells["ly_do"]
                .Value.ToString();

            f.ngay =
                Convert.ToDateTime(
                    row.Cells["ngay"].Value
                );

            f.ShowDialog();

            await LoadData();
        }

        private async void btnXoa_Click(
            object sender,
            EventArgs e
        )
        {
            List<int> ids =
                new List<int>();

            foreach (
                DataGridViewRow row
                in dgvNghiPhep.Rows
            )
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
                await service.Delete(id);
            }

            MessageBox.Show(
                "Xóa thành công!"
            );

            await LoadData();
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
            if (e.RowIndex < 0)
                return;

            if (
                dgvNghiPhep.Columns[e.ColumnIndex].Name
                == "colCheck"
            )
            {
                bool isChecked = false;

                if (
                    dgvNghiPhep.Rows[e.RowIndex]
                    .Cells["colCheck"].Value != null
                )
                {
                    isChecked = Convert.ToBoolean(
                        dgvNghiPhep.Rows[e.RowIndex]
                        .Cells["colCheck"].Value
                    );
                }

                if (isChecked)
                {
                    dgvNghiPhep.Rows[e.RowIndex]
                        .DefaultCellStyle.BackColor =
                            Color.LightPink;
                }
                else
                {
                    dgvNghiPhep.Rows[e.RowIndex]
                        .DefaultCellStyle.BackColor =
                            Color.White;
                }
            }
        }

        private async void dgvNghiPhep_CellDoubleClick(
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

            f.nhanVienId =
                row.Cells["nhan_vien_id"]
                .Value.ToString();

            f.caLamId =
                Convert.ToInt32(
                    row.Cells["ca_lam_id"].Value
                );

            f.loai =
                row.Cells["loai"]
                .Value.ToString();

            f.lyDo =
                row.Cells["ly_do"]
                .Value.ToString();

            f.ngay =
                Convert.ToDateTime(
                    row.Cells["ngay"].Value
                );

            f.ShowDialog();

            await LoadData();
        }
    }
}