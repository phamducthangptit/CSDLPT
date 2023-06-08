using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THITRACNGHIEM
{
    public partial class frmTaoTK : Form
    {
        public frmTaoTK()
        {
            InitializeComponent();
        }

        private void TAOTK_Load(object sender, EventArgs e)
        {
            this.DSTKTaiKhoan.EnforceConstraints = false;
            this.SP_THONG_TIN_DK_TKTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dSTKTaiKhoan.SP_THONG_TIN_DK_TK' table. You can move, or remove it, as needed.
            this.SP_THONG_TIN_DK_TKTableAdapter.Fill(this.DSTKTaiKhoan.SP_THONG_TIN_DK_TK);

            cmbCoSo.DataSource = Program.bds_dspm; // sao chép ds phân mảnh đã load ở form đăng nhập
            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
            cmbCoSo.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
                cmbNhom.Items.Add("TRUONG");
            }
            else
            {
                cmbNhom.Items.Add("COSO");
                cmbNhom.Items.Add("GIANGVIEN");
                cmbCoSo.Enabled = false;

            }
            cmbGV.DataSource = DSTKTaiKhoan.Tables[0];
            cmbGV.ValueMember = "TENGV";
            cmbGV.DisplayMember = "TENGV";
            cmbGV.SelectedIndex = bdsThongTinDK.Position;
            cmbNhom.SelectedIndex = 0;
            
        }

        private void cmbGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbGV.SelectedIndex;
            bdsThongTinDK.Position = selectedIndex;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string lgname = txtTaiKhoan.Text.Trim();
            string pass = txtMatMa.Text.Trim(); 
            if(lgname != "" || pass != "")
            {
                DialogResult check = MessageBox.Show("Bạn có muốn lưu thông tài khoản ?", "Thông báo", MessageBoxButtons.YesNo);
                if(check == DialogResult.Yes)
                {
                    btnTTK_Click(sender, e);
                }else
                {
                    this.Close();
                }
            }
        }

        private void btnTTK_Click(object sender, EventArgs e)
        {
            string lgname = txtTaiKhoan.Text.Trim();
            string pass = txtMatMa.Text.Trim();
            string username = txtMaGV.Text.Trim();  
            string role = cmbNhom.SelectedItem.ToString().Trim();

            if (lgname == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản!", "", MessageBoxButtons.OK);
                txtTaiKhoan.Focus();
                return;
            }
            if (pass == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!", "", MessageBoxButtons.OK);
                txtMaGV.Focus();
                return;
            }

            string strLenh1 = "SP_TAOLOGIN '"
                           + lgname + "', '"
                           + pass + "', '"
                            + username + "', '"
                            + role + "'"
                           ;
            int result = Program.ExecSqlNonQuery(strLenh1, Program.connstr);
            if (result == 1)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại", "Lỗi", MessageBoxButtons.OK);
                txtTaiKhoan.Focus();
                return;
            }
            if (result == 2)
            {
                MessageBox.Show("Mã giảng viên đã tồn tại", "Lỗi", MessageBoxButtons.OK);
                cmbGV.Focus();
                return;
            }
            if( result ==0)
            {
                MessageBox.Show("Tạo tài khoản thành công", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show("Tạo tài khoản thất bại", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCoSo.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.servername = cmbCoSo.SelectedValue.ToString();

            if (cmbCoSo.SelectedIndex != Program.mChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở mới", "", MessageBoxButtons.OK);
            }
           
        }
    }
}
