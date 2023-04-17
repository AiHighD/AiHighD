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
    public partial class fQLTinhTrangThanhToan : Form
    {
        DataGridViewCellMouseEventArgs vt;
        bool ktThem;
        int macu;

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public fQLTinhTrangThanhToan()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT LoaiThanhToan AS N'Loại Thanh Toán', IDTT FROM dbo.ThanhToan";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            
            dgLoaiThanhToan.DataSource = table;
            dgLoaiThanhToan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void XoaTrang()
        {
            txtLoaiThanhToan.Text = "";
        }
        public void KhoaMo(bool b)
        {
            dgLoaiThanhToan.Enabled = b;
            cmdThem.Enabled = b; cmdSua.Enabled = b; cmdXoa.Enabled = b; cmdKetThuc.Enabled = b;

            cmdGhi.Enabled = !b; cmdKhongGhi.Enabled = !b;

            txtLoaiThanhToan.ReadOnly = b;

        }

        private void fQLTinhTrangThanhToan_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            KhoaMo(true);
            
        }

        private void dgLoaiThanhToan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgLoaiThanhToan.RowCount <= 0) return;
            if (e.RowIndex >= 0)
            {
                vt = e;
                DataGridViewRow row = dgLoaiThanhToan.Rows[e.RowIndex];
                txtLoaiThanhToan.Text = row.Cells[0].Value.ToString();

            }
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            ktThem = true;
            XoaTrang();
            KhoaMo(false);
            txtLoaiThanhToan.Focus();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (txtLoaiThanhToan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một tình trạng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (dgLoaiThanhToan.SelectedRows.Count > 0)
            {
                ktThem = false;
                KhoaMo(false);
                txtLoaiThanhToan.Focus();
                macu = dgLoaiThanhToan.CurrentRow.Index;
            }

        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (txtLoaiThanhToan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một tình trạng để xóa bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (dgLoaiThanhToan.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa " + txtLoaiThanhToan.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int selectedIndex = dgLoaiThanhToan.SelectedRows[0].Index;

                    command = connection.CreateCommand();
                    command.CommandText = "SELECT COUNT(*) FROM dbo.HoaDon WHERE IDTT= @idTT";
                    command.Parameters.AddWithValue("@idTT", dgLoaiThanhToan.Rows[selectedIndex].Cells["IDTT"].Value.ToString());
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa bảng ghi này vì nó đang được sử dụng trong bảng Hóa đơn.");
                    }
                    else{ 
                    // xoa tinh trang thanh toan
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM dbo.ThanhToan WHERE LoaiThanhToan = @loaithanhtoan";
                    command.Parameters.AddWithValue("@loaithanhtoan", dgLoaiThanhToan.Rows[selectedIndex].Cells["Loại Thanh Toán"].Value.ToString());
                    command.ExecuteNonQuery();
                    table.Rows.RemoveAt(selectedIndex);

                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XoaTrang();
                    loadData();

                    }
                }
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtLoaiThanhToan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaiThanhToan.Focus();
                return;
            }

            if (ktThem)
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO dbo.ThanhToan (LoaiThanhToan) VALUES (@loaithanhtoan)";
                command.Parameters.AddWithValue("@loaithanhtoan", txtLoaiThanhToan.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaTrang();
                loadData();
            }
            else
            {
                int selectedIndex = dgLoaiThanhToan.SelectedRows[0].Index;

                command = connection.CreateCommand();
                command.CommandText = "UPDATE dbo.ThanhToan SET LoaiThanhToan = @loaithanhtoan WHERE LoaiThanhToan = @loaithanhtoancu";
                command.Parameters.AddWithValue("@loaithanhtoan", txtLoaiThanhToan.Text);
                command.Parameters.AddWithValue("@loaithanhtoancu", dgLoaiThanhToan.Rows[selectedIndex].Cells["Loại Thanh Toán"].Value.ToString());
                command.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công !" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaTrang();
                loadData();
            }

            KhoaMo(true);
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
    }
}
