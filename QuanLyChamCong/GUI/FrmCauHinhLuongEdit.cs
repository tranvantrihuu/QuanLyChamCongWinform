using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmCauHinhLuongEdit :
        BaseForm
    {
        private readonly
            CauHinhLuongService _service =
                new CauHinhLuongService();

        private readonly
            NhanVienService _nvService =
                new NhanVienService();

        public bool IsEdit = false;

        public CauHinhLuong CauHinhLuongEdit =
            new CauHinhLuong();

        public FrmCauHinhLuongEdit()
        {
            InitializeComponent();
        }

        private async void FrmCauHinhLuongEdit_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadNhanVien();

            SetupNumeric();

            SetupLoaiLuong();

            if (IsEdit)
            {
                LoadDataEdit();
            }
        }

        private void SetupLoaiLuong()
        {
            cbLoaiLuong.Items.Clear();

            cbLoaiLuong.Items.Add(
                "Lương tháng"
            );

            cbLoaiLuong.Items.Add(
                "Lương giờ"
            );

            cbLoaiLuong.SelectedIndex = 0;

            cbLoaiLuong.SelectedIndexChanged +=
                cbLoaiLuong_SelectedIndexChanged;
        }

        private void cbLoaiLuong_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            string loai =
                cbLoaiLuong.Text;

            if (loai == "Lương tháng")
            {
                numLuongCoBan.Enabled = true;

                numLuongTheoGio.Enabled = false;

                numLuongTheoGio.Value = 0;
            }
            else
            {
                numLuongCoBan.Enabled = false;

                numLuongTheoGio.Enabled = true;

                numLuongCoBan.Value = 0;
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

        private void SetupNumeric()
        {
            numLuongCoBan.Maximum =
                decimal.MaxValue;

            numLuongTheoGio.Maximum =
                decimal.MaxValue;

            numTangCa.Maximum =
                decimal.MaxValue;

            numPhuCap.Maximum =
                decimal.MaxValue;
            numLuongCoBan.ThousandsSeparator = true;

            numLuongTheoGio.ThousandsSeparator = true;

            numTangCa.ThousandsSeparator = true;

            numPhuCap.ThousandsSeparator = true;

            numLuongCoBan.DecimalPlaces = 0;

            numLuongTheoGio.DecimalPlaces = 0;

            numTangCa.DecimalPlaces = 0;

            numPhuCap.DecimalPlaces = 0;
        }

        private void LoadDataEdit()
        {
            try
            {
                cbNhanVien.SelectedValue =
                    CauHinhLuongEdit
                    .nhan_vien_id;

                numLuongCoBan.Value =
                    CauHinhLuongEdit
                    .luong_co_ban ?? 0m;

                numLuongTheoGio.Value =
                    CauHinhLuongEdit
                    .luong_theo_gio ?? 0m;

                numTangCa.Value =
                    CauHinhLuongEdit
                    .luong_tang_ca ?? 0m;

                numPhuCap.Value =
                    CauHinhLuongEdit
                    .phu_cap_mac_dinh ?? 0m;

                if (
                    CauHinhLuongEdit
                    .luong_theo_gio > 0
                )
                {
                    cbLoaiLuong.SelectedIndex = 1;

                    numLuongCoBan.Enabled = false;

                    numLuongTheoGio.Enabled = true;
                }
                else
                {
                    cbLoaiLuong.SelectedIndex = 0;

                    numLuongCoBan.Enabled = true;

                    numLuongTheoGio.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private async void btnOk_Click(
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

            if (
                cbLoaiLuong.Text
                == "Lương tháng"
                &&
                numLuongCoBan.Value <= 0
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập lương tháng"
                );

                return;
            }

            if (
                cbLoaiLuong.Text
                == "Lương giờ"
                &&
                numLuongTheoGio.Value <= 0
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập lương giờ"
                );

                return;
            }

            CauHinhLuongEdit.nhan_vien_id =
                cbNhanVien.SelectedValue
                .ToString();

            CauHinhLuongEdit.luong_co_ban =
                numLuongCoBan.Value;

            CauHinhLuongEdit.luong_theo_gio =
                numLuongTheoGio.Value;

            CauHinhLuongEdit.luong_tang_ca =
                numTangCa.Value;

            CauHinhLuongEdit.phu_cap_mac_dinh =
                numPhuCap.Value;

            bool result = false;

            if (IsEdit)
            {
                result =
                    await _service.Update(
                        CauHinhLuongEdit
                    );
            }
            else
            {
                result =
                    await _service.Add(
                        CauHinhLuongEdit
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

        private void btnCancel_Click(
            object sender,
            EventArgs e
        )
        {
            Close();
        }
    }
}