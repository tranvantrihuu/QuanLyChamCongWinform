using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
namespace QuanLyChamCong.GUI
{
    public partial class UcPhanCa : BaseUserControl
    {
        PhanCaService service = new PhanCaService();

        NhanVienService nvService =
            new NhanVienService();

        CaLamService caService =
            new CaLamService();

        DateTime monday;

        Dictionary<string, int> caMap =
            new Dictionary<string, int>();

        List<PhanCa> dsPhanCa =
            new List<PhanCa>();

        List<CaLam> dsCa =
            new List<CaLam>();

        List<NhanVien> dsNhanVien =
            new List<NhanVien>();

        public UcPhanCa()
        {
            InitializeComponent();
        }

        private async void UcPhanCa_Load(
            object sender,
            EventArgs e)
        {
            dtpNgay.Value = DateTime.Now;

            await LoadNhanVien();

            await LoadCaMap();

            await LoadWeek();

            dtpNgay.ValueChanged +=
                dtpNgay_ValueChanged;

            dgvPhanCa.MultiSelect = true;

            dgvPhanCa.SelectionMode =
                DataGridViewSelectionMode.CellSelect;
        }

        private async Task LoadCaMap()
        {
            dsCa = await caService.GetAll();

            caMap.Clear();

            foreach (var ca in dsCa)
            {
                caMap[ca.ten_ca] = ca.id;
            }
        }

        private async Task LoadWeek()
        {
            DateTime selected =
                dtpNgay.Value.Date;

            int diff =
                (7 + (selected.DayOfWeek -
                DayOfWeek.Monday)) % 7;

            monday =
                selected.AddDays(-diff);

            dgvPhanCa.Columns.Clear();
            dgvPhanCa.Rows.Clear();

            dgvPhanCa.Columns.Add("ca", "CA");

            for (int i = 0; i < 7; i++)
            {
                DateTime d =
                    monday.AddDays(i);

                dgvPhanCa.Columns.Add(
                    d.ToString("yyyyMMdd"),
                    d.ToString("dd/MM")
                );
            }

            dgvPhanCa.AllowUserToAddRows = false;

            dgvPhanCa.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            await LoadData();
        }

        private async Task LoadData()
        {
            dsPhanCa =
                await service.GetAll();

            foreach (var ca in dsCa)
            {
                int maxRow =
                    GetMaxNhanVienTrongTuan(ca.id);

                for (int i = 0; i < maxRow; i++)
                {
                    int rowIndex =
                        dgvPhanCa.Rows.Add();

                    if (i == 0)
                    {
                        dgvPhanCa.Rows[rowIndex]
                            .Cells[0]
                            .Value = ca.ten_ca;
                    }
                    else
                    {
                        dgvPhanCa.Rows[rowIndex]
                            .Cells[0]
                            .Value = "";
                    }

                    for (int d = 0; d < 7; d++)
                    {
                        DateTime date =
                            monday.AddDays(d);

                        var rows =
                            dsPhanCa
                            .Where(r =>
                                r.ca_lam_id == ca.id
                                &&
                                r.ngay_lam.Date ==
                                date.Date)
                            .ToList();

                        if (i < rows.Count)
                        {
                            var pc = rows[i];

                            var nv =
                                dsNhanVien
                                .FirstOrDefault(
                                    x =>
                                    x.id.ToString()
                                    ==
                                    pc.nhan_vien_id
                                );

                            if (nv != null)
                            {
                                dgvPhanCa
                                    .Rows[rowIndex]
                                    .Cells[d + 1]
                                    .Value = nv.ho_ten;

                                dgvPhanCa
                                    .Rows[rowIndex]
                                    .Cells[d + 1]
                                    .Tag = nv.id;
                            }
                        }
                    }
                }
            }
        }

        private int GetMaxNhanVienTrongTuan(
            int caId)
        {
            int max = 0;

            for (int i = 0; i < 7; i++)
            {
                DateTime date =
                    monday.AddDays(i);

                int count =
                    dsPhanCa.Count(r =>
                        r.ca_lam_id == caId
                        &&
                        r.ngay_lam.Date ==
                        date.Date);

                if (count > max)
                    max = count;
            }

            return max == 0 ? 1 : max;
        }

        private async Task LoadNhanVien()
        {
            dsNhanVien =
                await nvService.GetAll();

            cbNhanVien.DataSource =
                dsNhanVien;

            cbNhanVien.DisplayMember =
                "ho_ten";

            cbNhanVien.ValueMember =
                "id";
        }

        private async void dtpNgay_ValueChanged(
            object sender,
            EventArgs e)
        {
            await LoadWeek();
        }
        private async void btnThem_Click(
            object sender,
            EventArgs e)
        {
            if (cbNhanVien.SelectedValue == null)
            {
                MessageBox.Show(
                    "Chọn nhân viên!");

                return;
            }

            if (dgvPhanCa.SelectedCells.Count == 0)
            {
                MessageBox.Show(
                    "Chọn ô!");

                return;
            }

            string nvId =
                cbNhanVien.SelectedValue
                .ToString();

            foreach (DataGridViewCell cell
                in dgvPhanCa.SelectedCells)
            {
                if (cell.RowIndex < 0
                    ||
                    cell.ColumnIndex <= 0)
                    continue;

                int row = cell.RowIndex;

                int col = cell.ColumnIndex;

                DateTime date =
                    DateTime.ParseExact(
                        dgvPhanCa.Columns[col].Name,
                        "yyyyMMdd",
                        null
                    );

                int caId =
                    GetCaIdFromRow(row);

                if (caId == -1)
                    continue;

                bool exists =
                    dsPhanCa.Any(x =>
                        x.nhan_vien_id == nvId
                        &&
                        x.ca_lam_id == caId
                        &&
                        x.ngay_lam.Date ==
                        date.Date);

                if (!exists)
                {
                    PhanCa pc =
                        new PhanCa()
                        {
                            nhan_vien_id = nvId,
                            ca_lam_id = caId,
                            ngay_lam = date
                        };

                    await service.Add(pc);
                }
            }

            await LoadWeek();
        }

        private async void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPhanCa.SelectedCells.Count == 0)
            {
                MessageBox.Show("Chọn ô!");

                return;
            }

            if (MessageBox.Show(
                "Xóa các ô đã chọn?",
                "Xác nhận",
                MessageBoxButtons.YesNo)
                == DialogResult.No)
                return;

            foreach (DataGridViewCell cell
                in dgvPhanCa.SelectedCells)
            {
                if (cell.RowIndex < 0
                    ||
                    cell.ColumnIndex <= 0)
                    continue;

                int row = cell.RowIndex;

                int col = cell.ColumnIndex;

                var tag =
                    dgvPhanCa.Rows[row]
                    .Cells[col]
                    .Tag;

                if (tag == null)
                    continue;

                string nvId =
                    tag.ToString();

                DateTime date =
                    DateTime.ParseExact(
                        dgvPhanCa.Columns[col].Name,
                        "yyyyMMdd",
                        null
                    );

                int caId =
                    GetCaIdFromRow(row);

                var pc =
                    dsPhanCa.FirstOrDefault(x =>
                        x.nhan_vien_id == nvId
                        &&
                        x.ca_lam_id == caId
                        &&
                        x.ngay_lam.Date ==
                        date.Date);

                if (pc != null)
                {
                    await service.Delete(pc.id);
                }
            }

            await LoadWeek();
        }

        private int GetCaIdFromRow(int row)
        {
            for (int i = row; i >= 0; i--)
            {
                var val =
                    dgvPhanCa.Rows[i]
                    .Cells[0]
                    .Value;

                if (val != null
                    &&
                    val.ToString() != "")
                {
                    string tenCa =
                        val.ToString();

                    if (caMap.ContainsKey(tenCa))
                    {
                        return caMap[tenCa];
                    }
                }
            }

            return -1;
        }

        protected override void OnLoad(
            EventArgs e)
        {
            base.OnLoad(e);

            AppStyles.StyleScheduleGrid(
                dgvPhanCa);
        }
    }
}