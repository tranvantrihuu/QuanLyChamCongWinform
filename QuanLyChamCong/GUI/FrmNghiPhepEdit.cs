// FrmNghiPhepEdit.cs

using BLL;
using QuanLyChamCong.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmNghiPhepEdit : Form
    {
        NghiPhepBLL bll = new NghiPhepBLL();

        public int id = 0;

        public FrmNghiPhepEdit()
        {
            InitializeComponent();
        }

        public FrmNghiPhepEdit(int id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void FrmNghiPhepEdit_Load(
            object sender,
            EventArgs e
        )
        {
            LoadNhanVien();

            LoadCaLam();

            cbLoai.Items.Clear();

            cbLoai.Items.Add("Có phép");
            cbLoai.Items.Add("Không phép");

            cbLoai.SelectedIndex = 0;

            if (id > 0)
            {
                LoadDetail();
            }
        }

        void LoadNhanVien()
        {
            string sql = @"
                SELECT 
                    id,
                    ho_ten
                FROM nhan_vien
                ORDER BY ho_ten";

            DataProvider dp =
                new DataProvider();

            DataTable dt =
                dp.ExecuteQuery(sql);

            cbNhanVien.DataSource = dt;

            cbNhanVien.DisplayMember =
                "ho_ten";

            cbNhanVien.ValueMember =
                "id";
        }

        void LoadCaLam()
        {
            string sql = @"
                SELECT 
                    id
                FROM ca_lam
                ORDER BY id";

            DataProvider dp =
                new DataProvider();

            DataTable dt =
                dp.ExecuteQuery(sql);

            cbCaLam.DataSource = dt;

            cbCaLam.DisplayMember =
                "id";

            cbCaLam.ValueMember =
                "id";
        }

        void LoadDetail()
        {
            DataTable dt =
                bll.GetById(id);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];

                cbNhanVien.SelectedValue =
                    r["nhan_vien_id"]
                    .ToString();

                cbCaLam.SelectedValue =
                    r["ca_lam_id"];

                dtNgay.Value =
                    Convert.ToDateTime(
                        r["ngay"]
                    );

                string loai =
                    r["loai"]
                    .ToString();

                if (loai == "co_phep")
                {
                    cbLoai.Text =
                        "Có phép";
                }
                else
                {
                    cbLoai.Text =
                        "Không phép";
                }

                txtLyDo.Text =
                    r["ly_do"]
                    .ToString();
            }
        }

        private void btnLuu_Click(
            object sender,
            EventArgs e
        )
        {
            string nhanVienId =
                cbNhanVien.SelectedValue
                .ToString();

            int caLamId =
                Convert.ToInt32(
                    cbCaLam.SelectedValue
                );

            DateTime ngay =
                dtNgay.Value;

            string loai =
                cbLoai.Text == "Có phép"
                ? "co_phep"
                : "khong_phep";

            string lyDo =
                txtLyDo.Text;

            if (id == 0)
            {
                bll.Insert(
                    nhanVienId,
                    caLamId,
                    ngay,
                    loai,
                    lyDo
                );
            }
            else
            {
                bll.Update(
                    id,
                    nhanVienId,
                    caLamId,
                    ngay,
                    loai,
                    lyDo
                );
            }

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnDong_Click(
            object sender,
            EventArgs e
        )
        {
            Close();
        }
    }
}