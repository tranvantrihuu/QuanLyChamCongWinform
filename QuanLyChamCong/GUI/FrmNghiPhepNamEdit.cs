using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmNghiPhepNamEdit :
        BaseForm
    {
        private readonly NghiPhepNamService _service =
            new NghiPhepNamService();

        private readonly NhanVienService _nvService =
            new NhanVienService();

        public bool IsEdit = false;

        public NghiPhepNam NghiPhepNamEdit =
            new NghiPhepNam();

        public FrmNghiPhepNamEdit()
        {
            InitializeComponent();
        }

        private async void FrmNghiPhepNamEdit_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadNhanVien();

            if (IsEdit)
            {
                numCoPhep.Enabled = false;
                numKhongPhep.Enabled = false;
                LoadDataEdit();
            }
            else
            {
                numNam.Value =
                    DateTime.Now.Year;
            }
        }

        private async Task LoadNhanVien()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load nhân viên:\n"
                    + ex.Message
                );
            }
        }

        private void LoadDataEdit()
        {
            try
            {
                cbNhanVien.SelectedValue =
                    NghiPhepNamEdit
                    .nhan_vien_id;

                numNam.Value =
                    NghiPhepNamEdit.nam;

                numDuocNghi.Value =
                    NghiPhepNamEdit
                    .so_ca_duoc_nghi;
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

            NghiPhepNamEdit.nhan_vien_id =
                cbNhanVien.SelectedValue
                .ToString();

            NghiPhepNamEdit.nam =
                (int)numNam.Value;

            NghiPhepNamEdit.so_ca_duoc_nghi =
                (int)numDuocNghi.Value;

            bool result = false;

            if (IsEdit)
            {
                result =
                    await _service.Update(
                        NghiPhepNamEdit
                    );
            }
            else
            {
                result =
                    await _service.Add(
                        NghiPhepNamEdit
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

        private void btnHuy_Click(
            object sender,
            EventArgs e
        )
        {
            Close();
        }
    }
}