using QuanLyChamCong.BLL;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcCaLam : BaseUserControl
    {
        CaLamBLL bll = new CaLamBLL();

        public UcCaLam()
        {
            InitializeComponent();
            dgvCaLam.CurrentCellDirtyStateChanged += dgvCaLam_CurrentCellDirtyStateChanged;
        }

        private void UcCaLam_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            var dt = bll.GetAll();

            dgvCaLam.DataSource = dt;

            // checkbox
            if (!dgvCaLam.Columns.Contains("colCheck"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "colCheck";
                chk.Width = 40;
                dgvCaLam.Columns.Insert(0, chk);
            }

            dgvCaLam.RowHeadersVisible = false;

            dgvCaLam.ReadOnly = false;

            foreach (DataGridViewColumn col in dgvCaLam.Columns)
            {
                col.ReadOnly = true;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvCaLam.Columns["colCheck"].ReadOnly = false;

            dgvCaLam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // header
            dgvCaLam.Columns["id"].HeaderText = "ID";
            dgvCaLam.Columns["ten_ca"].HeaderText = "TÊN CA";
            dgvCaLam.Columns["gio_bat_dau"].HeaderText = "GIỜ BẮT ĐẦU";
            dgvCaLam.Columns["gio_ket_thuc"].HeaderText = "GIỜ KẾT THÚC";
            dgvCaLam.Columns["phut_cho_phep_di_tre"].HeaderText = "ĐI TRỄ";
            dgvCaLam.Columns["phut_cho_phep_ve_som"].HeaderText = "VỀ SỚM";
            dgvCaLam.Columns["phut_cho_phep_checkin_som"].HeaderText = "CHECKIN SỚM";
            dgvCaLam.Columns["phut_cho_phep_checkout_tre"].HeaderText = "CHECKOUT TRỄ";

            // style giống bạn

            dgvCaLam.EnableHeadersVisualStyles = false;
            dgvCaLam.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvCaLam.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCaLam.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvCaLam.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCaLam.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvCaLam.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCaLam.AllowUserToAddRows = false;
            dgvCaLam.MultiSelect = false;
            dgvCaLam.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        // THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmCaLamEdit f = new FrmCaLamEdit(false);
            f.ShowDialog();
            LoadData();
        }

        // SỬA
        private void dgvCaLam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCaLam.Rows[e.RowIndex];

            FrmCaLamEdit f = new FrmCaLamEdit(true);
            f.id = Convert.ToInt32(row.Cells["id"].Value);
            f.txtTenCa.Text = row.Cells["ten_ca"].Value?.ToString();
            f.dtBatDau.Value = DateTime.Today + (TimeSpan)row.Cells["gio_bat_dau"].Value;
            f.dtKetThuc.Value = DateTime.Today + (TimeSpan)row.Cells["gio_ket_thuc"].Value;
            f.numDiTre.Value = Convert.ToDecimal(row.Cells["phut_cho_phep_di_tre"].Value);
            f.numVeSom.Value = Convert.ToDecimal(row.Cells["phut_cho_phep_ve_som"].Value);
            f.numCheckinSom.Value = Convert.ToDecimal(row.Cells["phut_cho_phep_checkin_som"].Value);
            f.numCheckoutTre.Value = Convert.ToDecimal(row.Cells["phut_cho_phep_checkout_tre"].Value);
            f.ShowDialog();
            LoadData();
        }

        // XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();

            foreach (DataGridViewRow row in dgvCaLam.Rows)
            {
                bool isChecked = row.Cells["colCheck"].Value != null
                    && Convert.ToBoolean(row.Cells["colCheck"].Value);

                if (isChecked)
                {
                    ids.Add(Convert.ToInt32(row.Cells["id"].Value));
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

            if (result == DialogResult.No) return;

            bll.Delete(ids);

            MessageBox.Show("Xóa thành công!");
            LoadData();
        }

        private void dgvCaLam_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCaLam.IsCurrentCellDirty)
            {
                dgvCaLam.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Double click dòng muốn sửa!");
        }

        private void dgvCaLam_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCaLam.Columns["colCheck"].Index)
            {
                var row = dgvCaLam.Rows[e.RowIndex];

                bool isChecked = row.Cells["colCheck"].Value != null &&
                                 Convert.ToBoolean(row.Cells["colCheck"].Value);

                row.DefaultCellStyle.BackColor = isChecked
                    ? Color.LightPink
                    : Color.White;
            }
        }

        
    }
}