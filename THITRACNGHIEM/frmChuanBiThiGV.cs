using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaoFormThiTNTest;

namespace THITRACNGHIEM
{
    public partial class frmChuanBiThiGV : Form
    {
        string maGV = Program.username;
        int vitrimonthi = 0;
        public frmChuanBiThiGV()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSChuanBiThi);

        }

        private void frmChuanBiThiGV_Load(object sender, EventArgs e)
        {
            
            dSChuanBiThi.EnforceConstraints = false;
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dSChuanBiThi.LOP);

            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.dSChuanBiThi.MONHOC);

            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.FillByMaGV(this.dSChuanBiThi.GIAOVIEN_DANGKY, maGV);

            if(bdsGVDK.Count != 0)
            {
                groupBox1.Visible = true;
            } else
            {
                groupBox1.Visible = false;
            }
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSChuanBiThi);

        }

        private void gIAOVIEN_DANGKYGridControl_Click(object sender, EventArgs e)
        {
            bdsLop.Position = bdsLop.Find("MALOP", this.txtMaLop.Text);
            this.txtTenLop.Text = ((DataRowView)bdsLop[bdsLop.Position])["TENLOP"].ToString();

            bdsMonHoc.Position = bdsMonHoc.Find("MAMH", this.txtMaMH.Text);
            this.txtTenMH.Text = ((DataRowView)bdsMonHoc[bdsMonHoc.Position])["TENMH"].ToString();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitrimonthi = bdsGVDK.Position;

            try
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dSChuanBiThi.LOP);

                this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.MONHOCTableAdapter.Fill(this.dSChuanBiThi.MONHOC);

                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIEN_DANGKYTableAdapter.FillByMaGV(this.dSChuanBiThi.GIAOVIEN_DANGKY, maGV);
                bdsGVDK.Position = vitrimonthi;

                bdsLop.Position = bdsLop.Find("MALOP", this.txtMaLop.Text);
                this.txtTenLop.Text = ((DataRowView)bdsLop[bdsLop.Position])["TENLOP"].ToString();

                bdsMonHoc.Position = bdsMonHoc.Find("MAMH", this.txtMaMH.Text);
                this.txtTenMH.Text = ((DataRowView)bdsMonHoc[bdsMonHoc.Position])["TENMH"].ToString();

            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThiThu_Click(object sender, EventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmThiGV));
            if (frm != null) frm.Activate();
            else
            {
                // vào thi thử
                frmThiGV f = new frmThiGV(this.txtMaMH.Text, this.txtTenMH.Text, maGV, 
                    Program.mHoTen, this.txtMaLop.Text, this.txtTenLop.Text, 
                    Int32.Parse(this.txtLan.Text), Int32.Parse(this.txtSoCauThi.Text), Int32.Parse(this.txtTG.Text));
                f.Show();
            }
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int vitriMH = bdsMonHoc.Find("MaMH", this.txtMaMH.Text);
            this.txtTenMH.Text = ((DataRowView)bdsMonHoc[vitriMH])["TENMH"].ToString();
        }
    }
}
