using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcNghiPhepNam :
        BaseUserControl
    {
        private readonly NghiPhepNamService _service =
            new NghiPhepNamService();

        private bool _sortAsc = true;

        public UcNghiPhepNam()
        {
            InitializeComponent();

            dgvNghiPhepNam.ColumnHeaderMouseClick +=
                dgvNghiPhepNam_ColumnHeaderMouseClick;
        }

        private async void UcNghiPhepNam_Load(
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
                List<NghiPhepNam> data =
                    (await _service.GetAll())
                    .OrderBy(x => x.nhan_vien_id)
                    .ToList();

                dgvNghiPhepNam.DataSource =
                    null;

                dgvNghiPhepNam.DataSource =
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
            dgvNghiPhepNam.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvNghiPhepNam.MultiSelect =
                false;

            dgvNghiPhepNam.ReadOnly =
                true;

            dgvNghiPhepNam.AllowUserToAddRows =
                false;

            /*
             * HEADER
             */

            dgvNghiPhepNam.Columns["id"]
                .HeaderText =
                "ID";

            dgvNghiPhepNam.Columns["nhan_vien_id"]
                .HeaderText =
                "Mã NV";

            dgvNghiPhepNam.Columns["ho_ten"]
                .HeaderText =
                "Họ tên";

            dgvNghiPhepNam.Columns["nam"]
                .HeaderText =
                "Năm";

            dgvNghiPhepNam.Columns["so_ca_duoc_nghi"]
                .HeaderText =
                "Số ca được nghỉ";

            dgvNghiPhepNam.Columns["so_ca_da_nghi_co_phep"]
                .HeaderText =
                "Đã nghỉ có phép";

            dgvNghiPhepNam.Columns["so_ca_da_nghi_khong_phep"]
                .HeaderText =
                "Đã nghỉ không phép";

            dgvNghiPhepNam.Columns["created_at"]
                .HeaderText =
                "Ngày tạo";

            dgvNghiPhepNam.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                .Fill;

            /*
             * ENABLE SORT
             */

            foreach (
                DataGridViewColumn col
                in dgvNghiPhepNam.Columns
            )
            {
                col.SortMode =
                    DataGridViewColumnSortMode
                    .Automatic;
            }
        }

        private void dgvNghiPhepNam_ColumnHeaderMouseClick(
            object sender,
            DataGridViewCellMouseEventArgs e
        )
        {
            string columnName =
                dgvNghiPhepNam
                .Columns[e.ColumnIndex]
                .Name;

            List<NghiPhepNam> data =
                dgvNghiPhepNam.DataSource
                as List<NghiPhepNam>;

            if (data == null)
            {
                return;
            }

            if (_sortAsc)
            {
                data = data
                    .OrderBy(x =>
                        x.GetType()
                         .GetProperty(columnName)
                         ?.GetValue(x, null)
                    )
                    .ToList();
            }
            else
            {
                data = data
                    .OrderByDescending(x =>
                        x.GetType()
                         .GetProperty(columnName)
                         ?.GetValue(x, null)
                    )
                    .ToList();
            }

            _sortAsc = !_sortAsc;

            dgvNghiPhepNam.DataSource =
                null;

            dgvNghiPhepNam.DataSource =
                data;

            FormatGrid();
        }

        private NghiPhepNam GetCurrentRow()
        {
            if (
                dgvNghiPhepNam.CurrentRow
                == null
            )
            {
                return null;
            }

            return dgvNghiPhepNam
                .CurrentRow
                .DataBoundItem
                as NghiPhepNam;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmNghiPhepNamEdit frm =
                new FrmNghiPhepNamEdit();

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
            NghiPhepNam item =
                GetCurrentRow();

            if (item == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            FrmNghiPhepNamEdit frm =
                new FrmNghiPhepNamEdit();

            frm.IsEdit = true;

            frm.NghiPhepNamEdit = item;

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
            NghiPhepNam item =
                GetCurrentRow();

            if (item == null)
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
                    item.id
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

        private async void dgvNghiPhepNam_CellDoubleClick(
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

        /*
         * DESIGNER ĐANG BIND EVENT
         */

        private void dgvNghiPhepNam_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }

        private void dgvNghiPhepNam_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {

        }
    }
}