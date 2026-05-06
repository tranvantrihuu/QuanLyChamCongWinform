// FrmBangLuongChotChiTiet.cs

using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmBangLuongChotChiTiet : Form
    {
        private DataRow row;

        public FrmBangLuongChotChiTiet(
            DataRow r
        )
        {
            InitializeComponent();

            row = r;
        }

        private void FrmBangLuongChotChiTiet_Load(
            object sender,
            EventArgs e
        )
        {
            LoadChiTiet();
        }

        private void LoadChiTiet()
        {
            try
            {
                lblNhanVien.Text =
                    row["ho_ten"].ToString();

                lblMaNV.Text =
                    row["nhan_vien_id"].ToString();

                lblTongCa.Text =
                    row["tong_ca_duoc_phan"]
                        .ToString();

                lblDiLam.Text =
                    row["tong_ca_di_lam"]
                        .ToString();

                lblNghi.Text =
                    row["tong_ca_nghi"]
                        .ToString();

                lblDiTre.Text =
                    row["tong_phut_di_tre"]
                        + " phút";

                lblVeSom.Text =
                    row["tong_phut_ve_som"]
                        + " phút";

                lblTangCa.Text =
                    row["tong_phut_tang_ca"]
                        + " phút";

                lblLuongCoBan.Text =
                    Convert.ToDecimal(
                        row["luong_co_ban"]
                    ).ToString("N0");

                lblLuongChinh.Text =
                    Convert.ToDecimal(
                        row["tong_luong_chinh"]
                    ).ToString("N0");

                lblLuongTangCa.Text =
                    Convert.ToDecimal(
                        row["tong_luong_tang_ca"]
                    ).ToString("N0");

                lblPhuCap.Text =
                    Convert.ToDecimal(
                        row["phu_cap_mac_dinh"]
                    ).ToString("N0");

                lblThuong.Text =
                    Convert.ToDecimal(
                        row["thuong"]
                    ).ToString("N0");

                lblPhat.Text =
                    Convert.ToDecimal(
                        row["phat"]
                    ).ToString("N0");

                lblTongLuong.Text =
                    Convert.ToDecimal(
                        row["tong_luong"]
                    ).ToString("N0");
            }
            catch
            {
                MessageBox.Show(
                    "Không thể tải chi tiết bảng lương",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnDong_Click(
            object sender,
            EventArgs e
        )
        {
            Close();
        }
    }
}