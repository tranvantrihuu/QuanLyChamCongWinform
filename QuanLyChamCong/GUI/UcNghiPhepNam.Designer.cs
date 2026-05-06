// UcNghiPhepNam.Designer.cs

namespace QuanLyChamCong.GUI
{
    partial class UcNghiPhepNam
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvNghiPhepNam = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNghiPhepNam)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // tableLayoutPanel1
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent,
                    100F
                )
            );

            this.tableLayoutPanel1.Controls.Add(this.dgvNghiPhepNam, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);

            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";

            this.tableLayoutPanel1.RowCount = 2;

            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent,
                    85F
                )
            );

            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent,
                    15F
                )
            );

            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 700);
            this.tableLayoutPanel1.TabIndex = 0;

            // dgvNghiPhepNam
            this.dgvNghiPhepNam.BackgroundColor = System.Drawing.Color.White;
            this.dgvNghiPhepNam.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvNghiPhepNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNghiPhepNam.Location = new System.Drawing.Point(3, 3);
            this.dgvNghiPhepNam.Name = "dgvNghiPhepNam";
            this.dgvNghiPhepNam.RowHeadersWidth = 51;
            this.dgvNghiPhepNam.RowTemplate.Height = 24;
            this.dgvNghiPhepNam.Size = new System.Drawing.Size(1194, 589);
            this.dgvNghiPhepNam.TabIndex = 0;

            this.dgvNghiPhepNam.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvNghiPhepNam_CellDoubleClick
                );

            this.dgvNghiPhepNam.CellValueChanged +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvNghiPhepNam_CellValueChanged
                );

            this.dgvNghiPhepNam.CurrentCellDirtyStateChanged +=
                new System.EventHandler(
                    this.dgvNghiPhepNam_CurrentCellDirtyStateChanged
                );

            // flowLayoutPanel1
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Controls.Add(this.btnThem);
            this.flowLayoutPanel1.Controls.Add(this.btnSua);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);

            this.flowLayoutPanel1.Location = new System.Drawing.Point(375, 620);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(450, 50);
            this.flowLayoutPanel1.TabIndex = 1;

            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.LightPink;
            this.btnThem.Font = new System.Drawing.Font(
                "Segoe UI",
                10.2F,
                System.Drawing.FontStyle.Bold
            );

            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = false;

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSua.Font = new System.Drawing.Font(
                "Segoe UI",
                10.2F,
                System.Drawing.FontStyle.Bold
            );

            this.btnSua.Location = new System.Drawing.Point(139, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = false;

            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.BackColor = System.Drawing.Color.LightCoral;
            this.btnXoa.Font = new System.Drawing.Font(
                "Segoe UI",
                10.2F,
                System.Drawing.FontStyle.Bold
            );

            this.btnXoa.Location = new System.Drawing.Point(275, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;

            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // UcNghiPhepNam
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.Controls.Add(this.tableLayoutPanel1);

            this.Name = "UcNghiPhepNam";
            this.Size = new System.Drawing.Size(1200, 700);

            this.Load += new System.EventHandler(this.UcNghiPhepNam_Load);

            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNghiPhepNam)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvNghiPhepNam;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
    }
}