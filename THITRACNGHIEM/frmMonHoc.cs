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
    public partial class frmMonHoc : Form
    {
        int vitri = 0;
        string suKien = "";
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMONHOC.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSMonHoc);

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSMonHoc.BODE' table. You can move, or remove it, as needed.
            
            dSMonHoc.EnforceConstraints = false; // vẫn tải các khóa ngoại về nhưng không kiểm tra ràng buộc

            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.dSMonHoc.MONHOC);

            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSMonHoc.GIAOVIEN_DANGKY);

            this.BANGDIEMTableAdapter.Connection.ConnectionString= Program.connstr;
            this.BANGDIEMTableAdapter.Fill(this.dSMonHoc.BANGDIEM);

            this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.BODETableAdapter.Fill(this.dSMonHoc.BODE);

            if (Program.mGroup.Equals("TRUONG")) // nếu là nhóm trường thì chỉ được phép xem dữ liệu
            {
                btnThem.Enabled = btnHieuChinh.Enabled = btnGhi.Enabled = 
                    btnXoa.Enabled = btnPhucHoi.Enabled = groupBox1.Enabled = false;
            } else if (Program.mGroup.Equals("COSO"))
            {
                btnGhi.Enabled = false;
                btnPhucHoi.Enabled = groupBox1.Enabled = false;
            }

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            vitri = bdsMONHOC.Position;
            suKien = "THEM";
            groupBox1.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
            bdsMONHOC.AddNew();

            txtMaMH.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = 
                btnReload.Enabled =  btnThoat.Enabled = false;
            gcMonHoc.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMONHOC.CancelEdit();
            if(btnThem.Enabled == false) bdsMONHOC.Position = vitri;
            gcMonHoc.Enabled = true;
            groupBox1.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled =  true;
            btnGhi.Enabled = btnPhucHoi.Enabled =false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMONHOC.Position;
            suKien = "HC";
            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Không thể sửa môn học này vì đã có giáo viên đăng kí thi", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBANGDIEM.Count > 0)
            {
                MessageBox.Show("Không thể sửa môn học này vì đã có sinh viên thi", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBODE.Count > 0)
            {
                MessageBox.Show("Không thể sửa môn học này vì đã có câu hỏi thi.", "", MessageBoxButtons.OK);
                return;
            }
            groupBox1.Enabled = true;
            gcMonHoc.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = 
                btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMONHOC.Position;
            try
            {
                this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.MONHOCTableAdapter.Fill(this.dSMonHoc.MONHOC);
                bdsMONHOC.Position = vitri;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mamh = "";
            if(bdsGVDK.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học này vì đã có giáo viên đăng kí thi", "", MessageBoxButtons.OK);
                return;
            }
            if(bdsBANGDIEM.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học này vì đã có sinh viên thi", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBODE.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học này vì đã có câu hỏi thi.", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    mamh = ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["MAMH"].ToString();
                    bdsMONHOC.RemoveCurrent();
                    this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.MONHOCTableAdapter.Update(this.dSMonHoc.MONHOC);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa môn học. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.MONHOCTableAdapter.Fill(this.dSMonHoc.MONHOC);
                    bdsMONHOC.Position = bdsMONHOC.Find("MAMH", mamh);
                    return;
                }
            }
            if (bdsMONHOC.Count == 0) btnXoa.Enabled = false;
        }
        
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if(txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được thiếu" , "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không được thiếu", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }
            string maMH = ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["MAMH"].ToString();
            if (suKien.Equals("THEM") || (suKien.Equals("HC") && !txtMaMH.Text.Equals(maMH))) // nếu sử dụng nút thêm hoặc nút hiệu chỉnh mà ở đó sửa cả mã
            {
                string strLenh = "EXEC SP_CHECKEXISTSMONHOC '" + txtMaMH.Text + "'";
                SqlDataReader dataReaderMonHoc = Program.ExecSqlDataReader(strLenh);
                dataReaderMonHoc.Read();
                int check = dataReaderMonHoc.GetInt32(0); // check xem trong db đã có mã môn học này hay chưa
                dataReaderMonHoc.Close();
                Program.conn.Close();
                if (check == 0)
                {
                    try
                    {
                        bdsMONHOC.EndEdit();
                        bdsMONHOC.ResetCurrentItem();
                        this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.MONHOCTableAdapter.Update(this.dSMonHoc.MONHOC);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mã môn học đã tồn tại.\n", "", MessageBoxButtons.OK);
                    return;
                }
                
            } else if (suKien.Equals("HC")) // sử dụng nút hiệu chỉnh và chỉ sửa mỗi tên môn học
            {
                try
                {
                    bdsMONHOC.EndEdit();
                    bdsMONHOC.ResetCurrentItem();
                    this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.MONHOCTableAdapter.Update(this.dSMonHoc.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            
            gcMonHoc.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled 
                = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsMONHOC.Count == 0)
            {
                btnXoa.Enabled = false;
                btnHieuChinh.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
                btnHieuChinh.Enabled = true;
            }
        }
    }
}
