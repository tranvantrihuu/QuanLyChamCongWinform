using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmNghiPhepEdit :
        BaseForm
    {
        private readonly NghiPhepService _service =
            new NghiPhepService();

        private readonly NhanVienService _nvService =
            new NhanVienService();

        private readonly CaLamService _caLamService =
            new CaLamService();

        public bool IsEdit = false;

        public NghiPhep NghiPhepEdit =
            new NghiPhep();

        public FrmNghiPhepEdit()
        {
            InitializeComponent();
        }

        private async void FrmNghiPhepEdit_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadNhanVien();

            await LoadCaLam();

            LoadLoai();

            if (IsEdit)
            {
                LoadDataEdit();
            }
        }

        private async Task LoadNhanVien()
        {
            var ds =
                await _nvService.GetAll();

            cbNhanVien.DataSource =
                ds;

            cbNhanVien.DisplayMember =
                "ho_ten";

            cbNhanVien.ValueMember =
                "id";
        }

        private async Task LoadCaLam()
        {
            var ds =
                await _caLamService.GetAll();

            cbCaLam.DataSource =
                ds;

            cbCaLam.DisplayMember =
                "ten_ca";

            cbCaLam.ValueMember =
                "id";
        }

        private void LoadLoai()
        {
            cbLoai.Items.Clear();

            cbLoai.Items.Add(
                "Có phép"
            );

            cbLoai.Items.Add(
                "Không phép"
            );

            cbLoai.SelectedIndex = 0;
        }

        private void LoadDataEdit()
        {
            try
            {
                cbNhanVien.SelectedValue =
                    NghiPhepEdit.nhan_vien_id;

                if (
                    NghiPhepEdit.ca_lam_id
                    != null
                )
                {
                    cbCaLam.SelectedValue =
                        NghiPhepEdit.ca_lam_id;
                }

                if (
                    NghiPhepEdit.ngay
                    != null
                )
                {
                    dtNgay.Value =
                        NghiPhepEdit
                        .ngay.Value;
                }

                txtLyDo.Text =
                    NghiPhepEdit.ly_do;

                cbLoai.Text =
                    NghiPhepEdit.loai;
            }
            catch
            {

            }
        }

        private async void btnLuu_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                cbNhanVien.SelectedValue
                == null
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên"
                );

                return;
            }

            /*
             * MAP MODEL
             */

            NghiPhepEdit.nhan_vien_id =
                cbNhanVien.SelectedValue
                .ToString();

            if (
                cbCaLam.SelectedValue
                != null
            )
            {
                NghiPhepEdit.ca_lam_id =
                    Convert.ToInt32(
                        cbCaLam.SelectedValue
                    );
            }

            NghiPhepEdit.ngay =
                dtNgay.Value.Date;

            NghiPhepEdit.loai =
                cbLoai.Text;

            NghiPhepEdit.ly_do =
                txtLyDo.Text.Trim();

            bool result = false;

            if (IsEdit)
            {
                result =
                    await _service.Update(
                        NghiPhepEdit
                    );
            }
            else
            {
                result =
                    await _service.Add(
                        NghiPhepEdit
                    );
            }

            if (result)
            {
                MessageBox.Show(
                    "Lưu thành công"
                );

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show(
                    "Lưu thất bại"
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