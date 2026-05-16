
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmNghiPhepEdit : BaseForm
    {
        NghiPhepService service =
            new NghiPhepService();

        NhanVienService nhanVienService =
            new NhanVienService();

        CaLamService caLamService =
            new CaLamService();

        public int id = 0;

      
        public string nhanVienId = "";

        public int caLamId = 0;

        public string loai = "";

        public string lyDo = "";

        public DateTime ngay;

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

            // loại
            cbLoai.Items.Clear();

            cbLoai.Items.Add("Có phép");

            cbLoai.Items.Add("Không phép");

            cbLoai.FormattingEnabled = true;

            if (id == 0)
            {
                cbLoai.SelectedIndex = 0;

                dtNgay.Value =
                    DateTime.Now;
            }

            else
            {
                // nhân viên
                if (!string.IsNullOrEmpty(
                    nhanVienId))
                {
                    cbNhanVien.SelectedValue =
                        nhanVienId;
                }

                // ca làm
                cbCaLam.SelectedValue =
                    caLamId;

                // loại
                cbLoai.SelectedItem =
                    loai;

                // lý do
                txtLyDo.Text =
                    lyDo;

                // ngày
                if (ngay.Year > 1900)
                {
                    dtNgay.Value =
                        ngay;
                }
                else
                {
                    dtNgay.Value =
                        DateTime.Now;
                }
            }
        }

        async System.Threading.Tasks.Task LoadNhanVien()
        {
            List<NhanVien> ds =
                await nhanVienService.GetAll();

            cbNhanVien.DataSource =
                ds;

            cbNhanVien.DisplayMember =
                "ho_ten";

            cbNhanVien.ValueMember =
                "id";
        }

        async System.Threading.Tasks.Task LoadCaLam()
        {
            List<CaLam> ds =
                await caLamService.GetAll();

            cbCaLam.DataSource =
                ds;

            cbCaLam.DisplayMember =
                "ten_ca";

            cbCaLam.ValueMember =
                "id";
        }

        private async void btnLuu_Click(
            object sender,
            EventArgs e
        )
        {
            if (cbNhanVien.SelectedValue == null)
            {
                MessageBox.Show(
                    "Chọn nhân viên"
                );

                return;
            }

            if (cbCaLam.SelectedValue == null)
            {
                MessageBox.Show(
                    "Chọn ca làm"
                );

                return;
            }

            if (cbLoai.SelectedItem == null)
            {
                MessageBox.Show(
                    "Chọn loại nghỉ"
                );

                return;
            }

            NghiPhep item =
                new NghiPhep();

            item.id = id;

            item.nhan_vien_id =
                cbNhanVien.SelectedValue
                .ToString();

            item.ca_lam_id =
                Convert.ToInt32(
                    cbCaLam.SelectedValue
                );

            item.ngay =
                dtNgay.Value;

            item.loai =
                cbLoai.SelectedItem
                .ToString();

            item.ly_do =
                txtLyDo.Text;

            bool result;

            if (id == 0)
            {
                result =
                    await service.Add(item);

                if (result)
                {
                    MessageBox.Show(
                        "Thêm thành công"
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Thêm thất bại"
                    );

                    return;
                }
            }

            else
            {
                result =
                    await service.Update(item);

                if (result)
                {
                    MessageBox.Show(
                        "Cập nhật thành công"
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Cập nhật thất bại"
                    );

                    return;
                }
            }

            this.Close();
        }

        private void btnDong_Click(
            object sender,
            EventArgs e
        )
        {
            this.Close();
        }
    }
}