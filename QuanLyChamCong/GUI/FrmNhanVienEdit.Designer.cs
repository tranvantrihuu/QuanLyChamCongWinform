namespace QuanLyChamCong.GUI
{
    partial class FrmNhanVienEdit
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lvlNgaySinh = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNgaySua = new System.Windows.Forms.Label();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.lblLoaiLuong = new System.Windows.Forms.Label();
            this.lblNgayVao = new System.Windows.Forms.Label();
            this.lblPin = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.txtIDNhanVien = new System.Windows.Forms.TextBox();
            this.txtMaVanTay = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtNgaySua = new System.Windows.Forms.TextBox();
            this.txtNgayTao = new System.Windows.Forms.TextBox();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.dtNgayVao = new System.Windows.Forms.DateTimePicker();
            this.cbVaiTro = new System.Windows.Forms.ComboBox();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.txtViTri = new System.Windows.Forms.TextBox();
            this.cbLoaiLuong = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(127, 32);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID Nhân viên";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMaNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNhanVien.Location = new System.Drawing.Point(3, 51);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(127, 32);
            this.lblMaNhanVien.TabIndex = 1;
            this.lblMaNhanVien.Text = "Mã vân tay";
            this.lblMaNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHoTen
            // 
            this.lblHoTen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(3, 102);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(127, 32);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ và Tên";
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSDT
            // 
            this.lblSDT.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(3, 153);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(127, 32);
            this.lblSDT.TabIndex = 3;
            this.lblSDT.Text = "Số điện thoại";
            this.lblSDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvlNgaySinh
            // 
            this.lvlNgaySinh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lvlNgaySinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvlNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlNgaySinh.Location = new System.Drawing.Point(3, 204);
            this.lvlNgaySinh.Name = "lvlNgaySinh";
            this.lvlNgaySinh.Size = new System.Drawing.Size(127, 32);
            this.lvlNgaySinh.TabIndex = 4;
            this.lvlNgaySinh.Text = "Ngày sinh";
            this.lvlNgaySinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(3, 255);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(127, 32);
            this.lblDiaChi.TabIndex = 5;
            this.lblDiaChi.Text = "Địa chỉ";
            this.lblDiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vị trí";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgaySua
            // 
            this.lblNgaySua.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblNgaySua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNgaySua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySua.Location = new System.Drawing.Point(398, 306);
            this.lblNgaySua.Name = "lblNgaySua";
            this.lblNgaySua.Size = new System.Drawing.Size(127, 32);
            this.lblNgaySua.TabIndex = 13;
            this.lblNgaySua.Text = "Ngày sửa";
            this.lblNgaySua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblNgayTao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayTao.Location = new System.Drawing.Point(398, 255);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(127, 32);
            this.lblNgayTao.TabIndex = 12;
            this.lblNgayTao.Text = "Ngày tạo";
            this.lblNgayTao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoaiLuong
            // 
            this.lblLoaiLuong.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLoaiLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoaiLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiLuong.Location = new System.Drawing.Point(398, 204);
            this.lblLoaiLuong.Name = "lblLoaiLuong";
            this.lblLoaiLuong.Size = new System.Drawing.Size(127, 32);
            this.lblLoaiLuong.TabIndex = 11;
            this.lblLoaiLuong.Text = "Loại lương";
            this.lblLoaiLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgayVao
            // 
            this.lblNgayVao.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblNgayVao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNgayVao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayVao.Location = new System.Drawing.Point(398, 153);
            this.lblNgayVao.Name = "lblNgayVao";
            this.lblNgayVao.Size = new System.Drawing.Size(127, 32);
            this.lblNgayVao.TabIndex = 10;
            this.lblNgayVao.Text = "Ngày vào làm";
            this.lblNgayVao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPin
            // 
            this.lblPin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPin.Location = new System.Drawing.Point(398, 102);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(127, 32);
            this.lblPin.TabIndex = 9;
            this.lblPin.Text = "PIN";
            this.lblPin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTrangThai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(398, 51);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(127, 32);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng thái";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVaiTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaiTro.Location = new System.Drawing.Point(398, 0);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(127, 32);
            this.lblVaiTro.TabIndex = 7;
            this.lblVaiTro.Text = "Vai trò";
            this.lblVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIDNhanVien
            // 
            this.txtIDNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIDNhanVien.Location = new System.Drawing.Point(168, 2);
            this.txtIDNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDNhanVien.Name = "txtIDNhanVien";
            this.txtIDNhanVien.Size = new System.Drawing.Size(224, 22);
            this.txtIDNhanVien.TabIndex = 14;
            // 
            // txtMaVanTay
            // 
            this.txtMaVanTay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaVanTay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaVanTay.Location = new System.Drawing.Point(168, 53);
            this.txtMaVanTay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaVanTay.Name = "txtMaVanTay";
            this.txtMaVanTay.Size = new System.Drawing.Size(224, 22);
            this.txtMaVanTay.TabIndex = 15;
            // 
            // txtHoTen
            // 
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoTen.Location = new System.Drawing.Point(168, 104);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(224, 22);
            this.txtHoTen.TabIndex = 16;
            // 
            // txtSDT
            // 
            this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSDT.Location = new System.Drawing.Point(168, 155);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(224, 22);
            this.txtSDT.TabIndex = 17;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiaChi.Location = new System.Drawing.Point(168, 257);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(224, 22);
            this.txtDiaChi.TabIndex = 19;
            // 
            // txtNgaySua
            // 
            this.txtNgaySua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgaySua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgaySua.Location = new System.Drawing.Point(563, 308);
            this.txtNgaySua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgaySua.Name = "txtNgaySua";
            this.txtNgaySua.Size = new System.Drawing.Size(225, 22);
            this.txtNgaySua.TabIndex = 27;
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayTao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgayTao.Location = new System.Drawing.Point(563, 257);
            this.txtNgayTao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.Size = new System.Drawing.Size(225, 22);
            this.txtNgayTao.TabIndex = 26;
            // 
            // txtPin
            // 
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPin.Location = new System.Drawing.Point(563, 104);
            this.txtPin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(225, 22);
            this.txtPin.TabIndex = 23;
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgaySinh.Location = new System.Drawing.Point(168, 206);
            this.dtNgaySinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(224, 22);
            this.dtNgaySinh.TabIndex = 29;
            // 
            // dtNgayVao
            // 
            this.dtNgayVao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgayVao.Location = new System.Drawing.Point(563, 155);
            this.dtNgayVao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtNgayVao.Name = "dtNgayVao";
            this.dtNgayVao.Size = new System.Drawing.Size(225, 22);
            this.dtNgayVao.TabIndex = 30;
            // 
            // cbVaiTro
            // 
            this.cbVaiTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbVaiTro.FormattingEnabled = true;
            this.cbVaiTro.Location = new System.Drawing.Point(563, 2);
            this.cbVaiTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbVaiTro.Name = "cbVaiTro";
            this.cbVaiTro.Size = new System.Drawing.Size(225, 24);
            this.cbVaiTro.TabIndex = 32;
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(563, 53);
            this.cbTrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(225, 24);
            this.cbTrangThai.TabIndex = 33;
            // 
            // txtViTri
            // 
            this.txtViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtViTri.Location = new System.Drawing.Point(168, 308);
            this.txtViTri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(224, 22);
            this.txtViTri.TabIndex = 34;
            // 
            // cbLoaiLuong
            // 
            this.cbLoaiLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLoaiLuong.FormattingEnabled = true;
            this.cbLoaiLuong.Location = new System.Drawing.Point(563, 206);
            this.cbLoaiLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLoaiLuong.Name = "cbLoaiLuong";
            this.cbLoaiLuong.Size = new System.Drawing.Size(225, 24);
            this.cbLoaiLuong.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cbLoaiLuong, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNgaySua, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNgayTao, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtNgayVao, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtViTri, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.dtNgaySinh, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtIDNhanVien, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbTrangThai, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNgaySua, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtPin, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNgayTao, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblVaiTro, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLoaiLuong, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtMaVanTay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNgayVao, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtHoTen, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPin, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSDT, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbVaiTro, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTrangThai, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDiaChi, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblMaNhanVien, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHoTen, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSDT, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lvlNgaySinh, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDiaChi, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.pnlButton, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 425);
            this.tableLayoutPanel1.TabIndex = 36;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnCancel);
            this.pnlButton.Controls.Add(this.btnOk);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.Location = new System.Drawing.Point(168, 359);
            this.pnlButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(224, 64);
            this.pnlButton.TabIndex = 37;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(127, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 47);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.BackColor = System.Drawing.Color.LightGreen;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(3, 15);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 47);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmNhanVienEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 425);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmNhanVienEdit";
            this.Text = "FrmNhanVienEdit";
            this.Load += new System.EventHandler(this.FrmNhanVienEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        public System.Windows.Forms.Label lblID;
        public System.Windows.Forms.Label lblMaNhanVien;
        public System.Windows.Forms.Label lblHoTen;
        public System.Windows.Forms.Label lblSDT;
        public System.Windows.Forms.Label lvlNgaySinh;
        public System.Windows.Forms.Label lblDiaChi;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblNgaySua;
        public System.Windows.Forms.Label lblNgayTao;
        public System.Windows.Forms.Label lblLoaiLuong;
        public System.Windows.Forms.Label lblNgayVao;
        public System.Windows.Forms.Label lblPin;
        public System.Windows.Forms.Label lblTrangThai;
        public System.Windows.Forms.Label lblVaiTro;
        public System.Windows.Forms.TextBox txtIDNhanVien;
        public System.Windows.Forms.TextBox txtMaVanTay;
        public System.Windows.Forms.TextBox txtHoTen;
        public System.Windows.Forms.TextBox txtSDT;
        public System.Windows.Forms.TextBox txtDiaChi;
        public System.Windows.Forms.TextBox txtNgaySua;
        public System.Windows.Forms.TextBox txtNgayTao;
        public System.Windows.Forms.TextBox txtPin;
        public System.Windows.Forms.DateTimePicker dtNgaySinh;
        public System.Windows.Forms.DateTimePicker dtNgayVao;
        public System.Windows.Forms.ComboBox cbVaiTro;
        public System.Windows.Forms.ComboBox cbTrangThai;
        public System.Windows.Forms.TextBox txtViTri;
        public System.Windows.Forms.ComboBox cbLoaiLuong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlButton;
    }
}