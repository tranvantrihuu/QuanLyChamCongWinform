using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcThuongPhat : BaseUserControl
    {
        ThuongPhatService service =
            new ThuongPhatService();

        public UcThuongPhat()
        {
            InitializeComponent();
        }

        private async void UcThuongPhat_Load(
            object sender,
            EventArgs e
        )
        {
            await LoadData();
        }

        async Task LoadData()
        {
            List<ThuongPhat> ds =
                await service.GetAll();

            dgvThuongPhat.DataSource =
                ds;

            if (!dgvThuongPhat.Columns.Contains("colCheck"))
            {
                DataGridViewCheckBoxColumn chk =
                    new DataGridViewCheckBoxColumn();

                chk.Name = "colCheck";
                chk.HeaderText = "Chọn";
                chk.Width = 50;

                dgvThuongPhat.Columns.Insert(0, chk);
            }

            dgvThuongPhat.Columns["id"].HeaderText =
                "ID";

            dgvThuongPhat.Columns["ho_ten"].HeaderText =
                "NHÂN VIÊN";

            dgvThuongPhat.Columns["loai"].HeaderText =
                "LOẠI";

            dgvThuongPhat.Columns["so_tien"].HeaderText =
                "SỐ TIỀN";

            dgvThuongPhat.Columns["so_tien"]
                .DefaultCellStyle.Format = "N0";

            dgvThuongPhat.Columns["so_tien"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvThuongPhat.Columns["ly_do"].HeaderText =
                "LÝ DO";

            dgvThuongPhat.Columns["ngay"].HeaderText =
                "NGÀY";

            dgvThuongPhat.Columns["nhan_vien_id"].Visible =
                false;

            dgvThuongPhat.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvThuongPhat.AllowUserToAddRows =
                false;

            dgvThuongPhat.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvThuongPhat.RowHeadersVisible =
                false;

            foreach (DataGridViewColumn col in dgvThuongPhat.Columns)
            {
                col.ReadOnly = true;
            }

            dgvThuongPhat.Columns["colCheck"].ReadOnly =
                false;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmThuongPhatEdit f =
                new FrmThuongPhatEdit();

            f.ShowDialog();

            await LoadData();
        }

        private async void btnSua_Click(
            object sender,
            EventArgs e
        )
        {
            if (dgvThuongPhat.CurrentRow == null)
            {
                MessageBox.Show(
                    "Chọn dòng muốn sửa"
                );

                return;
            }

            DataGridViewRow row = dgvThuongPhat.CurrentRow;

            FrmThuongPhatEdit f = new FrmThuongPhatEdit();

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.nhanVienId =
                row.Cells["nhan_vien_id"]
                .Value.ToString();

            f.loai =
                row.Cells["loai"]
                .Value.ToString();

            f.soTien =
                Convert.ToDecimal(
                    row.Cells["so_tien"].Value
                );

            f.lyDo =
                row.Cells["ly_do"]
                .Value.ToString();

            f.ngay =
                Convert.ToDateTime(
                    row.Cells["ngay"].Value
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

            foreach (DataGridViewRow row in dgvThuongPhat.Rows)
            {
                bool isChecked =
                    row.Cells["colCheck"].Value != null
                    && Convert.ToBoolean(
                        row.Cells["colCheck"].Value
                    );

                if (isChecked)
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

            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            foreach (int id in ids)
            {
                await service.Delete(id);
            }

            MessageBox.Show(
                "Xóa thành công!"
            );

            await LoadData();
        }

        private void dgvThuongPhat_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e
        )
        {
            if (dgvThuongPhat.IsCurrentCellDirty)
            {
                dgvThuongPhat.CommitEdit(
                    DataGridViewDataErrorContexts.Commit
                );
            }
        }

        private async void dgvThuongPhat_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvThuongPhat.Rows[e.RowIndex];

            FrmThuongPhatEdit f =
                new FrmThuongPhatEdit();

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.nhanVienId =
                row.Cells["nhan_vien_id"]
                .Value.ToString();

            f.loai =
                row.Cells["loai"]
                .Value.ToString();

            f.soTien =
                Convert.ToDecimal(
                    row.Cells["so_tien"].Value
                );

            f.lyDo =
                row.Cells["ly_do"]
                .Value.ToString();

            f.ngay =
                Convert.ToDateTime(
                    row.Cells["ngay"].Value
                );

            f.ShowDialog();

            await LoadData();
        }
    }
}