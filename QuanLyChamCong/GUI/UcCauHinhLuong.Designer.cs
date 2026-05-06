using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    partial class UcCauHinhLuong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCauHinhLuong = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHinhLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnThem);
            this.flowLayoutPanel1.Controls.Add(this.btnSua);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(216, 419);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(408, 46);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Pink;
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSua.Location = new System.Drawing.Point(139, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.LightCoral;
            this.btnXoa.Location = new System.Drawing.Point(275, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvCauHinhLuong, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 478);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvCauHinhLuong
            // 
            this.dgvCauHinhLuong.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvCauHinhLuong.ColumnHeadersHeight = 29;
            this.dgvCauHinhLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCauHinhLuong.Location = new System.Drawing.Point(3, 3);
            this.dgvCauHinhLuong.Name = "dgvCauHinhLuong";
            this.dgvCauHinhLuong.RowHeadersWidth = 51;
            this.dgvCauHinhLuong.Size = new System.Drawing.Size(834, 400);
            this.dgvCauHinhLuong.TabIndex = 0;
            this.dgvCauHinhLuong.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHinhLuong_CellDoubleClick);
            this.dgvCauHinhLuong.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHinhLuong_CellValueChanged);
            this.dgvCauHinhLuong.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCauHinhLuong_CurrentCellDirtyStateChanged);
            // 
            // UcCauHinhLuong
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcCauHinhLuong";
            this.Size = new System.Drawing.Size(840, 478);
            this.Load += new System.EventHandler(this.UcCauHinhLuong_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHinhLuong)).EndInit();
            this.ResumeLayout(false);

        }

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvCauHinhLuong;
    }
}