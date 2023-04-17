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
    public partial class fLapHoaDon : Form
    {

        DataGridViewCellMouseEventArgs vthd, vtHoaDon;
        string sDK = "";
        bool ktKetThucHopDong, ktThem , ktDV;
        int idHoaDon = -1, vtDichVu;
        ListViewItem itemLV;

        
        string str = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        
        public fLapHoaDon()
        {
            InitializeComponent();
        }

        public void KhoaMo(bool b)
        {
            txtTimKiem.ReadOnly= !b; chkHienThi.Enabled= b;
            dgHopDong.Enabled= b; dgHoaDon.Enabled= b;
            dtpNgayLap.Enabled= !b; lvwDichVu.Enabled= !b;
            txtTienGiam.ReadOnly= b; txtTienPhat.ReadOnly= b; txtTongTien.ReadOnly= b;
            txtTienKhachTra.ReadOnly= b; cbTinhTrangHD.Enabled= !b; txtGhiChu.ReadOnly = b;
            cmdThem.Enabled = b; cmdSua.Enabled = b; cmdXoa.Enabled = b; cmdKetThuc.Enabled = b;

            cmdXoaSoLuong.Enabled= !b; cmdTinhTien.Enabled= !b;

            cmdGhi.Enabled = !b; cmdKhongGhi.Enabled = !b;

            cbTinhTrangHD.Enabled = !b;

            txtTimKiem.ReadOnly = !b;
        }
        public void XoaTrang()
        {
            txtTienGiam.Text = "0"; txtTienPhat.Text = "0"; txtTienKhachTra.Text = "0";
            txtTongTien.Text = "0"; txtGhiChu.Text = "";
            lvwDichVu.Items.Clear();

        }

        public void LayNguonHopDong()
        {
            
            string query = @"SELECT hd.SoHopDong as [Số HĐ], kh.HoTen as [Họ Tên], ph.MaPhong as [Mã Phòng], hd.GiaThue as [Giá Thuê], hd.TuNgay as [Từ Ngày], hd.DuKienTra as [Dự Kiến Trả], hd.NgayTra as [Ngày Trả], hd.DaKetThuc as [Đã Kết Thúc]
                            FROM ChuTro ct
                            INNER JOIN HopDong hd ON ct.IDCT = hd.IDCT
                            INNER JOIN KhachHang kh ON hd.CCCD = kh.CCCD
                            INNER JOIN PhongTro ph ON hd.MaPhong = ph.MaPhong
                            WHERE ((@chkHienThi = 1 OR hd.DaKetThuc = 0) AND (ISNULL(@sDK, '') = '' OR hd.SoHopDong LIKE '%' + @sDK + '%' OR kh.HoTen LIKE '%' + @sDK + '%'  OR ph.MaPhong LIKE '%' + @sDK + '%'))
                            ORDER BY hd.SoHopDong";
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@chkHienThi", chkHienThi.Checked ? 1 : 0);
                    command.Parameters.AddWithValue("@sDK", sDK);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgHopDong.DataSource = dt;
                    }
                }
            }
            dgHoaDon.DataSource = null;
            XoaTrang();
        }

        private void LoadDataToComboBox()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;"))
            {
                connection.Open();

                string queryString = "SELECT * FROM ThanhToan";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    cbTinhTrangHD.DataSource = dt;
                    cbTinhTrangHD.DisplayMember = "LoaiThanhToan";
                    cbTinhTrangHD.ValueMember = "IDTT";
                }
            }
        }

        public void LayNguonHoaDon()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";
            string query = "SELECT IDHD, IDTT, SoHopDong as [Số HĐ], NgayLap as [Ngày Lập], TienGiam as [Tiền Giảm], TienPhat as [Tiền Phạt], SoTienTra as [Tiền khách trả], TongTien as [Tổng tiền], GhiChu FROM HoaDon WHERE SoHopDong = @soHopDong ORDER BY IDHD";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@soHopDong", txtSoHD.Text);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgHoaDon.DataSource = dt;
                    }
                }
            }
        }

        public void LayNguonCTHoaDon()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";
            string query = "SELECT dv.MaDV, dv.TenDichVu, ct.GiaTien, ct.SoLuong, (ct.GiaTien * ct.SoLuong) as ThanhTien " +
                           "FROM DichVu dv " +
                           "INNER JOIN CTHoaDon ct ON dv.MaDV = ct.MaDV " +
                           "WHERE ct.IDHD = @idHoaDon";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idHoaDon", idHoaDon);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        lvwDichVu.Items.Clear();
                        while (reader.Read())
                        {
                            itemLV = new ListViewItem(new[] {
                            reader["MaDV"].ToString(),
                            reader["TenDichVu"].ToString(),
                            reader["GiaTien"].ToString(),
                            reader["SoLuong"].ToString(),
                            reader["ThanhTien"].ToString() });
                            lvwDichVu.Items.Add(itemLV);
                        }
                    }
                }
            }
        }

        

        public void LayNguonDichVu()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;";
            string query = "SELECT MaDV, TenDichVu, SoTien FROM DichVu";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        lvwDichVu.Items.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            itemLV = new ListViewItem(new[] { row["MaDV"].ToString(), row["TenDichVu"].ToString(), row["SoTien"].ToString(), "0", "0" });
                            lvwDichVu.Items.Add(itemLV);
                        }
                    }
                }
            }
        }

        private void fLapHoaDon_Load(object sender, EventArgs e)
        {
            KhoaMo(true);
            LayNguonHopDong();
            LoadDataToComboBox();
        }

        
        private void dgHopDong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgHopDong.RowCount <= 0) return;
            if (e.RowIndex >= 0)
            {
                vthd = e;
                DataGridViewRow row = dgHopDong.Rows[e.RowIndex];
                txtSoHD.Text = row.Cells[0].Value.ToString();
                txtKhach.Text = row.Cells[1].Value.ToString();
                txtPhong.Text = row.Cells[2].Value.ToString();
                txtGiaTien.Text = row.Cells[3].Value.ToString();
                ktKetThucHopDong =(bool)row.Cells[7].Value;
                XoaTrang();
                LayNguonHoaDon();
            }
        }

       
        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                sDK = txtTimKiem.Text;
                LayNguonHopDong();
            }
        }

        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            sDK = txtTimKiem.Text;
            LayNguonHopDong();
        }

        private void dgHoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgHoaDon.RowCount <= 0) return;
            if (e.RowIndex >= 0)
            {
                vtHoaDon = e;
                DataGridViewRow row = dgHoaDon.Rows[e.RowIndex];
                dtpNgayLap.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                txtTienGiam.Text = row.Cells[4].Value.ToString();
                txtTienPhat.Text = row.Cells[5].Value.ToString();
                txtTienKhachTra.Text = row.Cells[6].Value.ToString();
                txtTongTien.Text = row.Cells[7].Value.ToString();
                cbTinhTrangHD.SelectedValue = row.Cells[1].Value;
                txtGhiChu.Text = row.Cells[8].Value.ToString();

                idHoaDon = Int32.Parse(row.Cells[0].Value.ToString());
                LayNguonCTHoaDon();

            }
        }
       
        private void cmdXoaSoLuong_Click(object sender, EventArgs e)
        {
            for(int i=0; i<lvwDichVu.Items.Count; i++)
            {
                lvwDichVu.Items[i].SubItems[3].Text = "0";
                lvwDichVu.Items[i].SubItems[4].Text = "0";
            }
        }

        private void lvwDichVu_MouseUp(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection itemSL = lvwDichVu.SelectedItems;
            if (itemSL.Count > 0)
            {
                ListViewHitTestInfo i = lvwDichVu.HitTest(e.X, e.Y);
                int cellTop = lvwDichVu.Top + i.SubItem.Bounds.Top;
                txtSoLuong.Location = new Point(txtSoLuong.Left, cellTop);
                txtSoLuong.Text = itemSL[0].SubItems[3].Text;
                vtDichVu = itemSL[0].Index;
                txtSoLuong.Visible = true;
                txtSoLuong.Focus();
                ktDV = true;
            }

        }
 

        private void cmdThem_Click(object sender, EventArgs e)
        {
            if (ktKetThucHopDong == true)
            {
                MessageBox.Show("Hợp đồng đã kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (txtSoHD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để thêm hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (txtSoHD.Text == "") return;
            ktThem = true;
            KhoaMo(false);
            XoaTrang();
            LayNguonDichVu();
            dtpNgayLap.Value = DateTime.Now; dtpNgayLap.Focus();

        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (ktKetThucHopDong == true)
            {
                MessageBox.Show("Hợp đồng đã kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (txtTongTien.Text == "0")
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (txtSoHD.Text == "") return;
            if (idHoaDon < 0) return;
            ktThem = false;
            KhoaMo(false);
            LayNguonDichVu();

        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (ktKetThucHopDong == true)
            {
                MessageBox.Show("Hợp đồng đã kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (txtTongTien.Text == "0")
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (txtSoHD.Text == "") return;
            if (idHoaDon < 0) return;

            if (MessageBox.Show("Bạn có muốn xóa hóa đơn đang xem không?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlCommand command;
                    command = conn.CreateCommand();
                    //delete chi tiet truoc
                    string deleteCTHoaDonQuery = "DELETE FROM CTHoaDon WHERE IDHD = @idHoaDon;";

                    command.CommandText = deleteCTHoaDonQuery;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@idHoaDon", idHoaDon);
                    command.ExecuteNonQuery();

                    // sau do xoa hoa don
                    string deleteHoaDonQuery = "DELETE FROM HoaDon WHERE IDHD = @idHoaDon;";
                    command.CommandText = deleteHoaDonQuery;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@idHoaDon", idHoaDon);
                    command.ExecuteNonQuery();
                    XoaTrang();
                idHoaDon = -1;
                LayNguonHoaDon();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }


        private void cmdGhi_Click(object sender, EventArgs e)
        {
            cmdTinhTien_Click(sender, e);

            if (MessageBox.Show("Bạn có muốn ghi hóa đơn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
         

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                // Create a SQL command
                SqlCommand command;

                if (ktThem)
                {
                
                command = conn.CreateCommand();

                command.CommandText = "INSERT INTO dbo.HoaDon (IDTT, SoHopDong,NgayLap,SoTienTra,TienGiam,TienPhat,TongTien,GhiChu) VALUES (@IDTT, @SoHopDong, @NgayLap, @SoTienTra, @TienGiam, @TienPhat, @TongTien, @GhiChu) ";
                command.Parameters.AddWithValue("@IDTT", cbTinhTrangHD.SelectedValue); 
                command.Parameters.AddWithValue("@SoHopDong", txtSoHD.Text);
                command.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                command.Parameters.AddWithValue("@SoTienTra", txtTienKhachTra.Text);
                command.Parameters.AddWithValue("@TienGiam", txtTienGiam.Text);
                command.Parameters.AddWithValue("@TienPhat", txtTienPhat.Text);
                command.Parameters.AddWithValue("@TongTien", txtTongTien.Text);
                command.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                
                command.ExecuteNonQuery();

                command.CommandText = "SELECT TOP 1 IDHD FROM HoaDon ORDER BY IDHD DESC";
                idHoaDon = Convert.ToInt32(command.ExecuteScalar());
                                      
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    command = conn.CreateCommand();

                    command.CommandText = "UPDATE dbo.HoaDon SET IDTT = @IDTT, SoHopDong = @SoHopDong,NgayLap = @NgayLap,SoTienTra = @SoTienTra,TienGiam = @TienGiam,TienPhat = @TienPhat,TongTien = @TongTien,GhiChu = @GhiChu WHERE IDHD = @idHoaDon";
                    command.Parameters.AddWithValue("@IDTT", cbTinhTrangHD.SelectedValue);
                    command.Parameters.AddWithValue("@SoHopDong", txtSoHD.Text);
                    command.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                    command.Parameters.AddWithValue("@SoTienTra", txtTienKhachTra.Text);
                    command.Parameters.AddWithValue("@TienGiam", txtTienGiam.Text);
                    command.Parameters.AddWithValue("@TienPhat", txtTienPhat.Text);
                    command.Parameters.AddWithValue("@TongTien", txtTongTien.Text);
                    command.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                    command.Parameters.AddWithValue("@idHoaDon", idHoaDon);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if(ktDV)
                        {
                            // Xóa chi tiết hóa đơn cũ
                            string deleteCTHoaDonQuery = "DELETE FROM CTHoaDon WHERE IDHD = @idHoaDon;";

                        command.CommandText = deleteCTHoaDonQuery;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@idHoaDon", idHoaDon);
                        command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                double sl, dg;
                for (int i = 0; i < lvwDichVu.Items.Count; i++)
                {
                    sl = Double.Parse(lvwDichVu.Items[i].SubItems[3].Text);
                    dg = Double.Parse(lvwDichVu.Items[i].SubItems[2].Text);
                    if(sl>0)
                    {
                        command = conn.CreateCommand();
                        command.CommandText = "INSERT INTO CTHoaDon(IDHD, MaDV, GiaTien, SoLuong) VALUES (@idHoaDon, @maDV, @giaTien, @soLuong);";
                        command.Parameters.AddWithValue("@idHoaDon", idHoaDon);
                        command.Parameters.AddWithValue("@maDV", Int32.Parse(lvwDichVu.Items[i].Text));
                        command.Parameters.AddWithValue("@soLuong", sl);
                        command.Parameters.AddWithValue("@giaTien", dg);
                        command.ExecuteNonQuery();
 
                    }
                }
                KhoaMo(true);
                LayNguonHoaDon();
                LayNguonCTHoaDon();
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

        private void txtTienGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Ký tự bạn nhập không hợp lệ");
                e.Handled = true; // Bỏ qua ký tự không hợp lệ
            }
        }

        private void txtTienPhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Ký tự bạn nhập không hợp lệ");
                e.Handled = true; // Bỏ qua ký tự không hợp lệ
            }
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Ký tự bạn nhập không hợp lệ");
                e.Handled = true; // Bỏ qua ký tự không hợp lệ
            }
        }

        private void txtTienKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Ký tự bạn nhập không hợp lệ");
                e.Handled = true; // Bỏ qua ký tự không hợp lệ
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Ký tự bạn nhập không hợp lệ");
                e.Handled = true; // Bỏ qua ký tự không hợp lệ
            }
        }

        private void cmdKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdTinhTien_Click(object sender, EventArgs e)
        {
            if (txtTienGiam.Text == "") txtTienGiam.Text = "0";
            if (txtTienPhat.Text == "") txtTienPhat.Text = "0";
            if (txtTienKhachTra.Text == "") txtTienKhachTra.Text = "0";
            if (txtTongTien.Text == "") txtTongTien.Text = "0";
            double tienphong = 0, tiendv = 0, tiengiam = 0, tienphat = 0, sotien = 0, sl, dg;
            tienphong = Double.Parse(txtGiaTien.Text);
            tiengiam = Double.Parse(txtTienGiam.Text);
            tienphat = Double.Parse(txtTienPhat.Text);
            for (int i = 0; i < lvwDichVu.Items.Count; i++)
            {
                sl = Double.Parse(lvwDichVu.Items[i].SubItems[3].Text);
                dg = Double.Parse(lvwDichVu.Items[i].SubItems[2].Text);
                lvwDichVu.Items[i].SubItems[4].Text = (sl * dg).ToString();
                tiendv = tiendv + (sl * dg);
            }
            sotien = tienphong + tienphat - tiengiam + tiendv;
            txtTongTien.Text = sotien.ToString();

        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            lvwDichVu.Items[vtDichVu].SubItems[3].Text = txtSoLuong.Text;
            txtSoLuong.Visible = false;

        }

    }
}
