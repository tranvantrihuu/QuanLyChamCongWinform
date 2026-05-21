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
        PhanCaService service =
            new PhanCaService();

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

        private async Task LoadCaMap()
        {
            dsCa =
                await caService.GetAll();
            caMap.Clear();

            foreach (var ca in dsCa)
            {
                if (!caMap.ContainsKey(ca.ten_ca))
                {
                    caMap.Add(
                        ca.ten_ca,
                        ca.id
                    );
                }
            }
            
        }

        private async Task LoadWeek()
        {
            DateTime selected =
                dtpNgay.Value.Date;

            int diff =
                (7 + (
                    selected.DayOfWeek -
                    DayOfWeek.Monday
                )) % 7;

            monday =
                selected.AddDays(-diff);

            dgvPhanCa.Columns.Clear();
            dgvPhanCa.Rows.Clear();

            dgvPhanCa.Columns.Add(
                "ca",
                "CA"
            );

            for (int i = 0; i < 7; i++)
            {
                DateTime d =
                    monday.AddDays(i);

                dgvPhanCa.Columns.Add(
                    d.ToString("yyyyMMdd"),
                    d.ToString("dd-MM")
                );
            }

            dgvPhanCa.AllowUserToAddRows =
                false;

            dgvPhanCa.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            await LoadData();
        }

        private async Task LoadData()
        {
            dgvPhanCa.Rows.Clear();

            dsPhanCa =
                await service.GetAll();

            if (dsPhanCa == null)
            {
                dsPhanCa =
                    new List<PhanCa>();
            }

            foreach (var ca in dsCa)
            {
                DateTime sunday =
                monday.AddDays(6);

                int maxNhanVien =
                    dsPhanCa
                    .Where(x =>
                        x.ca_lam_id == ca.id
                        &&
                        x.ngay_lam.Date >= monday.Date
                        &&
                        x.ngay_lam.Date <= sunday.Date
                    )
                    .GroupBy(x =>
                        x.ngay_lam.Date
                    )
                    .Select(g => g.Count())
                    .DefaultIfEmpty(1)
                    .Max();
                

                if (maxNhanVien <= 0)
                {
                    maxNhanVien = 1;
                }

                List<int> rowIndexes =
                    new List<int>();

                // tạo row trước
                for (int i = 0; i < maxNhanVien; i++)
                {
                    int row =
                        dgvPhanCa.Rows.Add();

                    rowIndexes.Add(row);

                    if (i == 0)
                    {
                        dgvPhanCa.Rows[row]
                            .Cells[0]
                            .Value =
                            ca.ten_ca;
                    }
                }

                // fill dữ liệu
                for (int d = 0; d < 7; d++)
                {
                    DateTime date =
                        monday.AddDays(d);

                    var listNhanVien =
                        dsPhanCa
                        .Where(x =>
                            x.ca_lam_id == ca.id
                            &&
                            x.ngay_lam.Date ==
                            date.Date
                        )
                        .OrderBy(x =>
                            x.nhan_vien_id
                        )
                        .ToList();

                    for (
                        int i = 0;
                        i < listNhanVien.Count;
                        i++
                    )
                    {
                        var pc =
                            listNhanVien[i];

                        var nv =
                            dsNhanVien
                            .FirstOrDefault(
                                x =>
                                x.id ==
                                pc.nhan_vien_id
                            );

                        if (nv != null)
                        {
                            int row =
                                rowIndexes[i];

                            dgvPhanCa.Rows[row]
                                .Cells[d + 1]
                                .Value =
                                nv.ho_ten;

                            dgvPhanCa.Rows[row]
                                .Cells[d + 1]
                                .Tag =
                                nv.id;
                        }
                    }
                }
            }
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
                    "Chọn nhân viên!"
                );

                return;
            }

            if (dgvPhanCa.SelectedCells.Count == 0)
            {
                MessageBox.Show(
                    "Chọn ô!"
                );

                return;
            }

            string nvId =
                cbNhanVien.SelectedValue
                .ToString();

            bool coTrungCa = false;
            bool themThanhCong = false;

            foreach (
                DataGridViewCell cell
                in dgvPhanCa.SelectedCells
            )
            {
                if (
                    cell.RowIndex < 0
                    ||
                    cell.ColumnIndex <= 0
                )
                {
                    continue;
                }

                int row = cell.RowIndex;
                int col = cell.ColumnIndex;

                DateTime date =
                    DateTime.ParseExact(
                        dgvPhanCa
                            .Columns[col]
                            .Name,
                        "yyyyMMdd",
                        null
                    );

                int caId =
                    GetCaIdFromRow(row);

                if (caId == -1)
                {
                    continue;
                }

                bool exists =
                    dsPhanCa.Any(x =>
                        x.nhan_vien_id ==
                        nvId
                        &&
                        x.ca_lam_id ==
                        caId
                        &&
                        x.ngay_lam.Date ==
                        date.Date
                    );

                if (exists)
                {
                    coTrungCa = true;
                    continue;
                }

                PhanCa pc =
                    new PhanCa()
                    {
                        nhan_vien_id =
                            nvId,

                        ca_lam_id =
                            caId,

                        ngay_lam =
                            date
                    };

                bool result =
                    await service.Add(pc);

                if (result)
                {
                    themThanhCong = true;
                }
            }

            if (themThanhCong)
            {
                MessageBox.Show(
                    "Phân ca thành công!"
                );
            }

            if (coTrungCa)
            {
                MessageBox.Show(
                    "Nhân viên đã được phân ca ở ô đã chọn!"
                );
            }

            await LoadWeek();
        }

        private async void btnXoa_Click(
    object sender,
    EventArgs e)
        {
            // chưa chọn ô
            if (dgvPhanCa.SelectedCells.Count == 0)
            {
                MessageBox.Show(
                    "Chọn ô cần xóa!"
                );

                return;
            }

            // xác nhận
            DialogResult result =
                MessageBox.Show(
                    "Xóa các ô đã chọn?",
                    "Xác nhận",
                    MessageBoxButtons.OKCancel
                );

            // CHỈ xóa khi bấm OK
            if (result != DialogResult.OK)
            {
                return;
            }

            // bắt đầu xóa
            foreach (
                DataGridViewCell cell
                in dgvPhanCa.SelectedCells
            )
            {
                // bỏ qua header
                if (
                    cell.RowIndex < 0
                    ||
                    cell.ColumnIndex <= 0
                )
                {
                    continue;
                }

                int row =
                    cell.RowIndex;

                int col =
                    cell.ColumnIndex;

                // lấy nhân viên từ Tag
                var tag =
                    dgvPhanCa
                    .Rows[row]
                    .Cells[col]
                    .Tag;

                if (tag == null)
                {
                    continue;
                }

                string nvId =
                    tag.ToString();

                // lấy ngày
                DateTime ngay =
                    DateTime.ParseExact(
                        dgvPhanCa
                            .Columns[col]
                            .Name,
                        "yyyyMMdd",
                        null
                    );

                // lấy ca
                int caId =
                    GetCaIdFromRow(row);

                if (caId == -1)
                {
                    continue;
                }

                // tìm phân ca
                PhanCa pc =
                    dsPhanCa
                    .FirstOrDefault(x =>
                        x.nhan_vien_id ==
                        nvId
                        &&
                        x.ca_lam_id ==
                        caId
                        &&
                        x.ngay_lam.Date ==
                        ngay.Date
                    );

                // xóa
                if (pc != null)
                {
                    bool success =
                        await service.Delete(
                            pc.id
                        );

                    if (!success)
                    {
                        MessageBox.Show(
                            "Xóa thất bại!"
                        );

                        return;
                    }
                }
            }

            MessageBox.Show(
                "Xóa thành công!"
            );

            await LoadWeek();
        }

        private int GetCaIdFromRow(
            int row)
        {
            for (int i = row; i >= 0; i--)
            {
                var val =
                    dgvPhanCa
                    .Rows[i]
                    .Cells[0]
                    .Value;

                if (
                    val != null
                    &&
                    val.ToString() != ""
                )
                {
                    string tenCa =
                        val.ToString();

                    if (
                        caMap.ContainsKey(
                            tenCa
                        )
                    )
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
                dgvPhanCa
            );
        }
    }
}