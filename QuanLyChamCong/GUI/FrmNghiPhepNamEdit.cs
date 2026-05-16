
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmNghiPhepNamEdit : BaseForm
    {
        NghiPhepNamService service =
            new NghiPhepNamService();

        NhanVienService nhanVienService =
            new NhanVienService();

        public int id = 0;

     
        public string nhanVienId = "";

        public int nam = 0;

        public int soCaDuocNghi = 0;

        public int soCaCoPhep = 0;

        public int soCaKhongPhep = 0;

        public FrmNghiPhepNamEdit()
        {
            InitializeComponent();
        }

        private async void FrmNghiPhepNamEdit_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadNhanVien();

        
            if (id == 0)
            {
                numNam.Value =
                    DateTime.Now.Year;

                numDuocNghi.Value = 12;

                numCoPhep.Value = 0;

                numKhongPhep.Value = 0;
            }

            else
            {
                if (!string.IsNullOrEmpty(
                    nhanVienId))
                {
                    cbNhanVien.SelectedValue =
                        nhanVienId;
                }

                numNam.Value =
                    nam;

                numDuocNghi.Value =
                    soCaDuocNghi;

                numCoPhep.Value =
                    soCaCoPhep;

                numKhongPhep.Value =
                    soCaKhongPhep;
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

            NghiPhepNam item =
                new NghiPhepNam();

            item.id = id;

            item.nhan_vien_id =
                cbNhanVien.SelectedValue
                .ToString();

            item.nam =
                Convert.ToInt32(
                    numNam.Value
                );

            item.so_ca_duoc_nghi =
                Convert.ToInt32(
                    numDuocNghi.Value
                );

            item.so_ca_da_nghi_co_phep =
                Convert.ToInt32(
                    numCoPhep.Value
                );

            item.so_ca_da_nghi_khong_phep =
                Convert.ToInt32(
                    numKhongPhep.Value
                );

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

        private void btnHuy_Click(
            object sender,
            EventArgs e
        )
        {
            this.Close();
        }
    }
}