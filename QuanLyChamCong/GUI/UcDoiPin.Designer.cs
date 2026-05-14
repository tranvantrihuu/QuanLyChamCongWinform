namespace QuanLyChamCong.GUI
{
    partial class UcDoiPin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(
            bool disposing
        )
        {
            if (
                disposing &&
                (components != null)
            )
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle =
                new System.Windows.Forms.Label();

            this.lblNhanVien =
                new System.Windows.Forms.Label();

            this.cboNhanVien =
                new System.Windows.Forms.ComboBox();

            this.lblPinText =
                new System.Windows.Forms.Label();

            this.lblPinHienTai =
                new System.Windows.Forms.Label();

            this.lblPinMoi =
                new System.Windows.Forms.Label();

            this.txtPinMoi =
                new System.Windows.Forms.TextBox();

            this.lblXacNhan =
                new System.Windows.Forms.Label();

            this.txtXacNhan =
                new System.Windows.Forms.TextBox();

            this.btnDoiPin =
                new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblTitle

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0))
                );

            this.lblTitle.Location =
                new System.Drawing.Point(50, 40);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(157, 41);

            this.lblTitle.TabIndex =
                0;

            this.lblTitle.Text =
                "ĐỔI PIN";

            // lblNhanVien

            this.lblNhanVien.AutoSize = true;

            this.lblNhanVien.Location =
                new System.Drawing.Point(55, 120);

            this.lblNhanVien.Name =
                "lblNhanVien";

            this.lblNhanVien.Size =
                new System.Drawing.Size(86, 20);

            this.lblNhanVien.TabIndex =
                1;

            this.lblNhanVien.Text =
                "Nhân viên";

            // cboNhanVien

            this.cboNhanVien.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboNhanVien.FormattingEnabled =
                true;

            this.cboNhanVien.Location =
                new System.Drawing.Point(180, 115);

            this.cboNhanVien.Name =
                "cboNhanVien";

            this.cboNhanVien.Size =
                new System.Drawing.Size(300, 28);

            this.cboNhanVien.TabIndex =
                2;

            this.cboNhanVien.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cboNhanVien_SelectedIndexChanged
                );

            // lblPinText

            this.lblPinText.AutoSize = true;

            this.lblPinText.Location =
                new System.Drawing.Point(55, 180);

            this.lblPinText.Name =
                "lblPinText";

            this.lblPinText.Size =
                new System.Drawing.Size(98, 20);

            this.lblPinText.TabIndex =
                3;

            this.lblPinText.Text =
                "PIN hiện tại";

            // lblPinHienTai

            this.lblPinHienTai.AutoSize = true;

            this.lblPinHienTai.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0))
                );

            this.lblPinHienTai.ForeColor =
                System.Drawing.Color.Red;

            this.lblPinHienTai.Location =
                new System.Drawing.Point(180, 178);

            this.lblPinHienTai.Name =
                "lblPinHienTai";

            this.lblPinHienTai.Size =
                new System.Drawing.Size(41, 23);

            this.lblPinHienTai.TabIndex =
                4;

            this.lblPinHienTai.Text =
                "----";

            // lblPinMoi

            this.lblPinMoi.AutoSize = true;

            this.lblPinMoi.Location =
                new System.Drawing.Point(55, 245);

            this.lblPinMoi.Name =
                "lblPinMoi";

            this.lblPinMoi.Size =
                new System.Drawing.Size(65, 20);

            this.lblPinMoi.TabIndex =
                5;

            this.lblPinMoi.Text =
                "PIN mới";

            // txtPinMoi

            this.txtPinMoi.Location =
                new System.Drawing.Point(180, 240);

            this.txtPinMoi.Name =
                "txtPinMoi";

            this.txtPinMoi.Size =
                new System.Drawing.Size(300, 27);

            this.txtPinMoi.TabIndex =
                6;

            this.txtPinMoi.UseSystemPasswordChar =
                true;

            // lblXacNhan

            this.lblXacNhan.AutoSize = true;

            this.lblXacNhan.Location =
                new System.Drawing.Point(55, 305);

            this.lblXacNhan.Name =
                "lblXacNhan";

            this.lblXacNhan.Size =
                new System.Drawing.Size(111, 20);

            this.lblXacNhan.TabIndex =
                7;

            this.lblXacNhan.Text =
                "Xác nhận PIN";

            // txtXacNhan

            this.txtXacNhan.Location =
                new System.Drawing.Point(180, 300);

            this.txtXacNhan.Name =
                "txtXacNhan";

            this.txtXacNhan.Size =
                new System.Drawing.Size(300, 27);

            this.txtXacNhan.TabIndex =
                8;

            this.txtXacNhan.UseSystemPasswordChar =
                true;

            // btnDoiPin

            this.btnDoiPin.Location =
                new System.Drawing.Point(180, 380);

            this.btnDoiPin.Name =
                "btnDoiPin";

            this.btnDoiPin.Size =
                new System.Drawing.Size(300, 45);

            this.btnDoiPin.TabIndex =
                9;

            this.btnDoiPin.Text =
                "ĐỔI PIN";

            this.btnDoiPin.UseVisualStyleBackColor =
                true;

            this.btnDoiPin.Click +=
                new System.EventHandler(
                    this.btnDoiPin_Click
                );

            // UcDoiPin

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    8F,
                    20F
                );

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.lblNhanVien);

            this.Controls.Add(this.cboNhanVien);

            this.Controls.Add(this.lblPinText);

            this.Controls.Add(this.lblPinHienTai);

            this.Controls.Add(this.lblPinMoi);

            this.Controls.Add(this.txtPinMoi);

            this.Controls.Add(this.lblXacNhan);

            this.Controls.Add(this.txtXacNhan);

            this.Controls.Add(this.btnDoiPin);

            this.Name =
                "UcDoiPin";

            this.Size =
                new System.Drawing.Size(700, 550);

            this.Load +=
                new System.EventHandler(
                    this.UcDoiPin_Load
                );

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblNhanVien;

        private System.Windows.Forms.ComboBox cboNhanVien;

        private System.Windows.Forms.Label lblPinText;

        private System.Windows.Forms.Label lblPinHienTai;

        private System.Windows.Forms.Label lblPinMoi;

        private System.Windows.Forms.TextBox txtPinMoi;

        private System.Windows.Forms.Label lblXacNhan;

        private System.Windows.Forms.TextBox txtXacNhan;

        private System.Windows.Forms.Button btnDoiPin;
    }
}