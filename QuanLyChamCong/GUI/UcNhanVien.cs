using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcNhanVien : BaseUserControl
    {
        private readonly NhanVienService service =
            new NhanVienService();
        private bool sortAscending = true;
        public UcNhanVien()
        {
            InitializeComponent();
        }

        private async void UcNhanVien_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                List<NhanVien> ds =
                    (await service.GetAll())
                    .OrderBy(x => x.id)
                    .ToList();

                dgvNhanVien.DataSource = null;

                dgvNhanVien.DataSource = ds;
                dgvNhanVien.MultiSelect = true;

                dgvNhanVien.SelectionMode =
                    DataGridViewSelectionMode
                    .FullRowSelect;
                dgvNhanVien.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode
                    .Fill;
                dgvNhanVien.ColumnHeaderMouseClick -=
                    dgvNhanVien_ColumnHeaderMouseClick;

                dgvNhanVien.ColumnHeaderMouseClick +=
                    dgvNhanVien_ColumnHeaderMouseClick;
                dgvNhanVien.ReadOnly = true;

                dgvNhanVien.AllowUserToAddRows =
                    false;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }
        private void FormatGrid()
        {
            /*
             * ẨN CỘT
             */

            if (
                dgvNhanVien.Columns["pin_code"]
                != null
            )
            {
                dgvNhanVien.Columns["pin_code"]
                    .Visible = false;
            }

            /*
             * ĐỔI TÊN CỘT
             */

            if (
                dgvNhanVien.Columns["id"]
                != null
            )
            {
                dgvNhanVien.Columns["id"]
                    .HeaderText = "Mã NV";
            }

            if (
                dgvNhanVien.Columns["ma_van_tay"]
                != null
            )
            {
                dgvNhanVien.Columns["ma_van_tay"]
                    .HeaderText = "Mã Vân Tay";
            }

            if (
                dgvNhanVien.Columns["ho_ten"]
                != null
            )
            {
                dgvNhanVien.Columns["ho_ten"]
                    .HeaderText = "Họ Tên";
            }

            if (
                dgvNhanVien.Columns["ngay_sinh"]
                != null
            )
            {
                dgvNhanVien.Columns["ngay_sinh"]
                    .HeaderText = "Ngày Sinh";
            }

            if (
                dgvNhanVien.Columns["so_dien_thoai"]
                != null
            )
            {
                dgvNhanVien.Columns["so_dien_thoai"]
                    .HeaderText = "Số Điện Thoại";
            }

            if (
                dgvNhanVien.Columns["vi_tri"]
                != null
            )
            {
                dgvNhanVien.Columns["vi_tri"]
                    .HeaderText = "Vị Trí";
            }

            if (
                dgvNhanVien.Columns["dia_chi"]
                != null
            )
            {
                dgvNhanVien.Columns["dia_chi"]
                    .HeaderText = "Địa Chỉ";
            }

            if (
                dgvNhanVien.Columns["vai_tro"]
                != null
            )
            {
                dgvNhanVien.Columns["vai_tro"]
                    .HeaderText = "Vai Trò";
            }

            if (
                dgvNhanVien.Columns["trang_thai"]
                != null
            )
            {
                dgvNhanVien.Columns["trang_thai"]
                    .HeaderText = "Trạng Thái";
            }

            if (
                dgvNhanVien.Columns["ngay_vao_lam"]
                != null
            )
            {
                dgvNhanVien.Columns["ngay_vao_lam"]
                    .HeaderText = "Ngày Vào Làm";
            }

            if (
                dgvNhanVien.Columns["loai_luong"]
                != null
            )
            {
                dgvNhanVien.Columns["loai_luong"]
                    .HeaderText = "Loại Lương";
            }

            if (
                dgvNhanVien.Columns["created_at"]
                != null
            )
            {
                dgvNhanVien.Columns["created_at"]
                    .HeaderText = "Ngày Tạo";
            }

            if (
                dgvNhanVien.Columns["updated_at"]
                != null
            )
            {
                dgvNhanVien.Columns["updated_at"]
                    .HeaderText = "Ngày Cập Nhật";
            }
        }
        private NhanVien GetSelectedNhanVien()
        {
            if (
                dgvNhanVien.CurrentRow == null
            )
            {
                return null;
            }

            return dgvNhanVien
                .CurrentRow
                .DataBoundItem
                as NhanVien;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmNhanVienEdit frm =
                new FrmNhanVienEdit();

            frm.IsEdit = false;

            if (
                frm.ShowDialog()
                == DialogResult.OK
            )
            {
                await LoadData();
            }
        }

        private async void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            NhanVien nv =
                GetSelectedNhanVien();

            if (nv == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên"
                );

                return;
            }

            FrmNhanVienEdit frm =
                new FrmNhanVienEdit();

            frm.IsEdit = true;

            frm.NhanVienEdit = nv;

            if (
                frm.ShowDialog()
                == DialogResult.OK
            )
            {
                await LoadData();
            }
        }

        private async void btnXoa_Click_1(
            object sender,
            EventArgs e
        )
        {
            try
            {
                if (
                    dgvNhanVien.SelectedRows.Count
                    <= 0
                )
                {
                    MessageBox.Show(
                        "Vui lòng chọn nhân viên"
                    );

                    return;
                }

                string message =
                    "Xác nhận xóa những dòng:\n\n";

                List<NhanVien> dsXoa =
                    new List<NhanVien>();

                foreach (
                    DataGridViewRow row
                    in dgvNhanVien.SelectedRows
                )
                {
                    if (
                        row.DataBoundItem
                        is NhanVien nv
                    )
                    {
                        dsXoa.Add(nv);

                        message +=
                            "- " +
                            nv.ho_ten +
                            "\n";
                    }
                }

                DialogResult result =
                    MessageBox.Show(
                        message,
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (
                    result != DialogResult.Yes
                )
                {
                    return;
                }

                bool hasError = false;

                foreach (
                    NhanVien nv
                    in dsXoa
                )
                {
                    bool success =
                        await service.Delete(
                            nv.id
                        );

                    if (!success)
                    {
                        hasError = true;
                    }
                }

                if (hasError)
                {
                    MessageBox.Show(
                        "Có dữ liệu xóa thất bại"
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Xóa thành công"
                    );
                }

                await LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private async void btnSearch_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                string keyword =
                    txtSearch.Text.Trim();

                if (
                    string.IsNullOrWhiteSpace(
                        keyword
                    )
                )
                {
                    await LoadData();
                    return;
                }

                List<NhanVien> ds =
                    await service.Search(
                        keyword
                    );

                dgvNhanVien.DataSource = null;
                dgvNhanVien.DataSource = ds;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private async void dgvNhanVien_CellDoubleClick_1(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            await Task.Run(() =>
            {
                Invoke(
                    new Action(() =>
                    {
                        btnSua.PerformClick();
                    })
                );
            });
        }

        private void panel1_Resize(
            object sender,
            EventArgs e
        )
        {

        }

        private void dgvNhanVien_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }

        private void dgvNhanVien_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }

        private void dgvNhanVien_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {

        }

        private void dgvNhanVien_ColumnHeaderMouseClick(
            object sender,
            DataGridViewCellMouseEventArgs e
        )
        {
            try
            {
                string columnName =
                    dgvNhanVien.Columns[e.ColumnIndex]
                    .DataPropertyName;

                if (
                    dgvNhanVien.DataSource
                    is List<NhanVien> ds
                )
                {
                    if (sortAscending)
                    {
                        ds = ds
                            .OrderBy(
                                x => x.GetType()
                                .GetProperty(columnName)
                                ?.GetValue(x, null)
                            )
                            .ToList();
                    }
                    else
                    {
                        ds = ds
                            .OrderByDescending(
                                x => x.GetType()
                                .GetProperty(columnName)
                                ?.GetValue(x, null)
                            )
                            .ToList();
                    }

                    sortAscending =
                        !sortAscending;

                    dgvNhanVien.DataSource = null;

                    dgvNhanVien.DataSource = ds;
                    FormatGrid();
                }
            }
            catch
            {

            }
        }

        private async void txtSearch_TextChanged(
            object sender,
            EventArgs e
        )
        {
            try
            {
                string keyword =
                    txtSearch.Text.Trim();

                List<NhanVien> ds;

                if (
                    string.IsNullOrWhiteSpace(
                        keyword
                    )
                )
                {
                    ds =
                        await service.GetAll();
                }
                else
                {
                    ds =
                        await service.Search(
                            keyword
                        );
                }

                dgvNhanVien.DataSource =
                    ds;

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }
    }
}