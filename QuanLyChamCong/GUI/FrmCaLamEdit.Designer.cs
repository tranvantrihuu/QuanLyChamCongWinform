using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    partial class FrmCaLamEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenCa = new System.Windows.Forms.Label();
            this.txtTenCa = new System.Windows.Forms.TextBox();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.dtBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.dtKetThuc = new System.Windows.Forms.DateTimePicker();
            this.lblDiTre = new System.Windows.Forms.Label();
            this.numDiTre = new System.Windows.Forms.NumericUpDown();
            this.lblVeSom = new System.Windows.Forms.Label();
            this.numVeSom = new System.Windows.Forms.NumericUpDown();
            this.lblCheckinSom = new System.Windows.Forms.Label();
            this.numCheckinSom = new System.Windows.Forms.NumericUpDown();
            this.lblCheckoutTre = new System.Windows.Forms.Label();
            this.numCheckoutTre = new System.Windows.Forms.NumericUpDown();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiTre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVeSom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckinSom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckoutTre)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTenCa, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTenCa, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBatDau, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtBatDau, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKetThuc, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtKetThuc, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDiTre, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numDiTre, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblVeSom, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.numVeSom, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCheckinSom, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numCheckinSom, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblCheckoutTre, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.numCheckoutTre, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.pnlButton, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 400);
            this.tableLayoutPanel1.TabIndex = 0;
            
            this.lblTenCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblTenCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenCa.Location = new System.Drawing.Point(3, 0);
            this.lblTenCa.Name = "lblTenCa";
            this.lblTenCa.Size = new System.Drawing.Size(174, 50);
            this.lblTenCa.TabIndex = 0;
            this.lblTenCa.Text = "Tên ca";
            this.lblTenCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           
            this.txtTenCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenCa.Location = new System.Drawing.Point(183, 3);
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.Size = new System.Drawing.Size(314, 30);
            this.txtTenCa.TabIndex = 1;
             
            this.lblBatDau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblBatDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBatDau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBatDau.Location = new System.Drawing.Point(3, 50);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(174, 50);
            this.lblBatDau.TabIndex = 2;
            this.lblBatDau.Text = "Giờ bắt đầu";
            this.lblBatDau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.dtBatDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtBatDau.Location = new System.Drawing.Point(183, 53);
            this.dtBatDau.Name = "dtBatDau";
            this.dtBatDau.Size = new System.Drawing.Size(314, 30);
            this.dtBatDau.TabIndex = 3;
                        this.lblKetThuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblKetThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKetThuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKetThuc.Location = new System.Drawing.Point(3, 100);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(174, 50);
            this.lblKetThuc.TabIndex = 4;
            this.lblKetThuc.Text = "Giờ kết thúc";
            this.lblKetThuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
             
            this.dtKetThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtKetThuc.Location = new System.Drawing.Point(183, 103);
            this.dtKetThuc.Name = "dtKetThuc";
            this.dtKetThuc.Size = new System.Drawing.Size(314, 30);
            this.dtKetThuc.TabIndex = 5;
            
            this.lblDiTre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblDiTre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiTre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiTre.Location = new System.Drawing.Point(3, 150);
            this.lblDiTre.Name = "lblDiTre";
            this.lblDiTre.Size = new System.Drawing.Size(174, 50);
            this.lblDiTre.TabIndex = 6;
            this.lblDiTre.Text = "Phút đi trễ";
            this.lblDiTre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
             
            this.numDiTre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numDiTre.Location = new System.Drawing.Point(183, 153);
            this.numDiTre.Name = "numDiTre";
            this.numDiTre.Size = new System.Drawing.Size(314, 30);
            this.numDiTre.TabIndex = 7;
             
            this.lblVeSom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblVeSom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVeSom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVeSom.Location = new System.Drawing.Point(3, 200);
            this.lblVeSom.Name = "lblVeSom";
            this.lblVeSom.Size = new System.Drawing.Size(174, 50);
            this.lblVeSom.TabIndex = 8;
            this.lblVeSom.Text = "Phút về sớm";
            this.lblVeSom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.numVeSom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numVeSom.Location = new System.Drawing.Point(183, 203);
            this.numVeSom.Name = "numVeSom";
            this.numVeSom.Size = new System.Drawing.Size(314, 30);
            this.numVeSom.TabIndex = 9;
             
            this.lblCheckinSom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCheckinSom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckinSom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCheckinSom.Location = new System.Drawing.Point(3, 250);
            this.lblCheckinSom.Name = "lblCheckinSom";
            this.lblCheckinSom.Size = new System.Drawing.Size(174, 50);
            this.lblCheckinSom.TabIndex = 10;
            this.lblCheckinSom.Text = "Checkin sớm";
            this.lblCheckinSom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
             
            this.numCheckinSom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numCheckinSom.Location = new System.Drawing.Point(183, 253);
            this.numCheckinSom.Name = "numCheckinSom";
            this.numCheckinSom.Size = new System.Drawing.Size(314, 30);
            this.numCheckinSom.TabIndex = 11;
            
            this.lblCheckoutTre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCheckoutTre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckoutTre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCheckoutTre.Location = new System.Drawing.Point(3, 300);
            this.lblCheckoutTre.Name = "lblCheckoutTre";
            this.lblCheckoutTre.Size = new System.Drawing.Size(174, 50);
            this.lblCheckoutTre.TabIndex = 12;
            this.lblCheckoutTre.Text = "Checkout trễ";
            this.lblCheckoutTre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
             
            this.numCheckoutTre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numCheckoutTre.Location = new System.Drawing.Point(183, 303);
            this.numCheckoutTre.Name = "numCheckoutTre";
            this.numCheckoutTre.Size = new System.Drawing.Size(314, 30);
            this.numCheckoutTre.TabIndex = 13;
            
            this.pnlButton.Controls.Add(this.btnOk);
            this.pnlButton.Controls.Add(this.btnCancel);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.Location = new System.Drawing.Point(183, 353);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(314, 44);
            this.pnlButton.TabIndex = 14;
             
            this.btnOk.BackColor = System.Drawing.Color.LightGreen;
            this.btnOk.Location = new System.Drawing.Point(50, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 40);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
             
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Location = new System.Drawing.Point(170, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
             
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCaLamEdit";
            this.Text = "Ca Làm";
            this.Load += new System.EventHandler(this.FrmCaLamEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiTre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVeSom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckinSom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckoutTre)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public TextBox txtTenCa;
        public DateTimePicker dtBatDau;
        public DateTimePicker dtKetThuc;

        public NumericUpDown numDiTre;
        public NumericUpDown numVeSom;
        public NumericUpDown numCheckinSom;
        public NumericUpDown numCheckoutTre;

        public Button btnOk;
        public Button btnCancel;

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlButton;

        private Label lblTenCa;
        private Label lblBatDau;
        private Label lblKetThuc;
        private Label lblDiTre;
        private Label lblVeSom;
        private Label lblCheckinSom;
        private Label lblCheckoutTre;
    }
}