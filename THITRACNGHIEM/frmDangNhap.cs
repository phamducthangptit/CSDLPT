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

namespace THITRACNGHIEM
{
    public partial class frmDangNhap : Form
    {
        private SqlConnection conn_publisher = new SqlConnection();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            cmbCoSo.DataSource = dt;
            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
        }
        private int KetNoi_CSDLGoc()
        { 
            if(conn_publisher != null && conn_publisher.State == ConnectionState.Open) conn_publisher.Close();

            try 
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;
                conn_publisher.Open();
                return 1;
            } 
            catch(Exception e)
            {
                MessageBox.Show("Lỗi kết nối về CSDL gốc.\nBạn xem lại tên Server của Publisher, và tên CSDL trong chuỗi kết nối.\n" + e.Message);
                return 0;
            }
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGoc() == 0) return;
            LayDSPM("SELECT * FROM V_DS_PHANMANH");
            cmbCoSo.SelectedIndex = 1;
            cmbCoSo.SelectedIndex = 0;
        }

        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmbCoSo.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
            Program.frmChinh.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Trim() == "" || txtMatMa.Text.Trim() == "")
            {
                MessageBox.Show("Login name, mật khẩu, tư cách không được trống", "", MessageBoxButtons.OK);
                return;
            }
            if (!cbSinhVien.Checked)
            {
                Program.mlogin = txtTaiKhoan.Text;
                Program.password = txtMatMa.Text;
                if (Program.KetNoi() == 0) return;

                Program.mChiNhanh = cmbCoSo.SelectedIndex;
                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                string strLenh = "EXEC SP_THONGTINDANGNHAPGV '" + Program.mlogin + "'";

                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                Program.username = Program.myReader.GetString(0);
                if (Convert.IsDBNull(Program.username))
                {
                    MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username và password", "", MessageBoxButtons.OK);
                    return;
                }

                Program.mHoTen = Program.myReader.GetString(1);
                Program.mGroup = Program.myReader.GetString(2);
                Program.myReader.Close();
                Program.conn.Close();
                Program.frmChinh.HienThiMenuGV();
                Close();
            }
            else
            {
                Program.mlogin = "student";
                Program.password = "123456";
                if (Program.KetNoi() == 0) return;
                Program.mChiNhanh = cmbCoSo.SelectedIndex;
                Program.mloginDN = txtTaiKhoan.Text;
                Program.passwordDN = txtMatMa.Text;

                string strLenh = "EXEC SP_THONGTINDANGNHAPSV '" + Program.mloginDN + "', " + "'" + Program.passwordDN + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                try
                {
                    Program.myReader.Read();
                    Program.username = Program.myReader.GetString(0);
                    Program.mHoTen = Program.myReader.GetString(1);
                    Program.mGroup = Program.myReader.GetString(2);
                    Program.myReader.Close();
                    Program.conn.Close();
                    Program.frmChinh.HienThiMenuSV();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username và password", "", MessageBoxButtons.OK);
                    return;
                }

            }
        }

        private void cbSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSinhVien.Checked == true)
            {
                lbTaiKhoan.Text = "Mã sinh viên:";
            }
            else
            {
                lbTaiKhoan.Text = "Tài khoản:";
            }
        }
    }

}

