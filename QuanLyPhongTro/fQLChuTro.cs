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

using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace QuanLyPhongTro
{
    
    public partial class fQLChuTro : Form
    {
        DataGridViewCellMouseEventArgs vt;
        bool ktThem;
        int macu;

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table= new DataTable();


        public void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT HoTen AS N'Họ Tên',SDT AS N'Số Điện Thoại', DiaChi AS N'Địa Chỉ', GhiChu AS N'Ghi Chú', IDCT FROM dbo.ChuTro";
            adapter.SelectCommand= command;
            table.Clear();
            adapter.Fill(table);

            dgDanhSach.DataSource = table;
            dgDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        public fQLChuTro()
        {
            InitializeComponent();
        }

        private void fQLChuTro_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            KhoaMo(true);
            
        }

        public void XoaTrang()
        {
            txtID.Text = ""; txtHoTen.Text = "";txtSDT.Text = "";
            txtDiaChi.Text = "";txtGhiChu.Text = "";
        }

        public void KhoaMo(bool b)
        {
            dgDanhSach.Enabled = b;
            cmdThem.Enabled= b; cmdSua.Enabled= b; cmdXoa.Enabled= b; cmdKetThuc.Enabled= b;

            cmdGhi.Enabled= !b; cmdKhongGhi.Enabled= !b;

            txtHoTen.ReadOnly = b; txtSDT.ReadOnly = b; txtDiaChi.ReadOnly= b; txtGhiChu.ReadOnly= b;

        }

        private void dgDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgDanhSach.RowCount <= 0 ) return;
            if(e.RowIndex >= 0)
            {
                vt = e;
                DataGridViewRow row = dgDanhSach.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells[0].Value.ToString();
                txtSDT.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                txtGhiChu.Text = row.Cells[3].Value.ToString();

            }
        }
        private void cmdThem_Click(object sender, EventArgs e)
        {

            ktThem = true;
            XoaTrang();
            KhoaMo(false);
            txtHoTen.Focus();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {

            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một trường để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (dgDanhSach.SelectedRows.Count > 0)
            {
                ktThem = false;
                KhoaMo(false);
                txtHoTen.Focus();
                macu = dgDanhSach.CurrentRow.Index;
            }
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một trường để xóa bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (dgDanhSach.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa chủ trọ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = dgDanhSach.SelectedRows[0].Index;

                    string maChuTro = dgDanhSach.Rows[rowIndex].Cells[0].Value.ToString();
                    string id = dgDanhSach.Rows[rowIndex].Cells[4].Value.ToString();
                    command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM dbo.HopDong WHERE IDCT=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM dbo.ChuTro WHERE HoTen=@hoten";
                    command.Parameters.AddWithValue("@hoten", maChuTro);
                    command.ExecuteNonQuery();

                    table.Rows.RemoveAt(rowIndex);
                    dgDanhSach.DataSource = table;
                    XoaTrang();
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (ktThem == true)
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO dbo.ChuTro(HoTen,SDT,DiaChi,GhiChu) VALUES(@hoten,@sdt,@diachi,@ghichu)";
                command.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                command.Parameters.AddWithValue("@sdt", txtSDT.Text);
                command.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                command.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                command.ExecuteNonQuery();
                loadData();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int rowIndex = dgDanhSach.SelectedRows[0].Index;
                string maChuTro = dgDanhSach.Rows[rowIndex].Cells[0].Value.ToString();

                command = connection.CreateCommand();
                command.CommandText = "UPDATE dbo.ChuTro SET HoTen=@hoten, SDT=@sdt, DiaChi=@diachi, GhiChu=@ghichu WHERE HoTen=@macu";
                command.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                command.Parameters.AddWithValue("@sdt", txtSDT.Text);
                command.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                command.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                command.Parameters.AddWithValue("@macu", maChuTro);
                command.ExecuteNonQuery();

                dgDanhSach.Rows[rowIndex].Cells[0].Value = txtHoTen.Text;
                dgDanhSach.Rows[rowIndex].Cells[1].Value = txtSDT.Text;
                dgDanhSach.Rows[rowIndex].Cells[2].Value = txtDiaChi.Text;
                dgDanhSach.Rows[rowIndex].Cells[3].Value = txtGhiChu.Text;
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                    
            };
        }

        private void cmdKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
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
