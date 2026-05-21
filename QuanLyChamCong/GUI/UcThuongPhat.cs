using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcThuongPhat :
        BaseUserControl
    {
        private readonly ThuongPhatService _service =
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

        private async Task LoadData()
        {
            try
            {
                List<ThuongPhat> data =
                    await _service.GetAll();

                dgvThuongPhat.DataSource = null;

                dgvThuongPhat.DataSource = data;

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load dữ liệu:\n" +
                    ex.Message
                );
            }
        }

        private void FormatGrid()
        {
            dgvThuongPhat.AutoGenerateColumns =
                false;

            dgvThuongPhat.Columns.Clear();

            dgvThuongPhat.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "id",
                    HeaderText = "ID",
                    DataPropertyName = "id",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 40
                }
            );

            dgvThuongPhat.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ho_ten",
                    HeaderText = "NHÂN VIÊN",
                    DataPropertyName = "ho_ten",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 150
                }
            );

            dgvThuongPhat.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "loai",
                    HeaderText = "LOẠI",
                    DataPropertyName = "loai",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 80
                }
            );

            dgvThuongPhat.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "so_tien",
                    HeaderText = "SỐ TIỀN",
                    DataPropertyName = "so_tien",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100,
                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "N0"
                        }
                }
            );

            dgvThuongPhat.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ly_do",
                    HeaderText = "LÝ DO",
                    DataPropertyName = "ly_do",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 220
                }
            );

            dgvThuongPhat.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ngay",
                    HeaderText = "NGÀY",
                    DataPropertyName = "ngay",
                    AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 90,
                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "dd/MM/yyyy"
                        }
                }
            );

            dgvThuongPhat.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvThuongPhat.MultiSelect =
                false;

            dgvThuongPhat.ReadOnly =
                true;

            dgvThuongPhat.AllowUserToAddRows =
                false;

            dgvThuongPhat.RowHeadersVisible =
                false;
        }

        private ThuongPhat GetCurrentRow()
        {
            if (
                dgvThuongPhat.CurrentRow
                == null
            )
            {
                return null;
            }

            return dgvThuongPhat
                .CurrentRow
                .DataBoundItem
                as ThuongPhat;
        }

        private async void btnThem_Click(
            object sender,
            EventArgs e
        )
        {
            FrmThuongPhatEdit frm =
                new FrmThuongPhatEdit();

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
            ThuongPhat tp =
                GetCurrentRow();

            if (tp == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            FrmThuongPhatEdit frm =
                new FrmThuongPhatEdit();

            frm.IsEdit = true;

            frm.ThuongPhatEdit = tp;

            if (
                frm.ShowDialog()
                == DialogResult.OK
            )
            {
                await LoadData();
            }
        }

        private async void btnXoa_Click(
            object sender,
            EventArgs e
        )
        {
            ThuongPhat tp =
                GetCurrentRow();

            if (tp == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn dữ liệu"
                );

                return;
            }

            DialogResult rs =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (rs != DialogResult.Yes)
            {
                return;
            }

            bool result =
                await _service.Delete(tp.id);

            if (result)
            {
                MessageBox.Show(
                    "Xóa thành công"
                );

                await LoadData();
            }
            else
            {
                MessageBox.Show(
                    "Xóa thất bại"
                );
            }
        }

        private async void dgvThuongPhat_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            await Task.Delay(1);

            btnSua.PerformClick();
        }
    }
}