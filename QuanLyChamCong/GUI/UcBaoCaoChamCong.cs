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
    public partial class UcBaoCaoChamCong :
        BaseUserControl
    {
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

            await LoadBaoCao();
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

        private async Task LoadBaoCao()
        {
            try
            {
                List<BaoCaoChamCong> ds =
                    await chamCongService
                    .GetAll();

                dgvBaoCao.DataSource =
                    null;

                dgvBaoCao.DataSource =
                    ds;

                dgvBaoCao.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode
                    .Fill;

                dgvBaoCao.AllowUserToAddRows =
                    false;

                dgvBaoCao.ReadOnly = true;

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
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

            dgvBaoCao.Columns["id"]
                .HeaderText = "ID";

            dgvBaoCao.Columns["nhan_vien_id"]
                .HeaderText = "Mã NV";

            dgvBaoCao.Columns["ho_ten"]
                .HeaderText = "Họ tên";

            dgvBaoCao.Columns["ten_ca"]
                .HeaderText = "Ca làm";

            dgvBaoCao.Columns["ngay_lam"]
                .HeaderText = "Ngày làm";

            dgvBaoCao.Columns["check_in"]
                .HeaderText = "Check In";

            dgvBaoCao.Columns["check_out"]
                .HeaderText = "Check Out";

            dgvBaoCao.Columns["so_gio_lam"]
                .HeaderText = "Số giờ làm";

            dgvBaoCao.Columns["so_phut_di_tre"]
                .HeaderText = "Đi trễ";

            dgvBaoCao.Columns["so_phut_ve_som"]
                .HeaderText = "Về sớm";

            dgvBaoCao.Columns["so_phut_tang_ca"]
                .HeaderText = "Tăng ca";

            dgvBaoCao.Columns["trang_thai"]
                .HeaderText = "Trạng thái";
        }

        private async void btnLoc_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                List<BaoCaoChamCong> ds =
                    await chamCongService
                    .GetAll();

                string nhanVienId =
                    cboNhanVien.SelectedValue?
                    .ToString();

                DateTime tuNgay = dtTuNgay.Value.Date;
                DateTime denNgay = dtDenNgay.Value.Date;

                var result =
                    ds.Where(x =>
                        (
                            string.IsNullOrEmpty(
                                nhanVienId
                            )
                            ||
                            x.nhan_vien_id ==
                            nhanVienId
                        )
                        &&
                        x.ngay_lam.HasValue
                        &&
                        x.ngay_lam.Value.Date
                        >= tuNgay
                        &&
                        x.ngay_lam.Value.Date
                        <= denNgay
                    )
                    .OrderByDescending(
                        x => x.ngay_lam
                    )
                    .ToList();

                dgvBaoCao.DataSource =
                    null;

                dgvBaoCao.DataSource =
                    result;

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

            await LoadBaoCao();
        }

        private void cboNhanVien_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

        }

        private void dtTuNgay_ValueChanged(
            object sender,
            EventArgs e)
        {

        }
    }
}