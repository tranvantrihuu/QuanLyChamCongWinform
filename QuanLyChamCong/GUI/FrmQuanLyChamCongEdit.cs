using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace QuanLyChamCong.GUI
{
    public partial class FrmQuanLyChamCongEdit : BaseForm
    {
        private readonly bool isEdit;

        private readonly int chamCongId;

        QuanLyChamCongService service =
            new QuanLyChamCongService();

        NhanVienService nhanVienService =
            new NhanVienService();

        CaLamService caLamService =
            new CaLamService();

        public FrmQuanLyChamCongEdit()
        {
            InitializeComponent();

            isEdit = false;
        }

        public FrmQuanLyChamCongEdit(
            int id
        )
        {
            InitializeComponent();

            isEdit = true;

            chamCongId = id;
        }

        private async void
            FrmQuanLyChamCongEdit_Load(
            object sender,
            EventArgs e
        )
        {

            await LoadNhanVien();

            await LoadCaLam();

            if (isEdit)
            {
                await LoadData();
            }
        }

        private async System.Threading.Tasks.Task
            LoadNhanVien()
        {
            List<NhanVien> ds =
                await nhanVienService
                .GetAll();

            cboNhanVien.DataSource =
                ds;

            cboNhanVien.DisplayMember =
                "ho_ten";

            cboNhanVien.ValueMember =
                "id";
        }

        private async System.Threading.Tasks.Task
            LoadCaLam()
        {
            List<CaLam> ds =
                await caLamService
                .GetAll();

            cboCaLam.DataSource =
                ds;

            cboCaLam.DisplayMember =
                "ten_ca";

            cboCaLam.ValueMember =
                "id";
        }

        private async System.Threading.Tasks.Task
            LoadData()
        {
            ChamCong item =
                await service.GetById(
                    chamCongId
                );

            if (item == null)
            {
                MessageBox.Show(
                    "Không tìm thấy dữ liệu"
                );

                Close();

                return;
            }

            cboNhanVien.SelectedValue =
                item.nhan_vien_id;

            cboCaLam.SelectedValue =
                item.ca_lam_id;

            dtpNgayLam.Value =
                item.ngay_lam
                ?? DateTime.Now;

            dtpCheckIn.Value =
                item.check_in
                ?? DateTime.Now;

            dtpCheckOut.Value =
                item.check_out
                ?? DateTime.Now;
        }

        private async void btnLuu_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                cboNhanVien.SelectedValue
                == null
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên"
                );

                return;
            }

            if (
                cboCaLam.SelectedValue
                == null
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn ca làm"
                );

                return;
            }

            ChamCong item =
                new ChamCong();

            item.nhan_vien_id =
                cboNhanVien
                .SelectedValue
                .ToString();

            item.ca_lam_id =
                Convert.ToInt32(
                    cboCaLam.SelectedValue
                );

            item.ngay_lam =
                dtpNgayLam.Value.Date;

            item.check_in =
                dtpCheckIn.Value;

            item.check_out =
                dtpCheckOut.Value;

            bool result;

            if (isEdit)
            {
                item.id =
                    chamCongId;

                result =
                    await service.Update(
                        item
                    );
            }
            else
            {
                result =
                    await service.Insert(
                        item
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