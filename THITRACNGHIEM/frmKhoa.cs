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
    public partial class frmKhoa : Form
    {
        string suKien = "";
        int vitri = 0;
        string maKhoa = "";
        public frmKhoa()
        {
            InitializeComponent();
        }



        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKHOA.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSKhoa);

        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            dSKhoa.EnforceConstraints = false;

            this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.KHOATableAdapter.Fill(this.dSKhoa.KHOA);

            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dSKhoa.LOP);

            this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIENTableAdapter.Fill(this.dSKhoa.GIAOVIEN);

            cmbCoSo.DataSource = Program.bds_dspm; // sao chép ds phân mảnh đã load ở form đăng nhập
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
                MessageBox.Show("Lỗi kết nối!", "", MessageBoxButtons.OK);
            }
            else
            {
                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Fill(this.dSKhoa.KHOA);

                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dSKhoa.LOP);

                this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIENTableAdapter.Fill(this.dSKhoa.GIAOVIEN);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKHOA.Position;
            try
            {
                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Fill(this.dSKhoa.KHOA);
                bdsKHOA.Position = vitri;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKHOA.CancelEdit();
            vitri = bdsKHOA.Position;

            gcKhoa.Enabled = true;
            groupBox1.Enabled = false;


            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suKien = "THEM";
            bdsKHOA.AddNew();
            vitri = bdsKHOA.Position;
            //lấy mã cơ sở hiện tại
            string strLenh = "SELECT MACS FROM COSO";
            SqlDataReader dataReaderCoSo = Program.ExecSqlDataReader(strLenh);
            dataReaderCoSo.Read();
            txtCoSo.Text = dataReaderCoSo.GetString(0);
            dataReaderCoSo.Close();
            Program.conn.Close();
            //txtCoSo.Text = bdsKHOA.;
            groupBox1.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;

            gcKhoa.Enabled = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKHOA.Position;
            suKien = "HC";
            groupBox1.Enabled = true;
            gcKhoa.Enabled = false;
            btnPhucHoi.Enabled = btnGhi.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;
            if (bdsGIAOVIEN.Count > 0 || bdsLOP.Count > 0) // nếu đã có lớp hoặc sv trong khoa thì chỉ sửa được tên khoa
            {
                txtMaKhoa.Enabled = false;
            }
            else txtMaKhoa.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsGIAOVIEN.Count > 0)
            {
                MessageBox.Show("Không thể xóa khoa vì đã có giáo viên trong khoa", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsLOP.Count > 0)
            {
                MessageBox.Show("Không thể xóa khoa vì đã có lớp trong khoa", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa khoa này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maKhoa = ((DataRowView)bdsKHOA[bdsKHOA.Position])["MAKH"].ToString();
                    bdsKHOA.RemoveCurrent();
                    this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.KHOATableAdapter.Update(this.dSKhoa.KHOA);

                } catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa khoa! Bạn hãy xóa lại!", "", MessageBoxButtons.OK);
                    this.KHOATableAdapter.Fill(this.dSKhoa.KHOA);
                    bdsKHOA.Position = bdsKHOA.Find("MAKH", maKhoa);
                    return;
                }
            }
            if (bdsKHOA.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMaKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Mã khoa không được trống!", "", MessageBoxButtons.OK);
                txtMaKhoa.Focus();
                return;
            }
            if (txtTenKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Tên khoa không được trống!", "", MessageBoxButtons.OK);
                txtTenKhoa.Focus();
                return;
            }
            maKhoa = ((DataRowView)bdsKHOA[bdsKHOA.Position])["MAKH"].ToString();
            
            if(suKien.Equals("THEM") || (suKien.Equals("HC") && !txtMaKhoa.Text.Equals(maKhoa)))
            {
                string strLenh = "EXEC SP_CHECKEXISTSKHOA '" + txtMaKhoa.Text + "'";
                SqlDataReader dataReaderKhoa = Program.ExecSqlDataReader(strLenh);
                dataReaderKhoa.Read();
                int check = Int32.Parse(dataReaderKhoa.GetString(0)); // check xem đã có mã khoa trong db chưa
                if(check == 0)
                {
                    try
                    {
                        bdsKHOA.EndEdit();
                        bdsKHOA.ResetCurrentItem();
                        this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                        this.KHOATableAdapter.Update(this.dSKhoa.KHOA);

                    } catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi khoa " + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                } else
                {
                    MessageBox.Show("Mã khoa đã tồn tại trong hệ thống!", "", MessageBoxButtons.OK);
                    return;
                }
                dataReaderKhoa.Close();
                Program.conn.Close();
            } else if(suKien.Equals("HC"))
            {
                try
                {
                    bdsKHOA.EndEdit();
                    bdsKHOA.ResetCurrentItem();
                    this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.KHOATableAdapter.Update(this.dSKhoa.KHOA);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi khoa " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            gcKhoa.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled
                = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
        }
    }
}
