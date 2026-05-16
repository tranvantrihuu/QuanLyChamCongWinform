
namespace QuanLyChamCong.GUI
{
    partial class FrmThuongPhatEdit
    {
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.ComboBox cbNhanVien;
        public System.Windows.Forms.ComboBox cbLoai;
        public System.Windows.Forms.TextBox txtSoTien;
        public System.Windows.Forms.TextBox txtLyDo;
        public System.Windows.Forms.DateTimePicker dtNgay;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 =
                new System.Windows.Forms.Label();

            this.label2 =
                new System.Windows.Forms.Label();

            this.label3 =
                new System.Windows.Forms.Label();

            this.label4 =
                new System.Windows.Forms.Label();

            this.label5 =
                new System.Windows.Forms.Label();

            this.cbNhanVien =
                new System.Windows.Forms.ComboBox();

            this.cbLoai =
                new System.Windows.Forms.ComboBox();

            this.txtSoTien =
                new System.Windows.Forms.TextBox();

            this.txtLyDo =
                new System.Windows.Forms.TextBox();

            this.dtNgay =
                new System.Windows.Forms.DateTimePicker();

            this.btnLuu =
                new System.Windows.Forms.Button();

            this.btnDong =
                new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.label1.AutoSize = true;
            this.label1.Location =
                new System.Drawing.Point(40, 40);
            this.label1.Text =
                "Nhân viên";

            this.cbNhanVien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbNhanVien.Location =
                new System.Drawing.Point(170, 37);

            this.cbNhanVien.Size =
                new System.Drawing.Size(250, 24);

            this.label2.AutoSize = true;
            this.label2.Location =
                new System.Drawing.Point(40, 90);
            this.label2.Text =
                "Loại";

            this.cbLoai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbLoai.Location =
                new System.Drawing.Point(170, 87);

            this.cbLoai.Size =
                new System.Drawing.Size(250, 24);

            this.label3.AutoSize = true;
            this.label3.Location =
                new System.Drawing.Point(40, 140);
            this.label3.Text =
                "Số tiền";

            this.txtSoTien.Location =
                new System.Drawing.Point(170, 137);

            this.txtSoTien.Size =
                new System.Drawing.Size(250, 22);

            this.label4.AutoSize = true;
            this.label4.Location =
                new System.Drawing.Point(40, 190);
            this.label4.Text =
                "Lý do";

            this.txtLyDo.Location =
                new System.Drawing.Point(170, 187);

            this.txtLyDo.Multiline =
                true;

            this.txtLyDo.Size =
                new System.Drawing.Size(250, 90);

            this.label5.AutoSize = true;
            this.label5.Location =
                new System.Drawing.Point(40, 310);
            this.label5.Text =
                "Ngày";

            this.dtNgay.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;

            this.dtNgay.Location =
                new System.Drawing.Point(170, 307);

            this.dtNgay.Size =
                new System.Drawing.Size(250, 22);

            this.btnLuu.Location =
                new System.Drawing.Point(170, 360);

            this.btnLuu.Size =
                new System.Drawing.Size(100, 35);

            this.btnLuu.Text =
                "Lưu";

            this.btnLuu.Click +=
                new System.EventHandler(
                    this.btnLuu_Click
                );


            this.btnDong.Location =
                new System.Drawing.Point(320, 360);

            this.btnDong.Size =
                new System.Drawing.Size(100, 35);

            this.btnDong.Text =
                "Đóng";

            this.btnDong.Click +=
                new System.EventHandler(
                    this.btnDong_Click
                );


            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(500, 450);

            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbNhanVien);

            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLoai);

            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoTien);

            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLyDo);

            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtNgay);

            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);

            this.Name =
                "FrmThuongPhatEdit";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Thưởng Phạt";

            this.Load +=
                new System.EventHandler(
                    this.FrmThuongPhatEdit_Load
                );

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}