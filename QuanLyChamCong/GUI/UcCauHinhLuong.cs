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
    public partial class UcCauHinhLuong :
        BaseUserControl
    {
        private bool _sortAsc = true;
        private readonly
            CauHinhLuongService _service =
                new CauHinhLuongService();

        public UcCauHinhLuong()
        {
            InitializeComponent();
        }

        private async void UcCauHinhLuong_Load(
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
                List<CauHinhLuong> data =
                    (await _service.GetAll())
                    .OrderBy(x => x.nhan_vien_id)
                    .ToList();

                dgvCauHinhLuong.DataSource =
                    null;

                dgvCauHinhLuong.DataSource =
                    data;
                dgvCauHinhLuong.ColumnHeaderMouseClick +=
                dgvCauHinhLuong_ColumnHeaderMouseClick;
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
            dgvCauHinhLuong.AutoGenerateColumns =
                true;

            dgvCauHinhLuong.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvCauHinhLuong.MultiSelect =
                false;

            dgvCauHinhLuong.ReadOnly =
                true;

            dgvCauHinhLuong.AllowUserToAddRows =
                false;

            /*
             * HEADER
             */

            dgvCauHinhLuong.Columns["id"]
                .HeaderText =
                "ID";

            dgvCauHinhLuong.Columns["nhan_vien_id"]
                .HeaderText =
                "Mã NV";

            dgvCauHinhLuong.Columns["ho_ten"]
                .HeaderText =
                "Họ tên";

            dgvCauHinhLuong.Columns["vi_tri"]
                .HeaderText =
                "Vị trí";

            dgvCauHinhLuong.Columns["loai_luong"]
                .HeaderText =
                "Loại lương";

            dgvCauHinhLuong.Columns["luong_co_ban"]
                .HeaderText =
                "Lương cơ bản";

            dgvCauHinhLuong.Columns["luong_theo_gio"]
                .HeaderText =
                "Lương giờ";

            dgvCauHinhLuong.Columns["luong_tang_ca"]
                .HeaderText =
                "Tăng ca";

            dgvCauHinhLuong.Columns["phu_cap_mac_dinh"]
                .HeaderText =
                "Phụ cấp";

            /*
             * FORMAT MONEY
             */

            dgvCauHinhLuong.Columns["luong_co_ban"]
                .DefaultCellStyle.Format =
                "N0";

            dgvCauHinhLuong.Columns["luong_theo_gio"]
                .DefaultCellStyle.Format =
                "N0";

            dgvCauHinhLuong.Columns["luong_tang_ca"]
                .DefaultCellStyle.Format =
                "N0";

            dgvCauHinhLuong.Columns["phu_cap_mac_dinh"]
                .DefaultCellStyle.Format =
                "N0";

            dgvCauHinhLuong.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                .Fill;

            /*
             * SORT
             */

            foreach (
                DataGridViewColumn col
                in dgvCauHinhLuong.Columns
            )
            {
                col.SortMode =
                    DataGridViewColumnSortMode
                    .Automatic;
            }
        }

        private void dgvCauHinhLuong_ColumnHeaderMouseClick(
            object sender,
            DataGridViewCellMouseEventArgs e
        )
        {
            string columnName =
                dgvCauHinhLuong
                .Columns[e.ColumnIndex]
                .DataPropertyName;

            List<CauHinhLuong> data =
                dgvCauHinhLuong.DataSource
                as List<CauHinhLuong>;

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
                         .GetValue(x, null)
                    )
                    .ToList();
            }
            else
            {
                data = data
                    .OrderByDescending(x =>
                        x.GetType()
                         .GetProperty(columnName)
                         .GetValue(x, null)
                    )
                    .ToList();
            }

            _sortAsc = !_sortAsc;

            dgvCauHinhLuong.DataSource =
                null;

            dgvCauHinhLuong.DataSource =
                data;
        }
        private CauHinhLuong GetCurrentRow()
        {
            if (
                dgvCauHinhLuong.CurrentRow
                == null
            )
            {
                return null;
            }

            return dgvCauHinhLuong
                .CurrentRow
                .DataBoundItem
                as CauHinhLuong;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmCauHinhLuongEdit frm =
                new FrmCauHinhLuongEdit();

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
            CauHinhLuong item =
                GetCurrentRow();

            if (item == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            FrmCauHinhLuongEdit frm =
                new FrmCauHinhLuongEdit();

            frm.IsEdit = true;

            frm.CauHinhLuongEdit =
                item;

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
            CauHinhLuong item =
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

        private async void dgvCauHinhLuong_CellDoubleClick(
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

        private void dgvCauHinhLuong_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }

        private void dgvCauHinhLuong_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {

        }
    }
}