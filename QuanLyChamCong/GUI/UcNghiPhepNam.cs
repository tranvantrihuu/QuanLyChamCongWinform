using QuanLyChamCong.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcNghiPhepNam : UserControl
    {
        NghiPhepNamBLL bll = new NghiPhepNamBLL();

        public UcNghiPhepNam()
        {
            InitializeComponent();
        }

        private void UcNghiPhepNam_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            DataTable dt = bll.GetAll();

            dgvNghiPhepNam.DataSource = dt;

            if (!dgvNghiPhepNam.Columns.Contains("colCheck"))
            {
                DataGridViewCheckBoxColumn chk =
                    new DataGridViewCheckBoxColumn();

                chk.Name = "colCheck";
                chk.HeaderText = "Chọn";
                chk.Width = 50;

                dgvNghiPhepNam.Columns.Insert(0, chk);
            }

            dgvNghiPhepNam.Columns["id"].HeaderText = "ID";
            dgvNghiPhepNam.Columns["ho_ten"].HeaderText = "NHÂN VIÊN";
            dgvNghiPhepNam.Columns["nam"].HeaderText = "NĂM";
            dgvNghiPhepNam.Columns["so_ca_duoc_nghi"].HeaderText = "ĐƯỢC NGHỈ";
            dgvNghiPhepNam.Columns["so_ca_da_nghi_co_phep"].HeaderText = "CÓ PHÉP";
            dgvNghiPhepNam.Columns["so_ca_da_nghi_khong_phep"].HeaderText = "KHÔNG PHÉP";

            dgvNghiPhepNam.Columns["nhan_vien_id"].Visible = false;
            dgvNghiPhepNam.Columns["created_at"].Visible = false;
            dgvNghiPhepNam.SelectionMode =DataGridViewSelectionMode.FullRowSelect;
            
            // Tick checkbox được
            dgvNghiPhepNam.EditMode = DataGridViewEditMode.EditOnEnter;

            dgvNghiPhepNam.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvNghiPhepNam.IsCurrentCellDirty)
                {
                    dgvNghiPhepNam.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
            dgvNghiPhepNam.AllowUserToAddRows = false;

            dgvNghiPhepNam.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvNghiPhepNam.RowHeadersVisible = false;

            // KHÔNG để readonly cả grid
            dgvNghiPhepNam.ReadOnly = false;

            // Chỉ khóa các cột dữ liệu
            foreach (DataGridViewColumn col in dgvNghiPhepNam.Columns)
            {
                if (col.Name != "colCheck")
                {
                    col.ReadOnly = true;
                }
            }
            dgvNghiPhepNam.CellValueChanged += dgvNghiPhepNam_CellValueChanged;
            dgvNghiPhepNam.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNghiPhepNam.EnableHeadersVisualStyles = false;

            // HEADER
            dgvNghiPhepNam.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            dgvNghiPhepNam.ColumnHeadersDefaultCellStyle.BackColor =
                Color.RoyalBlue;

            dgvNghiPhepNam.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvNghiPhepNam.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);


            dgvNghiPhepNam.ColumnHeadersHeight = 42;

            // CELL
            foreach (DataGridViewColumn col in dgvNghiPhepNam.Columns)
            {
                // tất cả center
                col.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                // font
                col.DefaultCellStyle.Font =
                    new Font("Segoe UI", 10);

                // header in hoa
                col.HeaderText = col.HeaderText.ToUpper();
            }

            // riêng tên nhân viên căn trái
            dgvNghiPhepNam.Columns["ho_ten"]
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
            dgvNghiPhepNam.Columns["colCheck"].ReadOnly = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmNghiPhepNamEdit f =
                new FrmNghiPhepNamEdit(false);

            f.ShowDialog();

            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNghiPhepNam.CurrentRow == null)
            {
                MessageBox.Show("Chọn dòng muốn sửa");
                return;
            }

            DataGridViewRow row = dgvNghiPhepNam.CurrentRow;

            FrmNghiPhepNamEdit f =
                new FrmNghiPhepNamEdit(true);

            f.id = Convert.ToInt32(row.Cells["id"].Value);

            f.cbNhanVien.SelectedValue =
                row.Cells["nhan_vien_id"].Value;

            f.numNam.Value =
                Convert.ToDecimal(row.Cells["nam"].Value);

            f.numDuocNghi.Value =
                Convert.ToDecimal(
                    row.Cells["so_ca_duoc_nghi"].Value
                );

            f.numCoPhep.Value =
                Convert.ToDecimal(
                    row.Cells["so_ca_da_nghi_co_phep"].Value
                );

            f.numKhongPhep.Value =
                Convert.ToDecimal(
                    row.Cells["so_ca_da_nghi_khong_phep"].Value
                );

            f.ShowDialog();

            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();

            foreach (DataGridViewRow row in dgvNghiPhepNam.Rows)
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
                MessageBox.Show("Tick chọn dòng muốn xóa!");
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

            bll.Delete(ids);

            MessageBox.Show("Xóa thành công!");

            LoadData();
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

        private void dgvNghiPhepNam_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvNghiPhepNam.Rows[e.RowIndex];

            FrmNghiPhepNamEdit f =
                new FrmNghiPhepNamEdit(true);

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.cbNhanVien.SelectedValue =
                row.Cells["nhan_vien_id"].Value;

            f.numNam.Value =
                Convert.ToDecimal(
                    row.Cells["nam"].Value
                );

            f.numDuocNghi.Value =
                Convert.ToDecimal(
                    row.Cells["so_ca_duoc_nghi"].Value
                );

            f.numCoPhep.Value =
                Convert.ToDecimal(
                    row.Cells["so_ca_da_nghi_co_phep"].Value
                );

            f.numKhongPhep.Value =
                Convert.ToDecimal(
                    row.Cells["so_ca_da_nghi_khong_phep"].Value
                );

            f.ShowDialog();

            LoadData();
        }
    }
}