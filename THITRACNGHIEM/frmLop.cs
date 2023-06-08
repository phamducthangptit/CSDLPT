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
    public partial class frmLop : Form
    {
        string maKhoa = "";
        int vitri = 0;
        int vitrikhoa = 0;
        string suKien = "";
        string maLop = "";
        public frmLop()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSLop);

        }

        private void frmLop_Load(object sender, EventArgs e)
        {

            dSLop.EnforceConstraints = false;

            this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.KHOATableAdapter.Fill(this.dSLop.KHOA);

            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dSLop.LOP);

            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSLop.GIAOVIEN_DANGKY);

            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.dSLop.SINHVIEN);


            //cmbCoSo
            cmbCoSo.DataSource = Program.bds_dspm;
            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
            cmbCoSo.SelectedIndex = Program.mChiNhanh;

            if (Program.mGroup.Equals("TRUONG"))
            {
                btnThem.Enabled = btnHieuChinh.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
                btnReload.Enabled = btnThoat.Enabled = true;
                cmbCoSo.Enabled = true;

            }
            else
            {
                cmbCoSo.Enabled = false;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            }
            groupBox1.Enabled = false;
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
                MessageBox.Show("Lỗi kết nối về cơ sở!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Fill(this.dSLop.KHOA);

                this.dSLop.LOP.Clear();

                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dSLop.LOP);

                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSLop.GIAOVIEN_DANGKY);

                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.dSLop.SINHVIEN);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLOP.Position;
            vitrikhoa = bdsKHOA.Position;
            try
            {
                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Fill(this.dSLop.KHOA);
                bdsKHOA.Position = vitrikhoa;

                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dSLop.LOP);
                bdsLOP.Position = vitri;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.CancelEdit();
            bdsLOP.Position = vitri;

            gcLop.Enabled = true;
            gcKHOA.Enabled = true;
            groupBox1.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suKien = "THEM";
            
            vitri = bdsLOP.Position;
            bdsLOP.AddNew();
            maKhoa = ((DataRowView)bdsKHOA[bdsKHOA.Position])["MAKH"].ToString();

            txtMaLop.Enabled = true;
            txtMaKhoa.Text = maKhoa;


            groupBox1.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;

            gcLop.Enabled = false;
            gcKHOA.Enabled = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suKien = "HC";
            vitri = bdsLOP.Position;
            groupBox1.Enabled = true;
            gcKHOA.Enabled = false;
            gcLop.Enabled = false;

            btnPhucHoi.Enabled = btnGhi.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;

            if (bdsSINHVIEN.Count > 0 || bdsGVDK.Count > 0) //đã có sinh viên thì chỉ sửa được tên
            {
                txtMaLop.Enabled = false;
            }
            else txtMaLop.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsSINHVIEN.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp vì đã tồn tại sinh viên!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp vì đã đăng kí thi!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
                    bdsLOP.RemoveCurrent();
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTableAdapter.Update(this.dSLop.LOP);
                } catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa lớp " + ex.Message, "", MessageBoxButtons.OK);
                    this.LOPTableAdapter.Fill(this.dSLop.LOP);
                    bdsLOP.Position = this.bdsLOP.Find("MALOP", maLop);
                    return;
                }
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được thiếu", "", MessageBoxButtons.OK);
                txtMaKhoa.Focus();
                return;
            }

            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Tên lớp không được thiếu", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }

            maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();

            if (suKien.Equals("THEM") || (suKien.Equals("HC") && !maLop.Equals(txtMaLop.Text)))
            {
                string strLenh = "EXEC SP_CHECKEXISTSLOP '" + txtMaLop.Text + "'";
                SqlDataReader dataReaderLop = Program.ExecSqlDataReader(strLenh);
                dataReaderLop.Read();
                int check = Int32.Parse(dataReaderLop.GetString(0));
                if(check == 0)
                {
                    try
                    {
                        bdsLOP.EndEdit();
                        bdsLOP.ResetCurrentItem();
                        this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.LOPTableAdapter.Update(this.dSLop.LOP);
                    } catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi lớp " + ex.Message, "", MessageBoxButtons.OK);
                        Program.conn.Close();
                        return;
                    }

                } else
                {
                    MessageBox.Show("Mã lớp đã tồn tại trong hệ thống", "", MessageBoxButtons.OK);
                    return;
                }
                dataReaderLop.Close();
                Program.conn.Close();
            } else if (suKien.Equals("HC"))
            {
                try
                {
                    bdsLOP.EndEdit();
                    bdsLOP.ResetCurrentItem();
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTableAdapter.Update(this.dSLop.LOP);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi lớp " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                Program.conn.Close();
            }

            gcLop.Enabled = true;
            gcKHOA.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled
                = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
        }
    }
}
