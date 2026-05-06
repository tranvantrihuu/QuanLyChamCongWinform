// FrmThuongPhatEdit.cs

using BLL;
using QuanLyChamCong.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmThuongPhatEdit : Form
    {
        ThuongPhatBLL bll =
            new ThuongPhatBLL();

        DataProvider dp =
            new DataProvider();

        public int id = 0;

        public FrmThuongPhatEdit()
        {
            InitializeComponent();
        }

        private void FrmThuongPhatEdit_Load(
            object sender,
            EventArgs e
        )
        {
            LoadNhanVien();

            cbLoai.Items.Add("thuong");
            cbLoai.Items.Add("phat");
            cbLoai.FormattingEnabled = true;
            cbLoai.Format += (s, ev) =>
            {
                if (ev.ListItem.ToString() == "thuong")
                    ev.Value = "Thưởng";

                else if (ev.ListItem.ToString() == "phat")
                    ev.Value = "Phạt";
            };
            cbLoai.SelectedIndex = 0;
        }

        void LoadNhanVien()
        {
            string sql = @"
                SELECT id, ho_ten
                FROM nhan_vien";

            DataTable dt =
                dp.ExecuteQuery(sql);

            cbNhanVien.DataSource =
                dt;

            cbNhanVien.DisplayMember =
                "ho_ten";

            cbNhanVien.ValueMember =
                "id";
        }

        private void btnLuu_Click(
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

            decimal soTien;

            if (!decimal.TryParse(
                txtSoTien.Text,
                out soTien
            ))
            {
                MessageBox.Show(
                    "Số tiền không hợp lệ"
                );

                return;
            }

            string nhanVienId =
                cbNhanVien.SelectedValue
                .ToString();

            string loai =
                cbLoai.Text;

            string lyDo =
                txtLyDo.Text;

            DateTime ngay =
                dtNgay.Value;

            if (id == 0)
            {
                bll.Insert(
                    nhanVienId,
                    loai,
                    soTien,
                    lyDo,
                    ngay
                );

                MessageBox.Show(
                    "Thêm thành công"
                );
            }
            else
            {
                bll.Update(
                    id,
                    nhanVienId,
                    loai,
                    soTien,
                    lyDo,
                    ngay
                );

                MessageBox.Show(
                    "Cập nhật thành công"
                );
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