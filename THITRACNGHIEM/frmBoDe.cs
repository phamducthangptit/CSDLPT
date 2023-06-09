using DevExpress.XtraReports.UI;
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
    public partial class frmBoDe : Form
    {
        string maMH = "";
        string suKien = "";
        int vitrimonhoc = 0, vitricauhoi = 0;
        int idch = 0;
        public frmBoDe()
        {
            InitializeComponent();
        }

        private void frmBoDe_Load(object sender, EventArgs e)
        {
            dSBoDe.EnforceConstraints = false;

            
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.dSBoDe.MONHOC);

            this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.BODETableAdapter.FillByMaGV(this.dSBoDe.BODE, Program.username);

            this.BAITHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.BAITHITableAdapter.Fill(this.dSBoDe.BAITHI);

            groupBox1.Enabled = false;

            vitricauhoi = bdsBODE.Position;
            vitrimonhoc = bdsMONHOC.Position;

            maMH = ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["MAMH"].ToString();

            cmbTrinhDo.Items.Add("A");
            cmbTrinhDo.Items.Add("B");
            cmbTrinhDo.Items.Add("C");


            cmbDapAn.Items.Add("A");
            cmbDapAn.Items.Add("B");
            cmbDapAn.Items.Add("C");
            cmbDapAn.Items.Add("D");

            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitricauhoi = bdsBODE.Position;
            vitrimonhoc = bdsMONHOC.Position;
            try
            {
                this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.MONHOCTableAdapter.Fill(this.dSBoDe.MONHOC);
                bdsMONHOC.Position = vitrimonhoc;

                this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.BODETableAdapter.FillByMaGV(this.dSBoDe.BODE, Program.username);
                bdsBODE.Position = vitricauhoi;

                this.BAITHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.BAITHITableAdapter.Fill(this.dSBoDe.BAITHI);
                Program.conn.Close();
            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitricauhoi = bdsBODE.Position;
            vitrimonhoc = bdsMONHOC.Position;
            bdsBODE.CancelEdit();
            gcBoDe.Enabled = true;
            gcMonHoc.Enabled = true;
            groupBox1.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suKien = "THEM";
            vitricauhoi = bdsBODE.Position;
            vitrimonhoc = bdsMONHOC.Position;
            bdsBODE.AddNew();
            maMH = ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["MAMH"].ToString();

            txtMaMH.Text = maMH;
            txtMaGV.Text = Program.username;

            groupBox1.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;

            gcBoDe.Enabled = false;
            gcMonHoc.Enabled = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suKien = "HC";
            if(bdsBAITHI.Count > 0)
            {
                MessageBox.Show("Không thể chỉnh sửa câu hỏi vì đã có sinh viên thi!", "", MessageBoxButtons.OK);
                return;
            }
            if(bdsBODE.Count == 0)
            {
                MessageBox.Show("Chưa có câu hỏi để chỉnh sửa!", "", MessageBoxButtons.OK);
                return;
            }
            idch = Int32.Parse(((DataRowView)bdsBODE[bdsBODE.Position])["CAUHOI"].ToString());
            gcBoDe.Enabled = false;
            gcMonHoc.Enabled = false;

            btnPhucHoi.Enabled = btnGhi.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (bdsBAITHI.Count > 0)
            {
                MessageBox.Show("Không thể xóa câu hỏi này vì đã được thi!", "", MessageBoxButtons.OK);
                return;
            }
            idch = Int32.Parse(((DataRowView)bdsBODE[bdsBODE.Position])["CAUHOI"].ToString());
            if (MessageBox.Show("Bạn có thật sự muốn câu hỏi này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String strcmd = "SP_DELETECAUHOI '" + idch + "'";
                int result = Program.ExecSqlNonQuery(strcmd, Program.connstr);
                btnReload_ItemClick(sender, e);
                if (bdsBODE.Count == 0) btnXoa.Enabled = false;
            }
        }

        private void btnInDsCauHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsBODE.Count == 0)
            {
                MessageBox.Show("Chưa có câu hỏi để in!", "", MessageBoxButtons.OK);
                return;
            }
            String maGV = txtMaGV.Text;
            String maMH = txtMaMH.Text;
            String tenMH = ((DataRowView)bdsMONHOC[bdsMONHOC.Position])["TENMH"].ToString();
            String hoTen = Program.mHoTen;

            Xrpt_CauHoiTheoGV rpt = new Xrpt_CauHoiTheoGV(maGV, maMH);
            rpt.lblTieuDe.Text= "DANH SÁCH CÂU HỎI MÔN " + tenMH.ToUpper() + " CỦA GIÁO VIÊN " + hoTen.ToUpper();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();

        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsBODE.Count == 0)
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

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtNoiDung.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung không được trống", "", MessageBoxButtons.OK);
                txtNoiDung.Focus();
                return;
            }

            if (txtDapAnA.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án A không được trống", "", MessageBoxButtons.OK);
                txtDapAnA.Focus();
                return;
            }

            if (txtDapAnB.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án B không được trống", "", MessageBoxButtons.OK);
                txtDapAnB.Focus();
                return;
            }

            if (txtDapAnC.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án C không được trống", "", MessageBoxButtons.OK);
                txtDapAnC.Focus();
                return;
            }

            if (txtDapAnD.Text.Trim() == "")
            {
                MessageBox.Show("Đáp án D không được trống", "", MessageBoxButtons.OK);
                txtDapAnD.Focus();
                return;
            }
            if(cmbDapAn.SelectedIndex == -1)
            {
                MessageBox.Show("Đáp án không được để trống", "", MessageBoxButtons.OK);
                cmbDapAn.Focus();
                return;
            }

            if(cmbTrinhDo.SelectedIndex == -1)
            {
                MessageBox.Show("Trình độ không được để trống", "", MessageBoxButtons.OK);
                cmbTrinhDo.Focus();
                return;
            }
            if (suKien.Equals("THEM")) //sự kiện thêm câu hỏi
            {
                String strcmd = "SP_INSERTCAUHOI N'" + txtMaMH.Text +
                    "',N'" + cmbTrinhDo.SelectedItem.ToString() +
                    "',N'" + txtNoiDung.Text + "',N'" + txtDapAnA.Text +
                    "',N'" + txtDapAnB.Text + "',N'" + txtDapAnC.Text +
                    "',N'" + txtDapAnD.Text + "',N'" + cmbDapAn.SelectedItem.ToString() +
                    "',N'" + txtMaGV.Text + "'";
                int result = Program.ExecSqlNonQuery(strcmd, Program.connstr);
                btnReload_ItemClick(sender, e);
            }

            if (suKien.Equals("HC"))
            {
                String strcmd = "SP_UPDATECAUHOI '" + idch +
                    "',N'" + cmbTrinhDo.SelectedItem.ToString() +
                    "',N'" + txtNoiDung.Text + "',N'" + txtDapAnA.Text +
                    "',N'" + txtDapAnB.Text + "',N'" + txtDapAnC.Text +
                    "',N'" + txtDapAnD.Text + "',N'" + cmbDapAn.SelectedItem.ToString() + "'";
                int result = Program.ExecSqlNonQuery(strcmd, Program.connstr);
                btnReload_ItemClick(sender, e);
            }

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled
               = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
            gcBoDe.Enabled = true;
            gcMonHoc.Enabled = true;
        }
    }
}
