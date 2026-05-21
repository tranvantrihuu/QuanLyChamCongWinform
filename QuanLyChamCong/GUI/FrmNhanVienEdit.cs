using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyChamCong.GUI
{
    public partial class FrmNhanVienEdit : BaseForm
    {
        private readonly NhanVienService service =
            new NhanVienService();

        public bool IsEdit = false;

        public NhanVien NhanVienEdit =
            new NhanVien();

        public FrmNhanVienEdit()
        {
            InitializeComponent();
        }

        private async void FrmNhanVienEdit_Load(
            object sender,
            EventArgs e
        )
        {
            LoadComboBox();

            if (IsEdit)
            {
                LoadNhanVienLenForm();
            }
            else
            {
                txtNgayTao.Text =
                    DateTime.Now
                    .ToString("dd/MM/yyyy HH:mm:ss");

                txtNgaySua.Text =
                    DateTime.Now
                    .ToString("dd/MM/yyyy HH:mm:ss");
                await TaoMaNhanVienTuDong();

                txtIDNhanVien.Enabled = false;
            }

            await Task.CompletedTask;
        }
        private async Task TaoMaNhanVienTuDong()
        {
            try
            {
                var ds =
                    await service.GetAll();

                int number = 1;

                while (true)
                {
                    string newId =
                        "ID" +
                        number.ToString("0000");

                    bool exists =
                        ds.Any(x => x.id == newId);

                    if (!exists)
                    {
                        txtIDNhanVien.Text =
                            newId;

                        break;
                    }

                    number++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }
        private void LoadComboBox()
        {
            cbVaiTro.Items.Clear();

            cbVaiTro.Items.Add("Admin");
            cbVaiTro.Items.Add("Nhân viên");

            cbTrangThai.Items.Clear();

            cbTrangThai.Items.Add("Đang làm");
            cbTrangThai.Items.Add("Nghỉ việc");

            cbLoaiLuong.Items.Clear();

            cbLoaiLuong.Items.Add("Theo giờ");
            cbLoaiLuong.Items.Add("Theo tháng");

            cbVaiTro.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;
            cbLoaiLuong.SelectedIndex = 0;
        }

        private void LoadNhanVienLenForm()
        {
            if (NhanVienEdit == null)
            {
                return;
            }

            txtIDNhanVien.Text =
                NhanVienEdit.id;

            txtIDNhanVien.Enabled = false;

            txtMaVanTay.Text =
                NhanVienEdit.ma_van_tay;

            txtHoTen.Text =
                NhanVienEdit.ho_ten;

            txtSDT.Text =
                NhanVienEdit.so_dien_thoai;

            txtDiaChi.Text =
                NhanVienEdit.dia_chi;

            txtViTri.Text =
                NhanVienEdit.vi_tri;

            txtPin.Text =
                NhanVienEdit.pin_code;

            if (
                !string.IsNullOrWhiteSpace(
                    NhanVienEdit.vai_tro
                )
            )
            {
                cbVaiTro.Text =
                    NhanVienEdit.vai_tro;
            }

            if (
                !string.IsNullOrWhiteSpace(
                    NhanVienEdit.trang_thai
                )
            )
            {
                cbTrangThai.Text =
                    NhanVienEdit.trang_thai;
            }

            if (
                !string.IsNullOrWhiteSpace(
                    NhanVienEdit.loai_luong
                )
            )
            {
                cbLoaiLuong.Text =
                    NhanVienEdit.loai_luong;
            }

            if (
                NhanVienEdit.ngay_sinh.HasValue
            )
            {
                dtNgaySinh.Value =
                    NhanVienEdit.ngay_sinh.Value;
            }

            if (
                NhanVienEdit.ngay_vao_lam
                .HasValue
            )
            {
                dtNgayVao.Value =
                    NhanVienEdit
                    .ngay_vao_lam.Value;
            }

            txtNgayTao.Text =
                NhanVienEdit.created_at?
                .ToString(
                    "dd/MM/yyyy HH:mm:ss"
                );

            txtNgaySua.Text =
                NhanVienEdit.updated_at?
                .ToString(
                    "dd/MM/yyyy HH:mm:ss"
                );
        }

        private async Task<bool> ValidateInput()
        {
            if (
                string.IsNullOrWhiteSpace(
                    txtIDNhanVien.Text
                )
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập ID"
                );

                txtIDNhanVien.Focus();

                return false;
            }

            if (
                string.IsNullOrWhiteSpace(
                    txtMaVanTay.Text
                )
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập mã vân tay"
                );

                txtMaVanTay.Focus();

                return false;
            }

            /*
             * FORMAT:
             * IDF + 1 CHỮ HOA + 4 SỐ
             * VD:
             * IDFA0001
             * IDFS4521
             */

            if (
                !Regex.IsMatch(
                    txtMaVanTay.Text.Trim(),
                    @"^IDF[A-Z]\d{4}$"
                )
            )
            {
                MessageBox.Show(
                    "Mã vân tay phải đúng dạng:\n" +
                    "IDF + 1 chữ in hoa + 4 số\n" +
                    "Ví dụ: IDFA0001"
                );

                txtMaVanTay.Focus();

                return false;
            }

            /*
             * CHECK TRÙNG MÃ VÂN TAY
             */

            try
            {
                var ds =
                    await service.GetAll();

                bool exists =
                    ds.Any(x =>
                        x.ma_van_tay ==
                            txtMaVanTay.Text.Trim()
                        &&
                        x.id !=
                            txtIDNhanVien.Text.Trim()
                    );

                if (exists)
                {
                    MessageBox.Show(
                        "Mã vân tay đã tồn tại"
                    );

                    txtMaVanTay.Focus();

                    return false;
                }
            }
            catch
            {

            }

            if (
                string.IsNullOrWhiteSpace(
                    txtHoTen.Text
                )
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên"
                );

                txtHoTen.Focus();

                return false;
            }

            if (
                !string.IsNullOrWhiteSpace(
                    txtPin.Text
                )
                &&
                txtPin.Text.Length != 4
            )
            {
                MessageBox.Show(
                    "PIN phải gồm 4 số"
                );

                txtPin.Focus();

                return false;
            }

            return true;
        }

        private NhanVien GetNhanVienFromForm()
        {
            return new NhanVien
            {
                id =
                    txtIDNhanVien.Text.Trim(),

                ma_van_tay =
                    txtMaVanTay.Text.Trim(),

                ho_ten =
                    txtHoTen.Text.Trim(),

                so_dien_thoai =
                    txtSDT.Text.Trim(),

                ngay_sinh =
                    dtNgaySinh.Value,

                dia_chi =
                    txtDiaChi.Text.Trim(),

                vi_tri =
                    txtViTri.Text.Trim(),

                vai_tro =
                    cbVaiTro.Text,

                trang_thai =
                    cbTrangThai.Text,

                pin_code =
                    txtPin.Text.Trim(),

                ngay_vao_lam =
                    dtNgayVao.Value,

                loai_luong =
                    cbLoaiLuong.Text
            };
        }

        private async void btnOk_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                if (!await ValidateInput())
                {
                    return;
                }

                NhanVien nv =
                    GetNhanVienFromForm();

                bool success;

                if (IsEdit)
                {
                    success =
                        await service
                        .Update(nv);
                }
                else
                {
                    success =
                        await service
                        .Insert(nv);
                }

                if (success)
                {
                    MessageBox.Show(
                        IsEdit
                        ? "Cập nhật thành công"
                        : "Thêm thành công"
                    );

                    DialogResult =
                        DialogResult.OK;

                    Close();
                }
                else
                {
                    MessageBox.Show(
                        IsEdit
                        ? "Cập nhật thất bại"
                        : "Thêm thất bại"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
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

        private void tableLayoutPanel1_Paint(
            object sender,
            PaintEventArgs e
        )
        {

        }
    }
}