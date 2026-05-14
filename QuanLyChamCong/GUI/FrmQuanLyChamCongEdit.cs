// FrmQuanLyChamCongEdit.cs

using BLL;
using DAL;
using QuanLyChamCong.DAL;
using QuanLyChamCong.THEME;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmQuanLyChamCongEdit : BaseForm
    {
        QuanLyChamCongBLL bll =
            new QuanLyChamCongBLL();

        DataProvider dp =
            new DataProvider();

        int id = 0;

        public FrmQuanLyChamCongEdit()
        {
            InitializeComponent();
        }

        public FrmQuanLyChamCongEdit(int _id)
        {
            InitializeComponent();

            id = _id;
        }

        private void FrmQuanLyChamCongEdit_Load(
            object sender,
            EventArgs e
        )
        {
            LoadNhanVien();
            LoadCaLam();

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

            DataTable dt =
                dp.ExecuteQuery(sql);

            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "ho_ten";
            cboNhanVien.ValueMember = "id";
        }

        void LoadCaLam()
        {
            string sql = @"
                SELECT
                    id,
                    ten_ca
                FROM ca_lam
                ORDER BY id";

            DataTable dt =
                dp.ExecuteQuery(sql);

            cboCaLam.DataSource = dt;
            cboCaLam.DisplayMember = "ten_ca";
            cboCaLam.ValueMember = "id";
        }

        void LoadDetail()
        {
            DataTable dt =
                bll.GetById(id);

            if (dt.Rows.Count <= 0)
            {
                return;
            }

            DataRow r =
                dt.Rows[0];

            cboNhanVien.SelectedValue =
                r["nhan_vien_id"].ToString();

            dtpNgayLam.Value =
                Convert.ToDateTime(
                    r["ngay_lam"]
                );

            cboCaLam.SelectedValue =
                Convert.ToInt32(
                    r["ca_lam_id"]
                );

            // FIX NULL CHECK_IN
            if (r["check_in"] != DBNull.Value)
            {
                dtpCheckIn.Value =
                    Convert.ToDateTime(
                        r["check_in"]
                    );
            }

            // FIX NULL CHECK_OUT
            if (r["check_out"] != DBNull.Value)
            {
                dtpCheckOut.Value =
                    Convert.ToDateTime(
                        r["check_out"]
                    );
            }

        }

        private void btnLuu_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                string nhanVienId =
                    cboNhanVien.SelectedValue.ToString();

                DateTime ngayLam =
                    dtpNgayLam.Value.Date;

                int caLamId =
                    Convert.ToInt32(
                        cboCaLam.SelectedValue
                    );

                DateTime checkIn =
                    dtpCheckIn.Value;

                DateTime checkOut =
                    dtpCheckOut.Value;


                if (id == 0)
                {
                    bll.Insert(
                        nhanVienId,
                        ngayLam,
                        caLamId,
                        checkIn,
                        checkOut
                    );
                }
                else
                {
                    bll.Update(
                        id,
                        nhanVienId,
                        ngayLam,
                        caLamId,
                        checkIn,
                        checkOut
                    );
                }

                MessageBox.Show(
                    "LƯU THÀNH CÔNG"
                );

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
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