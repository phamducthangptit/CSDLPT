using DevExpress.DataAccess.Native.Excel;
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
    
    public partial class Frpt_BANG_DIEM_MH : Form
    {
        string maLop1 = "";
        string maMH1 = "";
        string tenLop = "";
        string tenMH = "";
        public Frpt_BANG_DIEM_MH()
        {
            InitializeComponent();
        }

        private void Frpt_BANG_DIEM_MH_Load(object sender, EventArgs e)
        {
            string maGV = "";
            cmbCoSo.DataSource = Program.bds_dspm; // sao chép ds phân mảnh đã load ở form đăng nhập
            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
            cmbCoSo.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
            }
            else
            {
                cmbCoSo.Enabled = false;
            }
            if (Program.mGroup == "GIANGVIEN")
            {
                maGV = Program.username;
            } else
            {
                maGV = "";
            }
            string sql1 = "EXEC SP_THONG_TIN_LOP_BD '" +maGV+"'";
            DataTable dt1 = Program.ExecSqlDataTable(sql1);
            if (dt1.Rows.Count == 0)
            {
                DataRow newRow = dt1.NewRow();
                // Thiết lập giá trị cho các cột của dòng mới
                newRow["MALOP"] = "MATRONG";
                newRow["TENLOP"] = "Trống";
                dt1.Rows.Add(newRow);
            }
                cmbLop.DataSource = dt1;
                cmbLop.DisplayMember = "TENLOP";
                cmbLop.ValueMember = "MALOP";
                cmbLop.SelectedIndex = 0;

            string sql2 = "EXEC SP_THONG_TIN_MH_BD '" + maGV + "'";
            DataTable dt2 = Program.ExecSqlDataTable(sql2);
            if (dt2.Rows.Count == 0)
            {
                DataRow newRow = dt2.NewRow();
                // Thiết lập giá trị cho các cột của dòng mới
                newRow["MAMH"] = "MATRONG";
                newRow["TENMH"] = "Trống";
                dt2.Rows.Add(newRow);
            }
            cmbMH.DataSource = dt2;
            cmbMH.DisplayMember = "TENMH";
            cmbMH.ValueMember = "MAMH";
            cmbMH.SelectedIndex = 0;

            maLop1 = cmbLop.SelectedValue.ToString();
            maMH1 = cmbMH.SelectedValue.ToString();
            tenLop = ((DataRowView)cmbLop.SelectedItem)["TENLOP"].ToString();
            tenMH = ((DataRowView)cmbMH.SelectedItem)["TENMH"].ToString();
            DataTable dt3 = new DataTable();
            if (maLop1 != "MATRONG" && maMH1 != "MATRONG")
            {
                string sql3 = "EXEC SP_THONG_TIN_LAN_BD '" + maLop1 + "', '" + maMH1 + "'";
                dt3 = Program.ExecSqlDataTable(sql3);
            } 
            if(dt3.Rows.Count == 0)
            {   if(!dt3.Columns.Contains("LAN")) dt3.Columns.Add("LAN", typeof(int));

                DataRow newRow = dt3.NewRow();
                // Thiết lập giá trị cho các cột của dòng mới
                newRow["LAN"] = "0";
                dt3.Rows.Add(newRow);
            }
            cmbLan.DataSource = dt3;
            cmbLan.DisplayMember = "LAN";
            cmbLan.ValueMember = "LAN";
            cmbLan.SelectedIndex = 0;
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

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLop.SelectedValue.ToString() == "System.Data.DataRowView") return;

            if(cmbLop.SelectedValue.ToString() != maLop1)
            {
                maLop1 = cmbLop.SelectedValue.ToString();
                tenLop = ((DataRowView)cmbLop.SelectedItem)["TENLOP"].ToString();
                DataTable dt3 = new DataTable();
                if (maLop1 != "MATRONG" && maMH1 != "MATRONG")
                {
                    string sql3 = "EXEC SP_THONG_TIN_LAN_BD '" + maLop1 + "', '" + maMH1 + "'";
                    dt3 = Program.ExecSqlDataTable(sql3);
                }
                if (dt3.Rows.Count == 0)
                {
                    if (!dt3.Columns.Contains("LAN")) dt3.Columns.Add("LAN", typeof(int));

                    DataRow newRow = dt3.NewRow();
                    // Thiết lập giá trị cho các cột của dòng mới
                    newRow["LAN"] = "0";
                    dt3.Rows.Add(newRow);
                }
                cmbLan.DataSource = dt3;
                cmbLan.DisplayMember = "LAN";
                cmbLan.ValueMember = "LAN";
                cmbLan.SelectedIndex = 0;
            }
        }

        private void cmbMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMH.SelectedValue.ToString() == "System.Data.DataRowView") return;

            if (cmbMH.SelectedValue.ToString() != maMH1)
            {
                maMH1 = cmbMH.SelectedValue.ToString();
                tenLop = ((DataRowView)cmbLop.SelectedItem)["TENLOP"].ToString();
                DataTable dt3 = new DataTable();
                if (maLop1 != "MATRONG" && maMH1 != "MATRONG")
                {
                    string sql3 = "EXEC SP_THONG_TIN_LAN_BD '" + maLop1 + "', '" + maMH1 + "'";
                    dt3 = Program.ExecSqlDataTable(sql3);
                }
                if (dt3.Rows.Count == 0)
                {
                    if (!dt3.Columns.Contains("LAN")) dt3.Columns.Add("LAN", typeof(int));

                    DataRow newRow = dt3.NewRow();
                    // Thiết lập giá trị cho các cột của dòng mới
                    newRow["LAN"] = "0";
                    dt3.Rows.Add(newRow);
                }
                cmbLan.DataSource = dt3;
                cmbLan.DisplayMember = "LAN";
                cmbLan.ValueMember = "LAN";
                cmbLan.SelectedIndex = 0;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string lan = cmbLan.SelectedValue.ToString();
            if (maLop1 == "MATRONG")
            {
                MessageBox.Show("Chưa có lớp học nào được đăng kí thi!", "", MessageBoxButtons.OK);
                return;
            }
            if (maMH1 == "MATRONG")
            {
                MessageBox.Show("Chưa có môn học nào được đăng kí thi!", "", MessageBoxButtons.OK);
                return;
            }
            if (lan == "0")
            {
                MessageBox.Show("Lớp " + tenLop +" chưa thi môn học "+ tenMH +"!"
                    , "", MessageBoxButtons.OK);
                return;
            }
            Xrpt_BANG_DIEM_MH rpt;
            rpt = new Xrpt_BANG_DIEM_MH(maLop1, maMH1, Int32.Parse(lan));
            rpt.lblTieuDe.Text = "BẢNG ĐIỂM MÔN HỌC " + tenMH.ToUpper();
            rpt.lblLop.Text = "LỚP: " + tenLop.ToUpper() +"   LẦN: "+ lan;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
