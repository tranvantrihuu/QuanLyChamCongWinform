using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using System.Collections.Generic;
using System.Linq;
using QuanLyChamCong.GUI;
using QuanLyChamCong.THEME;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace GUI
{
    public partial class UcQuanLyChamCong : BaseUserControl
    {
        QuanLyChamCongService service = new QuanLyChamCongService();

        NhanVienService nhanVienService = new NhanVienService();
        public UcQuanLyChamCong()
        {
            InitializeComponent();
        }

        private async void UcQuanLyChamCong_Load(
            object sender,
            EventArgs e
        )
        {
            LoadNhanVien();

            dtTuNgay.Value =
                DateTime.Now.AddDays(-30);

            dtDenNgay.Value =
                DateTime.Now;

            LoadData();
        }

        private async void LoadNhanVien()
        {
            var ds =
                await nhanVienService.GetAll();

            ds.Insert(
                0,
                new NhanVien
                {
                    id = "",
                    ho_ten = "Tất cả"
                }
            );

            cboNhanVien.DataSource =
                ds;

            cboNhanVien.DisplayMember =
                "ho_ten";

            cboNhanVien.ValueMember =
                "id";
        }

        private async void LoadData()
        {
            string nhanVienId = "";

            if (
                cboNhanVien.SelectedValue
                != null
            )
            {
                nhanVienId =
                    cboNhanVien
                    .SelectedValue
                    .ToString();
            }

            DateTime tuNgay =
                dtTuNgay.Value.Date;

            DateTime denNgay =
                dtDenNgay.Value.Date;

            if (
                (denNgay - tuNgay)
                .TotalDays > 31
            )
            {
                MessageBox.Show(
                    "Chỉ được xem tối đa 31 ngày"
                );

                return;
            }

            List<ChamCong> ds =
                await service.GetAll();

            if (!string.IsNullOrEmpty(nhanVienId))
            {
                ds = ds.Where(x =>
                    x.nhan_vien_id ==
                    nhanVienId
                ).ToList();
            }

            ds = ds.Where(x =>
                x.ngay_lam.Value.Date >= tuNgay
                &&
                x.ngay_lam.Value.Date <= denNgay
            ).ToList();

            dgvChamCong.DataSource =
                ds;

            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvChamCong.Columns.Count <= 0)
                return;

            dgvChamCong.EnableHeadersVisualStyles = false;

            dgvChamCong.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvChamCong.AllowUserToAddRows = false;

            dgvChamCong.ReadOnly = true;

            dgvChamCong.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvChamCong.MultiSelect = false;

            dgvChamCong.RowHeadersVisible = false;

            
            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            headerStyle.BackColor =
                Color.RoyalBlue;

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            headerStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            headerStyle.WrapMode =
                DataGridViewTriState.True;

            dgvChamCong.ColumnHeadersDefaultCellStyle =
                headerStyle;

            dgvChamCong.ColumnHeadersHeight = 45;

            
            DataGridViewCellStyle cellStyle =
                new DataGridViewCellStyle();

            cellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            cellStyle.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            dgvChamCong.DefaultCellStyle =
                cellStyle;

            
            dgvChamCong.Columns["ho_ten"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            
            dgvChamCong.Columns["id"]
                .HeaderText = "ID";

            dgvChamCong.Columns["nhan_vien_id"]
                .HeaderText = "MÃ NV";

            dgvChamCong.Columns["ho_ten"]
                .HeaderText = "HỌ TÊN";

            dgvChamCong.Columns["ngay_lam"]
                .HeaderText = "NGÀY LÀM";

            dgvChamCong.Columns["ten_ca"]
                .HeaderText = "CA LÀM";

            dgvChamCong.Columns["gio_bat_dau"]
                .HeaderText = "GIỜ BẮT ĐẦU";

            dgvChamCong.Columns["gio_ket_thuc"]
                .HeaderText = "GIỜ KẾT THÚC";

            dgvChamCong.Columns["check_in"]
                .HeaderText = "CHECK IN";

            dgvChamCong.Columns["check_out"]
                .HeaderText = "CHECK OUT";

            dgvChamCong.Columns["so_phut_di_som"]
                .HeaderText = "ĐI SỚM";

            dgvChamCong.Columns["so_phut_di_tre"]
                .HeaderText = "ĐI TRỄ";

            dgvChamCong.Columns["so_phut_ve_som"]
                .HeaderText = "VỀ SỚM";

            dgvChamCong.Columns["so_phut_ve_tre"]
                .HeaderText = "VỀ TRỄ";

            dgvChamCong.Columns["so_phut_tang_ca"]
                .HeaderText = "TĂNG CA";

            dgvChamCong.Columns["so_phut_bi_tru"]
                .HeaderText = "BỊ TRỪ";

            dgvChamCong.Columns["trang_thai"]
                .HeaderText = "TRẠNG THÁI";

            
            dgvChamCong.Columns["ngay_lam"]
                .DefaultCellStyle.Format =
                "dd/MM/yyyy";

            dgvChamCong.Columns["check_in"]
                .DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";

            dgvChamCong.Columns["check_out"]
                .DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";

            
            dgvChamCong.Columns[
                "phut_cho_phep_di_tre"
            ].Visible = false;

            dgvChamCong.Columns[
                "phut_cho_phep_ve_som"
            ].Visible = false;

            dgvChamCong.Columns[
                "phut_cho_phep_checkin_som"
            ].Visible = false;

            dgvChamCong.Columns[
                "phut_cho_phep_checkout_tre"
            ].Visible = false;

            dgvChamCong.Columns[
                "ca_lam_id"
            ].Visible = false;
        }

        private void btnLoc_Click(
            object sender,
            EventArgs e
        )
        {
            LoadData();
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e
        )
        {
            cboNhanVien.SelectedIndex = 0;

            dtTuNgay.Value =
                DateTime.Now.AddDays(-30);

            dtDenNgay.Value =
                DateTime.Now;

            LoadData();
        }

        private void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmQuanLyChamCongEdit f =
                new FrmQuanLyChamCongEdit();

            if (
                f.ShowDialog()
                == DialogResult.OK
            )
            {
                LoadData();
            }
        }

        private void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                dgvChamCong.CurrentRow
                == null
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            int id =
                Convert.ToInt32(
                    dgvChamCong
                    .CurrentRow
                    .Cells["id"]
                    .Value
                );

            FrmQuanLyChamCongEdit f =
                new FrmQuanLyChamCongEdit(id);

            if (
                f.ShowDialog()
                == DialogResult.OK
            )
            {
                LoadData();
            }
        }

        private async void btnXoa_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                dgvChamCong.CurrentRow
                == null
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            DialogResult rs =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (
                rs != DialogResult.Yes
            )
            {
                return;
            }

            int id =
                Convert.ToInt32(
                    dgvChamCong
                    .CurrentRow
                    .Cells["id"]
                    .Value
                );

            bool result =
                await service.Delete(id);

            if (result)
            {
                LoadData();

                MessageBox.Show(
                    "Xóa thành công"
                );
            }
            else
            {
                MessageBox.Show(
                    "Xóa thất bại"
                );
            }
        }

        private void dtTuNgay_ValueChanged(
            object sender,
            EventArgs e
        )
        {
            if (
                dtDenNgay.Value.Date
                < dtTuNgay.Value.Date
            )
            {
                dtDenNgay.Value =
                    dtTuNgay.Value.Date;
            }
        }

        private void dtDenNgay_ValueChanged(
            object sender,
            EventArgs e
        )
        {
            if (
                dtDenNgay.Value.Date
                < dtTuNgay.Value.Date
            )
            {
                MessageBox.Show(
                    "Đến ngày không được nhỏ hơn từ ngày"
                );

                dtDenNgay.Value =
                    dtTuNgay.Value.Date;
            }
        }

        private void dgvChamCong_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
                {
                    if (e.RowIndex < 0)
                    {
                        return;
                    }

                    int id =
                        Convert.ToInt32(
                            dgvChamCong
                            .Rows[e.RowIndex]
                            .Cells["id"]
                            .Value
                        );

                    FrmQuanLyChamCongEdit f =
                        new FrmQuanLyChamCongEdit(id);

                    if (
                        f.ShowDialog()
                        == DialogResult.OK
                    )
                    {
                        LoadData();
                    }
                }
            }
}