using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmCaLamEdit :
        BaseForm
    {
        private readonly CaLamService _service =
            new CaLamService();

        public bool IsEdit = false;

        public CaLam CaLamEdit =
            new CaLam();

        public FrmCaLamEdit()
        {
            InitializeComponent();
        }

        private void FrmCaLamEdit_Load(
            object sender,
            EventArgs e
        )
        {
            SetupDateTimePicker();

            if (IsEdit)
            {
                LoadDataEdit();
            }
        }

        private void SetupDateTimePicker()
        {
            dtBatDau.Format =
                DateTimePickerFormat.Time;

            dtBatDau.ShowUpDown =
                true;

            dtKetThuc.Format =
                DateTimePickerFormat.Time;

            dtKetThuc.ShowUpDown =
                true;
        }

        private void LoadDataEdit()
        {
            try
            {
                txtTenCa.Text =
                    CaLamEdit.ten_ca;

                if (
                    CaLamEdit.gio_bat_dau
                    != null
                )
                {
                    dtBatDau.Value =
                        DateTime.Today
                        .Add(
                            CaLamEdit
                            .gio_bat_dau.Value
                        );
                }

                if (
                    CaLamEdit.gio_ket_thuc
                    != null
                )
                {
                    dtKetThuc.Value =
                        DateTime.Today
                        .Add(
                            CaLamEdit
                            .gio_ket_thuc.Value
                        );
                }

                numDiTre.Value =
                    CaLamEdit
                    .phut_cho_phep_di_tre
                    ?? 0;

                numVeSom.Value =
                    CaLamEdit
                    .phut_cho_phep_ve_som
                    ?? 0;

                numCheckinSom.Value =
                    CaLamEdit
                    .phut_cho_phep_checkin_som
                    ?? 0;

                numCheckoutTre.Value =
                    CaLamEdit
                    .phut_cho_phep_checkout_tre
                    ?? 0;
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
                string.IsNullOrWhiteSpace(
                    txtTenCa.Text
                )
            )
            {
                MessageBox.Show(
                    "Vui lòng nhập tên ca"
                );

                txtTenCa.Focus();

                return;
            }

            /*
             * GÁN MODEL
             */

            CaLamEdit.ten_ca =
                txtTenCa.Text.Trim();

            CaLamEdit.gio_bat_dau =
                dtBatDau.Value.TimeOfDay;

            CaLamEdit.gio_ket_thuc =
                dtKetThuc.Value.TimeOfDay;

            CaLamEdit.phut_cho_phep_di_tre =
                (int)numDiTre.Value;

            CaLamEdit.phut_cho_phep_ve_som =
                (int)numVeSom.Value;

            CaLamEdit.phut_cho_phep_checkin_som =
                (int)numCheckinSom.Value;

            CaLamEdit.phut_cho_phep_checkout_tre =
                (int)numCheckoutTre.Value;

            bool result = false;

            if (IsEdit)
            {
                result =
                    await _service.Update(
                        CaLamEdit
                    );
            }
            else
            {
                result =
                    await _service.Add(
                        CaLamEdit
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