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
using System.Security.Cryptography;

namespace QuanLyPhongTro
{
    public partial class fLapHopDong : Form
    {
        DataGridViewCellMouseEventArgs vt, vtTK;
       
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";
        bool ktThem;
        string sDK = "";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public fLapHopDong()
        {
            InitializeComponent();
        }
        public void KhoaMo(bool b)
        {
            
            cmdThemHD.Enabled = b; cmdKetThucHD.Enabled = b; cmdXoaHD.Enabled = b; cmdKetThuc.Enabled = b;

            cmdGhi.Enabled = !b; cmdChon.Enabled = !b; cmdBo.Enabled = !b;

            dgQLHopDong.Enabled = b;
        }
        public void loadDataHD()
        {
           
            string query = @"
            SELECT SoHopDong AS N'Số HĐ', dbo.ChuTro.HoTen AS N'Người Lập', dbo.KhachHang.HoTen AS N'Khách Thuê', dbo.KhachHang.CCCD , MaPhong AS N'Mã Phòng', GiaThue AS N'Giá Thuê', TuNgay AS N'Từ Ngày', DuKienTra AS N'Dự Kiến Trả', NgayTra AS N'Ngày Trả', DaKetThuc AS N'Đã Kết Thúc', HopDong.IDCT
                             FROM dbo.HopDong
                             INNER JOIN dbo.ChuTro ON HopDong.IDCT = ChuTro.IDCT
                             INNER JOIN dbo.KhachHang ON HopDong.CCCD = KhachHang.CCCD
                             WHERE ((@chkDaKetThuc = 1 OR DaKetThuc = 0) AND (ISNULL(@sDK, '') = '' OR SoHopDong LIKE '%' + @sDK + '%' OR dbo.ChuTro.HoTen LIKE '%' + @sDK + '%'  OR dbo.KhachHang.HoTen LIKE '%' + @sDK + '%' OR MaPhong LIKE '%' + @sDK + '%'))
                             ORDER BY SoHopDong";
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@chkDaKetThuc", chkDaKetThuc.Checked ? 1 : 0);
                    command.Parameters.AddWithValue("@sDK", sDK);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgQLHopDong.DataSource = dt;
                    }
                }
            }

        }

        private void fLapHopDong_Load(object sender, EventArgs e)
        {
            KhoaMo(true);
            loadDataHD();
            rbChuNha.CheckedChanged += rbChuNha_CheckedChanged;
            rbKhach.CheckedChanged += rbKhach_CheckedChanged;
            rbPhong.CheckedChanged += rbPhong_CheckedChanged;
        }

        private void dgQLHopDong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgQLHopDong.RowCount <= 0) return;
            if (e.RowIndex >= 0)
            {
                vt = e;
                DataGridViewRow row = dgQLHopDong.Rows[e.RowIndex];
                txtSoHD.Text = row.Cells[0].Value.ToString();
                txtTenChuNha.Text = row.Cells[1].Value.ToString();
                txtCCCDK.Text = row.Cells[2].Value.ToString();
                txtTenKhach.Text = row.Cells[3].Value.ToString();
                txtMaPhong.Text = row.Cells[4].Value.ToString();
                txtTienThue.Text = row.Cells[5].Value.ToString();
                chkTuNgay.Checked = false; dtpTuNgay.Value = DateTime.Now;
                chkDuKienTra.Checked = false; dtpDuKienTra.Value = DateTime.Now;
                txtIDCT.Text = row.Cells[10].Value.ToString();
                DateTime parsedDate;
                if (DateTime.TryParse(row.Cells[6].Value.ToString(), out parsedDate))
                {
                    chkTuNgay.Checked = true;
                    dtpTuNgay.Value = parsedDate;
                }
                
                if (DateTime.TryParse(row.Cells[7].Value.ToString(), out parsedDate))
                {
                    chkDuKienTra.Checked = true;
                    dtpDuKienTra.Value = parsedDate;
                }

                if (DateTime.TryParse(row.Cells[8].Value.ToString(), out parsedDate))
                {
                    chkNgayTra.Checked = true;
                    dtpNgayTra.Value = parsedDate;
                }

                bool ktKetThuc = (bool)row.Cells[9].Value;
                if (ktKetThuc == true )
                {
                    lbTinhTrang.Text = "Đã Kết Thúc";
                    cmdKetThucHD.Enabled = false;
                }
                else
                {
                    lbTinhTrang.Text = "Chưa Kết Thúc";
                    cmdKetThucHD.Enabled = true;
                    dtpNgayTra.Value = DateTime.Now;
                }

            }
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {
            string sDKTim = txtTraCuu.Text.Trim();
            if (rbChuNha.Checked == true)
            {
                string query = "SELECT IDCT, HoTen AS [Họ Tên], SDT AS [Số Điện Thoại] FROM dbo.ChuTro WHERE HoTen LIKE N'%"+sDKTim+ "%' OR SDT LIKE N'%"+sDKTim+"%' ";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThiTimKiem.DataSource = table;
                        dgHienThiTimKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            if (rbKhach.Checked == true)
            {
                string query = "SELECT HoTen AS [Họ Tên], CCCD AS [Số Căn Cước], SDT AS [Số ĐT] FROM dbo.KhachHang WHERE CCCD LIKE N'%" + sDKTim+ "%' OR HoTen LIKE N'%"+sDKTim+"%' OR SDT LIKE '%"+sDKTim+"%'";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThiTimKiem.DataSource = table;
                        dgHienThiTimKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            if (rbPhong.Checked == true)
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
                        dgHienThiTimKiem.DataSource = table;
                        dgHienThiTimKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        public void TaoSoHDMoi()
        {
            int num = 1;
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TOP 1 SoHopDong FROM HopDong ORDER BY SoHopDong DESC", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int temp;
                    if (int.TryParse(reader[0].ToString(), out temp))
                    {
                        num = temp + 1;
                    }
                }
                reader.Close();
                
            }
            txtSoHD.Text = num.ToString("00000000");
            
        }

        private void cmdThemHD_Click(object sender, EventArgs e)
        {
            txtIDCT.Text = ""; txtTenChuNha.Text = ""; txtTenKhach.Text = "";txtCCCDK.Text = "";txtMaPhong.Text = "";
            ktThem = true;
            TaoSoHDMoi();
            chkTuNgay.Checked = true; dtpTuNgay.Value = DateTime.Now;
            chkDuKienTra.Checked = true; dtpDuKienTra.Value = DateTime.Today.AddYears(1);
            chkNgayTra.Checked = false;
            KhoaMo(false);
        }

        private void cmdBo_Click(object sender, EventArgs e)
        {
            // Clear all: xóa trắng nma lười làm XD
            txtSoHD.Clear();
            txtTenChuNha.Clear();
            txtCCCDK.Clear();
            txtTenKhach.Clear();
            txtMaPhong.Clear();
            txtTienThue.Clear();
            chkTuNgay.Checked = false;
            chkDuKienTra.Checked = false;
            chkNgayTra.Checked = false;
            lbTinhTrang.Text = "";
            txtIDCT.Clear();

            // đặt lại khóa mở như ban đầu
            KhoaMo(true);
        }

        private void cmdKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgHienThiTimKiem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgHienThiTimKiem.RowCount <= 0) return;
            if (e.RowIndex >= 0)
                vtTK = e;
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if(txtTenChuNha.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbChuNha.Checked = true;
                txtTenChuNha.Focus();
                return;
            }
            if (txtCCCDK.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbKhach.Checked = true;
                txtCCCDK.Focus();
                return;
            }
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbPhong.Checked = true;
                txtMaPhong.Focus();
                return;
            }
            if (txtTienThue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienThue.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn thêm hợp đồng mới không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return ;

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                // Create a SQL command
                SqlCommand command;
                if (ktThem)
                {
                    // Insert new row
                    command = conn.CreateCommand();
                    command.CommandText = "INSERT INTO dbo.HopDong (SoHopDong, IDCT, CCCD, MaPhong, GiaThue , TuNgay , DuKienTra, NgayTra, DaKetThuc) VALUES (@SoHopDong, @IDCT, @CCCD, @MaPhong, @GiaThue , @TuNgay , @DuKienTra, @NgayTra, @DaKetThuc)";
                    command.Parameters.AddWithValue("@SoHopDong", txtSoHD.Text);
                    command.Parameters.AddWithValue("@IDCT", txtIDCT.Text);
                    command.Parameters.AddWithValue("@CCCD", txtCCCDK.Text);
                    command.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                    command.Parameters.AddWithValue("@GiaThue", txtTienThue.Text);
                    if(chkTuNgay.Checked==true)
                        command.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value);
                    else
                        command.Parameters.AddWithValue("@TuNgay", DBNull.Value);
                    if (chkDuKienTra.Checked == true)
                        command.Parameters.AddWithValue("@DuKienTra", dtpDuKienTra.Value);
                    else
                        command.Parameters.AddWithValue("@DuKienTra", DBNull.Value);
                    
                    command.Parameters.AddWithValue("@NgayTra", DBNull.Value); // mới lập hợp đồng đã đòi trả luôn

                    command.Parameters.Add("@DaKetThuc", SqlDbType.Bit).Value = 0; // tất nhiên chưa kết thúc
                   
                    command.ExecuteNonQuery();
                
                    MessageBox.Show("Lưu thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataHD();
                    KhoaMo(true);
                }

            }


        }

        private void cmdKetThucHD_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (dgQLHopDong.RowCount <= 0) return;
            if (MessageBox.Show("Bạn có chắc chắn muốn kết thúc hợp đồng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // kiểm tra hợp đồng đã kết thúc hay chưa
                bool daKetThuc = (bool)dgQLHopDong.Rows[vt.RowIndex].Cells[9].Value;
                if (daKetThuc == true)
                {
                    MessageBox.Show("Không thể kết thúc hợp đồng đã kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        string query = "UPDATE HopDong SET DaKetThuc=@DaKetThuc WHERE SoHopDong = @sohd";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@sohd", txtSoHD.Text);
                        command.Parameters.Add("@DaKetThuc", SqlDbType.Bit).Value = 1;
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Kết thúc hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDataHD();
                        }
                        else
                        {
                            MessageBox.Show("Kết thúc hợp đồng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdXoaHD_Click(object sender, EventArgs e)
        {
            if (dgQLHopDong.RowCount <= 0) return;

            if (txtSoHD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để xóa bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                // kiểm tra hợp đồng đã kết thúc hay chưa
                bool daKetThuc = (bool)dgQLHopDong.Rows[vt.RowIndex].Cells[9].Value;
                if (daKetThuc == false)
                {
                    MessageBox.Show("Không thể xóa hợp đồng chưa kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        string query = "DELETE FROM HopDong WHERE SoHopDong = @sohd";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@sohd", txtSoHD.Text);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDataHD();
                        }
                        else
                        {
                            MessageBox.Show("Xóa hợp đồng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        

        private void chkDaKetThuc_CheckedChanged(object sender, EventArgs e)
        {
            sDK = txtTimKiem.Text;
            loadDataHD();
        }

        private void txtTienThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Ký tự bạn nhập không hợp lệ");
                e.Handled = true; // Bỏ qua ký tự không hợp lệ
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sDK = txtTimKiem.Text;
                loadDataHD();
            }
        }

        private void rbChuNha_CheckedChanged(object sender, EventArgs e)
        {
            string sDKTim = txtTraCuu.Text;
            if (rbChuNha.Checked == true)
            {
                string query = "SELECT IDCT, HoTen AS [Họ Tên], SDT AS [Số Điện Thoại] FROM dbo.ChuTro ";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThiTimKiem.DataSource = table;
                        dgHienThiTimKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string sDKTim = txtTraCuu.Text.Trim();
            if (rbKhach.Checked == true)
            {
                string query = "SELECT HoTen AS [Họ Tên], CCCD AS [Số Căn Cước], SDT AS [Số ĐT] FROM dbo.KhachHang ";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThiTimKiem.DataSource = table;
                        dgHienThiTimKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string sDKTim = txtTraCuu.Text;
            if (rbPhong.Checked == true)
            {
                string query = "SELECT MaPhong AS [Mã Phòng], GiaPhong AS [Giá Phòng], ThongTin AS [Thông Tin] FROM dbo.PhongTro WHERE MaPhong NOT IN (  SELECT MaPhong  FROM dbo.HopDong) ";
                try
                {
                    using (SqlConnection connection = new SqlConnection(str))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgHienThiTimKiem.DataSource = table;
                        dgHienThiTimKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            if(cmdGhi.Enabled == false) return;
            try
            {
                DataGridViewRow row = dgHienThiTimKiem.Rows[vtTK.RowIndex];
                if(rbChuNha.Checked == true)
                {
                    txtIDCT.Text = row.Cells[0].Value.ToString();
                    txtTenChuNha.Text = row.Cells[1].Value.ToString();
                }
                if (rbKhach.Checked == true)
                {
                    txtCCCDK.Text = row.Cells[1].Value.ToString();
                    txtTenKhach.Text = row.Cells[0].Value.ToString();
                }
                if (rbPhong.Checked == true)
                {
                    txtMaPhong.Text = row.Cells[0].Value.ToString();
                    txtTienThue.Text = row.Cells[1].Value.ToString();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        

    }
}

