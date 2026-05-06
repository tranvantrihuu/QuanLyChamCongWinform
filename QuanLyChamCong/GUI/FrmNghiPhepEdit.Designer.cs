// FrmNghiPhepEdit.Designer.cs

namespace QuanLyChamCong.GUI
{
    partial class FrmNghiPhepEdit
    {
        private System.ComponentModel.IContainer
            components = null;

        protected override void Dispose(
            bool disposing
        )
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 =
                new System.Windows.Forms.Label();

            this.cbNhanVien =
                new System.Windows.Forms.ComboBox();

            this.label2 =
                new System.Windows.Forms.Label();

            this.cbCaLam =
                new System.Windows.Forms.ComboBox();

            this.label3 =
                new System.Windows.Forms.Label();

            this.dtNgay =
                new System.Windows.Forms.DateTimePicker();

            this.label4 =
                new System.Windows.Forms.Label();

            this.cbLoai =
                new System.Windows.Forms.ComboBox();

            this.label5 =
                new System.Windows.Forms.Label();

            this.txtLyDo =
                new System.Windows.Forms.TextBox();

            this.btnLuu =
                new System.Windows.Forms.Button();

            this.btnDong =
                new System.Windows.Forms.Button();

            this.SuspendLayout();

            // label1

            this.label1.AutoSize = true;

            this.label1.Location =
                new System.Drawing.Point(40, 40);

            this.label1.Name =
                "label1";

            this.label1.Size =
                new System.Drawing.Size(74, 16);

            this.label1.Text =
                "Nhân viên";

            // cbNhanVien

            this.cbNhanVien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbNhanVien.FormattingEnabled =
                true;

            this.cbNhanVien.Location =
                new System.Drawing.Point(170, 37);

            this.cbNhanVien.Name =
                "cbNhanVien";

            this.cbNhanVien.Size =
                new System.Drawing.Size(250, 24);

            // label2

            this.label2.AutoSize = true;

            this.label2.Location =
                new System.Drawing.Point(40, 90);

            this.label2.Name =
                "label2";

            this.label2.Size =
                new System.Drawing.Size(52, 16);

            this.label2.Text =
                "Ca làm";

            // cbCaLam

            this.cbCaLam.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbCaLam.FormattingEnabled =
                true;

            this.cbCaLam.Location =
                new System.Drawing.Point(170, 87);

            this.cbCaLam.Name =
                "cbCaLam";

            this.cbCaLam.Size =
                new System.Drawing.Size(250, 24);

            // label3

            this.label3.AutoSize = true;

            this.label3.Location =
                new System.Drawing.Point(40, 140);

            this.label3.Name =
                "label3";

            this.label3.Size =
                new System.Drawing.Size(41, 16);

            this.label3.Text =
                "Ngày";

            // dtNgay

            this.dtNgay.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;

            this.dtNgay.Location =
                new System.Drawing.Point(170, 137);

            this.dtNgay.Name =
                "dtNgay";

            this.dtNgay.Size =
                new System.Drawing.Size(250, 22);

            // label4

            this.label4.AutoSize = true;

            this.label4.Location =
                new System.Drawing.Point(40, 190);

            this.label4.Name =
                "label4";

            this.label4.Size =
                new System.Drawing.Size(67, 16);

            this.label4.Text =
                "Loại nghỉ";

            // cbLoai

            this.cbLoai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbLoai.FormattingEnabled =
                true;

            this.cbLoai.Location =
                new System.Drawing.Point(170, 187);

            this.cbLoai.Name =
                "cbLoai";

            this.cbLoai.Size =
                new System.Drawing.Size(250, 24);

            // label5

            this.label5.AutoSize = true;

            this.label5.Location =
                new System.Drawing.Point(40, 240);

            this.label5.Name =
                "label5";

            this.label5.Size =
                new System.Drawing.Size(42, 16);

            this.label5.Text =
                "Lý do";

            // txtLyDo

            this.txtLyDo.Location =
                new System.Drawing.Point(170, 237);

            this.txtLyDo.Multiline =
                true;

            this.txtLyDo.Name =
                "txtLyDo";

            this.txtLyDo.Size =
                new System.Drawing.Size(250, 90);

            // btnLuu

            this.btnLuu.Location =
                new System.Drawing.Point(170, 360);

            this.btnLuu.Name =
                "btnLuu";

            this.btnLuu.Size =
                new System.Drawing.Size(100, 35);

            this.btnLuu.Text =
                "Lưu";

            this.btnLuu.UseVisualStyleBackColor =
                true;

            this.btnLuu.Click +=
                new System.EventHandler(
                    this.btnLuu_Click
                );

            // btnDong

            this.btnDong.Location =
                new System.Drawing.Point(320, 360);

            this.btnDong.Name =
                "btnDong";

            this.btnDong.Size =
                new System.Drawing.Size(100, 35);

            this.btnDong.Text =
                "Đóng";

            this.btnDong.UseVisualStyleBackColor =
                true;

            this.btnDong.Click +=
                new System.EventHandler(
                    this.btnDong_Click
                );

            // FrmNghiPhepEdit

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    8F,
                    16F
                );

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(
                    500,
                    450
                );

            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbNhanVien);

            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCaLam);

            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtNgay);

            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbLoai);

            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLyDo);

            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);

            this.Name =
                "FrmNghiPhepEdit";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Nghỉ phép";

            this.Load +=
                new System.EventHandler(
                    this.FrmNghiPhepEdit_Load
                );

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbNhanVien;

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbCaLam;

        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtNgay;

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbLoai;

        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtLyDo;

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
    }
}