namespace QuanLyPhongTro
{
    partial class fQLTinhTrangThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fQLTinhTrangThanhToan));
            this.dgLoaiThanhToan = new System.Windows.Forms.DataGridView();
            this.txtLoaiThanhToan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdKetThuc = new System.Windows.Forms.Button();
            this.cmdKhongGhi = new System.Windows.Forms.Button();
            this.cmdGhi = new System.Windows.Forms.Button();
            this.cmdXoa = new System.Windows.Forms.Button();
            this.cmdSua = new System.Windows.Forms.Button();
            this.cmdThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoaiThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLoaiThanhToan
            // 
            this.dgLoaiThanhToan.AllowUserToAddRows = false;
            this.dgLoaiThanhToan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgLoaiThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLoaiThanhToan.Location = new System.Drawing.Point(12, 82);
            this.dgLoaiThanhToan.MultiSelect = false;
            this.dgLoaiThanhToan.Name = "dgLoaiThanhToan";
            this.dgLoaiThanhToan.ReadOnly = true;
            this.dgLoaiThanhToan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLoaiThanhToan.Size = new System.Drawing.Size(860, 282);
            this.dgLoaiThanhToan.TabIndex = 9;
            this.dgLoaiThanhToan.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgLoaiThanhToan_CellMouseClick);
            // 
            // txtLoaiThanhToan
            // 
            this.txtLoaiThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoaiThanhToan.Location = new System.Drawing.Point(167, 399);
            this.txtLoaiThanhToan.Name = "txtLoaiThanhToan";
            this.txtLoaiThanhToan.Size = new System.Drawing.Size(668, 29);
            this.txtLoaiThanhToan.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại Thanh Toán :";
            // 
            // cmdKetThuc
            // 
            this.cmdKetThuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdKetThuc.Location = new System.Drawing.Point(734, 452);
            this.cmdKetThuc.Name = "cmdKetThuc";
            this.cmdKetThuc.Size = new System.Drawing.Size(101, 37);
            this.cmdKetThuc.TabIndex = 8;
            this.cmdKetThuc.Text = "Kết thúc";
            this.cmdKetThuc.UseVisualStyleBackColor = true;
            this.cmdKetThuc.Click += new System.EventHandler(this.cmdKetThuc_Click);
            // 
            // cmdKhongGhi
            // 
            this.cmdKhongGhi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdKhongGhi.Location = new System.Drawing.Point(596, 452);
            this.cmdKhongGhi.Name = "cmdKhongGhi";
            this.cmdKhongGhi.Size = new System.Drawing.Size(109, 37);
            this.cmdKhongGhi.TabIndex = 7;
            this.cmdKhongGhi.Text = "Không ghi";
            this.cmdKhongGhi.UseVisualStyleBackColor = true;
            this.cmdKhongGhi.Click += new System.EventHandler(this.cmdKhongGhi_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGhi.Location = new System.Drawing.Point(477, 452);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(92, 37);
            this.cmdGhi.TabIndex = 6;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.UseVisualStyleBackColor = true;
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // cmdXoa
            // 
            this.cmdXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXoa.Location = new System.Drawing.Point(315, 452);
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Size = new System.Drawing.Size(101, 37);
            this.cmdXoa.TabIndex = 5;
            this.cmdXoa.Text = "Xóa bỏ";
            this.cmdXoa.UseVisualStyleBackColor = true;
            this.cmdXoa.Click += new System.EventHandler(this.cmdXoa_Click);
            // 
            // cmdSua
            // 
            this.cmdSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSua.Location = new System.Drawing.Point(180, 452);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(105, 37);
            this.cmdSua.TabIndex = 4;
            this.cmdSua.Text = "Cập nhật";
            this.cmdSua.UseVisualStyleBackColor = true;
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // cmdThem
            // 
            this.cmdThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThem.Location = new System.Drawing.Point(58, 452);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(92, 37);
            this.cmdThem.TabIndex = 3;
            this.cmdThem.Text = "Thêm";
            this.cmdThem.UseVisualStyleBackColor = true;
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Tình Trạng Thanh Toán Hóa Đơn ";
            // 
            // fQLTinhTrangThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLoaiThanhToan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdKetThuc);
            this.Controls.Add(this.cmdKhongGhi);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.cmdXoa);
            this.Controls.Add(this.cmdSua);
            this.Controls.Add(this.cmdThem);
            this.Controls.Add(this.dgLoaiThanhToan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fQLTinhTrangThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Tình Trạng Thanh Toán Hóa Đơn";
            this.Load += new System.EventHandler(this.fQLTinhTrangThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLoaiThanhToan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLoaiThanhToan;
        private System.Windows.Forms.TextBox txtLoaiThanhToan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdKetThuc;
        private System.Windows.Forms.Button cmdKhongGhi;
        private System.Windows.Forms.Button cmdGhi;
        private System.Windows.Forms.Button cmdXoa;
        private System.Windows.Forms.Button cmdSua;
        private System.Windows.Forms.Button cmdThem;
        private System.Windows.Forms.Label label1;
    }
}