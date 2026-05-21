using QuanLyChamCong.GUI;
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using QuanLyChamCong.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class UcQuanLyChamCong : BaseUserControl
    {
        private readonly QuanLyChamCongService _service =
            new QuanLyChamCongService();

        private readonly NhanVienService _nhanVienService =
            new NhanVienService();

        public UcQuanLyChamCong()
        {
            InitializeComponent();
        }

        private async void UcQuanLyChamCong_Load(
    object sender,
    EventArgs e
)
        {
            dtTuNgay.Value =
                DateTime.Now.AddMonths(-1);

            dtDenNgay.Value =
                DateTime.Now;

            /*
             * CHẶN CHỌN NGƯỢC NGÀY
             */

            dtDenNgay.MinDate =
                dtTuNgay.Value.Date;

            /*
             * FORMAT DATE
             */

            dtTuNgay.Format =
                DateTimePickerFormat.Custom;

            dtTuNgay.CustomFormat =
                "dd/MM/yyyy";

            dtDenNgay.Format =
                DateTimePickerFormat.Custom;

            dtDenNgay.CustomFormat =
                "dd/MM/yyyy";

            /*
             * EVENT
             */

            dtTuNgay.ValueChanged +=
                dtTuNgay_ValueChanged;
            dtDenNgay.ValueChanged +=
                dtDenNgay_ValueChanged;
            await LoadNhanVien();

            await LoadData();
        }

        private async Task LoadNhanVien()
        {
            try
            {
                var ds =
                    await _nhanVienService.GetAll();

                List<dynamic> list =
                    new List<dynamic>();

                list.Add(
                    new
                    {
                        id = "",
                        ho_ten = "TẤT CẢ"
                    }
                );

                foreach (var item in ds)
                {
                    list.Add(
                        new
                        {
                            id = item.id,
                            ho_ten =
                                item.id
                                + " - "
                                + item.ho_ten
                        }
                    );
                }

                cboNhanVien.DataSource = list;

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
                List<VwDanhSachChamCong> ds =
                    await _service.LocChamCong(
                        null,
                        dtTuNgay.Value.Date,
                        dtDenNgay.Value.Date
                    );

                dgvChamCong.AutoGenerateColumns =
                    true;

                dgvChamCong.DataSource =
                    null;

                dgvChamCong.DataSource =
                    ds;

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString()
                );
            }
        }

        private void FormatGrid()
        {
            if (
                dgvChamCong.Columns.Count <= 0
            )
            {
                return;
            }

            dgvChamCong.RowHeadersVisible = false;

            dgvChamCong.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvChamCong.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvChamCong.MultiSelect = true;

            dgvChamCong.ReadOnly = true;

            dgvChamCong.AllowUserToAddRows =
                false;

            dgvChamCong.Columns["id"]
                .HeaderText = "ID";

            dgvChamCong.Columns["nhan_vien_id"]
                .HeaderText = "MÃ NV";

            dgvChamCong.Columns["ho_ten"]
                .HeaderText = "HỌ TÊN";

            dgvChamCong.Columns["ngay_lam"]
                .HeaderText = "NGÀY LÀM";

            dgvChamCong.Columns["ten_ca"]
                .HeaderText = "CA";

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

            dgvChamCong.Columns["so_gio_lam"]
                .HeaderText = "SỐ GIỜ";

            dgvChamCong.Columns["so_phut_tang_ca"]
                .HeaderText = "TĂNG CA";

            dgvChamCong.Columns["so_phut_bi_tru"]
                .HeaderText = "BỊ TRỪ";

            dgvChamCong.Columns["trang_thai"]
                .HeaderText = "TRẠNG THÁI";

            /*
             * ẨN CỘT
             */

            if (
                dgvChamCong.Columns[
                    "ca_lam_id"
                ] != null
            )
            {
                dgvChamCong.Columns[
                    "ca_lam_id"
                ].Visible = false;
            }

            if (
                dgvChamCong.Columns[
                    "gio_bat_dau"
                ] != null
            )
            {
                dgvChamCong.Columns[
                    "gio_bat_dau"
                ].Visible = false;
            }

            if (
                dgvChamCong.Columns[
                    "gio_ket_thuc"
                ] != null
            )
            {
                dgvChamCong.Columns[
                    "gio_ket_thuc"
                ].Visible = false;
            }



            if (
                dgvChamCong.Columns[
                    "phut_cho_phep_di_tre"
                ] != null
            )
            {
                dgvChamCong.Columns[
                    "phut_cho_phep_di_tre"
                ].Visible = false;
            }

            if (
                dgvChamCong.Columns[
                    "phut_cho_phep_ve_som"
                ] != null
            )
            {
                dgvChamCong.Columns[
                    "phut_cho_phep_ve_som"
                ].Visible = false;
            }

            if (
                dgvChamCong.Columns[
                    "phut_cho_phep_checkin_som"
                ] != null
            )
            {
                dgvChamCong.Columns[
                    "phut_cho_phep_checkin_som"
                ].Visible = false;
            }

            if (
                dgvChamCong.Columns[
                    "phut_cho_phep_checkout_tre"
                ] != null
            )
            {
                dgvChamCong.Columns[
                    "phut_cho_phep_checkout_tre"
                ].Visible = false;
            }
        }

        private async void btnLoc_Click(
    object sender,
    EventArgs e
)
        {
            try
            {
                string nhanVienId =
                    cboNhanVien.SelectedValue
                    ?.ToString();

                List<VwDanhSachChamCong> ds =
                    await _service.LocChamCong(
                        nhanVienId,
                        dtTuNgay.Value.Date,
                        dtDenNgay.Value.Date
                    );

                dgvChamCong.DataSource = null;

                dgvChamCong.DataSource = ds;

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnLamMoi_Click(
            object sender,
            EventArgs e
        )
        {
            await LoadData();
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
                _ = LoadData();
            }
        }

        private void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                dgvChamCong.CurrentRow == null
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            VwDanhSachChamCong cc =
                dgvChamCong.CurrentRow
                .DataBoundItem
                as VwDanhSachChamCong;

            if (cc == null)
            {
                return;
            }

            FrmQuanLyChamCongEdit f =
                new FrmQuanLyChamCongEdit(
                    cc.id
                );

            if (
                f.ShowDialog()
                == DialogResult.OK
            )
            {
                _ = LoadData();
            }
        }

        private async void btnXoa_Click(
    object sender,
    EventArgs e
)
        {
            if (
                dgvChamCong.SelectedRows.Count <= 0
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            DialogResult rs =
                MessageBox.Show(
                    $"Xóa {dgvChamCong.SelectedRows.Count} dòng chấm công?",
                    "XÁC NHẬN",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (rs != DialogResult.Yes)
            {
                return;
            }

            int thanhCong = 0;

            int thatBai = 0;

            foreach (
                DataGridViewRow row
                in dgvChamCong.SelectedRows
            )
            {
                VwDanhSachChamCong cc =
                    row.DataBoundItem
                    as VwDanhSachChamCong;

                if (cc == null)
                {
                    thatBai++;

                    continue;
                }

                bool result =
                    await _service.Delete(
                        cc.id
                    );

                if (result)
                {
                    thanhCong++;
                }
                else
                {
                    thatBai++;
                }
            }

            MessageBox.Show(
                $"Xóa thành công: {thanhCong}\n" +
                $"Xóa thất bại: {thatBai}"
            );

            await LoadData();
        }

        private void dgvChamCong_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            btnSua.PerformClick();
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
                dtDenNgay.Value =
                    dtTuNgay.Value.Date;
            }
        }
    }
}