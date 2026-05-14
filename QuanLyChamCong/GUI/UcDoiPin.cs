using QuanLyChamCong.BLL;
using QuanLyChamCong.THEME;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcDoiPin
        : BaseUserControl
    {
        private DoiPinBLL bll =
            new DoiPinBLL();

        private DataTable dtNhanVien;

        public UcDoiPin()
        {
            InitializeComponent();
        }

        private void UcDoiPin_Load(
            object sender,
            EventArgs e
        )
        {
            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            dtNhanVien =
                bll.GetNhanVien();

            cboNhanVien.DataSource =
                null;

            cboNhanVien.DataSource =
                dtNhanVien;

            cboNhanVien.DisplayMember =
                "ho_ten";

            cboNhanVien.ValueMember =
                "id";

            cboNhanVien.SelectedIndex =
                -1;

            lblPinHienTai.Text =
                "----";
        }

        private void cboNhanVien_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            if (
                cboNhanVien.SelectedIndex < 0
            )
            {
                return;
            }

            DataRowView row =
                cboNhanVien.SelectedItem
                as DataRowView;

            if (row == null)
            {
                return;
            }

            lblPinHienTai.Text =
                row["pin_code"]
                .ToString();
        }

        private void btnDoiPin_Click(
            object sender,
            EventArgs e
        )
        {
            // chưa chọn nhân viên

            if (
                cboNhanVien.SelectedIndex < 0
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên"
                );

                return;
            }

            // kiểm tra nhập

            if (
                txtPinMoi.Text.Trim() == "" ||
                txtXacNhan.Text.Trim() == ""
            )
            {
                MessageBox.Show(
                    "Nhập đầy đủ thông tin"
                );

                return;
            }

            // xác nhận pin

            if (
                txtPinMoi.Text.Trim() !=
                txtXacNhan.Text.Trim()
            )
            {
                MessageBox.Show(
                    "PIN xác nhận không khớp"
                );

                return;
            }

            // lấy dòng hiện tại

            DataRowView row =
                cboNhanVien.SelectedItem
                as DataRowView;

            if (row == null)
            {
                MessageBox.Show(
                    "Không lấy được nhân viên"
                );

                return;
            }

            // lấy id

            string id = row["id"].ToString();

            // đổi pin

            bool result =
                bll.DoiPin(
                    id,
                    txtPinMoi.Text.Trim()
                );

            if (result)
            {
                MessageBox.Show(
                    "Đổi PIN thành công"
                );

                // reload

                LoadNhanVien();

                // clear

                txtPinMoi.Clear();

                txtXacNhan.Clear();
            }
            else
            {
                MessageBox.Show(
                    "Đổi PIN thất bại"
                );
            }
        }
    }
}