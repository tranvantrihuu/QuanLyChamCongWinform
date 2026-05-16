using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmThuongPhatEdit : BaseForm
    {
        ThuongPhatService service =
            new ThuongPhatService();

        NhanVienService nhanVienService =
            new NhanVienService();

        public int id = 0;

        
        public string nhanVienId = "";
        public string loai = "";
        public decimal soTien = 0;
        public string lyDo = "";
        public DateTime ngay;

        public FrmThuongPhatEdit()
        {
            InitializeComponent();
            txtSoTien.TextAlign = HorizontalAlignment.Right;
        }

        private async void FrmThuongPhatEdit_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadNhanVien();

            
            cbLoai.Items.Clear();

            cbLoai.Items.Add("Thưởng");
            cbLoai.Items.Add("Phạt");

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

                // loại
                if (loai == "Thuong")
                {
                    cbLoai.SelectedItem = "Thưởng";
                }
                else if (loai == "Phat")
                {
                    cbLoai.SelectedItem = "Phạt";
                }
                else
                {
                    cbLoai.SelectedItem = loai;
                }

                // số tiền
                txtSoTien.Text =
                soTien
                    .ToString("N0")
                    .Replace(",", ".");

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

            if (txtSoTien.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Nhập số tiền"
                );

                return;
            }

            decimal soTienValue;

            if (!decimal.TryParse(
                txtSoTien.Text,
                out soTienValue
            ))
            {
                MessageBox.Show(
                    "Số tiền không hợp lệ"
                );

                return;
            }

            ThuongPhat tp =
                new ThuongPhat();

            tp.id = id;

            tp.nhan_vien_id =
                cbNhanVien.SelectedValue
                .ToString();

            if (cbLoai.SelectedItem == null)
            {
                MessageBox.Show("Chọn loại");

                return;
            }

            tp.loai =
                cbLoai.SelectedItem
                .ToString();

            tp.so_tien =
                soTienValue;

            tp.ly_do =
                txtLyDo.Text;

            tp.ngay =
                dtNgay.Value;

            bool result;

            if (id == 0)
            {
                result =
                    await service.Add(tp);

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
                    await service.Update(tp);

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