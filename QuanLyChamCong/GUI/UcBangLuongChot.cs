
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace QuanLyChamCong.GUI
{
    public partial class UcBangLuongChot : BaseUserControl
    {
        BangLuongChotService service =
            new BangLuongChotService();
        public UcBangLuongChot()
        {
            InitializeComponent();
        }

        private void UcBangLuongChot_Load(
            object sender,
            EventArgs e
        )
        {
            cboThang.SelectedIndex =
                DateTime.Now.Month - 1;

            cboNam.Text =
                DateTime.Now.Year.ToString();

            LoadDuLieu();
        }

        private async Task LoadDuLieu()
        {
            try
            {
                int thang = 0;
                int nam = 0;

                int.TryParse(
                    cboThang.Text,
                    out thang
                );

                int.TryParse(
                    cboNam.Text,
                    out nam
                );

                DataTable dt;

                bool daChot =
                    await service.DaChotLuong(
                        thang,
                        nam
                    );

                if (daChot)
                {
                    dt =
                        await service
                            .LayBangLuongDaChot(
                                thang,
                                nam
                            );
                }
                else
                {
                    dt =
                        await service
                            .TinhLuongThang(
                                thang,
                                nam
                            );
                }

                dgvDanhSach.DataSource =
                    dt;

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
            dgvDanhSach.AutoGenerateColumns = false;
            if (
                dgvDanhSach.Columns.Count <= 0
            )
            {
                return;
            }

            dgvDanhSach.Columns["nhan_vien_id"]
                .HeaderText =
                "Mã nhân viên";

            dgvDanhSach.Columns["ho_ten"]
                .HeaderText =
                "Họ tên";

            dgvDanhSach.Columns["loai_luong"]
                .HeaderText =
                "Loại lương";

            dgvDanhSach.Columns["luong_co_ban"]
                .HeaderText =
                "Lương cơ bản";

            dgvDanhSach.Columns["luong_theo_gio"]
                .HeaderText =
                "Lương theo giờ";
            dgvDanhSach.Columns["tong_gio_lam"]
                .HeaderText =
                "Tổng giờ làm";
            if (
                dgvDanhSach.Columns.Contains(
                    "phu_cap_mac_dinh"
                )
            )
            {
                dgvDanhSach.Columns["phu_cap_mac_dinh"]
                    .HeaderText =
                    "Phụ cấp";
            }

            if (
                dgvDanhSach.Columns.Contains(
                    "phu_cap"
                )
            )
            {
                dgvDanhSach.Columns["phu_cap"]
                    .HeaderText =
                    "Phụ cấp";
            }

            dgvDanhSach.Columns["luong_tang_ca_theo_gio"]
                .HeaderText =
                "Lương tăng ca / giờ";

            dgvDanhSach.Columns["tong_ca_duoc_phan"]
                .HeaderText =
                "Ca phân";

            dgvDanhSach.Columns["tong_ca_di_lam"]
                .HeaderText =
                "Ca đi làm";

            dgvDanhSach.Columns["tong_ca_nghi"]
                .HeaderText =
                "Ca nghỉ";

            dgvDanhSach.Columns["tong_phut_di_tre"]
                .HeaderText =
                "Đi trễ";

            dgvDanhSach.Columns["tong_phut_ve_som"]
                .HeaderText =
                "Về sớm";

            dgvDanhSach.Columns["tong_phut_bi_tru"]
                .HeaderText =
                "Tổng phút bị trừ";

            dgvDanhSach.Columns["tong_phut_tang_ca"]
                .HeaderText =
                "Phút tăng ca";

            dgvDanhSach.Columns["thuong"]
                .HeaderText =
                "Thưởng";

            dgvDanhSach.Columns["phat"]
                .HeaderText =
                "Phạt";

            dgvDanhSach.Columns["tong_luong_chinh"]
                .HeaderText =
                "Lương chính";

            dgvDanhSach.Columns["tong_luong_tang_ca"]
                .HeaderText =
                "Lương tăng ca";

            dgvDanhSach.Columns["tong_luong"]
                .HeaderText =
                "Tổng lương";


            dgvDanhSach.Columns["luong_co_ban"]
            .DefaultCellStyle.Format =
            "N0";

            dgvDanhSach.Columns["luong_theo_gio"]
                .DefaultCellStyle.Format =
                "N0";

            dgvDanhSach.Columns["phu_cap_mac_dinh"]
                .DefaultCellStyle.Format =
                "N0";

            dgvDanhSach.Columns["luong_tang_ca_theo_gio"]
                .DefaultCellStyle.Format =
                "N0";

            dgvDanhSach.Columns["thuong"]
                .DefaultCellStyle.Format =
                "N0";

            dgvDanhSach.Columns["phat"]
                .DefaultCellStyle.Format =
                "N0";

            dgvDanhSach.Columns["tong_luong_chinh"]
                .DefaultCellStyle.Format =
                "N0";

            dgvDanhSach.Columns["tong_luong_tang_ca"]
                .DefaultCellStyle.Format =
                "N0";

            dgvDanhSach.Columns["tong_luong"]
                .DefaultCellStyle.Format =
                "N0";
            dgvDanhSach.Columns["tong_gio_lam"]
                .DefaultCellStyle.Format =
                "N2";
            if (
                dgvDanhSach.Columns.Contains(
                    "phu_cap"
                )
            )
            {
                dgvDanhSach.Columns["phu_cap_mac_dinh"]
                    .DefaultCellStyle.Format =
                    "N0";
            }

            if (dgvDanhSach.Columns.Contains("thuong"))
            {
                dgvDanhSach.Columns["thuong"]
                    .DefaultCellStyle.Format =
                    "N0";
            }

            if (dgvDanhSach.Columns.Contains("phat"))
            {
                dgvDanhSach.Columns["phat"]
                    .DefaultCellStyle.Format =
                    "N0";
            }

            if (dgvDanhSach.Columns.Contains("tong_luong"))
            {
                dgvDanhSach.Columns["tong_luong"]
                    .DefaultCellStyle.Format =
                    "N0";
            }

            dgvDanhSach.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDanhSach.RowTemplate.Height =
                35;

            dgvDanhSach.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dgvDanhSach.EnableHeadersVisualStyles =
                false;
        }

        private async void btnTaiLai_Click(
            object sender,
            EventArgs e
        )
        {
            await LoadDuLieu();
        }

        private async void btnChotLuong_Click(
    object sender,
    EventArgs e
)
        {
            try
            {
                if (
                    dgvDanhSach.Rows.Count <= 0
                )
                {
                    MessageBox.Show(
                        "Không có dữ liệu để chốt"
                    );

                    return;
                }

                int thanhCong = 0;

                foreach (
                    DataGridViewRow row
                    in dgvDanhSach.Rows
                )
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    BangLuongChot model =
                        new BangLuongChot();

                    model.nhan_vien_id =
                        row.Cells["nhan_vien_id"]
                            .Value
                            .ToString();

                    model.thang =
                        Convert.ToInt32(
                            cboThang.Text
                        );

                    model.nam =
                        Convert.ToInt32(
                            cboNam.Text
                        );

                    model.tong_ca_duoc_phan =
                        Convert.ToInt32(
                            row.Cells["tong_ca_duoc_phan"]
                                .Value
                        );

                    model.tong_ca_di_lam =
                        Convert.ToInt32(
                            row.Cells["tong_ca_di_lam"]
                                .Value
                        );

                    model.tong_ca_nghi =
                        Convert.ToInt32(
                            row.Cells["tong_ca_nghi"]
                                .Value
                        );

                    model.tong_phut_di_tre =
                        Convert.ToInt32(
                            row.Cells["tong_phut_di_tre"]
                                .Value
                        );

                    model.tong_phut_ve_som =
                        Convert.ToInt32(
                            row.Cells["tong_phut_ve_som"]
                                .Value
                        );

                    model.tong_phut_bi_tru =
                        Convert.ToInt32(
                            row.Cells["tong_phut_bi_tru"]
                                .Value
                        );

                    model.tong_phut_tang_ca =
                        Convert.ToInt32(
                            row.Cells["tong_phut_tang_ca"]
                                .Value
                        );

                    model.luong_co_ban =
                        Convert.ToDecimal(
                            row.Cells["luong_co_ban"]
                                .Value
                        );

                    model.luong_theo_gio =
                        Convert.ToDecimal(
                            row.Cells["luong_theo_gio"]
                                .Value
                        );

                    model.luong_tang_ca_theo_gio =
                        Convert.ToDecimal(
                            row.Cells["luong_tang_ca_theo_gio"]
                                .Value
                        );

                    model.tong_luong_chinh =
                        Convert.ToDecimal(
                            row.Cells["tong_luong_chinh"]
                                .Value
                        );

                    model.tong_luong_tang_ca =
                        Convert.ToDecimal(
                            row.Cells["tong_luong_tang_ca"]
                                .Value
                        );

                    model.phu_cap =
                        Convert.ToDecimal(
                            row.Cells["phu_cap_mac_dinh"]
                                .Value
                        );

                    model.thuong =
                        Convert.ToDecimal(
                            row.Cells["thuong"]
                                .Value
                        );

                    model.phat =
                        Convert.ToDecimal(
                            row.Cells["phat"]
                                .Value
                        );

                    model.tong_luong =
                        Convert.ToDecimal(
                            row.Cells["tong_luong"]
                                .Value
                        );

                    model.ghi_chu = "";

                    model.nguoi_chot = "admin";

                    model.ngay_chot =
                        DateTime.Now;

                    model.created_at =
                        DateTime.Now;

                    bool kq =
                        await service
                            .ChotLuong(model);

                    if (kq)
                    {
                        thanhCong++;
                    }
                }

                MessageBox.Show(
                    "Đã chốt thành công "
                    + thanhCong
                    + " bảng lương",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                await LoadDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvDanhSach_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int thang = 0;
            int nam = 0;

            int.TryParse(
                cboThang.Text,
                out thang
            );

            int.TryParse(
                cboNam.Text,
                out nam
            );

            string nhanVienId =
                dgvDanhSach.Rows[e.RowIndex]
                    .Cells["nhan_vien_id"]
                    .Value
                    .ToString();

            DataRowView drv =
            (DataRowView)
            dgvDanhSach.CurrentRow.DataBoundItem;

                    FrmBangLuongChotChiTiet frm =
                        new FrmBangLuongChotChiTiet(
                            drv.Row
                );


            frm.ShowDialog();
        }

        private async void cboThang_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            await LoadDuLieu();
        }

        private async void cboNam_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            await LoadDuLieu();
        }
    }
}