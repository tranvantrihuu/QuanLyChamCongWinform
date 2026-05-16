using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcCauHinhLuong : BaseUserControl
    {
        CauHinhLuongService service =
            new CauHinhLuongService();

        public UcCauHinhLuong()
        {
            InitializeComponent();

            dgvCauHinhLuong.CurrentCellDirtyStateChanged +=
                dgvCauHinhLuong_CurrentCellDirtyStateChanged;

        }

        private async void UcCauHinhLuong_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var dt = await service.GetAll();

            dgvCauHinhLuong.DataSource = dt;

            if (!dgvCauHinhLuong.Columns.Contains("colCheck"))
            {
                DataGridViewCheckBoxColumn chk =
                    new DataGridViewCheckBoxColumn();

                chk.Name = "colCheck";
                chk.Width = 40;

                dgvCauHinhLuong.Columns.Insert(0, chk);
            }

            if (!dgvCauHinhLuong.Columns.Contains("stt"))
            {
                DataGridViewTextBoxColumn stt =
                    new DataGridViewTextBoxColumn();

                stt.Name = "stt";
                stt.HeaderText = "STT";
                stt.Width = 50;

                dgvCauHinhLuong.Columns.Insert(1, stt);
            }

            dgvCauHinhLuong.RowPostPaint +=
                (s, e) =>
                {
                    dgvCauHinhLuong.Rows[e.RowIndex]
                        .Cells["stt"].Value =
                        (e.RowIndex + 1).ToString();
                };

            dgvCauHinhLuong.RowHeadersVisible = false;

            foreach (DataGridViewColumn col
                in dgvCauHinhLuong.Columns)
            {
                col.ReadOnly = true;

                col.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                col.HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            dgvCauHinhLuong.Columns["colCheck"]
                .ReadOnly = false;

            dgvCauHinhLuong.Columns["stt"]
                .DisplayIndex = 1;

            dgvCauHinhLuong.Columns["nhan_vien_id"]
                .DisplayIndex = 2;

            dgvCauHinhLuong.Columns["ho_ten"]
                .DisplayIndex = 3;

            dgvCauHinhLuong.Columns["vi_tri"]
                .DisplayIndex = 4;

            dgvCauHinhLuong.Columns["loai_luong"]
                .DisplayIndex = 5;

            dgvCauHinhLuong.Columns["luong_co_ban"]
                .DisplayIndex = 6;

            dgvCauHinhLuong.Columns["luong_theo_gio"]
                .DisplayIndex = 7;

            dgvCauHinhLuong.Columns["luong_tang_ca"]
                .DisplayIndex = 8;

            dgvCauHinhLuong.Columns["phu_cap_mac_dinh"]
                .DisplayIndex = 9;

            dgvCauHinhLuong.RowHeadersVisible = false;
            dgvCauHinhLuong.ReadOnly = false;

            foreach (DataGridViewColumn col
                in dgvCauHinhLuong.Columns)
            {
                col.ReadOnly = true;

                col.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                col.HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            dgvCauHinhLuong.Columns["colCheck"]
                .ReadOnly = false;

            dgvCauHinhLuong.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCauHinhLuong.Columns["nhan_vien_id"]
                .HeaderText = "ID NHÂN VIÊN";

            dgvCauHinhLuong.Columns["ho_ten"]
                .HeaderText = "HỌ VÀ TÊN";

            dgvCauHinhLuong.Columns["vi_tri"]
                .HeaderText = "VỊ TRÍ";

            dgvCauHinhLuong.Columns["loai_luong"]
                .HeaderText = "LOẠI LƯƠNG";

            dgvCauHinhLuong.Columns["luong_co_ban"]
                .HeaderText = "LƯƠNG CƠ BẢN";

            dgvCauHinhLuong.Columns["luong_theo_gio"]
                .HeaderText = "LƯƠNG GIỜ";

            dgvCauHinhLuong.Columns["luong_tang_ca"]
                .HeaderText = "TĂNG CA 1 GIỜ";

            dgvCauHinhLuong.Columns["phu_cap_mac_dinh"]
                .HeaderText = "PHỤ CẤP";

            if (dgvCauHinhLuong.Columns.Contains("nv_id"))
                dgvCauHinhLuong.Columns["nv_id"]
                    .Visible = false;

            if (dgvCauHinhLuong.Columns.Contains("ma_van_tay"))
                dgvCauHinhLuong.Columns["ma_van_tay"]
                    .Visible = false;

            if (dgvCauHinhLuong.Columns.Contains("id"))
                dgvCauHinhLuong.Columns["id"]
                    .Visible = false;

            var culture =
                new System.Globalization.CultureInfo("vi-VN");

            if (dgvCauHinhLuong.Columns.Contains("luong_co_ban"))
            {
                dgvCauHinhLuong.Columns["luong_co_ban"]
                    .DefaultCellStyle.Format = "N0";

                dgvCauHinhLuong.Columns["luong_co_ban"]
                    .DefaultCellStyle.FormatProvider = culture;
            }

            if (dgvCauHinhLuong.Columns.Contains("luong_theo_gio"))
            {
                dgvCauHinhLuong.Columns["luong_theo_gio"]
                    .DefaultCellStyle.Format = "N0";

                dgvCauHinhLuong.Columns["luong_theo_gio"]
                    .DefaultCellStyle.FormatProvider = culture;
            }

            if (dgvCauHinhLuong.Columns.Contains("luong_tang_ca"))
            {
                dgvCauHinhLuong.Columns["luong_tang_ca"]
                    .DefaultCellStyle.Format = "N0";

                dgvCauHinhLuong.Columns["luong_tang_ca"]
                    .DefaultCellStyle.FormatProvider = culture;
            }

            if (dgvCauHinhLuong.Columns.Contains("phu_cap_mac_dinh"))
            {
                dgvCauHinhLuong.Columns["phu_cap_mac_dinh"]
                    .DefaultCellStyle.Format = "N0";

                dgvCauHinhLuong.Columns["phu_cap_mac_dinh"]
                    .DefaultCellStyle.FormatProvider = culture;
            }

            dgvCauHinhLuong.EnableHeadersVisualStyles = false;

            dgvCauHinhLuong.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(0, 120, 215);

            dgvCauHinhLuong.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCauHinhLuong.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvCauHinhLuong.RowsDefaultCellStyle.BackColor =
                Color.White;

            dgvCauHinhLuong.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 240, 240);

            dgvCauHinhLuong.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCauHinhLuong.AllowUserToAddRows = false;

            dgvCauHinhLuong.MultiSelect = false;

            dgvCauHinhLuong.EditMode =
                DataGridViewEditMode.EditOnEnter;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmCauHinhLuongEdit f =
                new FrmCauHinhLuongEdit(false);

            f.ShowDialog();

            await LoadData();
        }

        private async void dgvCauHinhLuong_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
                return;

            var row =
                dgvCauHinhLuong.Rows[e.RowIndex];

            FrmCauHinhLuongEdit f =
                new FrmCauHinhLuongEdit(true);

            f.id =
                Convert.ToInt32(
                    row.Cells["id"].Value
                );

            f.nhanVienId =
                row.Cells["nhan_vien_id"]
                .Value
                .ToString();

            f.numLuongCoBan.Value =
                row.Cells["luong_co_ban"].Value
                == DBNull.Value
                ? 0
                : Convert.ToDecimal(
                    row.Cells["luong_co_ban"].Value
                );

            f.numLuongTheoGio.Value =
                row.Cells["luong_theo_gio"].Value
                == DBNull.Value
                ? 0
                : Convert.ToDecimal(
                    row.Cells["luong_theo_gio"].Value
                );

            f.numTangCa.Value =
                row.Cells["luong_tang_ca"].Value
                == DBNull.Value
                ? 0
                : Convert.ToDecimal(
                    row.Cells["luong_tang_ca"].Value
                );

            f.numPhuCap.Value =
                row.Cells["phu_cap_mac_dinh"].Value
                == DBNull.Value
                ? 0
                : Convert.ToDecimal(
                    row.Cells["phu_cap_mac_dinh"].Value
                );

            f.ShowDialog();

            await LoadData();
        }

        private async void btnXoa_Click(
            object sender,
            EventArgs e
        )
        {
            List<int> ids =
                new List<int>();

            foreach (DataGridViewRow row
                in dgvCauHinhLuong.Rows)
            {
                if (row.Cells["colCheck"].Value != null
                    &&
                    Convert.ToBoolean(
                        row.Cells["colCheck"].Value
                    ))
                {
                    ids.Add(
                        Convert.ToInt32(
                            row.Cells["id"].Value
                        )
                    );
                }
            }

            if (ids.Count == 0)
            {
                MessageBox.Show(
                    "Tick chọn dòng muốn xóa!"
                );

                return;
            }

            var result =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.No)
                return;

            foreach (int item in ids)
            {
                await service.Delete(item);
            }

            MessageBox.Show(
                "Xóa thành công!"
            );

            await LoadData();
        }

        private void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            MessageBox.Show(
                "Double click dòng muốn sửa!"
            );
        }

        private void dgvCauHinhLuong_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {
            if (dgvCauHinhLuong.IsCurrentCellDirty)
            {
                dgvCauHinhLuong.CommitEdit(
                    DataGridViewDataErrorContexts.Commit
                );
            }
        }

        private void dgvCauHinhLuong_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.ColumnIndex ==
                dgvCauHinhLuong.Columns["colCheck"].Index)
            {
                var row =
                    dgvCauHinhLuong.Rows[e.RowIndex];

                bool isChecked =
                    row.Cells["colCheck"].Value != null
                    &&
                    Convert.ToBoolean(
                        row.Cells["colCheck"].Value
                    );

                row.DefaultCellStyle.BackColor =
                    isChecked
                    ? Color.LightPink
                    : Color.White;
            }
        }
    }
}