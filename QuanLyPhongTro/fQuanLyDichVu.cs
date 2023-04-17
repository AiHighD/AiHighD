using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class fQuanLyDichVu : Form
    {

        DataGridViewCellMouseEventArgs vt;
        bool ktThem;
        string macu = "";

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        public fQuanLyDichVu()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT TenDichVu AS N'Tên Dịch Vụ', SoTien AS N'Số Tiền', GhiChu AS N'Ghi Chú' FROM dbo.DichVu";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgDichVu.DataSource = table;
            dgDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void XoaTrang()
        {
            txtTenDichVu.Text = ""; txtSoTien.Text = ""; txtGhiChu.Text = "";
        }
        public void KhoaMo(bool b)
        {
            dgDichVu.Enabled = b;
            cmdThem.Enabled = b; cmdSua.Enabled = b; cmdXoa.Enabled = b; cmdKetThuc.Enabled = b;

            cmdGhi.Enabled = !b; cmdKhongGhi.Enabled = !b;

            txtTenDichVu.ReadOnly = b; txtSoTien.ReadOnly = b; txtGhiChu.ReadOnly = b;

        }

        private void dgDichVu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDichVu.RowCount <= 0) return;
            if (e.RowIndex >= 0)
            {
                vt = e;
                DataGridViewRow row = dgDichVu.Rows[e.RowIndex];
                txtTenDichVu.Text = row.Cells[0].Value.ToString();
                txtSoTien.Text = row.Cells[1].Value.ToString();
                txtGhiChu.Text = row.Cells[2].Value.ToString();
            }
        }

        private void fQuanLyDichVu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            KhoaMo(true);
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            ktThem = true;
            XoaTrang();
            KhoaMo(false);
            txtTenDichVu.Focus();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (txtTenDichVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (txtTenDichVu.Text == " ") return;
            {
                ktThem = false;
                macu = txtTenDichVu.Text;
                KhoaMo(false);
                txtTenDichVu.Focus();
            }
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (txtTenDichVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ để xóa bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTenDichVu.Text ==" ") return;

            DialogResult result = MessageBox.Show("Bạn có muốn xóa dịch vụ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Connect to the database
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();

                        // Create a SQL command to delete the row
                        SqlCommand cmd = new SqlCommand("DELETE FROM DichVu WHERE TenDichVu=@TenDichVu", conn);
                        cmd.Parameters.AddWithValue("@TenDichVu", txtTenDichVu.Text);

                        // Execute the command
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bản ghi này đã được sử dụng trong Chi Tiết Hóa Đơn !");
                }
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtTenDichVu.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDichVu.Focus();
                return;
            }
            if (txtSoTien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoTien.Focus();
                return;
            }
            

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                // Create a SQL command
                SqlCommand cmd;

                if (ktThem)
                {
                    
                    // Insert new row
                    cmd = new SqlCommand("INSERT INTO DichVu (TenDichVu, SoTien, GhiChu) VALUES (@TenDichVu, @SoTien, @GhiChu)", conn);
                }
                else
                {
                    // Update existing row
                    cmd = new SqlCommand("UPDATE DichVu SET TenDichVu=@TenDichVu, SoTien=@SoTien, GhiChu=@GhiChu WHERE TenDichVu=@MaCu", conn);
                    cmd.Parameters.AddWithValue("@MaCu", macu);
                }

                // Set command parameters
                cmd.Parameters.AddWithValue("@TenDichVu", txtTenDichVu.Text);
                cmd.Parameters.AddWithValue("@SoTien", txtSoTien.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                // Execute the command
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Lưu thông tin dịch vụ thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    XoaTrang();
                    KhoaMo(true);
                }

            }

        }

        private void cmdKhongGhi_Click(object sender, EventArgs e)
        {
            try
            {
                XoaTrang();
                KhoaMo(true);
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void cmdKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Ký tự bạn nhập không hợp lệ");
                e.Handled = true; // Bỏ qua ký tự không hợp lệ
            }
        }
    }
}
