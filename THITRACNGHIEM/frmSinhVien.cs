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
    public partial class frmSinhVien : Form
    {
        string maLop = "";
        int vitri = 0;
        string suKien = "";
        int vitrilop = 0;
        string maSV = "";
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsSinhVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSSinhVien);

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            dSSinhVien.EnforceConstraints = false;
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dSSinhVien.LOP);

            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.dSSinhVien.SINHVIEN);

            this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.BANGDIEMTableAdapter.Fill(this.dSSinhVien.BANGDIEM);

            cmbCoSo.DataSource = Program.bds_dspm;

            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
            cmbCoSo.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
                btnThem.Enabled = btnHieuChinh.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
                btnReload.Enabled = btnThoat.Enabled = true;
                groupBox1.Enabled = false;
            }
            else
            {
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                cmbCoSo.Enabled = groupBox1.Enabled = false;
                groupBox1.Enabled = false;
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
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            }
            else
            {

                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dSSinhVien.LOP);

                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.dSSinhVien.SINHVIEN);

                Program.conn.Close();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsSinhVien.Position;
            vitrilop = bdsLOP.Position;
            try
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dSSinhVien.LOP);
                bdsLOP.Position = vitrilop;

                this.dSSinhVien.SINHVIEN.Clear();

                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.dSSinhVien.SINHVIEN);
                bdsSinhVien.Position = vitri;
                Program.conn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSinhVien.CancelEdit();
            bdsSinhVien.Position = vitri;

            gcSinhVien.Enabled = true;
            gcLop.Enabled = true;
            groupBox1.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suKien = "THEM";
            vitri = bdsSinhVien.Position;
            bdsSinhVien.AddNew();
            maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
            txtMaLop.Text = maLop;

            groupBox1.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;

            gcSinhVien.Enabled = false;
            gcLop.Enabled = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suKien = "HC";
            vitri = bdsSinhVien.Position;
            groupBox1.Enabled = true;
            gcSinhVien.Enabled = false;
            gcLop.Enabled = false;
            btnPhucHoi.Enabled = btnGhi.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;

            if (bdsBangDiem.Count > 0)
            {
                txtMaSV.Enabled = false;
            }
            else txtMaSV.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Không thể xóa sinh viên vì sinh viên đã tham gia thi", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maSV = ((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString();

                    bdsSinhVien.RemoveCurrent();
                    this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.SINHVIENTableAdapter.Update(this.dSSinhVien.SINHVIEN);
                    Program.conn.Close();

                } catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sinh viên. Bạn hãy xóa lại " + ex.Message, "", MessageBoxButtons.OK);

                    this.SINHVIENTableAdapter.Fill(this.dSSinhVien.SINHVIEN);
                    bdsSinhVien.Position = vitri;
                    return;
                }
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được thiếu!", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return;
            }

            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ sinh viên không được thiếu!", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }

            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên sinh viên không được thiếu!", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ sinh viên không được thiếu!", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }

            if (txtPASS.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được thiếu!", "", MessageBoxButtons.OK);
                txtPASS.Focus();
                return;
            }

            if (ngaySinh.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh không được thiếu!", "", MessageBoxButtons.OK);
                ngaySinh.Focus();
                return;
            }
            maSV = ((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString();
            if(suKien.Equals("THEM") || (suKien.Equals("HC") && !txtMaSV.Text.Equals(maSV)))
            {
                string strLenh = "EXEC SP_CHECKEXISTSSV '" + txtMaSV.Text + "'";
                SqlDataReader dataReaderSV = Program.ExecSqlDataReader(strLenh);
                dataReaderSV.Read();
                int check = Int32.Parse(dataReaderSV.GetString(0));
                if(check == 0)
                {
                    try
                    {
                        bdsSinhVien.EndEdit();
                        bdsSinhVien.ResetCurrentItem();
                        this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.SINHVIENTableAdapter.Update(this.dSSinhVien.SINHVIEN);
                    } catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi sinh viên " + ex.Message, "", MessageBoxButtons.OK);
                        Program.conn.Close();
                        return;
                    }
                } else
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại trong hệ thống", "", MessageBoxButtons.OK);
                }
                dataReaderSV.Close();
                Program.conn.Close();
            } else if (suKien.Equals("HC"))
            {
                try
                {
                    bdsSinhVien.EndEdit();
                    bdsSinhVien.ResetCurrentItem();
                    this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.SINHVIENTableAdapter.Update(this.dSSinhVien.SINHVIEN);
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi sinh viên " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }

            gcSinhVien.Enabled = true;
            gcLop.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled
                = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
        }
    }
}
