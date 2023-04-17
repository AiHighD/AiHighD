using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyPhongTro
{
    public partial class fQLKhachThue : Form
    {
        DataGridViewCellMouseEventArgs vt;
        bool ktThem;
        string macu = "";

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public fQLKhachThue()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            connection = new SqlConnection(str);
            command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT CCCD AS N'Số Căn Cước',HoTen AS N'Họ Tên', SDT AS N'Số ĐT', QueQuan AS N'Quê Quán', DiaChi AS N'Địa Chỉ', ThongTinKhac AS N'Thông Tin Khác', GhiChu AS N'Ghi Chú' FROM dbo.KhachHang";

            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgQLKhach.DataSource = table;
            dgQLKhach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        public void XoaTrang()
        {
            txtCCCD.Text = ""; txtHoTen.Text = ""; txtSDT.Text = ""; txtGhiChu.Text = ""; txtQueQuan.Text = "";
            txtDiaChi.Text = ""; txtTTKhac.Text = "";
        }

        public void KhoaMo(bool b)
        {
            dgQLKhach.Enabled = b;
            cmdThem.Enabled = b; cmdSua.Enabled = b; cmdXoa.Enabled = b; cmdKetThuc.Enabled = b;

            cmdGhi.Enabled = !b; cmdKhongGhi.Enabled = !b;

            txtCCCD.ReadOnly = b; txtHoTen.ReadOnly = b; txtDiaChi.ReadOnly = b; txtGhiChu.ReadOnly = b;
            txtSDT.ReadOnly = b; txtTTKhac.ReadOnly = b; txtQueQuan.ReadOnly = b;

            txtTimKiem.ReadOnly = !b;
        }

        private void fQLKhachThue_Load(object sender, EventArgs e)
        {
            KhoaMo(true);
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            
        }

        private void dgQLKhach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgQLKhach.RowCount <= 0) return;
            if (e.RowIndex >= 0)
            {
                vt = e;
                DataGridViewRow row = dgQLKhach.Rows[e.RowIndex];
                txtCCCD.Text = row.Cells[0].Value.ToString();              
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtSDT.Text = row.Cells[2].Value.ToString();                               
                txtQueQuan.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtTTKhac.Text = row.Cells[5].Value.ToString();
                txtGhiChu.Text = row.Cells[6].Value.ToString();
                
            }
            
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            ktThem = true;
            XoaTrang();
            KhoaMo(false);
            txtCCCD.Focus();
            macu = txtCCCD.Text;
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (txtCCCD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            
            if (txtCCCD.Text == " ") return;
            {
                ktThem = false;
                macu = txtCCCD.Text;
                KhoaMo(false);
                txtCCCD.Focus();
            }
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (txtCCCD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách để xóa bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn xóa khách này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        //delete hop dong cua khach truoc
                        string deleteHopDongQuery = "DELETE FROM HopDong WHERE CCCD= @cccd;";

                        command.CommandText = deleteHopDongQuery;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                        command.ExecuteNonQuery();

                        // sau do xoa hoa don
                        string deleteKhachQuery = "DELETE FROM KhachHang WHERE CCCD = @cccd;";
                        command.CommandText = deleteKhachQuery;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                        command.ExecuteNonQuery();
                        
                        MessageBox.Show("Xóa khách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        XoaTrang();
                       
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
            if (txtCCCD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !");
                txtCCCD.Focus();
                return;
            }

            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !");
                txtHoTen.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !");
                txtSDT.Focus();
                return;

            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !");
                txtDiaChi.Focus();
                return;

            }
            if (txtQueQuan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !");
                txtQueQuan.Focus();
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
                    if (CheckTrungCCCD(txtCCCD.Text) == true)
                    {
                        MessageBox.Show("Mã căn cước công dân bị trùng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCCCD.Focus();
                        return;
                    }
                    // Insert new row
                    cmd = new SqlCommand("INSERT INTO KhachHang (CCCD, HoTen, SDT, QueQuan, DiaChi , ThongTinKhac , GhiChu) VALUES (@CCCD, @HoTen, @SDT, @QueQuan, @DiaChi, @ThongTinKhac, @GhiChu)", conn);
                }
                else
                {
                    if (CheckTrungCCCD(txtCCCD.Text) == true)
                    {
                        MessageBox.Show("Mã căn cước công dân bị trùng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCCCD.Focus();
                        return;
                    }
                    // cập nhật
                    cmd = new SqlCommand("UPDATE KhachHang SET CCCD=@CCCD, HoTen=@HoTen, SDT=@SDT, QueQuan=@QueQuan, DiaChi=@DiaChi, ThongTinKhac=@ThongTinKhac, GhiChu=@GhiChu WHERE CCCD=@MaCu", conn);
                    cmd.Parameters.AddWithValue("@MaCu", macu);
                }

                // Set command parameters
                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@QueQuan", txtQueQuan.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@ThongTinKhac", txtTTKhac.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                // Execute the command
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Lưu thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void TimKiem()
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = "SELECT CCCD AS N'Số Căn Cước',HoTen AS N'Họ Tên', SDT AS N'Số ĐT', QueQuan AS N'Quê Quán', DiaChi AS N'Địa Chỉ', ThongTinKhac AS N'Thông Tin Khác', GhiChu AS N'Ghi Chú' FROM dbo.KhachHang WHERE CCCD LIKE '%' + @Keyword + '%' OR HoTen LIKE '%' + @Keyword + '%' OR SDT LIKE '%' + @Keyword + '%' OR QueQuan LIKE '%' + @Keyword + '%' OR DiaChi LIKE '%' + @Keyword + '%'";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Keyword", keyword);
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgQLKhach.DataSource = table;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private bool CheckTrungCCCD(string cccd)
        {
            bool result = false;
           
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                
                string query = "SELECT COUNT(*) FROM KhachHang WHERE CCCD=@cccc AND CCCD != @macu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cccc", cccd);
                cmd.Parameters.AddWithValue("@macu", macu);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                
                if (count > 0 )
                {
                    
                        result = true;
                    
                }
            }

            return result;
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

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
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
