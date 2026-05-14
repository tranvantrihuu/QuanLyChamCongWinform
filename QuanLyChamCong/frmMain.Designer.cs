using System.Windows.Forms;

namespace QuanLyChamCong
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCaLam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhanCa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCauHinhLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiPhepNam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChamCong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChamCongItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyChamCong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiPhep = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoChamCong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThuongPhat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiPIN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMuc,
            this.mnuChamCong,
            this.mnuLuong,
            this.mnuHeThong,
            this.mnuDangXuat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1221, 49);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhanVien,
            this.mnuCaLam,
            this.mnuPhanCa,
            this.mnuCauHinhLuong,
            this.mnuNghiPhepNam});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(90, 43);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(209, 26);
            this.mnuNhanVien.Text = "Quản lý nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuCaLam
            // 
            this.mnuCaLam.Name = "mnuCaLam";
            this.mnuCaLam.Size = new System.Drawing.Size(209, 26);
            this.mnuCaLam.Text = "Ca làm";
            this.mnuCaLam.Click += new System.EventHandler(this.mnuCaLam_Click);
            // 
            // mnuPhanCa
            // 
            this.mnuPhanCa.Name = "mnuPhanCa";
            this.mnuPhanCa.Size = new System.Drawing.Size(209, 26);
            this.mnuPhanCa.Text = "Phân ca";
            this.mnuPhanCa.Click += new System.EventHandler(this.mnuPhanCa_Click);
            // 
            // mnuCauHinhLuong
            // 
            this.mnuCauHinhLuong.Name = "mnuCauHinhLuong";
            this.mnuCauHinhLuong.Size = new System.Drawing.Size(209, 26);
            this.mnuCauHinhLuong.Text = "Cấu hình lương";
            this.mnuCauHinhLuong.Click += new System.EventHandler(this.mnuCauHinhLuong_Click);
            // 
            // mnuNghiPhepNam
            // 
            this.mnuNghiPhepNam.Name = "mnuNghiPhepNam";
            this.mnuNghiPhepNam.Size = new System.Drawing.Size(209, 26);
            this.mnuNghiPhepNam.Text = "Nghỉ phép năm";
            this.mnuNghiPhepNam.Click += new System.EventHandler(this.mnuNghiPhepNam_Click);
            // 
            // mnuChamCong
            // 
            this.mnuChamCong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChamCongItem,
            this.mnuQuanLyChamCong,
            this.mnuNghiPhep,
            this.mnuBaoCaoChamCong});
            this.mnuChamCong.Name = "mnuChamCong";
            this.mnuChamCong.Size = new System.Drawing.Size(98, 43);
            this.mnuChamCong.Text = "Chấm công";
            // 
            // mnuChamCongItem
            // 
            this.mnuChamCongItem.Name = "mnuChamCongItem";
            this.mnuChamCongItem.Size = new System.Drawing.Size(223, 26);
            this.mnuChamCongItem.Text = "Chấm công ngày";
            this.mnuChamCongItem.Click += new System.EventHandler(this.mnuChamCongItem_Click);
            // 
            // mnuQuanLyChamCong
            // 
            this.mnuQuanLyChamCong.Name = "mnuQuanLyChamCong";
            this.mnuQuanLyChamCong.Size = new System.Drawing.Size(223, 26);
            this.mnuQuanLyChamCong.Text = "Quản lý chấm công";
            this.mnuQuanLyChamCong.Click += new System.EventHandler(this.mnuQuanLyChamCong_Click);
            // 
            // mnuNghiPhep
            // 
            this.mnuNghiPhep.Name = "mnuNghiPhep";
            this.mnuNghiPhep.Size = new System.Drawing.Size(223, 26);
            this.mnuNghiPhep.Text = "Nghỉ phép";
            this.mnuNghiPhep.Click += new System.EventHandler(this.mnuNghiPhep_Click);
            // 
            // mnuBaoCaoChamCong
            // 
            this.mnuBaoCaoChamCong.Name = "mnuBaoCaoChamCong";
            this.mnuBaoCaoChamCong.Size = new System.Drawing.Size(223, 26);
            this.mnuBaoCaoChamCong.Text = "Báo cáo chấm công";
            this.mnuBaoCaoChamCong.Click += new System.EventHandler(this.mnuBaoCaoChamCong_Click);
            // 
            // mnuLuong
            // 
            this.mnuLuong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBangLuong,
            this.mnuThuongPhat});
            this.mnuLuong.Name = "mnuLuong";
            this.mnuLuong.Size = new System.Drawing.Size(65, 43);
            this.mnuLuong.Text = "Lương";
            // 
            // mnuBangLuong
            // 
            this.mnuBangLuong.Name = "mnuBangLuong";
            this.mnuBangLuong.Size = new System.Drawing.Size(177, 26);
            this.mnuBangLuong.Text = "Bảng lương";
            this.mnuBangLuong.Click += new System.EventHandler(this.mnuBangLuong_Click);
            // 
            // mnuThuongPhat
            // 
            this.mnuThuongPhat.Name = "mnuThuongPhat";
            this.mnuThuongPhat.Size = new System.Drawing.Size(177, 26);
            this.mnuThuongPhat.Text = "Thưởng phạt";
            this.mnuThuongPhat.Click += new System.EventHandler(this.mnuThuongPhat_Click);
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoiPIN});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(85, 43);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDoiPIN
            // 
            this.mnuDoiPIN.Name = "mnuDoiPIN";
            this.mnuDoiPIN.Size = new System.Drawing.Size(143, 26);
            this.mnuDoiPIN.Text = "Đổi PIN";
            this.mnuDoiPIN.Click += new System.EventHandler(this.mnuDoiPIN_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(91, 43);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(3, 52);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1215, 793);
            this.pnMain.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnMain, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1221, 848);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1221, 848);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ CHẤM CÔNG";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuCaLam;
        private System.Windows.Forms.ToolStripMenuItem mnuPhanCa;
        private System.Windows.Forms.ToolStripMenuItem mnuCauHinhLuong;
        private System.Windows.Forms.ToolStripMenuItem mnuChamCong;
        private System.Windows.Forms.ToolStripMenuItem mnuChamCongItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiPhep;
        private System.Windows.Forms.ToolStripMenuItem mnuLuong;
        private System.Windows.Forms.ToolStripMenuItem mnuBangLuong;
        private System.Windows.Forms.ToolStripMenuItem mnuThuongPhat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiPIN;
        private System.Windows.Forms.Panel pnMain;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStripMenuItem mnuNghiPhepNam;
        private ToolStripMenuItem mnuQuanLyChamCong;
        private ToolStripMenuItem mnuBaoCaoChamCong;
        private ToolStripMenuItem mnuDangXuat;
    }
}

