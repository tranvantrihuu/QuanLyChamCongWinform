using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace QuanLyChamCong.GUI
{
    public partial class UcCaLam : BaseUserControl
    {
        CaLamService service =
            new CaLamService();

        List<CaLam> dsCaLam =
            new List<CaLam>();

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

        async System.Threading.Tasks.Task
            LoadData()
        {
            dsCaLam =
                await service.GetAll();

            dgvCaLam.DataSource =
                null;

            dgvCaLam.DataSource =
                dsCaLam;

            FormatGrid();
        }

        void FormatGrid()
        {
            if (
                dgvCaLam.Columns.Count == 0
            )
            {
                return;
            }

            dgvCaLam.Columns["id"]
                .HeaderText = "ID";

            dgvCaLam.Columns["ten_ca"]
                .HeaderText = "Tên ca";

            dgvCaLam.Columns["gio_bat_dau"]
                .HeaderText = "Giờ bắt đầu";

            dgvCaLam.Columns["gio_ket_thuc"]
                .HeaderText = "Giờ kết thúc";

            dgvCaLam.Columns[
                "phut_cho_phep_di_tre"]
                .HeaderText =
                "Đi trễ";

            dgvCaLam.Columns[
                "phut_cho_phep_ve_som"]
                .HeaderText =
                "Về sớm";

            dgvCaLam.Columns[
                "phut_cho_phep_checkin_som"]
                .HeaderText =
                "Checkin sớm";

            dgvCaLam.Columns[
                "phut_cho_phep_checkout_tre"]
                .HeaderText =
                "Checkout trễ";

            dgvCaLam.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCaLam.ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );
        }

        

        private async void btnXoa_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                dgvCaLam.CurrentRow
                == null
            )
            {
                return;
            }

            int id =
                Convert.ToInt32(
                    dgvCaLam
                    .CurrentRow
                    .Cells["id"]
                    .Value
                );

            var rs =
                MessageBox.Show(
                    "Xóa ca làm này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (rs != DialogResult.Yes)
            {
                return;
            }

            bool success =
                await service.Delete(id);

            if (success)
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

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmCaLamEdit f =
                new FrmCaLamEdit();

            f.ShowDialog();

            await LoadData();
        }

        private async void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            await OpenEdit();
        }

        private async void dgvCaLam_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            await OpenEdit();
        }
        
        private async Task OpenEdit()
        {
            if (
                dgvCaLam.CurrentRow
                == null
            )
            {
                return;
            }

            int id =
                Convert.ToInt32(
                    dgvCaLam
                    .CurrentRow
                    .Cells["id"]
                    .Value
                );

            FrmCaLamEdit f =
                new FrmCaLamEdit(true);

            f.id = id;

            f.txtTenCa.Text =
                dgvCaLam.CurrentRow
                .Cells["ten_ca"]
                .Value
                .ToString();

            f.dtBatDau.Value =
                DateTime.Today.Add(
                    TimeSpan.Parse(
                        dgvCaLam.CurrentRow
                        .Cells["gio_bat_dau"]
                        .Value
                        .ToString()
                    )
                );

            f.dtKetThuc.Value =
                DateTime.Today.Add(
                    TimeSpan.Parse(
                        dgvCaLam.CurrentRow
                        .Cells["gio_ket_thuc"]
                        .Value
                        .ToString()
                    )
                );

            f.numDiTre.Value =
                Convert.ToDecimal(
                    dgvCaLam.CurrentRow
                    .Cells[
                        "phut_cho_phep_di_tre"]
                    .Value
                );

            f.numVeSom.Value =
                Convert.ToDecimal(
                    dgvCaLam.CurrentRow
                    .Cells[
                        "phut_cho_phep_ve_som"]
                    .Value
                );

            f.numCheckinSom.Value =
                Convert.ToDecimal(
                    dgvCaLam.CurrentRow
                    .Cells[
                        "phut_cho_phep_checkin_som"]
                    .Value
                );

            f.numCheckoutTre.Value =
                Convert.ToDecimal(
                    dgvCaLam.CurrentRow
                    .Cells[
                        "phut_cho_phep_checkout_tre"]
                    .Value
                );

            f.ShowDialog();

            await LoadData();
        }
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