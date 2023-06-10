using DevExpress.Utils.Extensions;
using DevExpress.XtraReports.UI;
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
using TaoFormThiTNTest;

namespace THITRACNGHIEM
{
    public partial class frmChuanBiThiSV : Form
    {
        string maSV = Program.username;
        int vitrimonthi = 0;
        public frmChuanBiThiSV()
        {
            InitializeComponent();
        }

        private void frmChuanBiThi_Load(object sender, EventArgs e)
        {
            
            dSChuanBiThi.EnforceConstraints = false;
            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.FillDanhSachThi(this.dSChuanBiThi.GIAOVIEN_DANGKY, maSV.Trim());
            
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dSChuanBiThi.LOP);
            
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.dSChuanBiThi.MONHOC);

            Program.conn.Close();
            if(bdsGVDK.Count == 0)
            {
                groupBox1.Visible = false;
            } else
            {
                groupBox1.Visible = true;
            }
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSChuanBiThi);

        }

        private void btnVaoThi_Click(object sender, EventArgs e)
        {
            if (!this.txtNgayThi.ToString().Equals(DateTime.Today.ToString()))
            {
                MessageBox.Show("Đã quá ngày thi", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string strLenhCheck = "EXEC SP_CHECKTHI '" + maSV + "'" + ",'" + txtMaMH.Text + "'," + Int32.Parse(txtLan.Text);
            SqlDataReader dataReaderCheckThi = Program.ExecSqlDataReader(strLenhCheck);
            dataReaderCheckThi.Read();
            int checkthi = dataReaderCheckThi.GetInt32(0);
            dataReaderCheckThi.Close();
            // check xem form thi da duoc mo chua
            Form frm = this.CheckExist(typeof(frmThiSinhVien));
            if (frm != null) frm.Activate();
            else
            {
                if (checkthi == 0)
                {
                    if (txtLan.Text.Equals("2")) // nếu thi lần 2 thì cần check xem đã thi lần 1 chưa
                    {
                        string strLenh = "EXEC SP_CHECKTHILAN2 '" + maSV + "'" + ",'" + txtMaMH.Text + "'";
                        SqlDataReader dataReaderCheckThiLan2 = Program.ExecSqlDataReader(strLenh);
                        dataReaderCheckThiLan2.Read();
                        int check = dataReaderCheckThiLan2.GetInt32(0);
                        dataReaderCheckThiLan2.Close();
                        if (check == 1) //đã thi lần 1
                        {
                            //vao thi
                            frmThiSinhVien f = new frmThiSinhVien(txtMaMH.Text, txtTenMH.Text, maSV,
                                                            Program.mHoTen, txtMaLop.Text, txtTenLop.Text, Int32.Parse(txtLan.Text), Int32.Parse(txtSoCauThi.Text), Int32.Parse(txtTG.Text));
                            f.Show();
                        }
                        else // chưa thi lần 1
                        {
                            MessageBox.Show("Môn học này bạn chưa thi lần 1! Vui lòng thi lần 1", "", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    else // chọn thi lần 1
                    {
                        //vao thi
                        frmThiSinhVien f = new frmThiSinhVien(txtMaMH.Text, txtTenMH.Text, maSV,
                                                            Program.mHoTen, txtMaLop.Text, txtTenLop.Text, Int32.Parse(txtLan.Text), Int32.Parse(txtSoCauThi.Text), Int32.Parse(txtTG.Text));
                        f.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn đã thi! Vui lòng Click Reload để hiện thông tin mới nhất", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXemLaiKQ_Click(object sender, EventArgs e)
        {
            //tao xtrareport sau
            
            Xrpt_BaiThi xrpt = new Xrpt_BaiThi(maSV, this.txtMaMH.Text, Int32.Parse(this.txtLan.Text));
            xrpt.lblLop.Text = this.txtTenLop.Text;
            xrpt.lblHoTen.Text = Program.mHoTen;
            xrpt.lblMonThi.Text = this.txtTenMH.Text;
            xrpt.lblNgayThi.Text = this.txtNgayThi.Text;
            xrpt.lblLan.Text = this.txtLan.Text;
            
            ReportPrintTool print = new ReportPrintTool(xrpt);
            print.ShowPreviewDialog();
        }

        private Form CheckExist(Type ftype)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (ftype == f.GetType())
                {
                    return f;
                }
            }
            return null;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitrimonthi = bdsGVDK.Position;
            try
            {
                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIEN_DANGKYTableAdapter.FillDanhSachThi(this.dSChuanBiThi.GIAOVIEN_DANGKY, maSV.Trim());
                bdsGVDK.Position = vitrimonthi;

                
                if (bdsGVDK.Count == 0)
                {
                    groupBox1.Visible = false;
                }
                else
                {
                    groupBox1.Visible = true;
                }
            } catch( Exception ex ) 
            {
                MessageBox.Show("Lỗi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsGVDK.Count == 0) return;
            string maMHQuery = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAMH"].ToString();
            int lanQuery = Int32.Parse( ((DataRowView)bdsGVDK[bdsGVDK.Position])["LAN"].ToString());
            string strLenh = "EXEC SP_CHECKTHI '" + maSV + "'" + ",'" + maMHQuery + "'," + lanQuery;
            SqlDataReader dataReaderCheckThi = Program.ExecSqlDataReader(strLenh);
            dataReaderCheckThi.Read();
            int check = dataReaderCheckThi.GetInt32(0);
            dataReaderCheckThi.Close();
            Program.conn.Close();
            int vitriMH = bdsMonHoc.Find("MaMH", maMHQuery);
            this.txtTenMH.Text = ((DataRowView)bdsMonHoc[vitriMH])["TENMH"].ToString();
            if (check == 0)
            {

                btnVaoThi.Visible = true;
                btnXemLaiKQ.Visible = false;
            }
            else
            {
                btnVaoThi.Visible = false;
                btnXemLaiKQ.Visible = true;
            }
            
        }
    }
}
