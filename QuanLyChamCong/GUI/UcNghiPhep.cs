using QuanLyChamCong.Models;
using QuanLyChamCong.Models.ViewModels;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcNghiPhep :
        BaseUserControl
    {
        private readonly NghiPhepService _service =
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

        private async Task LoadData()
        {
            try
            {
                List<VwDanhSachNghiPhep> data =
                    await _service.GetAll();

                dgvNghiPhep.DataSource =
                    null;

                dgvNghiPhep.DataSource =
                    data;

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load dữ liệu:\n"
                    + ex.Message
                );
            }
        }

        private void FormatGrid()
        {
            dgvNghiPhep.AutoGenerateColumns =
                true;

            dgvNghiPhep.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvNghiPhep.MultiSelect =
                false;

            dgvNghiPhep.ReadOnly =
                true;

            dgvNghiPhep.AllowUserToAddRows =
                false;

            dgvNghiPhep.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                .Fill;

            /*
             * HEADER
             */

            dgvNghiPhep.Columns["id"]
                .HeaderText =
                "ID";

            dgvNghiPhep.Columns["ho_ten"]
                .HeaderText =
                "Nhân viên";

            dgvNghiPhep.Columns["ca_lam_id"]
                .HeaderText =
                "Ca làm";

            dgvNghiPhep.Columns["ngay"]
                .HeaderText =
                "Ngày";

            dgvNghiPhep.Columns["loai"]
                .HeaderText =
                "Loại";

            dgvNghiPhep.Columns["ly_do"]
                .HeaderText =
                "Lý do";

            /*
             * ẨN FIELD
             */

            if (
                dgvNghiPhep.Columns["nhan_vien_id"]
                != null
            )
            {
                dgvNghiPhep.Columns["nhan_vien_id"]
                    .Visible = false;
            }

            if (
                dgvNghiPhep.Columns["vi_tri"]
                != null
            )
            {
                dgvNghiPhep.Columns["vi_tri"]
                    .Visible = false;
            }
        }

        private VwDanhSachNghiPhep
            GetCurrentRow()
        {
            if (
                dgvNghiPhep.CurrentRow
                == null
            )
            {
                return null;
            }

            return dgvNghiPhep
                .CurrentRow
                .DataBoundItem
                as VwDanhSachNghiPhep;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmNghiPhepEdit frm =
                new FrmNghiPhepEdit();

            frm.IsEdit = false;

            if (
                frm.ShowDialog()
                == DialogResult.OK
            )
            {
                await LoadData();
            }
        }

        private async void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            var row =
                GetCurrentRow();

            if (row == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            FrmNghiPhepEdit frm =
                new FrmNghiPhepEdit();

            frm.IsEdit = true;

            frm.NghiPhepEdit =
                new NghiPhep
                {
                    id = row.id,
                    nhan_vien_id =
                        row.nhan_vien_id,

                    ca_lam_id =
                        row.ca_lam_id,

                    ngay =
                        row.ngay,

                    loai =
                        row.loai,

                    ly_do =
                        row.ly_do
                };

            if (
                frm.ShowDialog()
                == DialogResult.OK
            )
            {
                await LoadData();
            }
        }

        private async void btnXoa_Click(
            object sender,
            EventArgs e
        )
        {
            var row =
                GetCurrentRow();

            if (row == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            DialogResult rs =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (rs != DialogResult.Yes)
            {
                return;
            }

            bool result =
                await _service.Delete(
                    row.id
                );

            if (result)
            {
                MessageBox.Show(
                    "Xóa thành công"
                );

                await LoadData();
            }
            else
            {
                MessageBox.Show(
                    "Xóa thất bại"
                );
            }
        }

        private async void dgvNghiPhep_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            await Task.Delay(1);

            btnSua.PerformClick();
        }

        private void dgvNghiPhep_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }

        private void dgvNghiPhep_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {

        }
    }
}