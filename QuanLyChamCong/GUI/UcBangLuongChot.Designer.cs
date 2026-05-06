// UcBangLuongChot.Designer.cs

namespace QuanLyChamCong.GUI
{
    partial class UcBangLuongChot
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed;
        /// otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (
                disposing
                && (components != null)
            )
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support
        /// - do not modify
        /// the contents of this method
        /// with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop =
                new System.Windows.Forms.Panel();

            this.label2 =
                new System.Windows.Forms.Label();

            this.cboNam =
                new System.Windows.Forms.ComboBox();

            this.label1 =
                new System.Windows.Forms.Label();

            this.cboThang =
                new System.Windows.Forms.ComboBox();

            this.btnTaiLai =
                new System.Windows.Forms.Button();

            this.btnChotLuong =
                new System.Windows.Forms.Button();

            this.dgvDanhSach =
                new System.Windows.Forms.DataGridView();

            this.panelTop.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(
                this.dgvDanhSach
            )).BeginInit();

            this.SuspendLayout();

            // panelTop

            this.panelTop.Controls.Add(
                this.btnChotLuong
            );

            this.panelTop.Controls.Add(
                this.btnTaiLai
            );

            this.panelTop.Controls.Add(
                this.cboNam
            );

            this.panelTop.Controls.Add(
                this.label2
            );

            this.panelTop.Controls.Add(
                this.cboThang
            );

            this.panelTop.Controls.Add(
                this.label1
            );

            this.panelTop.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.panelTop.Location =
                new System.Drawing.Point(0, 0);

            this.panelTop.Name =
                "panelTop";

            this.panelTop.Size =
                new System.Drawing.Size(1280, 70);

            this.panelTop.TabIndex =
                0;

            // label1

            this.label1.AutoSize =
                true;

            this.label1.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.label1.Location =
                new System.Drawing.Point(20, 24);

            this.label1.Name =
                "label1";

            this.label1.Size =
                new System.Drawing.Size(57, 23);

            this.label1.TabIndex =
                0;

            this.label1.Text =
                "Tháng";

            // cboThang

            this.cboThang.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboThang.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.cboThang.FormattingEnabled =
                true;

            this.cboThang.Items.AddRange(
                new object[]
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "11",
                    "12"
                }
            );

            this.cboThang.Location =
                new System.Drawing.Point(83, 20);

            this.cboThang.Name =
                "cboThang";

            this.cboThang.Size =
                new System.Drawing.Size(90, 31);

            this.cboThang.TabIndex =
                1;

            this.cboThang.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cboThang_SelectedIndexChanged
                );

            // label2

            this.label2.AutoSize =
                true;

            this.label2.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.label2.Location =
                new System.Drawing.Point(200, 24);

            this.label2.Name =
                "label2";

            this.label2.Size =
                new System.Drawing.Size(43, 23);

            this.label2.TabIndex =
                2;

            this.label2.Text =
                "Năm";

            // cboNam

            this.cboNam.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.cboNam.FormattingEnabled =
                true;

            this.cboNam.Items.AddRange(
                new object[]
                {
                    "2024",
                    "2025",
                    "2026",
                    "2027",
                    "2028",
                    "2029",
                    "2030"
                }
            );

            this.cboNam.Location =
                new System.Drawing.Point(249, 20);

            this.cboNam.Name =
                "cboNam";

            this.cboNam.Size =
                new System.Drawing.Size(100, 31);

            this.cboNam.TabIndex =
                3;

            this.cboNam.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cboNam_SelectedIndexChanged
                );

            // btnTaiLai

            this.btnTaiLai.BackColor =
                System.Drawing.Color.White;

            this.btnTaiLai.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnTaiLai.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnTaiLai.Location =
                new System.Drawing.Point(390, 16);

            this.btnTaiLai.Name =
                "btnTaiLai";

            this.btnTaiLai.Size =
                new System.Drawing.Size(120, 38);

            this.btnTaiLai.TabIndex =
                4;

            this.btnTaiLai.Text =
                "Tải lại";

            this.btnTaiLai.UseVisualStyleBackColor =
                false;

            this.btnTaiLai.Click +=
                new System.EventHandler(
                    this.btnTaiLai_Click
                );

            // btnChotLuong

            this.btnChotLuong.BackColor =
                System.Drawing.Color.FromArgb(
                    0,
                    120,
                    215
                );

            this.btnChotLuong.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnChotLuong.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnChotLuong.ForeColor =
                System.Drawing.Color.White;

            this.btnChotLuong.Location =
                new System.Drawing.Point(530, 16);

            this.btnChotLuong.Name =
                "btnChotLuong";

            this.btnChotLuong.Size =
                new System.Drawing.Size(160, 38);

            this.btnChotLuong.TabIndex =
                5;

            this.btnChotLuong.Text =
                "Chốt bảng lương";

            this.btnChotLuong.UseVisualStyleBackColor =
                false;

            this.btnChotLuong.Click +=
                new System.EventHandler(
                    this.btnChotLuong_Click
                );

            // dgvDanhSach

            this.dgvDanhSach.AllowUserToAddRows =
                false;

            this.dgvDanhSach.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvDanhSach.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvDanhSach.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.dgvDanhSach.Location =
                new System.Drawing.Point(0, 70);

            this.dgvDanhSach.MultiSelect =
                false;

            this.dgvDanhSach.Name =
                "dgvDanhSach";

            this.dgvDanhSach.ReadOnly =
                true;

            this.dgvDanhSach.RowHeadersWidth =
                51;

            this.dgvDanhSach.RowTemplate.Height =
                29;

            this.dgvDanhSach.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvDanhSach.Size =
                new System.Drawing.Size(1280, 650);

            this.dgvDanhSach.TabIndex =
                1;

            this.dgvDanhSach.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvDanhSach_CellDoubleClick
                );

            // UcBangLuongChot

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    8F,
                    20F
                );

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.Controls.Add(
                this.dgvDanhSach
            );

            this.Controls.Add(
                this.panelTop
            );

            this.Name =
                "UcBangLuongChot";

            this.Size =
                new System.Drawing.Size(1280, 720);

            this.Load +=
                new System.EventHandler(
                    this.UcBangLuongChot_Load
                );

            this.panelTop.ResumeLayout(false);

            this.panelTop.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(
                this.dgvDanhSach
            )).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnChotLuong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}