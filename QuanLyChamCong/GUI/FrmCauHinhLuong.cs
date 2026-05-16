using Newtonsoft.Json;
using MessageBox = QuanLyChamCong.THEME.CustomMessageBox;
using QuanLyChamCong.Models;
using QuanLyChamCong.Services;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmCauHinhLuongEdit : BaseForm
    {
        CauHinhLuongService service =
            new CauHinhLuongService();

        List<CauHinhLuong> dsCauHinh =
            new List<CauHinhLuong>();

        public int id = 0;

        public string nhanVienId = "";

        bool isEdit = false;

        bool isLoading = false;

        public FrmCauHinhLuongEdit(
            bool edit = false
        )
        {
            InitializeComponent();
            SetupMoney(numLuongCoBan);
            SetupMoney(numLuongTheoGio);
            SetupMoney(numTangCa);
            SetupMoney(numPhuCap);
            isEdit = edit;

            cbNhanVien.SelectedIndexChanged +=
                cbNhanVien_SelectedIndexChanged;

            numLuongCoBan.Maximum =
                decimal.MaxValue;

            numLuongTheoGio.Maximum =
                decimal.MaxValue;

            numTangCa.Maximum =
                decimal.MaxValue;

            numPhuCap.Maximum =
                decimal.MaxValue;
        }

        private async void FrmCauHinhLuongEdit_Load(
            object sender,
            EventArgs e
        )
        {
            isLoading = true;

            await LoadNhanVien();

            dsCauHinh =
                await service.GetAll();

            if (isEdit)
            {
                for (int i = 0;
                    i < cbNhanVien.Items.Count;
                    i++)
                {
                    dynamic item =
                        cbNhanVien.Items[i];

                    if (item.id.ToString()
                        == nhanVienId)
                    {
                        cbNhanVien.SelectedIndex =
                            i;

                        break;
                    }
                }

                LoadTheoNhanVien();
            }

            isLoading = false;
        }

        async Task LoadNhanVien()
        {
            try
            {
                HttpClientHandler handler =
                    new HttpClientHandler();

                handler.ServerCertificateCustomValidationCallback =
                    (a, b, c, d) => true;

                using (HttpClient client =
                    new HttpClient(handler))
                {
                    string json =
                        await client.GetStringAsync(
                            "https://localhost:7133/api/NhanVien"
                        );

                    var ds =
                        JsonConvert.DeserializeObject
                        <List<dynamic>>(json);

                    cbNhanVien.DataSource = null;

                    cbNhanVien.DisplayMember =
                        "ho_ten";

                    cbNhanVien.ValueMember =
                        "id";

                    cbNhanVien.DataSource =
                        ds;

                    if (!isEdit)
                    {
                        cbNhanVien.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }
        private void SetupMoney(
            NumericUpDown num
        )
        {
            num.ThousandsSeparator =
                true;

            num.DecimalPlaces =
                0;

            num.Maximum =
                decimal.MaxValue;

            num.Minimum =
                0;

            num.TextAlign =
                HorizontalAlignment.Right;
        }
        void LoadTheoNhanVien()
        {
            try
            {
                if (cbNhanVien.SelectedValue == null)
                    return;

                string nvId =
                    cbNhanVien.SelectedValue
                    .ToString();

                dynamic nv =
                    cbNhanVien.SelectedItem;

                string loaiLuong =
                    nv.loai_luong.ToString();

                if (loaiLuong == "Tháng")
                {
                    numLuongCoBan.Enabled = true;

                    numLuongTheoGio.Enabled = false;
                }
                else
                {
                    numLuongTheoGio.Enabled = true;

                    numLuongCoBan.Enabled = false;
                }

                var data =
                    dsCauHinh.FirstOrDefault(
                        x => x.nhan_vien_id == nvId
                    );

                if (data != null)
                {

                    id = data.id;

                    numLuongCoBan.Value =
                        data.luong_co_ban;

                    numLuongTheoGio.Value =
                        data.luong_theo_gio;

                    numTangCa.Value =
                        data.luong_tang_ca;

                    numPhuCap.Value =
                        data.phu_cap_mac_dinh;
                }
                else
                {
                    id = 0;

                    numLuongCoBan.Value = 0;

                    numLuongTheoGio.Value = 0;

                    numTangCa.Value = 0;

                    numPhuCap.Value = 0;
                }
            }
            catch
            {

            }
        }

        private void cbNhanVien_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            if (isLoading)
                return;

            LoadTheoNhanVien();
        }

        private async void btnOk_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                if (cbNhanVien.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Chọn nhân viên!"
                    );

                    return;
                }

                CauHinhLuong model =
                    new CauHinhLuong
                    {
                        id = id,

                        nhan_vien_id =
                            cbNhanVien.SelectedValue
                            .ToString(),

                        luong_co_ban =
                            numLuongCoBan.Value,

                        luong_theo_gio =
                            numLuongTheoGio.Value,

                        luong_tang_ca =
                            numTangCa.Value,

                        phu_cap_mac_dinh =
                            numPhuCap.Value
                    };

                bool result;

                if (isEdit)
                {
                    result =
                        await service.Update(
                            model
                        );
                }
                else
                {
                    result =
                        await service.Add(
                            model
                        );
                }

                if (result)
                {
                    MessageBox.Show(
                        isEdit
                        ? "Cập nhật thành công!"
                        : "Thêm thành công!"
                    );

                    DialogResult =
                        DialogResult.OK;

                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "API trả về thất bại!\n\n" +
                        "ID: " + id +
                        "\nNhân viên: " +
                        cbNhanVien.SelectedValue +
                        "\nLương cơ bản: " +
                        numLuongCoBan.Value +
                        "\nLương giờ: " +
                        numLuongTheoGio.Value
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

        private void btnCancel_Click(
            object sender,
            EventArgs e
        )
        {
            Close();
        }
    }
}