using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyChamCong.Models.ViewModels;
namespace QuanLyChamCong.GUI
{
    public partial class UcBaoCaoChamCong :
        BaseUserControl
    {
        private bool sortAscending = true;
        private readonly
            ChamCongService chamCongService =
                new ChamCongService();

        private readonly
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
            dtTuNgay.Value =
                DateTime.Now.AddDays(-7);

            dtDenNgay.Value =
                DateTime.Now;

            await LoadNhanVien();
           
            await LoadData();
        }

        private async Task LoadNhanVien()
        {
            try
            {
                List<NhanVien> ds =
                    await nhanVienService
                    .GetAll();

                ds.Insert(
                    0,
                    new NhanVien
                    {
                        id = "",
                        ho_ten =
                            "-- Tất cả --"
                    }
                );

                cboNhanVien.DataSource =
                    ds;

                cboNhanVien.DisplayMember =
                    "ho_ten";

                cboNhanVien.ValueMember =
                    "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private async Task LoadData()
        {
            try
            {
                var data =
                    await chamCongService.ThongKeChamCong(
                    null,
                    dtTuNgay.Value.Date,
                    dtDenNgay.Value.Date
                );

                dgvBaoCao.DataSource =
                    data;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormatGrid()
        {
            if (
                dgvBaoCao.Columns.Count <= 0
            )
            {
                return;
            }

            dgvBaoCao.Columns[
                "nhan_vien_id"
            ].HeaderText =
                "Mã nhân viên";

            dgvBaoCao.Columns[
                "ho_ten"
            ].HeaderText =
                "Họ tên";

            dgvBaoCao.Columns[
                "tong_so_ca_cong"
            ].HeaderText =
                "Tổng số ca công";

            dgvBaoCao.Columns[
                "tong_ca_di_tre"
            ].HeaderText =
                "Tổng ca đi trễ";

            dgvBaoCao.Columns[
                "tong_ca_vang"
            ].HeaderText =
                "Tổng ca vắng";
            dgvBaoCao.Columns["tu_ngay"].Visible = false;

            dgvBaoCao.Columns["den_ngay"].Visible =  false;
        }
        private async void btnLoc_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                string nhanVienId =
                    cboNhanVien.SelectedValue?
                    .ToString();

                var data =
                    await chamCongService
                    .ThongKeChamCong(
                        nhanVienId,
                        dtTuNgay.Value.Date,
                        dtDenNgay.Value.Date
                    );

                dgvBaoCao.DataSource =
                    null;

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

        private async void btnLamMoi_Click(
            object sender,
            EventArgs e
        )
        {
            cboNhanVien.SelectedIndex =
                0;

            dtTuNgay.Value =
                DateTime.Now.AddDays(-7);

            dtDenNgay.Value =
                DateTime.Now;

            await LoadData();
        }

        private void cboNhanVien_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

        }
        private void dgvBaoCao_ColumnHeaderMouseClick(
            object sender,
            DataGridViewCellMouseEventArgs e
        )
        {
            string columnName =
                dgvBaoCao.Columns[e.ColumnIndex]
                .DataPropertyName;

            if (string.IsNullOrEmpty(columnName))
            {
                return;
            }

            List<VwThongKeChamCongNhanVien> data =
                dgvBaoCao.DataSource
                as List<VwThongKeChamCongNhanVien>;

            if (data == null)
            {
                return;
            }

            if (sortAscending)
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

            sortAscending = !sortAscending;

            dgvBaoCao.DataSource = null;
            dgvBaoCao.DataSource = data;

            FormatGrid();
        }
        private void dtTuNgay_ValueChanged(
            object sender,
            EventArgs e)
        {

        }
    }
}