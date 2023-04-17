using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyPhongTro
{
    public partial class fThongTinPhong : Form
    {
       

        DataGridViewCellMouseEventArgs vt;
        bool ktThem;
        string macu=" ";


        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public void loadData()
        {
            connection = new SqlConnection(str);
            command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"
            SELECT PhongTro.MaPhong AS N'Mã Phòng', TinhTrang.TinhTrang AS N'Tình Trạng', 
            PhongTro.ThongTin AS N'Thông Tin', PhongTro.GiaPhong AS N'Giá Phòng', 
            PhongTro.GhiChu AS N'Ghi Chú'
            FROM PhongTro
            INNER JOIN TinhTrang ON PhongTro.MaTinhTrang = TinhTrang.MaTinhTrang";

            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgQLPhong.DataSource = table;
            dgQLPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                            

        }

        public void XoaTrang()
        {
            txtMaPhong.Text = ""; txtGiaPhong.Text = ""; txtThongTin.Text = "";
            txtGhiChu.Text = "";
        }

        private void dgQLPhong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgQLPhong.RowCount <= 0) return;
            if (e.RowIndex >= 0)
            {
                vt = e;
                DataGridViewRow row = dgQLPhong.Rows[e.RowIndex];
                txtMaPhong.Text = row.Cells[0].Value.ToString();
                cbTinhTrang.Text = row.Cells[1].Value.ToString();
                txtThongTin.Text = row.Cells[2].Value.ToString();
                txtGiaPhong.Text = row.Cells[3].Value.ToString();
                txtGhiChu.Text = row.Cells[4].Value.ToString();
            }
        }

        public void KhoaMo(bool b)
        {
            dgQLPhong.Enabled = b;
            cmdThem.Enabled = b; cmdSua.Enabled = b; cmdXoa.Enabled = b; cmdKetThuc.Enabled = b;

            cmdGhi.Enabled = !b; cmdKhongGhi.Enabled = !b;

            txtMaPhong.ReadOnly = b; txtThongTin.ReadOnly = b; txtGiaPhong.ReadOnly = b; txtGhiChu.ReadOnly = b;

            cbTinhTrang.Enabled = !b;

            txtTimKiem.ReadOnly= !b;
        }

        public fThongTinPhong()
        {
            InitializeComponent();
        }

        private void fThongTinPhong_Load(object sender, EventArgs e)
        {
            KhoaMo(true);
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            LoadDataToComboBox();


        }

        public void TimKiem()
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = "SELECT PhongTro.MaPhong AS N'Mã Phòng', TinhTrang.TinhTrang AS N'Tình Trạng', PhongTro.ThongTin AS N'Thông Tin', PhongTro.GiaPhong AS N'Giá Phòng', PhongTro.GhiChu AS N'Ghi Chú' FROM PhongTro INNER JOIN TinhTrang ON PhongTro.MaTinhTrang = TinhTrang.MaTinhTrang WHERE ThongTin LIKE '%' + @Keyword + '%' OR TinhTrang LIKE '%' + @Keyword + '%' OR MaPhong LIKE '%' + @Keyword + '%'";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Keyword", keyword);
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgQLPhong.DataSource = table;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();  
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            ktThem = true;
            XoaTrang();
            KhoaMo(false);
            txtMaPhong.Focus();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            
            if (txtMaPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }

            if (txtMaPhong.Text == " ") return;
            {
                ktThem = false;
                macu = txtMaPhong.Text;
                KhoaMo(false);
                txtMaPhong.ReadOnly = true;
                txtMaPhong.Focus();
            }

        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {

            if (txtMaPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng để xóa bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (txtMaPhong.Text == "") return;

            
            DialogResult result = MessageBox.Show("Bạn có muốn xóa phòng trọ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Connect to the database
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();
                        SqlCommand command;
                        command = conn.CreateCommand();
                        //delete hop dong truoc
                        string deleteHDQuery = "DELETE FROM HopDong WHERE MaPhong = @MaPhong;";
                        command.CommandText = deleteHDQuery;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                        command.ExecuteNonQuery();

                        // sau do xoa phong
                        string deletePhongQuery = "DELETE FROM PhongTro WHERE MaPhong = @MaPhong;";
                        command.CommandText = deletePhongQuery;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                        command.ExecuteNonQuery();
                        

                        
                       
                        MessageBox.Show("Xóa phòng trọ thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            
            if (txtMaPhong.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPhong.Focus();
                return;
            }
            if(txtThongTin.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThongTin.Focus();
                return;
            }
            if(txtGiaPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaPhong.Focus();
                return;
                
            }
            
            // Connect to the database
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                // Create a SQL command
                SqlCommand cmd;

                if (ktThem)
                {
                    if (CheckMaPhongTonTai(txtMaPhong.Text) == true)
                    {
                        MessageBox.Show("Mã phòng đã tồn tại, vui lòng chọn mã phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaPhong.Focus();
                        return;
                    }
                    // Insert new row
                    cmd = new SqlCommand("INSERT INTO PhongTro (MaPhong, MaTinhTrang, ThongTin, GiaPhong, GhiChu) VALUES (@MaPhong, @MaTinhTrang, @ThongTin, @GiaPhong, @GhiChu)", conn);
                }
                else
                {
                    // Update existing row
                    cmd = new SqlCommand("UPDATE PhongTro SET MaPhong=@MaPhong, MaTinhTrang=@MaTinhTrang, ThongTin=@ThongTin, GiaPhong=@GiaPhong, GhiChu=@GhiChu WHERE MaPhong=@MaCu", conn);
                    cmd.Parameters.AddWithValue("@MaCu", macu);
                }

                // Set command parameters
                cmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                cmd.Parameters.AddWithValue("@MaTinhTrang", cbTinhTrang.SelectedValue);
                cmd.Parameters.AddWithValue("@ThongTin", txtThongTin.Text);
                cmd.Parameters.AddWithValue("@GiaPhong", txtGiaPhong.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                // Execute the command
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Lưu thông tin phòng trọ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool CheckMaPhongTonTai(string maPhong)
        {
            bool result = false;

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                // Tạo câu truy vấn SQL
                string query = "SELECT COUNT(*) FROM PhongTro WHERE MaPhong=@MaPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);

                // Thực hiện câu truy vấn và lấy số lượng bản ghi trả về
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                // Nếu số lượng bản ghi > 0, tức là mã phòng đã tồn tại
                if (count > 0)
                {
                    result = true;
                }
            }

            return result;
        }


        private void LoadDataToComboBox()
        {
            
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM TinhTrang";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cbTinhTrang.DataSource = dt;
            cbTinhTrang.DisplayMember = "TinhTrang";
            cbTinhTrang.ValueMember = "MaTinhTrang";
            
        }

        private void txtGiaPhong_KeyPress(object sender, KeyPressEventArgs e)
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
