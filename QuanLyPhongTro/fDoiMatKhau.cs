using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyPhongTro
{
    public partial class fDoiMatKhau : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True");


        public fDoiMatKhau()
        {
            InitializeComponent();
        }

        public void XoaTrang()
        {
            txtAccount.Text = ""; txtMkCu.Text = ""; txtMkMoi.Text = "";
            txtNhapLaiMkMoi.Text = ""; 
        }

        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            txtAccount.Focus();
            if (string.IsNullOrEmpty(txtAccount.Text) || string.IsNullOrEmpty(txtMkCu.Text) || txtMkMoi.Text.Trim().Length == 0 || txtNhapLaiMkMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMkMoi.Text == txtMkCu.Text)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu cũ không được giống nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMkMoi.Text != txtNhapLaiMkMoi.Text)
            {
                MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu mới không khớp nhau!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Account SET PassWord = @newPassword WHERE UserName = @userName AND Password = @oldPassword", cn);
                cmd.Parameters.AddWithValue("@userName", txtAccount.Text);
                cmd.Parameters.AddWithValue("@oldPassword", txtMkCu.Text);
                cmd.Parameters.AddWithValue("@newPassword", txtMkMoi.Text);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    XoaTrang();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu cũ không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        private void btHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void pnDoiMatKhau_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
