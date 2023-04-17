namespace QuanLyPhongTro
{
    partial class fLapHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLapHoaDon));
            this.chkHienThi = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgHopDong = new System.Windows.Forms.DataGridView();
            this.dgHoaDon = new System.Windows.Forms.DataGridView();
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKhach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTienGiam = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTienKhachTra = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbTinhTrangHD = new System.Windows.Forms.ComboBox();
            this.cmdXoaSoLuong = new System.Windows.Forms.Button();
            this.cmdTinhTien = new System.Windows.Forms.Button();
            this.cmdKetThuc = new System.Windows.Forms.Button();
            this.cmdKhongGhi = new System.Windows.Forms.Button();
            this.cmdGhi = new System.Windows.Forms.Button();
            this.cmdXoa = new System.Windows.Forms.Button();
            this.cmdSua = new System.Windows.Forms.Button();
            this.cmdThem = new System.Windows.Forms.Button();
            this.lvwDichVu = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // chkHienThi
            // 
            this.chkHienThi.AutoSize = true;
            this.chkHienThi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienThi.Location = new System.Drawing.Point(268, 24);
            this.chkHienThi.Name = "chkHienThi";
            this.chkHienThi.Size = new System.Drawing.Size(124, 25);
            this.chkHienThi.TabIndex = 2;
            this.chkHienThi.Text = "Hiển thị tất cả";
            this.chkHienThi.UseVisualStyleBackColor = true;
            this.chkHienThi.CheckedChanged += new System.EventHandler(this.chkHienThi_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm :";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(104, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(145, 29);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // dgHopDong
            // 
            this.dgHopDong.AllowUserToAddRows = false;
            this.dgHopDong.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHopDong.Location = new System.Drawing.Point(19, 85);
            this.dgHopDong.Name = "dgHopDong";
            this.dgHopDong.ReadOnly = true;
            this.dgHopDong.Size = new System.Drawing.Size(419, 248);
            this.dgHopDong.TabIndex = 37;
            this.dgHopDong.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgHopDong_CellMouseClick);
            // 
            // dgHoaDon
            // 
            this.dgHoaDon.AllowUserToAddRows = false;
            this.dgHoaDon.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHoaDon.Location = new System.Drawing.Point(19, 370);
            this.dgHoaDon.Name = "dgHoaDon";
            this.dgHoaDon.ReadOnly = true;
            this.dgHoaDon.Size = new System.Drawing.Size(419, 226);
            this.dgHoaDon.TabIndex = 38;
            this.dgHoaDon.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgHoaDon_CellMouseClick);
            // 
            // txtSoHD
            // 
            this.txtSoHD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHD.Location = new System.Drawing.Point(523, 88);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.ReadOnly = true;
            this.txtSoHD.Size = new System.Drawing.Size(151, 29);
            this.txtSoHD.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(456, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "Số HĐ :";
            // 
            // txtPhong
            // 
            this.txtPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhong.Location = new System.Drawing.Point(748, 88);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.ReadOnly = true;
            this.txtPhong.Size = new System.Drawing.Size(167, 29);
            this.txtPhong.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(682, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 24;
            this.label2.Text = "Phòng :";
            // 
            // txtKhach
            // 
            this.txtKhach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhach.Location = new System.Drawing.Point(983, 88);
            this.txtKhach.Name = "txtKhach";
            this.txtKhach.ReadOnly = true;
            this.txtKhach.Size = new System.Drawing.Size(197, 29);
            this.txtKhach.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(921, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "Khách :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(665, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 47);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quản Lý Hóa Đơn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(455, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 28;
            this.label5.Text = "Thông tin hóa đơn";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(456, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 21);
            this.label11.TabIndex = 29;
            this.label11.Text = "Ngày lập :";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(541, 152);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(187, 29);
            this.dtpNgayLap.TabIndex = 30;
            this.dtpNgayLap.Value = new System.DateTime(2023, 3, 5, 0, 0, 0, 0);
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaTien.Location = new System.Drawing.Point(983, 152);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.ReadOnly = true;
            this.txtGiaTien.Size = new System.Drawing.Size(197, 29);
            this.txtGiaTien.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(827, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 21);
            this.label7.TabIndex = 31;
            this.label7.Text = "Giá tiền thuê phòng :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(457, 403);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 21);
            this.label8.TabIndex = 4;
            this.label8.Text = "Tiền được giảm :";
            // 
            // txtTienGiam
            // 
            this.txtTienGiam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienGiam.Location = new System.Drawing.Point(587, 396);
            this.txtTienGiam.Name = "txtTienGiam";
            this.txtTienGiam.Size = new System.Drawing.Size(230, 29);
            this.txtTienGiam.TabIndex = 5;
            this.txtTienGiam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienGiam_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(457, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 21);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tiền phạt :";
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienPhat.Location = new System.Drawing.Point(587, 435);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(230, 29);
            this.txtTienPhat.TabIndex = 7;
            this.txtTienPhat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienPhat_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(457, 483);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Tổng số tiền thu :";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(587, 476);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(230, 29);
            this.txtTongTien.TabIndex = 9;
            this.txtTongTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongTien_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(457, 523);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 21);
            this.label12.TabIndex = 14;
            this.label12.Text = "Ghi chú :";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(587, 516);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(596, 29);
            this.txtGhiChu.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(834, 446);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 21);
            this.label13.TabIndex = 10;
            this.label13.Text = "Số tiền khách trả :";
            // 
            // txtTienKhachTra
            // 
            this.txtTienKhachTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachTra.Location = new System.Drawing.Point(982, 438);
            this.txtTienKhachTra.Name = "txtTienKhachTra";
            this.txtTienKhachTra.Size = new System.Drawing.Size(198, 29);
            this.txtTienKhachTra.TabIndex = 11;
            this.txtTienKhachTra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienKhachTra_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(834, 483);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 21);
            this.label14.TabIndex = 12;
            this.label14.Text = "Tình trạng hóa đơn :";
            // 
            // cbTinhTrangHD
            // 
            this.cbTinhTrangHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTinhTrangHD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTinhTrangHD.FormattingEnabled = true;
            this.cbTinhTrangHD.Location = new System.Drawing.Point(981, 476);
            this.cbTinhTrangHD.Name = "cbTinhTrangHD";
            this.cbTinhTrangHD.Size = new System.Drawing.Size(200, 29);
            this.cbTinhTrangHD.TabIndex = 13;
            // 
            // cmdXoaSoLuong
            // 
            this.cmdXoaSoLuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXoaSoLuong.Location = new System.Drawing.Point(838, 390);
            this.cmdXoaSoLuong.Name = "cmdXoaSoLuong";
            this.cmdXoaSoLuong.Size = new System.Drawing.Size(142, 35);
            this.cmdXoaSoLuong.TabIndex = 35;
            this.cmdXoaSoLuong.Text = "Xóa số lượng";
            this.cmdXoaSoLuong.UseVisualStyleBackColor = true;
            this.cmdXoaSoLuong.Click += new System.EventHandler(this.cmdXoaSoLuong_Click);
            // 
            // cmdTinhTien
            // 
            this.cmdTinhTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTinhTien.Location = new System.Drawing.Point(1026, 390);
            this.cmdTinhTien.Name = "cmdTinhTien";
            this.cmdTinhTien.Size = new System.Drawing.Size(155, 35);
            this.cmdTinhTien.TabIndex = 36;
            this.cmdTinhTien.Text = "Tính tiền hóa đơn";
            this.cmdTinhTien.UseVisualStyleBackColor = true;
            this.cmdTinhTien.Click += new System.EventHandler(this.cmdTinhTien_Click);
            // 
            // cmdKetThuc
            // 
            this.cmdKetThuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdKetThuc.Location = new System.Drawing.Point(1090, 563);
            this.cmdKetThuc.Name = "cmdKetThuc";
            this.cmdKetThuc.Size = new System.Drawing.Size(86, 33);
            this.cmdKetThuc.TabIndex = 21;
            this.cmdKetThuc.Text = "Kết thúc";
            this.cmdKetThuc.UseVisualStyleBackColor = true;
            this.cmdKetThuc.Click += new System.EventHandler(this.cmdKetThuc_Click);
            // 
            // cmdKhongGhi
            // 
            this.cmdKhongGhi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdKhongGhi.Location = new System.Drawing.Point(971, 563);
            this.cmdKhongGhi.Name = "cmdKhongGhi";
            this.cmdKhongGhi.Size = new System.Drawing.Size(94, 33);
            this.cmdKhongGhi.TabIndex = 20;
            this.cmdKhongGhi.Text = "Không ghi";
            this.cmdKhongGhi.UseVisualStyleBackColor = true;
            this.cmdKhongGhi.Click += new System.EventHandler(this.cmdKhongGhi_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGhi.Location = new System.Drawing.Point(869, 563);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(77, 33);
            this.cmdGhi.TabIndex = 19;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.UseVisualStyleBackColor = true;
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // cmdXoa
            // 
            this.cmdXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXoa.Location = new System.Drawing.Point(758, 563);
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Size = new System.Drawing.Size(86, 33);
            this.cmdXoa.TabIndex = 18;
            this.cmdXoa.Text = "Xóa bỏ";
            this.cmdXoa.UseVisualStyleBackColor = true;
            this.cmdXoa.Click += new System.EventHandler(this.cmdXoa_Click);
            // 
            // cmdSua
            // 
            this.cmdSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSua.Location = new System.Drawing.Point(643, 563);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(90, 33);
            this.cmdSua.TabIndex = 17;
            this.cmdSua.Text = "Cập nhật";
            this.cmdSua.UseVisualStyleBackColor = true;
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // cmdThem
            // 
            this.cmdThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThem.Location = new System.Drawing.Point(479, 563);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(140, 33);
            this.cmdThem.TabIndex = 16;
            this.cmdThem.Text = "Thêm hóa đơn mới";
            this.cmdThem.UseVisualStyleBackColor = true;
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // lvwDichVu
            // 
            this.lvwDichVu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.column3,
            this.column4,
            this.column5});
            this.lvwDichVu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDichVu.FullRowSelect = true;
            this.lvwDichVu.GridLines = true;
            this.lvwDichVu.HideSelection = false;
            this.lvwDichVu.Location = new System.Drawing.Point(461, 195);
            this.lvwDichVu.Name = "lvwDichVu";
            this.lvwDichVu.Size = new System.Drawing.Size(720, 176);
            this.lvwDichVu.TabIndex = 33;
            this.lvwDichVu.UseCompatibleStateImageBehavior = false;
            this.lvwDichVu.View = System.Windows.Forms.View.Details;
            this.lvwDichVu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwDichVu_MouseUp);
            // 
            // column1
            // 
            this.column1.Text = "Mã DV";
            this.column1.Width = 63;
            // 
            // column2
            // 
            this.column2.Text = "Dịch Vụ";
            this.column2.Width = 199;
            // 
            // column3
            // 
            this.column3.Text = "Giá Tiền";
            this.column3.Width = 182;
            // 
            // column4
            // 
            this.column4.Text = "Số Lượng";
            this.column4.Width = 112;
            // 
            // column5
            // 
            this.column5.Text = "Thành Tiền";
            this.column5.Width = 159;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(907, 220);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(112, 27);
            this.txtSoLuong.TabIndex = 34;
            this.txtSoLuong.Visible = false;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            this.txtSoLuong.Leave += new System.EventHandler(this.txtSoLuong_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(21, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 21);
            this.label15.TabIndex = 39;
            this.label15.Text = "Chọn hợp đồng :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(21, 347);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 21);
            this.label16.TabIndex = 40;
            this.label16.Text = "Chọn hóa đơn :";
            // 
            // fLapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 616);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lvwDichVu);
            this.Controls.Add(this.cmdKetThuc);
            this.Controls.Add(this.cmdKhongGhi);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.cmdXoa);
            this.Controls.Add(this.cmdSua);
            this.Controls.Add(this.cmdThem);
            this.Controls.Add(this.cmdTinhTien);
            this.Controls.Add(this.cmdXoaSoLuong);
            this.Controls.Add(this.cbTinhTrangHD);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTienKhachTra);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTienPhat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTienGiam);
            this.Controls.Add(this.txtGiaTien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpNgayLap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKhach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoHD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgHoaDon);
            this.Controls.Add(this.dgHopDong);
            this.Controls.Add(this.chkHienThi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fLapHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập hóa đơn thanh toán";
            this.Load += new System.EventHandler(this.fLapHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHienThi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgHopDong;
        private System.Windows.Forms.DataGridView dgHoaDon;
        private System.Windows.Forms.TextBox txtSoHD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKhach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTienGiam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTienKhachTra;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbTinhTrangHD;
        private System.Windows.Forms.Button cmdXoaSoLuong;
        private System.Windows.Forms.Button cmdTinhTien;
        private System.Windows.Forms.Button cmdKetThuc;
        private System.Windows.Forms.Button cmdKhongGhi;
        private System.Windows.Forms.Button cmdGhi;
        private System.Windows.Forms.Button cmdXoa;
        private System.Windows.Forms.Button cmdSua;
        private System.Windows.Forms.Button cmdThem;
        private System.Windows.Forms.ListView lvwDichVu;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.ColumnHeader column4;
        private System.Windows.Forms.ColumnHeader column5;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}