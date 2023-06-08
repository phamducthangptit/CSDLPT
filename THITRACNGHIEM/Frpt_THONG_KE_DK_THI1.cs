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
    public partial class Frpt_THONG_KE_DK_THI1 : Form
    {

        int chuyenCoSo;
        int thaydoiNgay;
        string tuNgay1 = "";
        string denNgay1 = "";
        public Frpt_THONG_KE_DK_THI1()
        {
            InitializeComponent();
        }

        private void Frpt_THONG_KE_DK_THI1_Load(object sender, EventArgs e)
        {
            cmbCoSo.DataSource = Program.bds_dspm; // sao chép ds phân mảnh đã load ở form đăng nhập
            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
            cmbCoSo.SelectedIndex = Program.mChiNhanh;
            chuyenCoSo = 0;
            thaydoiNgay = 0;
            if (Program.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
            }
            else
            {
                cmbCoSo.Enabled = false;
            }
        }

        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCoSo.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.servername = cmbCoSo.SelectedValue.ToString();

            if (cmbCoSo.SelectedIndex != Program.mChiNhanh)
            {
                chuyenCoSo = 1;
            }
            else
            {
                chuyenCoSo = 0;
            }
        }
        private string chuyenDangNgay(string s)
        {
            string[] tmp = s.Split('/');
            return tmp[2] + "/" + tmp[1] + "/" + tmp[0];
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            string tuNgay = deTuNgay.Text.Trim();
            string denNgay = deDenNgay.Text.Trim();
            Xrpt_THONG_KE_DK_THI1 rpt;
            if (tuNgay== "")
            {
                MessageBox.Show("Ngày bắt đầu không được thiếu", "", MessageBoxButtons.OK);
                deTuNgay.Focus();
                return;
            }

            if (denNgay == "")
            {
                MessageBox.Show("Ngày kết thúc không được thiếu", "", MessageBoxButtons.OK);
                deDenNgay.Focus();
                return;
            }
            if (tuNgay == tuNgay1 && denNgay == denNgay1 )
            {
                thaydoiNgay = 0;
            } else
            {
                thaydoiNgay = 1;
            }
            if (chuyenCoSo == 0 && thaydoiNgay == 0)
            {
                rpt = new Xrpt_THONG_KE_DK_THI1(0, chuyenDangNgay(tuNgay),chuyenDangNgay( denNgay));
                rpt.lblTieuDe.Text = "DANH SÁCH ĐĂNG KÝ THI TRẮC NGHIỆM " + cmbCoSo.Text.ToUpper();
                rpt.lblNgay.Text = "TỪ NGÀY " + tuNgay + " ĐẾN NGÀY " + denNgay;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            } else if (chuyenCoSo == 1 && thaydoiNgay == 0)
            {
                rpt = new Xrpt_THONG_KE_DK_THI1(1, chuyenDangNgay(tuNgay), chuyenDangNgay(denNgay));
                rpt.lblTieuDe.Text = "DANH SÁCH ĐĂNG KÝ THI TRẮC NGHIỆM " + cmbCoSo.Text.ToUpper();
                rpt.lblNgay.Text = "TỪ NGÀY " + tuNgay + " ĐẾN NGÀY " + denNgay;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else if (chuyenCoSo == 0 && thaydoiNgay == 1)
            {
                rpt = new Xrpt_THONG_KE_DK_THI1(2, chuyenDangNgay(tuNgay), chuyenDangNgay(denNgay));
                rpt.lblTieuDe.Text = "DANH SÁCH ĐĂNG KÝ THI TRẮC NGHIỆM " + cmbCoSo.Text.ToUpper();
                rpt.lblNgay.Text = "TỪ NGÀY " + tuNgay + " ĐẾN NGÀY " + denNgay;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else if (chuyenCoSo == 1 && thaydoiNgay == 1)
            {
                rpt = new Xrpt_THONG_KE_DK_THI1(3, chuyenDangNgay(tuNgay), chuyenDangNgay(denNgay));
                rpt.lblTieuDe.Text = "DANH SÁCH ĐĂNG KÝ THI TRẮC NGHIỆM " + cmbCoSo.Text.ToUpper();
                rpt.lblNgay.Text = "TỪ NGÀY " + tuNgay + " ĐẾN NGÀY " + denNgay;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            tuNgay1 = tuNgay;
            denNgay1 = denNgay;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
