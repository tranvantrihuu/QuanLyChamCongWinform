using QuanLyChamCong.GUI;
using System;
using System.Windows.Forms;
using GUI;
using QuanLyChamCong.THEME;

namespace QuanLyChamCong
{
    public partial class frmMain : BaseForm
    {
        public bool DaDangNhapPin = false;
        public int CurrentUserId = 1;
        public frmMain()
        {
            InitializeComponent();
        }

        public void LoadControl(UserControl uc)
        {
            pnMain.Controls.Clear();

            uc.Dock = DockStyle.Fill;

            pnMain.Controls.Add(uc);
        }

        private void frmMain_Load(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcChamCong(this));

            CapNhatTrangThaiMenu();
        }

        public void MoKhoaChucNang()
        {
            DaDangNhapPin = true;

            CapNhatTrangThaiMenu();
        }

        public void KhoaChucNang()
        {
            DaDangNhapPin = false;

            CapNhatTrangThaiMenu();

            LoadControl(new UcChamCong(this));
        }

        private void CapNhatTrangThaiMenu()
        {
            // luôn cho chấm công

            mnuChamCong.Enabled = true;

            // khóa toàn bộ khi chưa nhập PIN

            mnuDanhMuc.Enabled =
                DaDangNhapPin;

            mnuLuong.Enabled =
                DaDangNhapPin;

            mnuHeThong.Enabled =
                DaDangNhapPin;

            // menu con

            mnuQuanLyChamCong.Enabled =
                DaDangNhapPin;

            mnuNghiPhep.Enabled =
                DaDangNhapPin;

            mnuBaoCaoChamCong.Enabled =
                DaDangNhapPin;

            mnuDoiPIN.Enabled =
                DaDangNhapPin;

            mnuDangXuat.Enabled =
                DaDangNhapPin;
        }

        private void mnuNhanVien_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcNhanVien());
        }

        private void mnuCaLam_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcCaLam());
        }

        private void mnuPhanCa_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcPhanCa());
        }

        private void mnuCauHinhLuong_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcCauHinhLuong());
        }

        private void mnuNghiPhepNam_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcNghiPhepNam());
        }

        private void mnuNghiPhep_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcNghiPhep());
        }

        private void mnuThuongPhat_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcThuongPhat());
        }

        private void mnuBangLuong_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcBangLuongChot());
        }

        private void mnuChamCongItem_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcChamCong(this));
        }

        private void mnuQuanLyChamCong_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcQuanLyChamCong());
        }

        private void mnuBaoCaoChamCong_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcBaoCaoChamCong());
        }
        private void mnuDoiPIN_Click(
            object sender,
            EventArgs e
        )
        {
            LoadControl(new UcDoiPin());
        }

        private void mnuDangXuat_Click_1(
            object sender,
            EventArgs e
        )
        {
            DaDangNhapPin = false;

            CapNhatTrangThaiMenu();

            LoadControl(new UcChamCong(this));

            MessageBox.Show(
                "Đã đăng xuất và khóa chức năng"
            );
        }

    }
}