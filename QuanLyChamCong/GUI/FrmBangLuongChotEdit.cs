using QuanLyChamCong.Models;
using QuanLyChamCong.THEME;
using System;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmBangLuongChotEdit :
        BaseForm
    {
        public BangLuongChot DataDetail =
            new BangLuongChot();

        public FrmBangLuongChotEdit()
        {
            InitializeComponent();
        }

        private void FrmBangLuongChotChiTiet_Load(
            object sender,
            EventArgs e
        )
        {
            LoadData();
        }

        private void LoadData()
        {
            if (DataDetail == null)
            {
                return;
            }

            lblNhanVien.Text =
                DataDetail.ho_ten;

            lblMaNV.Text =
                "Mã NV: "
                + DataDetail.nhan_vien_id;

            /*
             * THỐNG KÊ
             */

            lblTongCa.Text =
                (
                    DataDetail
                    .tong_ca_duoc_phan
                    ?? 0
                ).ToString();

            lblDiLam.Text =
                (
                    DataDetail
                    .tong_ca_di_lam
                    ?? 0
                ).ToString();

            lblNghi.Text =
                (
                    DataDetail
                    .tong_ca_nghi
                    ?? 0
                ).ToString();

            lblDiTre.Text =
                (
                    DataDetail
                    .tong_phut_di_tre
                    ?? 0
                ) + " phút";

            lblVeSom.Text =
                (
                    DataDetail
                    .tong_phut_ve_som
                    ?? 0
                ) + " phút";

            lblTangCa.Text =
                (
                    DataDetail
                    .tong_phut_tang_ca
                    ?? 0
                ) + " phút";

            /*
             * LƯƠNG
             */

            lblLuongCoBan.Text =
                FormatMoney(
                    DataDetail
                    .luong_co_ban
                );

            lblLuongChinh.Text =
                FormatMoney(
                    DataDetail
                    .tong_luong_chinh
                );

            lblLuongTangCa.Text =
                FormatMoney(
                    DataDetail
                    .tong_luong_tang_ca
                );

            lblPhuCap.Text =
                FormatMoney(
                    DataDetail
                    .phu_cap
                );

            lblThuong.Text =
                FormatMoney(
                    DataDetail
                    .thuong
                );

            lblPhat.Text =
                FormatMoney(
                    DataDetail
                    .phat
                );

            lblTongLuong.Text =
                FormatMoney(
                    DataDetail
                    .tong_luong
                );
        }

        private string FormatMoney(
            decimal? money
        )
        {
            return string.Format(
                "{0:N0} VNĐ",
                money ?? 0
            );
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