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
    public partial class frmGiangVien : Form
    {
        string maKhoa = "";
        int vitri = 0;
        int vitrikhoa = 0;
        string suKien = "";
        string maGV = "";
        public frmGiangVien()
        {
            InitializeComponent();
        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGIANGVIEN.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSGiangVien);

        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {

            dSGiangVien.EnforceConstraints = false;
            // Load khoa của cơ sở đó trước
            this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.KHOATableAdapter.Fill(this.dSGiangVien.KHOA);

            this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIENTableAdapter.Fill(this.dSGiangVien.GIAOVIEN);


            this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.BODETableAdapter.Fill(this.dSGiangVien.BODE);


            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSGiangVien.GIAOVIEN_DANGKY);

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
                groupBox1.Enabled = false;
            }
        }

        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCoSo.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.servername = cmbCoSo.SelectedValue.ToString();

            if(cmbCoSo.SelectedIndex != Program.mChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            } else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if(Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            } else
            {

                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Fill(this.dSGiangVien.KHOA);

                this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIENTableAdapter.Fill(this.dSGiangVien.GIAOVIEN);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitrikhoa = bdsKHOA.Position;
            vitri = bdsGIANGVIEN.Position;
            try
            {
                this.KHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.KHOATableAdapter.Fill(this.dSGiangVien.KHOA);
                bdsKHOA.Position = vitrikhoa;

                this.dSGiangVien.GIAOVIEN.Clear();

                this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIENTableAdapter.Fill(this.dSGiangVien.GIAOVIEN);
                bdsGIANGVIEN.Position = vitri;
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGIANGVIEN.CancelEdit();
            bdsGIANGVIEN.Position = vitri;

            gcGiangVien.Enabled = true;
            gcKHOA.Enabled = true;
            groupBox1.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suKien = "THEM";
            maKhoa = ((DataRowView)bdsKHOA[bdsKHOA.Position])["MAKH"].ToString();
            vitri = bdsGIANGVIEN.Position;
            bdsGIANGVIEN.AddNew();
            txtMaKhoa.Text = maKhoa;

            this.txtMaGV.Enabled = true;
            groupBox1.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = 
                btnReload.Enabled = btnThoat.Enabled = false;

            gcGiangVien.Enabled = false;
            gcKHOA.Enabled = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGIANGVIEN.Position;
            suKien = "HC";
            groupBox1.Enabled = true;
            gcGiangVien.Enabled = false;
            gcKHOA.Enabled = false;
            btnPhucHoi.Enabled = btnGhi.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;
            if (bdsBODE.Count > 0 || bdsGVDK.Count > 0) //nếu gv đã đki hoặc ra đề thi thì chỉ cho sửa họ tên địa chỉ
            {
                txtMaGV.Enabled = false;
            }
            else txtMaGV.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMaGV.Text.Trim() == "")
            {
                MessageBox.Show("Mã giảng viên không được thiếu", "", MessageBoxButtons.OK);
                txtMaGV.Focus();
                return;
            }
            if (txtHoGV.Text.Trim() == "")
            {
                MessageBox.Show("Họ giảng viên không được thiếu", "", MessageBoxButtons.OK);
                txtHoGV.Focus();
                return;
            }
            if (txtTenGV.Text.Trim() == "")
            {
                MessageBox.Show("Tên giảng viên không được thiếu", "", MessageBoxButtons.OK);
                txtTenGV.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ của giảng viên không được thiếu", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }

            maGV = ((DataRowView)bdsGIANGVIEN[bdsGIANGVIEN.Position])["MAGV"].ToString();

            if(suKien.Equals("THEM") || (suKien.Equals("HC") && !txtMaGV.Text.Equals(maGV)))
            {
                string strLenh = "EXEC SP_CHECKEXISTSGV '" + txtMaGV.Text + "'";
                SqlDataReader dataReaderGV = Program.ExecSqlDataReader(strLenh);
                dataReaderGV.Read();
                int check = dataReaderGV.GetInt32(0); // check xem trong db đã có mã gv này hay chưa
                dataReaderGV.Close();
                Program.conn.Close();
                if (check == 0)
                {
                    try
                    {
                        bdsGIANGVIEN.EndEdit();
                        bdsGIANGVIEN.ResetCurrentItem();
                        this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.GIAOVIENTableAdapter.Update(this.dSGiangVien.GIAOVIEN);
                    } catch (Exception ex) 
                    {
                        MessageBox.Show("Lỗi ghi giảng viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                } else
                {
                    MessageBox.Show("Mã giảng viên đã tồn tại.\n", "", MessageBoxButtons.OK);
                    return;
                }
                
            } else if (suKien.Equals("HC"))
            {
                try
                {
                    bdsGIANGVIEN.EndEdit();
                    bdsGIANGVIEN.ResetCurrentItem();
                    this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.GIAOVIENTableAdapter.Update(this.dSGiangVien.GIAOVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi giảng viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }

            gcGiangVien.Enabled = true;
            gcKHOA.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled
                = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsBODE.Count > 0)
            {
                MessageBox.Show("Không thể xóa giảng viên này vì giảng viên đã ra đề", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Không thể xóa giảng viên này vì giảng viên đã đăng kí thi", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa giảng viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maGV = ((DataRowView)bdsGIANGVIEN[bdsGIANGVIEN.Position])["MAGV"].ToString();

                    bdsGIANGVIEN.RemoveCurrent();
                    this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.GIAOVIENTableAdapter.Update(this.dSGiangVien.GIAOVIEN);

                } catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa giảng viên. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.GIAOVIENTableAdapter.Fill(this.dSGiangVien.GIAOVIEN);
                    bdsGIANGVIEN.Position = bdsGIANGVIEN.Find("MAGV", maGV);
                    return;
                }
                if(bdsGIANGVIEN.Count == 0) btnXoa.Enabled = false;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(bdsGIANGVIEN.Count == 0)
            {
                btnXoa.Enabled = false;
                btnHieuChinh.Enabled = false;
            } else
            {
                btnXoa.Enabled = true;
                btnHieuChinh.Enabled = true;
            }
        }
    }
}
