// FrmNghiPhepNamEdit.cs

using QuanLyChamCong.BLL;
using QuanLyChamCong.DTO;
using QuanLyChamCong.THEME;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    public partial class FrmNghiPhepNamEdit : BaseForm
    {
        NghiPhepNamBLL bll = new NghiPhepNamBLL();

        public bool isEdit = false;
        public int id = 0;

        public FrmNghiPhepNamEdit(bool edit = false)
        {
            InitializeComponent();

            isEdit = edit;
        }

        private void FrmNghiPhepNamEdit_Load(object sender, EventArgs e)
        {
            LoadNhanVien();

            if (isEdit)
            {
                cbNhanVien.Enabled = true;
            }
        }

        void LoadNhanVien()
        {
            DataTable dt = bll.GetNhanVien();

            cbNhanVien.DataSource = dt;
            cbNhanVien.DisplayMember = "ho_ten";
            cbNhanVien.ValueMember = "id";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var param = new Dictionary<string, object>
            {
                { "@id", id },
                { "@nhanVienId", cbNhanVien.SelectedValue },
                { "@nam", numNam.Value },
                { "@duocNghi", numDuocNghi.Value },
                { "@coPhep", numCoPhep.Value },
                { "@khongPhep", numKhongPhep.Value }
            };

            if (isEdit)
            {
                bll.Update(param);

                MessageBox.Show("Sửa thành công");
            }
            else
            {
                bll.Insert(param);

                MessageBox.Show("Thêm thành công");
            }

            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}