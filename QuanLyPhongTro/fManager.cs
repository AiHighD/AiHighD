using QuanLyPhongTro;
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
    public partial class fManager : Form
    {
        private string loggedInUsername;
        
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";
        private void LoadUsername()
        {
            // Hiển thị tên người dùng đã đăng nhập lên label
            lbHienThi.Text = loggedInUsername;
        }
        public fManager(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            LoadUsername();
        }

              
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQLChuTro frm = new fQLChuTro();
            
            frm.ShowDialog();
            
        }

        private void thôngTinPhòngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fThongTinPhong frm = new fThongTinPhong();
            
            frm.ShowDialog();
            
        }

        private void tìnhTrạngPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTinhTrangPhong frm = new fTinhTrangPhong();
            
            frm.ShowDialog();
            
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fDoiMatKhau frm = new fDoiMatKhau();
            
            frm.ShowDialog();
            
            
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyDichVu frm = new fQuanLyDichVu();
            frm.ShowDialog();
        }

        private void thôngTinKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQLKhachThue frm = new fQLKhachThue();
            frm.ShowDialog();
        }

        private void lậpHợpĐồngMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLapHopDong frm = new fLapHopDong();
            frm.ShowDialog();
        }

        private void tìnhTrạngThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQLTinhTrangThanhToan frm = new fQLTinhTrangThanhToan();
            frm.ShowDialog();
        }

        private void lậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLapHoaDon frm = new fLapHoaDon();
            frm.ShowDialog();
        }

        private void fManager_Load(object sender, EventArgs e)
        {
            rbPhong.CheckedChanged += rbPhong_CheckedChanged;
            rbKhach.CheckedChanged += rbKhach_CheckedChanged;
            rbPhongTrong.CheckedChanged += rbKhach_CheckedChanged;
            LoadRecordCounts();
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LoadRecordCounts();
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng điền từ tìm kiếm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
                return;
            }
            string sDKTim = txtTimKiem.Text.Trim();   
            if (rbPhong.Checked == true)
            {
                string query = "SELECT MaPhong as [Mã Phòng], ThongTin as [Thông Tin], GiaPhong AS [Giá Phòng] FROM dbo.PhongTro WHERE MaPhong LIKE N'%" + sDKTim + "%' OR ThongTin LIKE N'%" + sDKTim + "%' OR GiaPhong LIKE '%" + sDKTim + "%'";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);                        
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThi.DataSource = table;
                        dgHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            if (rbKhach.Checked == true)
            {
                string query = "SELECT CCCD AS N'Số Căn Cước',HoTen AS N'Họ Tên', SDT AS N'Số ĐT', QueQuan AS N'Quê Quán', DiaChi AS N'Địa Chỉ', ThongTinKhac AS N'Thông Tin Khác', GhiChu AS N'Ghi Chú' FROM dbo.KhachHang WHERE CCCD LIKE N'%" + sDKTim + "%' OR HoTen LIKE N'%" + sDKTim + "%' OR SDT LIKE '%" + sDKTim + "%' OR DiaChi LIKE N'%" + sDKTim + "%' OR QueQuan LIKE N'%" + sDKTim + "%'";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThi.DataSource = table;
                        dgHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            if (rbPhongTrong.Checked == true)
            {
                string query = "SELECT MaPhong AS [Mã Phòng], GiaPhong AS [Giá Phòng], ThongTin AS [Thông Tin] FROM dbo.PhongTro WHERE MaPhong NOT IN (  SELECT MaPhong  FROM dbo.HopDong) AND (MaPhong LIKE N'%"+sDKTim+"%' OR GiaPhong LIKE N'%"+sDKTim+"%' OR ThongTin LIKE N'%"+sDKTim+"%')";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThi.DataSource = table;
                        dgHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void rbPhong_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rbPhong.Checked == true)
            {
                string query = "SELECT MaPhong as [Mã Phòng], ThongTin as [Thông Tin], GiaPhong AS [Giá Phòng] FROM dbo.PhongTro ";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThi.DataSource = table;
                        dgHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void rbKhach_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKhach.Checked == true)
            {
                string query = "SELECT CCCD AS N'Số Căn Cước',HoTen AS N'Họ Tên', SDT AS N'Số ĐT', QueQuan AS N'Quê Quán', DiaChi AS N'Địa Chỉ', ThongTinKhac AS N'Thông Tin Khác', GhiChu AS N'Ghi Chú' FROM dbo.KhachHang ";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThi.DataSource = table;
                        dgHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void rbPhongTrong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPhongTrong.Checked == true)
            {
                string query = "SELECT MaPhong AS [Mã Phòng], GiaPhong AS [Giá Phòng], ThongTin AS [Thông Tin] FROM dbo.PhongTro WHERE MaPhong NOT IN (  SELECT MaPhong  FROM dbo.HopDong)";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThi.DataSource = table;
                        dgHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        public void LoadRecordCounts()
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM dbo.HopDong", connection);
                string count1 = command1.ExecuteScalar().ToString();
                lbSoHopDong.Text = count1;

                SqlCommand command2 = new SqlCommand("SELECT COUNT(*) FROM dbo.PhongTro", connection);
                string count2 = command2.ExecuteScalar().ToString();
                lbSoPhong.Text = count2;

                SqlCommand command3 = new SqlCommand("SELECT COUNT(*) FROM dbo.KhachHang", connection);
                string count3 = command3.ExecuteScalar().ToString();
                lbSoKhach.Text = count3;

                SqlCommand command4 = new SqlCommand("SELECT COUNT(*) FROM dbo.HoaDon", connection);
                string count4 = command4.ExecuteScalar().ToString();
                lbSoHoaDon.Text = count4;

                SqlCommand command5 = new SqlCommand("SELECT SUM(SoLuong*GiaTien) FROM dbo.CTHoaDon ", connection);
                string count5 = command5.ExecuteScalar().ToString();
                lbTongTien.Text = count5;

                connection.Close();
            }


        }
    }
}
