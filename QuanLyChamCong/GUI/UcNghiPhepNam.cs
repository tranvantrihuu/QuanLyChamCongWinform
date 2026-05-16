
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
    public partial class UcNghiPhepNam : BaseUserControl
    {
        NghiPhepNamService service =
            new NghiPhepNamService();

        public UcNghiPhepNam()
        {
            InitializeComponent();
        }

        private async void UcNghiPhepNam_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadData();
        }

        async Task LoadData()
        {
            List<NghiPhepNam> ds =
                await service.GetAll();

            dgvNghiPhepNam.DataSource =
                ds;

            if (!dgvNghiPhepNam.Columns.Contains("colCheck"))
            {
                DataGridViewCheckBoxColumn chk =
                    new DataGridViewCheckBoxColumn();

                chk.Name = "colCheck";
                chk.HeaderText = "Chọn";
                chk.Width = 50;

                dgvNghiPhepNam.Columns.Insert(0, chk);
            }

            dgvNghiPhepNam.Columns["id"].HeaderText =
                "ID";

            dgvNghiPhepNam.Columns["ho_ten"].HeaderText =
                "NHÂN VIÊN";

            dgvNghiPhepNam.Columns["nam"].HeaderText =
                "NĂM";

            dgvNghiPhepNam.Columns["so_ca_duoc_nghi"].HeaderText =
                "ĐƯỢC NGHỈ";

            dgvNghiPhepNam.Columns["so_ca_da_nghi_co_phep"].HeaderText =
                "CÓ PHÉP";

            dgvNghiPhepNam.Columns["so_ca_da_nghi_khong_phep"].HeaderText =
                "KHÔNG PHÉP";

            dgvNghiPhepNam.Columns["nhan_vien_id"].Visible =
                false;

            dgvNghiPhepNam.Columns["created_at"].Visible =
                false;

            dgvNghiPhepNam.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            
            dgvNghiPhepNam.EditMode =
                DataGridViewEditMode.EditOnEnter;

            dgvNghiPhepNam.AllowUserToAddRows =
                false;

            dgvNghiPhepNam.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvNghiPhepNam.RowHeadersVisible =
                false;

            dgvNghiPhepNam.ReadOnly = false;

            foreach (
                DataGridViewColumn col
                in dgvNghiPhepNam.Columns
            )
            {
                if (col.Name != "colCheck")
                {
                    col.ReadOnly = true;
                }
            }

            dgvNghiPhepNam.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvNghiPhepNam.EnableHeadersVisualStyles =
                false;

            dgvNghiPhepNam.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            dgvNghiPhepNam.ColumnHeadersDefaultCellStyle.BackColor =
                Color.RoyalBlue;

            dgvNghiPhepNam.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvNghiPhepNam.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            dgvNghiPhepNam.ColumnHeadersHeight =
                42;

            foreach (
                DataGridViewColumn col
                in dgvNghiPhepNam.Columns
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

            dgvNghiPhepNam.Columns["ho_ten"]
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            dgvNghiPhepNam.Columns["colCheck"].ReadOnly =
                false;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmNghiPhepNamEdit f =
                new FrmNghiPhepNamEdit();

            f.ShowDialog();

            await LoadData();
        }

        private async void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            if (dgvNghiPhepNam.CurrentRow == null)
            {
                MessageBox.Show(
                    "Chọn dòng muốn sửa"
                );

                return;
            }

            DataGridViewRow row =
                dgvNghiPhepNam.CurrentRow;

            FrmNghiPhepNamEdit f =
                new FrmNghiPhepNamEdit();

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.nhanVienId =
                row.Cells["nhan_vien_id"]
                .Value.ToString();

            f.nam =
                Convert.ToInt32(
                    row.Cells["nam"].Value
                );

            f.soCaDuocNghi =
                Convert.ToInt32(
                    row.Cells["so_ca_duoc_nghi"].Value
                );

            f.soCaCoPhep =
                Convert.ToInt32(
                    row.Cells["so_ca_da_nghi_co_phep"].Value
                );

            f.soCaKhongPhep =
                Convert.ToInt32(
                    row.Cells["so_ca_da_nghi_khong_phep"].Value
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
                in dgvNghiPhepNam.Rows
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

        private void dgvNghiPhepNam_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {
            if (dgvNghiPhepNam.IsCurrentCellDirty)
            {
                dgvNghiPhepNam.CommitEdit(
                    DataGridViewDataErrorContexts.Commit
                );
            }
        }

        private void dgvNghiPhepNam_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
                return;

            if (
                dgvNghiPhepNam.Columns[e.ColumnIndex].Name
                == "colCheck"
            )
            {
                bool isChecked = false;

                if (
                    dgvNghiPhepNam.Rows[e.RowIndex]
                    .Cells["colCheck"].Value != null
                )
                {
                    isChecked = Convert.ToBoolean(
                        dgvNghiPhepNam.Rows[e.RowIndex]
                        .Cells["colCheck"].Value
                    );
                }

                if (isChecked)
                {
                    dgvNghiPhepNam.Rows[e.RowIndex]
                        .DefaultCellStyle.BackColor =
                            Color.LightPink;
                }
                else
                {
                    dgvNghiPhepNam.Rows[e.RowIndex]
                        .DefaultCellStyle.BackColor =
                            Color.White;
                }
            }
        }

        private async void dgvNghiPhepNam_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvNghiPhepNam.Rows[e.RowIndex];

            FrmNghiPhepNamEdit f =
                new FrmNghiPhepNamEdit();

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.nhanVienId =
                row.Cells["nhan_vien_id"]
                .Value.ToString();

            f.nam =
                Convert.ToInt32(
                    row.Cells["nam"].Value
                );

            f.soCaDuocNghi =
                Convert.ToInt32(
                    row.Cells["so_ca_duoc_nghi"].Value
                );

            f.soCaCoPhep =
                Convert.ToInt32(
                    row.Cells["so_ca_da_nghi_co_phep"].Value
                );

            f.soCaKhongPhep =
                Convert.ToInt32(
                    row.Cells["so_ca_da_nghi_khong_phep"].Value
                );

            f.ShowDialog();

            await LoadData();
        }
    }
}