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
    public partial class fTinhTrangPhong : Form
    {
        DataGridViewCellMouseEventArgs vt;
        bool ktThem;
        int macu;

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        public fTinhTrangPhong()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT TinhTrang AS N'Tình Trạng Phòng', MaTinhTrang AS N'Mã Tình Trạng' FROM dbo.TinhTrang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            
            dgTinhTrang.DataSource = table;
            dgTinhTrang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void fTinhTrangPhong_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            KhoaMo(true);
            
        }


        public void XoaTrang()
        {
            txtTinhTrang.Text = "";
        }
        public void KhoaMo(bool b)
        {
            dgTinhTrang.Enabled = b;
            cmdThem.Enabled = b; cmdSua.Enabled = b; cmdXoa.Enabled = b; cmdKetThuc.Enabled = b;

            cmdGhi.Enabled = !b; cmdKhongGhi.Enabled = !b;

            txtTinhTrang.ReadOnly = b;
           
        }

        private void dgTinhTrang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (dgTinhTrang.RowCount <= 0) return;
            if (e.RowIndex >= 0)
            {
                vt = e;
                DataGridViewRow row = dgTinhTrang.Rows[e.RowIndex];
                txtTinhTrang.Text = row.Cells[0].Value.ToString();
               
            }
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            ktThem = true;
            XoaTrang();
            KhoaMo(false);
            txtTinhTrang.Focus();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (txtTinhTrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một tình trạng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (dgTinhTrang.SelectedRows.Count > 0)
            {
                ktThem = false;
                KhoaMo(false);
                txtTinhTrang.Focus();
                macu = dgTinhTrang.CurrentRow.Index;
            }
            
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (txtTinhTrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một tình trạng để xóa bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (dgTinhTrang.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa "+txtTinhTrang.Text+" không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = dgTinhTrang.SelectedRows[0].Index;
                    int selectedIndex = dgTinhTrang.SelectedRows[0].Index;
                    string maTT = dgTinhTrang.Rows[rowIndex].Cells[1].Value.ToString();
                    // xoa tinh trang o bang phong tro truoc
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM dbo.PhongTro WHERE MaTinhTrang = @maTT";
                    command.Parameters.AddWithValue("@maTT", maTT);
                    command.ExecuteNonQuery();

                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM dbo.TinhTrang WHERE TinhTrang = @tinhtrang";
                    command.Parameters.AddWithValue("@tinhtrang", dgTinhTrang.Rows[selectedIndex].Cells["Tình Trạng Phòng"].Value.ToString());
                    command.ExecuteNonQuery();

                    table.Rows.RemoveAt(selectedIndex);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XoaTrang();
                    loadData();
                    
                }
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtTinhTrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTinhTrang.Focus();
                return;
            }

            if (ktThem)
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO dbo.TinhTrang (TinhTrang) VALUES (@tinhtrang)";
                command.Parameters.AddWithValue("@tinhtrang", txtTinhTrang.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaTrang();
                loadData();
            }
            else
            {
                int selectedIndex = dgTinhTrang.SelectedRows[0].Index;

                command = connection.CreateCommand();
                command.CommandText = "UPDATE dbo.TinhTrang SET TinhTrang = @tinhtrang WHERE TinhTrang = @tinhtrangcu";
                command.Parameters.AddWithValue("@tinhtrang", txtTinhTrang.Text);
                command.Parameters.AddWithValue("@tinhtrangcu", dgTinhTrang.Rows[selectedIndex].Cells["Tình Trạng Phòng"].Value.ToString());
                command.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
