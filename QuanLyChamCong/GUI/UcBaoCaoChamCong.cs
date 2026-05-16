using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace QuanLyChamCong.GUI
{
    public partial class UcBaoCaoChamCong : BaseUserControl
    {
        ChamCongService service =
            new ChamCongService();

        NhanVienService nhanVienService =
            new NhanVienService();

        public UcBaoCaoChamCong()
        {
            InitializeComponent();
        }

        private async void UcBaoCaoChamCong_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadNhanVien();

            dtTuNgay.Value =
                DateTime.Now.AddMonths(-1);

            dtDenNgay.Value =
                DateTime.Now;

            dtDenNgay.MinDate =
                dtTuNgay.Value.Date;

            await LoadBaoCao();
        }

        private async Task LoadNhanVien()
        {
            var ds =
                await nhanVienService
                .GetAll();

            ds.Insert(
                0,
                new Models.NhanVien
                {
                    id = "TATCA",
                    ho_ten = "Tất cả"
                }
            );

            cboNhanVien.DataSource =
                ds;

            cboNhanVien.DisplayMember =
                "ho_ten";

            cboNhanVien.ValueMember =
                "id";

            cboNhanVien.SelectedIndex =
                0;
        }

        private async void btnLoc_Click(
            object sender,
            EventArgs e
        )
        {
            await LoadBaoCao();
        }

        private async void btnLamMoi_Click(
            object sender,
            EventArgs e
        )
        {
            cboNhanVien.SelectedIndex = 0;

            dtTuNgay.Value =
                DateTime.Now.AddMonths(-1);

            dtDenNgay.Value =
                DateTime.Now;

            await LoadBaoCao();
        }

        private async Task LoadBaoCao()
        {
            try
            {
                if (
                    cboNhanVien.SelectedValue
                    == null
                )
                {
                    return;
                }

                string nhanVienId =
                    cboNhanVien.SelectedValue
                    .ToString();

                var data =
                    await service.BaoCaoTongHop(
                        nhanVienId,
                        dtTuNgay.Value.Date,
                        dtDenNgay.Value.Date
                    );

                dgvBaoCao.DataSource =
                    data;

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private void dtTuNgay_ValueChanged(
            object sender,
            EventArgs e
        )
        {
            dtDenNgay.MinDate =
                dtTuNgay.Value.Date;

            if (
                dtDenNgay.Value.Date
                < dtTuNgay.Value.Date
            )
            {
                dtDenNgay.Value =
                    dtTuNgay.Value.Date;
            }
        }

        private void FormatGrid()
        {
            dgvBaoCao.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvBaoCao.AllowUserToAddRows =
                false;

            dgvBaoCao.RowHeadersVisible =
                false;

            dgvBaoCao.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvBaoCao.MultiSelect =
                false;

            dgvBaoCao.ReadOnly =
                true;

            dgvBaoCao.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            dgvBaoCao.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dgvBaoCao.ColumnHeadersHeight =
                40;

            dgvBaoCao.RowTemplate.Height =
                35;

            if (
                dgvBaoCao.Columns.Count > 0
            )
            {
                dgvBaoCao.Columns[0]
                    .HeaderText =
                    "Mã nhân viên";

                if (
                    dgvBaoCao.Columns.Count > 1
                )
                {
                    dgvBaoCao.Columns[1]
                        .HeaderText =
                        "Họ tên";
                }

                if (
                    dgvBaoCao.Columns.Count > 2
                )
                {
                    dgvBaoCao.Columns[2]
                        .HeaderText =
                        "Tổng số ca công";
                }

                if (
                    dgvBaoCao.Columns.Count > 3
                )
                {
                    dgvBaoCao.Columns[3]
                        .HeaderText =
                        "Tổng ca đi trễ";
                }

                if (
                    dgvBaoCao.Columns.Count > 4
                )
                {
                    dgvBaoCao.Columns[4]
                        .HeaderText =
                        "Tổng ca vắng";
                }
            }
        }

        private async void cboNhanVien_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            if (
                !IsHandleCreated
            )
            {
                return;
            }

            await LoadBaoCao();
        }
    }
}