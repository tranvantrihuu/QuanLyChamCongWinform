using QuanLyChamCong.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class UcPhanCa : UserControl
    {
        PhanCaBLL bll = new PhanCaBLL();
        NhanVienBLL nvBll = new NhanVienBLL();
        CaLamBLL caBll = new CaLamBLL();

        DateTime monday;


        // cache ca
        Dictionary<string, int> caMap = new Dictionary<string, int>();

        public UcPhanCa()
        {
            InitializeComponent();
        }

        private void UcPhanCa_Load(object sender, EventArgs e)
        {
            dtpNgay.Value = DateTime.Now;

            LoadNhanVien();
            LoadCaMap();
            LoadWeek();

            dtpNgay.ValueChanged += dtpNgay_ValueChanged;

            dgvPhanCa.MultiSelect = true;
            dgvPhanCa.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        // ================= LOAD CA MAP =================
        private void LoadCaMap()
        {
            var dt = caBll.GetAll();
            caMap.Clear();

            foreach (DataRow r in dt.Rows)
            {
                caMap[r["ten_ca"].ToString()] = Convert.ToInt32(r["id"]);
            }
        }

        // ================= LOAD WEEK =================
        private void LoadWeek()
        {
            DateTime selected = dtpNgay.Value.Date;

            int diff = (7 + (selected.DayOfWeek - DayOfWeek.Monday)) % 7;
            monday = selected.AddDays(-diff);

            dgvPhanCa.Columns.Clear();
            dgvPhanCa.Rows.Clear();

            dgvPhanCa.Columns.Add("ca", "CA");

            for (int i = 0; i < 7; i++)
            {
                DateTime d = monday.AddDays(i);
                dgvPhanCa.Columns.Add(
                    d.ToString("yyyyMMdd"),
                    d.ToString("dd/MM")
                );
            }

            dgvPhanCa.AllowUserToAddRows = false;
            dgvPhanCa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();

        }

        // ================= LOAD DATA =================
        private void LoadData()
        {
            DateTime sunday = monday.AddDays(6);

            DataTable dt = bll.GetByWeek(monday, sunday);
            DataTable dtCa = caBll.GetAll();

            foreach (DataRow ca in dtCa.Rows)
            {
                int caId = Convert.ToInt32(ca["id"]);

                int maxRow = GetMaxNhanVienTrongTuan(dt, caId);

                for (int i = 0; i < maxRow; i++)
                {
                    int rowIndex = dgvPhanCa.Rows.Add();

                    if (i == 0)
                        dgvPhanCa.Rows[rowIndex].Cells[0].Value = ca["ten_ca"].ToString();
                    else
                        dgvPhanCa.Rows[rowIndex].Cells[0].Value = "";

                    for (int d = 0; d < 7; d++)
                    {
                        DateTime date = monday.AddDays(d);

                        var rows = dt.AsEnumerable()
                            .Where(r =>
                                Convert.ToInt32(r["ca_lam_id"]) == caId &&
                                Convert.ToDateTime(r["ngay_lam"]).Date == date.Date
                            ).ToArray();

                        if (i < rows.Length)
                        {
                            dgvPhanCa.Rows[rowIndex].Cells[d + 1].Value =
                                rows[i]["ho_ten"].ToString();

                            // lưu id để xóa nhanh
                            dgvPhanCa.Rows[rowIndex].Cells[d + 1].Tag =
                                rows[i]["nhan_vien_id"];
                        }
                    }
                }
            }
        }

        // ================= MAX ROW =================
        private int GetMaxNhanVienTrongTuan(DataTable dt, int caId)
        {
            int max = 0;

            for (int i = 0; i < 7; i++)
            {
                DateTime date = monday.AddDays(i);

                var rows = dt.AsEnumerable()
                    .Where(r =>
                        Convert.ToInt32(r["ca_lam_id"]) == caId &&
                        Convert.ToDateTime(r["ngay_lam"]).Date == date.Date
                    ).ToArray();

                if (rows.Length > max)
                    max = rows.Length;
            }

            return max == 0 ? 1 : max;
        }

        // ================= LOAD NHÂN VIÊN =================
        private void LoadNhanVien()
        {
            var dt = nvBll.GetAll();

            cbNhanVien.DataSource = dt;
            cbNhanVien.DisplayMember = "ho_ten";
            cbNhanVien.ValueMember = "id";
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadWeek();
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Chọn nhân viên!");
                return;
            }

            if (dgvPhanCa.SelectedCells.Count == 0)
            {
                MessageBox.Show("Chọn ô!");
                return;
            }

            string nvId = cbNhanVien.SelectedValue.ToString();

            foreach (DataGridViewCell cell in dgvPhanCa.SelectedCells)
            {
                if (cell.RowIndex < 0 || cell.ColumnIndex <= 0) continue;

                int row = cell.RowIndex;
                int col = cell.ColumnIndex;

                DateTime date = DateTime.ParseExact(
                    dgvPhanCa.Columns[col].Name,
                    "yyyyMMdd",
                    null
                );

                int caId = GetCaIdFromRow(row);
                if (caId == -1) continue;

                if (!bll.Exists(nvId, caId, date))
                {
                    bll.Insert(nvId, caId, date);
                }
            }

            LoadWeek();
        }

        // ================= XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhanCa.SelectedCells.Count == 0)
            {
                MessageBox.Show("Chọn ô!");
                return;
            }

            if (MessageBox.Show("Xóa các ô đã chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            foreach (DataGridViewCell cell in dgvPhanCa.SelectedCells)
            {
                if (cell.RowIndex < 0 || cell.ColumnIndex <= 0) continue;

                int row = cell.RowIndex;
                int col = cell.ColumnIndex;

                var val = dgvPhanCa.Rows[row].Cells[col].Value;
                if (val == null) continue;

                DateTime date = DateTime.ParseExact(
                    dgvPhanCa.Columns[col].Name,
                    "yyyyMMdd",
                    null
                );

                int caId = GetCaIdFromRow(row);
                if (caId == -1) continue;

                var tag = dgvPhanCa.Rows[row].Cells[col].Tag;
                if (tag == null) continue;

                string nvId = tag.ToString();

                bll.Delete(nvId, caId, date);
            }

            LoadWeek();
        }

        // ================= MAP CA =================
        private int GetCaIdFromRow(int row)
        {
            for (int i = row; i >= 0; i--)
            {
                var val = dgvPhanCa.Rows[i].Cells[0].Value;

                if (val != null && val.ToString() != "")
                {
                    string tenCa = val.ToString();

                    if (caMap.ContainsKey(tenCa))
                        return caMap[tenCa];
                }
            }

            return -1;
        }

    }
}