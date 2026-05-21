using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcCaLam :
        BaseUserControl
    {
        private readonly CaLamService _service =
            new CaLamService();

        public UcCaLam()
        {
            InitializeComponent();
        }

        private async void UcCaLam_Load(
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
                List<CaLam> ds =
                    await _service.GetAll();

                dgvCaLam.DataSource = null;

                dgvCaLam.DataSource = ds;

                dgvCaLam.AutoGenerateColumns =
                    true;

                dgvCaLam.SelectionMode =
                    DataGridViewSelectionMode
                    .FullRowSelect;

                dgvCaLam.MultiSelect =
                    false;

                dgvCaLam.AllowUserToAddRows =
                    false;

                dgvCaLam.ReadOnly =
                    true;

                /*
                 * HEADER
                 */

                dgvCaLam.Columns["id"]
                    .HeaderText =
                    "ID";

                dgvCaLam.Columns["ten_ca"]
                    .HeaderText =
                    "Tên ca";

                dgvCaLam.Columns["gio_bat_dau"]
                    .HeaderText =
                    "Giờ bắt đầu";

                dgvCaLam.Columns["gio_ket_thuc"]
                    .HeaderText =
                    "Giờ kết thúc";

                dgvCaLam.Columns["phut_cho_phep_di_tre"]
                    .HeaderText =
                    "Phút cho phép đi trễ";

                dgvCaLam.Columns["phut_cho_phep_ve_som"]
                    .HeaderText =
                    "Phút cho phép về sớm";

                dgvCaLam.Columns["phut_cho_phep_checkin_som"]
                    .HeaderText =
                    "Checkin sớm";

                dgvCaLam.Columns["phut_cho_phep_checkout_tre"]
                    .HeaderText =
                    "Checkout trễ";

                /*
                 * WIDTH
                 */

                dgvCaLam.Columns["id"]
                    .Width = 60;

                dgvCaLam.Columns["ten_ca"]
                    .Width = 180;

                dgvCaLam.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode
                    .Fill;

                /*
                 * FORMAT TIME
                 */

                dgvCaLam.Columns["gio_bat_dau"]
                    .DefaultCellStyle.Format =
                    @"hh\:mm";

                dgvCaLam.Columns["gio_ket_thuc"]
                    .DefaultCellStyle.Format =
                    @"hh\:mm";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load dữ liệu:\n"
                    + ex.Message
                );
            }
        }

        private CaLam GetCurrentRow()
        {
            if (
                dgvCaLam.CurrentRow
                == null
            )
            {
                return null;
            }

            return dgvCaLam
                .CurrentRow
                .DataBoundItem
                as CaLam;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmCaLamEdit frm =
                new FrmCaLamEdit();

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
            CaLam ca =
                GetCurrentRow();

            if (ca == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn ca làm"
                );

                return;
            }

            FrmCaLamEdit frm =
                new FrmCaLamEdit();

            frm.IsEdit = true;

            frm.CaLamEdit = ca;

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
            CaLam ca =
                GetCurrentRow();

            if (ca == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn ca làm"
                );

                return;
            }

            DialogResult rs =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa ca làm này?",
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
                    ca.id
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

        private async void dgvCaLam_CellDoubleClick(
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
         * Designer đang bind event
         * nên phải để tránh lỗi runtime
         */

        private void dgvCaLam_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }

        private void dgvCaLam_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {

        }
    }
}