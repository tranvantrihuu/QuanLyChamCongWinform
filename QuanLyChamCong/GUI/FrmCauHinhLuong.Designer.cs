using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    partial class FrmCauHinhLuongEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblLuongCoBan = new System.Windows.Forms.Label();
            this.numLuongCoBan = new System.Windows.Forms.NumericUpDown();
            this.lblLuongTheoGio = new System.Windows.Forms.Label();
            this.numLuongTheoGio = new System.Windows.Forms.NumericUpDown();
            this.lblTangCa = new System.Windows.Forms.Label();
            this.numTangCa = new System.Windows.Forms.NumericUpDown();
            this.lblPhuCap = new System.Windows.Forms.Label();
            this.numPhuCap = new System.Windows.Forms.NumericUpDown();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongCoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongTheoGio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTangCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhuCap)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblNhanVien, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbNhanVien, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLuongCoBan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numLuongCoBan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLuongTheoGio, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numLuongTheoGio, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTangCa, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numTangCa, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPhuCap, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.numPhuCap, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pnlButton, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 350);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhanVien.Location = new System.Drawing.Point(3, 0);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(174, 58);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Nhân viên";
            this.lblNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbNhanVien
            // 
            this.cbNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhanVien.Location = new System.Drawing.Point(183, 3);
            this.cbNhanVien.Name = "cbNhanVien";
            this.cbNhanVien.Size = new System.Drawing.Size(314, 24);
            this.cbNhanVien.TabIndex = 1;
            // 
            // lblLuongCoBan
            // 
            this.lblLuongCoBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblLuongCoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLuongCoBan.Location = new System.Drawing.Point(3, 58);
            this.lblLuongCoBan.Name = "lblLuongCoBan";
            this.lblLuongCoBan.Size = new System.Drawing.Size(174, 58);
            this.lblLuongCoBan.TabIndex = 2;
            this.lblLuongCoBan.Text = "Lương cơ bản";
            this.lblLuongCoBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLuongCoBan
            // 
            this.numLuongCoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numLuongCoBan.Location = new System.Drawing.Point(183, 61);
            this.numLuongCoBan.Name = "numLuongCoBan";
            this.numLuongCoBan.Size = new System.Drawing.Size(314, 22);
            this.numLuongCoBan.TabIndex = 3;
            // 
            // lblLuongTheoGio
            // 
            this.lblLuongTheoGio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblLuongTheoGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLuongTheoGio.Location = new System.Drawing.Point(3, 116);
            this.lblLuongTheoGio.Name = "lblLuongTheoGio";
            this.lblLuongTheoGio.Size = new System.Drawing.Size(174, 58);
            this.lblLuongTheoGio.TabIndex = 4;
            this.lblLuongTheoGio.Text = "Lương theo giờ";
            this.lblLuongTheoGio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLuongTheoGio
            // 
            this.numLuongTheoGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numLuongTheoGio.Location = new System.Drawing.Point(183, 119);
            this.numLuongTheoGio.Name = "numLuongTheoGio";
            this.numLuongTheoGio.Size = new System.Drawing.Size(314, 22);
            this.numLuongTheoGio.TabIndex = 5;
            // 
            // lblTangCa
            // 
            this.lblTangCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblTangCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTangCa.Location = new System.Drawing.Point(3, 174);
            this.lblTangCa.Name = "lblTangCa";
            this.lblTangCa.Size = new System.Drawing.Size(174, 58);
            this.lblTangCa.TabIndex = 6;
            this.lblTangCa.Text = "Lương tăng ca";
            this.lblTangCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTangCa
            // 
            this.numTangCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numTangCa.Location = new System.Drawing.Point(183, 177);
            this.numTangCa.Name = "numTangCa";
            this.numTangCa.Size = new System.Drawing.Size(314, 22);
            this.numTangCa.TabIndex = 7;
            // 
            // lblPhuCap
            // 
            this.lblPhuCap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPhuCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhuCap.Location = new System.Drawing.Point(3, 232);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(174, 58);
            this.lblPhuCap.TabIndex = 8;
            this.lblPhuCap.Text = "Phụ cấp mặc định";
            this.lblPhuCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPhuCap
            // 
            this.numPhuCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numPhuCap.Location = new System.Drawing.Point(183, 235);
            this.numPhuCap.Name = "numPhuCap";
            this.numPhuCap.Size = new System.Drawing.Size(314, 22);
            this.numPhuCap.TabIndex = 9;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnOk);
            this.pnlButton.Controls.Add(this.btnCancel);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.Location = new System.Drawing.Point(183, 293);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(314, 54);
            this.pnlButton.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightGreen;
            this.btnOk.Location = new System.Drawing.Point(50, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 40);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Location = new System.Drawing.Point(170, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmCauHinhLuongEdit
            // 
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCauHinhLuongEdit";
            this.Text = "Cấu hình lương";
            this.Load += new System.EventHandler(this.FrmCauHinhLuongEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numLuongCoBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongTheoGio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTangCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhuCap)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        // ===== PUBLIC CONTROL (GIỐNG BẠN) =====
        public ComboBox cbNhanVien;
        public NumericUpDown numLuongCoBan;
        public NumericUpDown numLuongTheoGio;
        public NumericUpDown numTangCa;
        public NumericUpDown numPhuCap;

        public Button btnOk;
        public Button btnCancel;

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlButton;

        private Label lblNhanVien;
        private Label lblLuongCoBan;
        private Label lblLuongTheoGio;
        private Label lblTangCa;
        private Label lblPhuCap;
    }
}