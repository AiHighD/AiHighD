namespace QuanLyPhongTro
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.pnLogin = new System.Windows.Forms.Panel();
            this.btExit = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.pnPW = new System.Windows.Forms.Panel();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.lbPassWord = new System.Windows.Forms.Label();
            this.pnTenDN = new System.Windows.Forms.Panel();
            this.txbLogin = new System.Windows.Forms.TextBox();
            this.lbLogin = new System.Windows.Forms.Label();
            this.pnLogin.SuspendLayout();
            this.pnPW.SuspendLayout();
            this.pnTenDN.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLogin
            // 
            this.pnLogin.Controls.Add(this.btExit);
            this.pnLogin.Controls.Add(this.btLogin);
            this.pnLogin.Controls.Add(this.pnPW);
            this.pnLogin.Controls.Add(this.pnTenDN);
            this.pnLogin.Location = new System.Drawing.Point(12, 12);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(395, 157);
            this.pnLogin.TabIndex = 0;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(279, 121);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(165, 121);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "Đăng nhập";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // pnPW
            // 
            this.pnPW.Controls.Add(this.txbPassWord);
            this.pnPW.Controls.Add(this.lbPassWord);
            this.pnPW.Location = new System.Drawing.Point(3, 57);
            this.pnPW.Name = "pnPW";
            this.pnPW.Size = new System.Drawing.Size(389, 47);
            this.pnPW.TabIndex = 2;
            // 
            // txbPassWord
            // 
            this.txbPassWord.Location = new System.Drawing.Point(119, 16);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(250, 20);
            this.txbPassWord.TabIndex = 1;
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // lbPassWord
            // 
            this.lbPassWord.AutoSize = true;
            this.lbPassWord.Location = new System.Drawing.Point(12, 19);
            this.lbPassWord.Name = "lbPassWord";
            this.lbPassWord.Size = new System.Drawing.Size(58, 13);
            this.lbPassWord.TabIndex = 0;
            this.lbPassWord.Text = "Mật khẩu :";
            // 
            // pnTenDN
            // 
            this.pnTenDN.Controls.Add(this.txbLogin);
            this.pnTenDN.Controls.Add(this.lbLogin);
            this.pnTenDN.Location = new System.Drawing.Point(3, 3);
            this.pnTenDN.Name = "pnTenDN";
            this.pnTenDN.Size = new System.Drawing.Size(389, 48);
            this.pnTenDN.TabIndex = 0;
            // 
            // txbLogin
            // 
            this.txbLogin.Location = new System.Drawing.Point(119, 16);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(250, 20);
            this.txbLogin.TabIndex = 1;
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(12, 19);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(87, 13);
            this.lbLogin.TabIndex = 0;
            this.lbLogin.Text = "Tên đăng nhập :";
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 174);
            this.Controls.Add(this.pnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.Load += new System.EventHandler(this.fLogin_Load);
            this.pnLogin.ResumeLayout(false);
            this.pnPW.ResumeLayout(false);
            this.pnPW.PerformLayout();
            this.pnTenDN.ResumeLayout(false);
            this.pnTenDN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Panel pnPW;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Label lbPassWord;
        private System.Windows.Forms.Panel pnTenDN;
        private System.Windows.Forms.TextBox txbLogin;
        private System.Windows.Forms.Label lbLogin;
    }
}

