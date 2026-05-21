
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmThuongPhatEdit : Form
    {
        private readonly ThuongPhatService _service =
            new ThuongPhatService();

        private readonly NhanVienService _nhanVienService =
            new NhanVienService();

        public bool IsEdit = false;

        public ThuongPhat ThuongPhatEdit =
            new ThuongPhat();

        public FrmThuongPhatEdit()
        {
            InitializeComponent();
        }

        private async void FrmThuongPhatEdit_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadNhanVien();

            LoadLoai();

            SetupNumeric();

            if (IsEdit)
            {
                LoadDataEdit();
            }
        }

        private async Task LoadNhanVien()
        {
            try
            {
                var dsNhanVien =
                    await _nhanVienService
                    .GetAll();

                cbNhanVien.DataSource =
                    dsNhanVien;

                cbNhanVien.DisplayMember =
                    "ho_ten";

                cbNhanVien.ValueMember =
                    "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load nhân viên:\n" +
                    ex.Message
                );
            }
        }

        private void LoadLoai()
        {
            cbLoai.Items.Clear();

            cbLoai.Items.Add("Thưởng");

            cbLoai.Items.Add("Phạt");

            cbLoai.SelectedIndex = 0;
        }

        private void SetupNumeric()
        {
            nudSoTien.Minimum = 0;

            nudSoTien.Maximum =
                 decimal.MaxValue;
            nudSoTien.Increment =
                1;

            nudSoTien.DecimalPlaces =
                0;

            nudSoTien.ThousandsSeparator =
                true;
        }

        private void LoadDataEdit()
        {
            try
            {
                cbNhanVien.SelectedValue =
                    ThuongPhatEdit
                    .nhan_vien_id;

                cbLoai.Text =
                    ThuongPhatEdit.loai;

                nudSoTien.Value =
                    Convert.ToDecimal(
                        ThuongPhatEdit
                        .so_tien ?? 0
                    );

                txtLyDo.Text =
                    ThuongPhatEdit.ly_do;

                if (
                    ThuongPhatEdit.ngay
                    != null
                )
                {
                    dtNgay.Value =
                        ThuongPhatEdit
                        .ngay.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private async void btnLuu_Click(
            object sender,
            EventArgs e
        )
        {
            try
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

                if (
                    string.IsNullOrWhiteSpace(
                        txtLyDo.Text
                    )
                )
                {
                    MessageBox.Show(
                        "Vui lòng nhập lý do"
                    );

                    return;
                }

                ThuongPhatEdit
                    .nhan_vien_id =
                    cbNhanVien
                    .SelectedValue
                    .ToString();

                ThuongPhatEdit.loai =
                    cbLoai.Text;

                ThuongPhatEdit.so_tien =
                    nudSoTien.Value;

                ThuongPhatEdit.ly_do =
                    txtLyDo.Text.Trim();

                ThuongPhatEdit.ngay =
                    dtNgay.Value.Date;

                bool result = false;

                if (IsEdit)
                {
                    result =
                        await _service
                        .Update(
                            ThuongPhatEdit
                        );
                }
                else
                {
                    result =
                        await _service
                        .Add(
                            ThuongPhatEdit
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString()
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
