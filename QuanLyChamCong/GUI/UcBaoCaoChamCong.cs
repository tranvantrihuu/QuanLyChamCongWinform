using QuanLyChamCong.BLL;
using QuanLyChamCong.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcBaoCaoChamCong : UserControl
    {
        private BaoCaoChamCongBLL bll =
            new BaoCaoChamCongBLL();

        private DataProvider provider =
            new DataProvider();

        public UcBaoCaoChamCong()
        {
            InitializeComponent();
        }

        private void UcBaoCaoChamCong_Load(
            object sender,
            EventArgs e
        )
        {
            LoadNhanVien();

            dtTuNgay.Value =
                DateTime.Now.AddMonths(-1);

            dtDenNgay.Value =
                DateTime.Now;
            dtDenNgay.MinDate =
                dtTuNgay.Value.Date;

            LoadBaoCao();
        }

        private void LoadNhanVien()
        {
            string sql = @"
SELECT
    id,
    ho_ten
FROM nhan_vien
ORDER BY ho_ten
";

            DataTable dt =
                provider.ExecuteQuery(sql);

            DataRow row =
                dt.NewRow();

            row["id"] = "TATCA";

            row["ho_ten"] = "Tất cả";

            dt.Rows.InsertAt(row, 0);

            cboNhanVien.DataSource = dt;

            cboNhanVien.DisplayMember =
                "ho_ten";

            cboNhanVien.ValueMember =
                "id";

            cboNhanVien.SelectedIndex = 0;
        }

        private void btnLoc_Click(
            object sender,
            EventArgs e
        )
        {
            LoadBaoCao();
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e
        )
        {
            cboNhanVien.SelectedIndex = 0;

            dtTuNgay.Value =
                DateTime.Now.AddMonths(-1);

            dtDenNgay.Value =
                DateTime.Now;

            LoadBaoCao();
        }

        private void LoadBaoCao()
        {
            string nhanVienId =
                cboNhanVien.SelectedValue
                .ToString();

            DataTable dt =
                bll.BaoCaoTongHop(
                    nhanVienId,
                    dtTuNgay.Value.Date,
                    dtDenNgay.Value.Date
                );

            dgvBaoCao.DataSource = dt;

            FormatGrid();
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

            dgvBaoCao.ColumnHeadersHeight = 40;

            dgvBaoCao.RowTemplate.Height = 35;

            if (
                dgvBaoCao.Columns.Contains(
                    "Tổng giờ tăng ca"
                )
            )
            {
                dgvBaoCao.Columns[
                    "Tổng giờ tăng ca"
                ].DefaultCellStyle.Format = "N2";
            }

            if (
                dgvBaoCao.Columns.Contains(
                    "Tỷ lệ chuyên cần (%)"
                )
            )
            {
                dgvBaoCao.Columns[
                    "Tỷ lệ chuyên cần (%)"
                ].DefaultCellStyle.Format = "N2";
            }
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBaoCao();
        }
    }
}