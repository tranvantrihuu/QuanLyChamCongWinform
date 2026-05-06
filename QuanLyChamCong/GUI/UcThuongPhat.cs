// UcThuongPhat.cs

using BLL;
using QuanLyChamCong.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcThuongPhat : UserControl
    {
        ThuongPhatBLL bll =
            new ThuongPhatBLL();

        public UcThuongPhat()
        {
            InitializeComponent();
        }

        private void UcThuongPhat_Load(
            object sender,
            EventArgs e
        )
        {
            LoadData();
        }

        void LoadData()
        {
            DataTable dt =
                bll.GetAll();

            dgvThuongPhat.DataSource =
                dt;

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
            dgvThuongPhat.Columns["so_tien"].DefaultCellStyle.Format =
                "N0";

            dgvThuongPhat.Columns["so_tien"].DefaultCellStyle.Alignment =
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

        private void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmThuongPhatEdit f =
                new FrmThuongPhatEdit();

            f.ShowDialog();

            LoadData();
        }

        private void btnSua_Click(
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

            DataGridViewRow row =
                dgvThuongPhat.CurrentRow;

            FrmThuongPhatEdit f =
                new FrmThuongPhatEdit();

            f.id = Convert.ToInt32(
                row.Cells["id"].Value
            );

            f.cbNhanVien.SelectedValue =
                row.Cells["nhan_vien_id"].Value;

            f.cbLoai.Text =
                row.Cells["loai"]
                .Value.ToString();

            f.txtSoTien.Text =
                row.Cells["so_tien"]
                .Value.ToString();

            f.txtLyDo.Text =
                row.Cells["ly_do"]
                .Value.ToString();

            f.dtNgay.Value =
                Convert.ToDateTime(
                    row.Cells["ngay"].Value
                );

            f.ShowDialog();

            LoadData();
        }

        private void btnXoa_Click(
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
                bll.Delete(id);
            }

            MessageBox.Show(
                "Xóa thành công!"
            );

            LoadData();
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

        private void dgvThuongPhat_CellDoubleClick(
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

            f.cbNhanVien.SelectedValue =
                row.Cells["nhan_vien_id"].Value;

            f.cbLoai.Text =
                row.Cells["loai"]
                .Value.ToString();

            f.txtSoTien.Text =
                row.Cells["so_tien"]
                .Value.ToString();

            f.txtLyDo.Text =
                row.Cells["ly_do"]
                .Value.ToString();

            f.dtNgay.Value =
                Convert.ToDateTime(
                    row.Cells["ngay"].Value
                );

            f.ShowDialog();

            LoadData();
        }
    }
}