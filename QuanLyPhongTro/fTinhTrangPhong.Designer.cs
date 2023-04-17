namespace QuanLyPhongTro
{
    partial class fTinhTrangPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTinhTrangPhong));
            this.dgTinhTrang = new System.Windows.Forms.DataGridView();
            this.cmdKetThuc = new System.Windows.Forms.Button();
            this.cmdKhongGhi = new System.Windows.Forms.Button();
            this.cmdGhi = new System.Windows.Forms.Button();
            this.cmdXoa = new System.Windows.Forms.Button();
            this.cmdSua = new System.Windows.Forms.Button();
            this.cmdThem = new System.Windows.Forms.Button();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTinhTrang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTinhTrang
            // 
            this.dgTinhTrang.AllowUserToAddRows = false;
            this.dgTinhTrang.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgTinhTrang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTinhTrang.Location = new System.Drawing.Point(12, 68);
            this.dgTinhTrang.MultiSelect = false;
            this.dgTinhTrang.Name = "dgTinhTrang";
            this.dgTinhTrang.ReadOnly = true;
            this.dgTinhTrang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTinhTrang.Size = new System.Drawing.Size(843, 282);
            this.dgTinhTrang.TabIndex = 9;
            this.dgTinhTrang.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTinhTrang_CellMouseClick);
            // 
            // cmdKetThuc
            // 
            this.cmdKetThuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdKetThuc.Location = new System.Drawing.Point(721, 430);
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
            this.cmdKhongGhi.Location = new System.Drawing.Point(583, 430);
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
            this.cmdGhi.Location = new System.Drawing.Point(464, 430);
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
            this.cmdXoa.Location = new System.Drawing.Point(302, 430);
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
            this.cmdSua.Location = new System.Drawing.Point(167, 430);
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
            this.cmdThem.Location = new System.Drawing.Point(45, 430);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(92, 37);
            this.cmdThem.TabIndex = 3;
            this.cmdThem.Text = "Thêm";
            this.cmdThem.UseVisualStyleBackColor = true;
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinhTrang.Location = new System.Drawing.Point(200, 377);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(630, 29);
            this.txtTinhTrang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tình Trạng Phòng :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Tình Trạng Phòng ";
            // 
            // fTinhTrangPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTinhTrang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdKetThuc);
            this.Controls.Add(this.cmdKhongGhi);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.cmdXoa);
            this.Controls.Add(this.cmdSua);
            this.Controls.Add(this.cmdThem);
            this.Controls.Add(this.dgTinhTrang);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fTinhTrangPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Tình Trạng Phòng";
            this.Load += new System.EventHandler(this.fTinhTrangPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTinhTrang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTinhTrang;
        private System.Windows.Forms.Button cmdKetThuc;
        private System.Windows.Forms.Button cmdKhongGhi;
        private System.Windows.Forms.Button cmdGhi;
        private System.Windows.Forms.Button cmdXoa;
        private System.Windows.Forms.Button cmdSua;
        private System.Windows.Forms.Button cmdThem;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}