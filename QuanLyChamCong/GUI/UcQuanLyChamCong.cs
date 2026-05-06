// UcQuanLyChamCong.cs

using BLL;
using QuanLyChamCong.BLL;
using QuanLyChamCong.GUI;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class UcQuanLyChamCong : UserControl
    {
        QuanLyChamCongBLL bll =
            new QuanLyChamCongBLL();

        NhanVienBLL nhanVienBLL =
            new NhanVienBLL();

        public UcQuanLyChamCong()
        {
            InitializeComponent();
        }

        private void UcQuanLyChamCong_Load(
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

        private void LoadNhanVien()
        {
            DataTable dt =
                nhanVienBLL.GetAll();

            DataRow r =
                dt.NewRow();

            r["id"] = "";

            r["ho_ten"] =
                "Tất cả";

            dt.Rows.InsertAt(r, 0);

            cboNhanVien.DataSource =
                dt;

            cboNhanVien.DisplayMember =
                "ho_ten";

            cboNhanVien.ValueMember =
                "id";
        }

        private void LoadData()
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

            dgvChamCong.DataSource =
                bll.GetByNgay(
                    nhanVienId,
                    tuNgay,
                    denNgay
                );

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

            // HEADER STYLE
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

            // CELL STYLE
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

            // riêng họ tên căn trái
            dgvChamCong.Columns["ho_ten"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // HEADER TEXT
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

            // FORMAT DATE
            dgvChamCong.Columns["ngay_lam"]
                .DefaultCellStyle.Format =
                "dd/MM/yyyy";

            dgvChamCong.Columns["check_in"]
                .DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";

            dgvChamCong.Columns["check_out"]
                .DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";

            // HIDE
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

        private void btnXoa_Click(
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

            bll.Delete(id);

            LoadData();

            MessageBox.Show(
                "Xóa thành công"
            );
        }
        // Thêm vào UcQuanLyChamCong.cs

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