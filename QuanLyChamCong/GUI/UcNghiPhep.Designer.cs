
using System.Windows.Forms;

namespace QuanLyChamCong.GUI
{
    partial class UcNghiPhep
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvNghiPhep = new System.Windows.Forms.DataGridView();

            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNghiPhep)).BeginInit();

            this.SuspendLayout();

            this.flowLayoutPanel1.Anchor =
                System.Windows.Forms.AnchorStyles.None;

            this.flowLayoutPanel1.AutoSize = true;

            this.flowLayoutPanel1.Controls.Add(this.btnThem);
            this.flowLayoutPanel1.Controls.Add(this.btnSua);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);

            this.flowLayoutPanel1.Location =
                new System.Drawing.Point(395, 616);

            this.flowLayoutPanel1.Name =
                "flowLayoutPanel1";

            this.flowLayoutPanel1.Size =
                new System.Drawing.Size(408, 46);

            this.flowLayoutPanel1.TabIndex = 0;

            this.flowLayoutPanel1.WrapContents = false;


            this.btnThem.BackColor =
                System.Drawing.Color.Pink;

            this.btnThem.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    10.2F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnThem.Location =
                new System.Drawing.Point(3, 3);

            this.btnThem.Name = "btnThem";

            this.btnThem.Size =
                new System.Drawing.Size(130, 40);

            this.btnThem.TabIndex = 0;

            this.btnThem.Text = "THÊM";

            this.btnThem.UseVisualStyleBackColor = false;

            this.btnThem.Click +=
                new System.EventHandler(
                    this.btnThem_Click
                );

            this.btnSua.BackColor =
                System.Drawing.Color.PaleGreen;

            this.btnSua.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    10.2F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnSua.Location =
                new System.Drawing.Point(139, 3);

            this.btnSua.Name = "btnSua";

            this.btnSua.Size =
                new System.Drawing.Size(130, 40);

            this.btnSua.TabIndex = 1;

            this.btnSua.Text = "SỬA";

            this.btnSua.UseVisualStyleBackColor = false;

            this.btnSua.Click +=
                new System.EventHandler(
                    this.btnSua_Click
                );


            this.btnXoa.BackColor =
                System.Drawing.Color.LightCoral;

            this.btnXoa.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    10.2F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnXoa.Location =
                new System.Drawing.Point(275, 3);

            this.btnXoa.Name = "btnXoa";

            this.btnXoa.Size =
                new System.Drawing.Size(130, 40);

            this.btnXoa.TabIndex = 2;

            this.btnXoa.Text = "XÓA";

            this.btnXoa.UseVisualStyleBackColor = false;

            this.btnXoa.Click +=
                new System.EventHandler(
                    this.btnXoa_Click
                );


            this.tableLayoutPanel1.ColumnCount = 1;

            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent,
                    100F
                )
            );

            this.tableLayoutPanel1.Controls.Add(
                this.dgvNghiPhep,
                0,
                0
            );

            this.tableLayoutPanel1.Controls.Add(
                this.flowLayoutPanel1,
                0,
                1
            );

            this.tableLayoutPanel1.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.tableLayoutPanel1.Location =
                new System.Drawing.Point(0, 0);

            this.tableLayoutPanel1.Name =
                "tableLayoutPanel1";

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

            this.tableLayoutPanel1.Size =
                new System.Drawing.Size(1199, 691);

            this.tableLayoutPanel1.TabIndex = 0;

            this.dgvNghiPhep.BackgroundColor =
                System.Drawing.Color.GhostWhite;

            this.dgvNghiPhep.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvNghiPhep.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.dgvNghiPhep.Location =
                new System.Drawing.Point(3, 3);

            this.dgvNghiPhep.Name =
                "dgvNghiPhep";

            this.dgvNghiPhep.RowHeadersWidth = 51;

            this.dgvNghiPhep.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvNghiPhep.Size =
                new System.Drawing.Size(1193, 581);

            this.dgvNghiPhep.TabIndex = 0;

            this.dgvNghiPhep.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvNghiPhep_CellDoubleClick
                );

            this.dgvNghiPhep.CellValueChanged +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvNghiPhep_CellValueChanged
                );

            this.dgvNghiPhep.CurrentCellDirtyStateChanged +=
                new System.EventHandler(
                    this.dgvNghiPhep_CurrentCellDirtyStateChanged
                );

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.Controls.Add(this.tableLayoutPanel1);

            this.Name = "UcNghiPhep";

            this.Size =
                new System.Drawing.Size(1199, 691);

            this.Load +=
                new System.EventHandler(
                    this.UcNghiPhep_Load
                );

            this.flowLayoutPanel1.ResumeLayout(false);

            this.tableLayoutPanel1.ResumeLayout(false);

            this.tableLayoutPanel1.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(
                this.dgvNghiPhep
            )).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvNghiPhep;
    }
}