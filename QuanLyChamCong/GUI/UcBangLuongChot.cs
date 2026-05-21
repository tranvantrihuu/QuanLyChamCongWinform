using QuanLyChamCong.Models;
using QuanLyChamCong.Models.ViewModels;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcBangLuongChot :
        BaseUserControl
    {
        private bool sortAscending = true;
        private readonly
            BangLuongChotService _service =
                new BangLuongChotService();

        private bool _isLoaded = false;

        public UcBangLuongChot()
        {
            InitializeComponent();
        }

        private async void UcBangLuongChot_Load(
        object sender,
        EventArgs e
        )
        {

        LoadFilter();

          
            _isLoaded = true;

           
            await LoadData();


}

        private void LoadFilter()
        {
            cboThang.Items.Clear();


        for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i);
            }

            cboNam.Items.Clear();

            for (int i = 2024; i <= 2035; i++)
            {
                cboNam.Items.Add(i);
            }

            /*
             * MẶC ĐỊNH THÁNG/NĂM HIỆN TẠI
             */

            cboThang.SelectedItem =
                DateTime.Now.Month;

            cboNam.Text =
                DateTime.Now.Year
                .ToString();


}


        private async Task LoadData()
        {
            try
            {
                if (
                    !int.TryParse(
                        cboThang.Text,
                        out int thang
                    )
                )
                {
                    return;
                }

                if (
                    !int.TryParse(
                        cboNam.Text,
                        out int nam
                    )
                )
                {
                    return;
                }

                List<VwBangLuongChot> data =
                    await _service
                    .GetByThangNam(
                        thang,
                        nam
                    );

                dgvDanhSach.DataSource =
                    null;

                dgvDanhSach.AutoGenerateColumns =
                    true;

                dgvDanhSach.DataSource =
                    data;

                bool daChot =
                    data.Count > 0
                    && data[0].id > 0;

                btnChotLuong.Enabled =
                    !daChot;

                btnChotLuong.Text =
                    daChot
                    ? "Đã chốt"
                    : "Chốt bảng lương";
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load dữ liệu:\n"
                    + ex.Message
                );
            }
        }

        private void FormatGrid()
        {
            if (
            dgvDanhSach.Columns.Count == 0
            )
            {
                return;
            }
/*
 * GRID
 */

dgvDanhSach.SelectionMode =
    DataGridViewSelectionMode
    .FullRowSelect;

            dgvDanhSach.MultiSelect =
                false;

            dgvDanhSach.ReadOnly =
                true;

            dgvDanhSach.AllowUserToAddRows =
                false;

            dgvDanhSach.RowHeadersVisible =
                false;

            dgvDanhSach.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                .Fill;

            /*
             * STYLE
             */

            dgvDanhSach.EnableHeadersVisualStyles =
                false;

            dgvDanhSach.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    0,
                    120,
                    215
                );

            dgvDanhSach.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dgvDanhSach.ColumnHeadersHeight =
                45;

            dgvDanhSach.RowTemplate.Height =
                36;

            dgvDanhSach.BorderStyle =
                BorderStyle.None;

            dgvDanhSach.CellBorderStyle =
                DataGridViewCellBorderStyle
                .SingleHorizontal;

            dgvDanhSach.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(
                    245,
                    245,
                    245
                );

            /*
             * ẨN CỘT
             */

            string[] hiddenCols =
            {
                "id",
                "created_at",
                "updated_at",
                "nguoi_chot",
                "ngay_chot",
                "ghi_chu",
                "vi_tri",
                "thang",
                "nam"
            };

            foreach (
                string col
                in hiddenCols
            )
            {
                if (
                    dgvDanhSach.Columns[col]
                    != null
                )
                {
                    dgvDanhSach.Columns[col]
                        .Visible = false;
                }
            }

            /*
             * HEADER
             */

            SetHeader(
                "nhan_vien_id",
                "Mã nhân viên"
            );

            SetHeader(
                "ho_ten",
                "Họ tên"
            );

            SetHeader(
                "loai_luong",
                "Loại lương"
            );

            SetHeader(
                "luong_co_ban",
                "Lương cơ bản"
            );

            SetHeader(
                "luong_theo_gio",
                "Lương theo giờ"
            );

            SetHeader(
                "phu_cap",
                "Phụ cấp"
            );

            SetHeader(
                "luong_tang_ca_theo_gio",
                "Lương tăng ca / giờ"
            );

            SetHeader(
                "tong_ca_duoc_phan",
                "Ca phân"
            );

            SetHeader(
                "tong_ca_di_lam",
                "Ca đi làm"
            );

            SetHeader(
                "tong_ca_nghi",
                "Ca nghỉ"
            );

            SetHeader(
                "tong_phut_di_tre",
                "Đi trễ"
            );

            SetHeader(
                "tong_phut_ve_som",
                "Về sớm"
            );

            SetHeader(
                "tong_phut_bi_tru",
                "Tổng phút bị trừ"
            );

            SetHeader(
                "tong_phut_tang_ca",
                "Phút tăng ca"
            );

            SetHeader(
                "tong_gio_lam",
                "Tổng giờ làm"
            );

            SetHeader(
                "tong_luong_chinh",
                "Lương chính"
            );

            SetHeader(
                "tong_luong_tang_ca",
                "Lương tăng ca"
            );

            SetHeader(
                "thuong",
                "Thưởng"
            );

            SetHeader(
                "phat",
                "Phạt"
            );

            SetHeader(
                "tong_luong",
                "Tổng lương"
            );

            /*
             * FORMAT MONEY
             */

            string[] moneyCols =
            {
                "luong_co_ban",
                "luong_theo_gio",
                "phu_cap",
                "luong_tang_ca_theo_gio",
                "tong_luong_chinh",
                "tong_luong_tang_ca",
                "thuong",
                "phat",
                "tong_luong"
            };

            foreach (
                string col
                in moneyCols
            )
            {
                if (
                    dgvDanhSach.Columns[col]
                    != null
                )
                {
                    dgvDanhSach.Columns[col]
                        .DefaultCellStyle.Format =
                        "N0";
                }
            }

            /*
             * THỨ TỰ CỘT
             */

            SetDisplayIndex(
                "nhan_vien_id",
                0
            );

            SetDisplayIndex(
                "ho_ten",
                1
            );

            SetDisplayIndex(
                "loai_luong",
                2
            );

            SetDisplayIndex(
                "luong_co_ban",
                3
            );

            SetDisplayIndex(
                "luong_theo_gio",
                4
            );

            SetDisplayIndex(
                "phu_cap",
                5
            );

            SetDisplayIndex(
                "luong_tang_ca_theo_gio",
                6
            );

            SetDisplayIndex(
                "tong_ca_duoc_phan",
                7
            );

            SetDisplayIndex(
                "tong_ca_di_lam",
                8
            );

            SetDisplayIndex(
                "tong_ca_nghi",
                9
            );

            SetDisplayIndex(
                "tong_phut_di_tre",
                10
            );

            SetDisplayIndex(
                "tong_phut_ve_som",
                11
            );

            SetDisplayIndex(
                "tong_phut_bi_tru",
                12
            );

            SetDisplayIndex(
                "tong_phut_tang_ca",
                13
            );

            SetDisplayIndex(
                "tong_gio_lam",
                14
            );

            SetDisplayIndex(
                "tong_luong_chinh",
                15
            );

            SetDisplayIndex(
                "tong_luong_tang_ca",
                16
            );

            SetDisplayIndex(
                "thuong",
                17
            );

            SetDisplayIndex(
                "phat",
                18
            );

            SetDisplayIndex(
                "tong_luong",
                19
            );
           
            /*
             * THƯỞNG
             */

            dgvDanhSach.Columns["thuong"]
                .DefaultCellStyle.ForeColor =
                    Color.Green;

            /*
             * PHẠT
             */

            dgvDanhSach.Columns["phat"]
                .DefaultCellStyle.ForeColor =
                    Color.Red;

            /*
             * TỔNG LƯƠNG
             */

            dgvDanhSach.Columns["tong_luong"]
                .DefaultCellStyle.Font =
                    new Font(
                        dgvDanhSach.Font,
                        FontStyle.Bold
                    );

            dgvDanhSach.Columns["tong_luong"]
                .DefaultCellStyle.ForeColor =
                    Color.DarkBlue;

        }

        private void SetHeader(
        string columnName,
        string text
        )
        {
            if (
            dgvDanhSach.Columns[columnName]
            != null
            )
            {
                dgvDanhSach.Columns[columnName]
                .HeaderText = text;
            }
        }

        private void SetDisplayIndex(
            string columnName,
            int index
        )
        {
            if (
                dgvDanhSach.Columns[columnName]
                != null
            )
            {
                int maxIndex =
                    dgvDanhSach.Columns.Count - 1;

                if (index > maxIndex)
                {
                    index = maxIndex;
                }

                dgvDanhSach.Columns[columnName]
                    .DisplayIndex = index;
            }
        }


        private VwBangLuongChot
            GetCurrentRow()
        {
            if (
                dgvDanhSach.CurrentRow
                == null
            )
            {
                return null;
            }

            return dgvDanhSach
                .CurrentRow
                .DataBoundItem
                as VwBangLuongChot;
        }

        private async void btnTaiLai_Click(
            object sender,
            EventArgs e
        )
        {
            await LoadData();
        }

        private async void btnChotLuong_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                if (
                    !int.TryParse(
                        cboThang.Text,
                        out int thang
                    )
                )
                {
                    MessageBox.Show(
                        "Tháng không hợp lệ"
                    );

                    return;
                }

                if (
                    !int.TryParse(
                        cboNam.Text,
                        out int nam
                    )
                )
                {
                    MessageBox.Show(
                        "Năm không hợp lệ"
                    );

                    return;
                }

                DialogResult rs =
                    MessageBox.Show(
                        $"Tính bảng lương tháng {thang}/{nam} ?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (
                    rs != DialogResult.Yes
                )
                {
                    return;
                }

                bool result =
                    await _service
                    .TinhBangLuong(
                        thang,
                        nam
                    );

                if (result)
                {
                    MessageBox.Show(
                        "Tính bảng lương thành công"
                    );

                    await LoadData();
                }
                else
                {
                    MessageBox.Show(
                        "Tính bảng lương thất bại"
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
        

        private async void dgvDanhSach_CellDoubleClick(
        object sender,
        DataGridViewCellEventArgs e
        )
                {
                    if (e.RowIndex < 0)
                    {
                        return;
                    }

        VwBangLuongChot item =
            GetCurrentRow();

            if (item == null)
            {
                return;
            }

            FrmBangLuongChotEdit frm =
                new FrmBangLuongChotEdit();

            /*
             * REALTIME + ĐÃ CHỐT
             * DÙNG TRỰC TIẾP DATA GRID
             */

            frm.DataDetail =
                new BangLuongChot
                {
                    id =
                        item.id,

                    nhan_vien_id =
                        item.nhan_vien_id,

                    ho_ten =
                        item.ho_ten,

                    tong_ca_duoc_phan =
                        item.tong_ca_duoc_phan,

                    tong_ca_di_lam =
                        item.tong_ca_di_lam,

                    tong_ca_nghi =
                        item.tong_ca_nghi,

                    tong_phut_di_tre =
                        item.tong_phut_di_tre,

                    tong_phut_ve_som =
                        item.tong_phut_ve_som,

                    tong_phut_tang_ca =
                        item.tong_phut_tang_ca,

                    luong_co_ban =
                        item.luong_co_ban,

                    tong_luong_chinh =
                        item.tong_luong_chinh,

                    tong_luong_tang_ca =
                        item.tong_luong_tang_ca,

                    phu_cap =
                        item.phu_cap,

                    thuong =
                        item.thuong,

                    phat =
                        item.phat,

                    tong_luong =
                        item.tong_luong
                };

            frm.ShowDialog();

            await LoadData();

}


        private async void cboThang_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            if (_isLoaded)
            {
                await LoadData();
            }
        }

        private async void cboNam_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            if (_isLoaded)
            {
                await LoadData();
            }
        }

        private void dgvDanhSach_ColumnHeaderMouseClick(
            object sender,
            DataGridViewCellMouseEventArgs e
        )
        {
            string columnName =
                dgvDanhSach.Columns[e.ColumnIndex]
                .DataPropertyName;

            if (string.IsNullOrEmpty(columnName))
            {
                return;
            }

            List<VwBangLuongChot> data =
                dgvDanhSach.DataSource
                as List<VwBangLuongChot>;

            if (data == null)
            {
                return;
            }

            if (sortAscending)
            {
                data = data
                    .OrderBy(x =>
                        x.GetType()
                        .GetProperty(columnName)
                        .GetValue(x, null)
                    )
                    .ToList();
            }
            else
            {
                data = data
                    .OrderByDescending(x =>
                        x.GetType()
                        .GetProperty(columnName)
                        .GetValue(x, null)
                    )
                    .ToList();
            }

            sortAscending =
                !sortAscending;

            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = data;

            FormatGrid();
        }
    }
}