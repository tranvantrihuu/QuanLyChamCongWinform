using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmQuanLyChamCongEdit :
        BaseForm
    {
        private readonly
            QuanLyChamCongService _service =
                new QuanLyChamCongService();

        private readonly
            NhanVienService _nhanVienService =
                new NhanVienService();

        private readonly
            CaLamService _caLamService =
                new CaLamService();

        private readonly int _id = 0;

        public FrmQuanLyChamCongEdit()
        {
            InitializeComponent();
        }

        public FrmQuanLyChamCongEdit(
            int id
        )
        {
            InitializeComponent();

            _id = id;
        }

        private async void
            FrmQuanLyChamCongEdit_Load(
                object sender,
                EventArgs e
            )
        {
            await LoadNhanVien();

            await LoadCaLam();

            if (_id > 0)
            {
                await LoadDetail();
            }
        }

        private async Task LoadNhanVien()
        {
            try
            {
                var ds =
                    await _nhanVienService.GetAll();

                cboNhanVien.DataSource = ds;

                cboNhanVien.DisplayMember =
                    "ho_ten";

                cboNhanVien.ValueMember =
                    "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private async Task LoadCaLam()
        {
            try
            {
                var ds =
                    await _caLamService.GetAll();

                cboCaLam.DataSource = ds;

                cboCaLam.DisplayMember =
                    "ten_ca";

                cboCaLam.ValueMember =
                    "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private async Task LoadDetail()
        {
            try
            {
                var cc =
                    await _service.GetById(
                        _id
                    );

                if (cc == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy dữ liệu"
                    );

                    Close();

                    return;
                }

                cboNhanVien.SelectedValue =
                    cc.nhan_vien_id;

                dtpNgayLam.Value =
                    cc.ngay_lam
                    ?? DateTime.Now;

                cboCaLam.SelectedValue =
                    cc.ca_lam_id;

                dtpCheckIn.Value =
                    cc.check_in
                    ?? DateTime.Now;

                dtpCheckOut.Value =
                    cc.check_out
                    ?? DateTime.Now;
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
                    cboNhanVien.SelectedValue
                    == null
                )
                {
                    MessageBox.Show(
                        "Chọn nhân viên"
                    );

                    return;
                }

                if (
                    cboCaLam.SelectedValue
                    == null
                )
                {
                    MessageBox.Show(
                        "Chọn ca làm"
                    );

                    return;
                }

                ChamCong cc =
                    new ChamCong();

                cc.id = _id;

                cc.nhan_vien_id =
                    cboNhanVien
                    .SelectedValue
                    .ToString();

                cc.ngay_lam =
                    dtpNgayLam.Value.Date;

                cc.ca_lam_id =
                    Convert.ToInt32(
                        cboCaLam
                        .SelectedValue
                    );

                cc.check_in =
                    dtpCheckIn.Value;

                cc.check_out =
                    dtpCheckOut.Value;

                bool result;

                if (_id == 0)
                {
                    result =
                        await _service.Insert(
                            cc
                        );
                }
                else
                {
                    result =
                        await _service.Update(
                            cc
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
                    ex.Message
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