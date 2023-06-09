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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace THITRACNGHIEM
{
    public partial class frmGVDK : Form
    {

        private SqlConnection conn_publisher = new SqlConnection();
        int viTri = 0;
        int viTriLop = 0;
        string suKien = "";
        //string maGV = "";
        public frmGVDK()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSGVDK);

        }

        private void frmGVDK_Load(object sender, EventArgs e)
        {
            dSGVDK.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dSGVDK.LOP' table. You can move, or remove it, as needed.
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dSGVDK.LOP);

            // TODO: This line of code loads data into the 'dSGVDK.MONHOC' table. You can move, or remove it, as needed.
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.dSGVDK.MONHOC);
            // TODO: This line of code loads data into the 'dSGVDK.GIAOVIEN' table. You can move, or remove it, as needed.
            this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIENTableAdapter.Fill(this.dSGVDK.GIAOVIEN);
            // TODO: This line of code loads data into the 'dSGVDK.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSGVDK.GIAOVIEN_DANGKY);

            cmbCoSo.DataSource = Program.bds_dspm; // sao chép ds phân mảnh đã load ở form đăng nhập
            cmbCoSo.DisplayMember = "TENCS";
            cmbCoSo.ValueMember = "TENSERVER";
            cmbCoSo.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
                btnThem.Enabled = btnHieuChinh.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
                btnReload.Enabled = btnThoat.Enabled = true;
                panelControl2.Enabled = false;
            }
            else
            {
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                cmbCoSo.Enabled = false;
                panelControl1.Enabled = false;
                panelControl2.Enabled = false;
            }
            string sql1 = "SELECT * FROM V_DS_MH";
            DataTable dt1 = Program.ExecSqlDataTable(sql1);

            DataRow newRow = dt1.NewRow();
            // Thiết lập giá trị cho các cột của dòng mới
            newRow["MAMH"] = "MATRONG";
            newRow["TENMH"] = "Trống";

            // Thêm dòng mới vào DataTable
            dt1.Rows.Add(newRow);
            cmbMH.DataSource = dt1;
            cmbMH.DisplayMember = "TENMH";
            cmbMH.ValueMember = "MAMH";
            if (bdsGVDK.Position != -1)
                cmbMH.SelectedValue = ((DataRowView)bdsGVDK[0])["MAMH"].ToString();
            else cmbMH.SelectedValue = "MATRONG";
            string sql2 = "SELECT * FROM V_DS_GV";
            DataTable dt2 = Program.ExecSqlDataTable(sql2);
            DataRow newRow2 = dt2.NewRow();
            // Thiết lập giá trị cho các cột của dòng mới
            newRow2["MAGV"] = "MATRONG";
            newRow2["TENGV"] = "Trống";

            dt2.Rows.Add(newRow2);
            cmbGV.DataSource = dt2;
            cmbGV.DisplayMember = "TENGV";
            cmbGV.ValueMember = "MAGV";
            if (bdsGVDK.Position != -1)
                cmbGV.SelectedValue = ((DataRowView)bdsGVDK[0])["MAGV"].ToString();
            else cmbGV.SelectedValue = "MATRONG";
            //cmbGV.SelectedValue = ((DataRowView)bdsGVDK[0])["MAGV"].ToString();
            cmbTrinhDo.Items.Add("A");
            cmbTrinhDo.Items.Add("B");
            cmbTrinhDo.Items.Add("C");
            cmbTrinhDo.SelectedItem = "A";
            cmbLan.Items.Add("1");
            cmbLan.Items.Add("2");
            cmbLan.SelectedItem = "1";
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
            else
            {

                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dSGVDK.LOP);

                this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.MONHOCTableAdapter.Fill(this.dSGVDK.MONHOC);

                this.GIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIENTableAdapter.Fill(this.dSGVDK.GIAOVIEN);

                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSGVDK.GIAOVIEN_DANGKY);

                string sql2 = "SELECT * FROM V_DS_GV";
                DataTable dt2 = Program.ExecSqlDataTable(sql2);
                DataRow newRow2 = dt2.NewRow();
                // Thiết lập giá trị cho các cột của dòng mới
                newRow2["MAGV"] = "MATRONG";
                newRow2["TENGV"] = "Trống";

                dt2.Rows.Add(newRow2);
                cmbGV.DataSource = dt2;
                cmbGV.DisplayMember = "TENGV";
                cmbGV.ValueMember = "MAGV";
<<<<<<< HEAD
                if (bdsGVDK.Position != -1) {
                    cmbGV.SelectedValue = ((DataRowView)bdsGVDK[0])["MAGV"].ToString();
                    cmbMH.SelectedValue = ((DataRowView)bdsGVDK[0])["MAMH"].ToString();
                }
                else {
=======
                if (bdsGVDK.Position != -1)
                {
                    cmbGV.SelectedValue = ((DataRowView)bdsGVDK[0])["MAGV"].ToString();
                    cmbMH.SelectedValue = ((DataRowView)bdsGVDK[0])["MAMH"].ToString();
                }
                else
                {
>>>>>>> adfec87adf745761bbc1d034eac389b9ea62acaa
                    cmbGV.SelectedValue = "MATRONG";
                    cmbMH.SelectedValue = "MATRONG";
                }
                cmbTrinhDo.SelectedItem = "A";
                cmbLan.SelectedItem = "1";
                //cmbGV.SelectedValue = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAGV"].ToString();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viTri = bdsGVDK.Position;
            viTriLop = bdsLop.Position;
            try
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dSGVDK.LOP);
                bdsLop.Position = viTriLop;

                this.dSGVDK.GIAOVIEN_DANGKY.Clear();

                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSGVDK.GIAOVIEN_DANGKY);
                bdsGVDK.Position = viTri;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGVDK.CancelEdit();
            bdsGVDK.Position = viTri;

            gcGVDK.Enabled = true;
            gcLop.Enabled = true;
            panelControl2.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            suKien = "THEM";
            //maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
            viTri = bdsGVDK.Position;
            viTriLop = bdsLop.Position;
            bdsGVDK.AddNew();
            txtMaLop.Text = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
            cmbMH.SelectedValue = "MATRONG";
            cmbGV.SelectedValue = "MATRONG";


            panelControl2.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;
            gcGVDK.Enabled = false;
            gcLop.Enabled = false;

        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viTri = bdsGVDK.Position;
            viTriLop = bdsLop.Position;
            suKien = "HC";
            panelControl2.Enabled = true;
            gcGVDK.Enabled = false;
            gcLop.Enabled = false;
            cmbMH.SelectedValue = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAMH"].ToString();
            cmbGV.SelectedValue = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAGV"].ToString();


            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;

        }


        private string chuyenDangNgay(string s)
        {
            string[] tmp = s.Split('/');
            return tmp[2] + "/" + tmp[1] + "/" + tmp[0];
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string maMH = cmbMH.SelectedValue.ToString().Trim();
            string maGV = cmbGV.SelectedValue.ToString().Trim();
            string trinhDo = cmbTrinhDo.SelectedItem.ToString().Trim();
            string ngayThi = deNgayThi.Text.Trim();
            string lan = cmbLan.SelectedItem.ToString().Trim();
            string soCauThi = txtSoCauThi.Text.Trim();
            string thoiGian = txtThoiGian.Text.Trim();
            if (maLop == "")
            {
                MessageBox.Show("Mã lớp không được thiếu", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return;
            }
            if (maMH == "MATRONG")
            {
                MessageBox.Show("Mã môn học không được để trống", "", MessageBoxButtons.OK);
                cmbMH.Focus();
                return;
            }
            if (maGV == "MATRONG")
            {
                MessageBox.Show("Mã giảng viên không được để trống", "", MessageBoxButtons.OK);
                cmbGV.Focus();
                return;
            }


            if (ngayThi == "")
            {
                MessageBox.Show("Ngày thi không được thiếu", "", MessageBoxButtons.OK);
                deNgayThi.Focus();
                return;
            }
            string currentDay = DateTime.Today.AddDays(7).ToString("dd/MM/yyyy");
            if (ngayThi.CompareTo(currentDay) < 0)
            {
                MessageBox.Show("Ngày thi phải được đăng kí trước 1 tuần!" + currentDay, "", MessageBoxButtons.OK);
                deNgayThi.Focus();
                return;
            }
            if (lan == "")
            {
                MessageBox.Show("Lần thi không được thiếu", "", MessageBoxButtons.OK);
                cmbLan.Focus();
                return;
            }
<<<<<<< HEAD

=======
>>>>>>> adfec87adf745761bbc1d034eac389b9ea62acaa
            if (int.Parse(lan) < 1 || int.Parse(lan) > 2)
            {
                MessageBox.Show("Lần thi phải lớn hơn hoặc bằng 1 và nhỏ hơn hoặc bằng 2", "", MessageBoxButtons.OK);
                cmbLan.Focus();
                return;
            }
<<<<<<< HEAD
            if (int.Parse(lan) == 2)
            {
                string strLenh1 = "EXEC SP_CHECKEXISTGVDK '" + maMH + "', '"
                                + maLop + "', '1'";
                SqlDataReader dataReaderGVDK1 = Program.ExecSqlDataReader(strLenh1);
                dataReaderGVDK1.Read();

                int check1 = Int32.Parse(dataReaderGVDK1.GetString(0)); // check xem trong db đã có mã gv này hay chưa
                dataReaderGVDK1.Close();
                Program.conn.Close();
                if( check1 == 0)
                {
                    MessageBox.Show("Lớp " +
                        ((DataRowView)bdsLop[bdsLop.Position])["TENLOP"].ToString().Trim()
                        +"chưa đăng kí thi lần 1 ứng với môn học "
                        + ((DataRowView)cmbMH.SelectedItem)["TENMH"].ToString().Trim()
                        + " nên chưa thể đăng kí thi lần 2!"
                        , "", MessageBoxButtons.OK);
                    cmbLan.Focus();
                    return;
                }
            }
=======
>>>>>>> adfec87adf745761bbc1d034eac389b9ea62acaa
            if (soCauThi == "")
            {
                MessageBox.Show("Số câu thi không được thiếu", "", MessageBoxButtons.OK);
                txtSoCauThi.Focus();
                return;
            }

            if (thoiGian == "")
            {
                MessageBox.Show("Thời gian thi không được thiếu", "", MessageBoxButtons.OK);
                txtThoiGian.Focus();
                return;
            }
            if (trinhDo == "")
            {
                MessageBox.Show("Trình độ không được bỏ trống", "", MessageBoxButtons.OK);
                cmbTrinhDo.Focus();
                return;
            }

            if (int.Parse(soCauThi) < 10 || int.Parse(soCauThi) > 100)
            {
                MessageBox.Show("Số câu thi phải lớn hơn hoặc bằng 10 và nhỏ hơn hoặc bằng 100", "", MessageBoxButtons.OK);
                txtSoCauThi.Focus();
                return;
            }

            if (int.Parse(thoiGian) < 15 || int.Parse(thoiGian) > 60)
            {
                MessageBox.Show("Thời gian thi phải lớn hơn hoặc bằng 15 và nhỏ hơn hoặc bằng 60", "", MessageBoxButtons.OK);
                txtThoiGian.Focus();
                return;
            }
<<<<<<< HEAD
            if (suKien.Equals("HC"))
            {
               string maMH1 = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAMH"].ToString().Trim();
               string maLop1 = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MALOP"].ToString().Trim();
               string lan1 = ((DataRowView)bdsGVDK[bdsGVDK.Position])["LAN"].ToString().Trim();
                if (maMH.Equals(maMH1) && maLop.Equals(maLop1) && lan.Equals(lan1))
                {
                    panelControl2.Enabled = false;
                    gcGVDK.Enabled = true;
                    gcLop.Enabled = true;

                    btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                        btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnPhucHoi.Enabled = false;
                    return;
                }
            }
=======

            //maLop = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MALOP"].ToString();
            if (suKien.Equals("THEM") || (suKien.Equals("HC")))
            {
>>>>>>> adfec87adf745761bbc1d034eac389b9ea62acaa
                string strLenh = "EXEC SP_CHECKEXISTGVDK '" + maMH + "', '"
                                + maLop + "', '" +
                                 lan + "'";
                SqlDataReader dataReaderGVDK = Program.ExecSqlDataReader(strLenh);
                dataReaderGVDK.Read();

                int check = Int32.Parse(dataReaderGVDK.GetString(0)); // check xem trong db đã có mã gv này hay chưa
                dataReaderGVDK.Close();
                Program.conn.Close();
                if (check == 0)
                {
<<<<<<< HEAD
                     if(suKien.Equals("THEM"))
                       {
                        
=======
                    if (suKien.Equals("THEM"))
                    {

>>>>>>> adfec87adf745761bbc1d034eac389b9ea62acaa
                        //MessageBox.Show(chuyenDangNgay(ngayThi), "", MessageBoxButtons.OK);
                        string strLenh1 = "SP_GIANGVIEN_DANGKI_THI '"
                            + maLop + "', '"
                            + maMH + "', '"
                             + maGV + "', '"
                             + trinhDo + "', '"
                             + chuyenDangNgay(ngayThi) + "', '"
                            + lan + "', '"
                            + soCauThi + "', '"
                            + thoiGian + "', '"
                            + "0'"
                            ;
                        int result = Program.ExecSqlNonQuery(strLenh1, Program.connstr);
                        if (result == 0)
                        {
<<<<<<< HEAD
                            MessageBox.Show("Lưu thành công","", MessageBoxButtons.OK);
=======
                            MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK);
>>>>>>> adfec87adf745761bbc1d034eac389b9ea62acaa
                        }
                        this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.LOPTableAdapter.Fill(this.dSGVDK.LOP);
                        bdsLop.Position = viTriLop;

                        this.dSGVDK.GIAOVIEN_DANGKY.Clear();

                        this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSGVDK.GIAOVIEN_DANGKY);

<<<<<<< HEAD
                    } else if (suKien.Equals("HC"))
                    {
                        string strLenh1 = "SP_GIANGVIEN_DANGKI_THI '"
                               + maLop + "', '"
                               + maMH + "', '"
                                + maGV + "', '"
                                + trinhDo + "', '"
                                + chuyenDangNgay(ngayThi) + "', '"
                               + lan + "', '"
                               + soCauThi + "', '"
                               + thoiGian + "', '"
                               + "1'"
                               ;
                            int result = Program.ExecSqlNonQuery(strLenh1, Program.connstr);
                            if (result == 0)
                            {
                                MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK);
                            }
                            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.LOPTableAdapter.Fill(this.dSGVDK.LOP);
                            bdsLop.Position = viTriLop;
=======
                    }
                    else
                    {
                        MessageBox.Show("Lớp học này đã được đăng kí thi rồi.\n", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    if (suKien.Equals("HC"))
                    {
                        string strLenh1 = "SP_GIANGVIEN_DANGKI_THI '"
                           + maLop + "', '"
                           + maMH + "', '"
                            + maGV + "', '"
                            + trinhDo + "', '"
                            + chuyenDangNgay(ngayThi) + "', '"
                           + lan + "', '"
                           + soCauThi + "', '"
                           + thoiGian + "', '"
                           + "1'"
                           ;
                        int result = Program.ExecSqlNonQuery(strLenh1, Program.connstr);
                        if (result == 0)
                        {
                            MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK);
                        }
                        this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.LOPTableAdapter.Fill(this.dSGVDK.LOP);
                        bdsLop.Position = viTriLop;
>>>>>>> adfec87adf745761bbc1d034eac389b9ea62acaa

                            this.dSGVDK.GIAOVIEN_DANGKY.Clear();

                            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSGVDK.GIAOVIEN_DANGKY);
                            bdsGVDK.Position = viTri;
                    }
                }   else 
                    {
                        MessageBox.Show("Đã tồn tại đăng kí thi lần "+ lan 
                            +" của lớp "
                            + ((DataRowView)bdsLop[bdsLop.Position])["TENLOP"].ToString().Trim()
                            +" ứng với môn học "
                            + ((DataRowView)cmbMH.SelectedItem)["TENMH"].ToString().Trim(),
                            "", MessageBoxButtons.OK);
                        return;
                    }
<<<<<<< HEAD
                    
               
=======

                }

            }
>>>>>>> adfec87adf745761bbc1d034eac389b9ea62acaa
            panelControl2.Enabled = false;
            gcGVDK.Enabled = true;
            gcLop.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled =
                btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }







        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsGVDK.Count == 0)
            {
                cmbMH.SelectedValue = "MATRONG";
                cmbGV.SelectedValue = "MATRONG";
                cmbTrinhDo.SelectedItem = "A";
                cmbLan.SelectedItem = "1";
                btnXoa.Enabled = false;
                btnHieuChinh.Enabled = false;
                return;
            }
            if (Program.mGroup == "COSO")
            {
                string maMH = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAMH"].ToString();
                string maLop = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MALOP"].ToString();
                string lan = ((DataRowView)bdsGVDK[bdsGVDK.Position])["LAN"].ToString();
                string strLenh = "EXEC SP_CHECKDATHI '" + maMH + "', '" + maLop + "', '" + lan + "'";
                SqlDataReader dataReaderGVDK = Program.ExecSqlDataReader(strLenh);
                dataReaderGVDK.Read();
                int check = dataReaderGVDK.GetInt32(0); // check xem trong db đã có mã gv này hay chưa
                if (check == 0)
                {
                    btnHieuChinh.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    btnXoa.Enabled = false;
                    btnHieuChinh.Enabled = false;
                }
                dataReaderGVDK.Close();
                Program.conn.Close();
            }
            cmbMH.SelectedValue = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAMH"].ToString();
            cmbGV.SelectedValue = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAGV"].ToString();
            cmbLan.SelectedItem = ((DataRowView)bdsGVDK[bdsGVDK.Position])["LAN"].ToString();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tenLop = ((DataRowView)bdsLop[bdsLop.Position])["TENLOP"].ToString();
            if (MessageBox.Show("Bạn có thật sự muốn xóa đăng kí thi của lớp " +
                tenLop + " này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {


                    bdsGVDK.RemoveCurrent();
                    this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.GIAOVIEN_DANGKYTableAdapter.Update(this.dSGVDK.GIAOVIEN_DANGKY);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa đăng kí thi của lớp " +
                        tenLop + " . Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSGVDK.GIAOVIEN_DANGKY);

                    return;
                }
                if (bdsGVDK.Count == 0) btnXoa.Enabled = false;
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsGVDK.Count == 0)
            {
                cmbMH.SelectedValue = "MATRONG";
                cmbGV.SelectedValue = "MATRONG";
                cmbTrinhDo.SelectedItem = "A";
                cmbLan.SelectedItem = "1";
                btnXoa.Enabled = false;
                btnHieuChinh.Enabled = false;
                return;
            }
            if (Program.mGroup == "COSO")
            {
                string maMH = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAMH"].ToString();
                string maLop = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MALOP"].ToString();
                string lan = ((DataRowView)bdsGVDK[bdsGVDK.Position])["LAN"].ToString();
                string strLenh = "EXEC SP_CHECKDATHI '" + maMH + "', '" + maLop + "', '" + lan + "'";
                SqlDataReader dataReaderGVDK = Program.ExecSqlDataReader(strLenh);
                dataReaderGVDK.Read();
                int check = dataReaderGVDK.GetInt32(0); // check xem trong db đã có mã gv này hay chưa
                if (check == 0)
                {
                    btnHieuChinh.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    btnXoa.Enabled = false;
                    btnHieuChinh.Enabled = false;
                }
                dataReaderGVDK.Close();
                Program.conn.Close();
            }
            cmbMH.SelectedValue = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAMH"].ToString();
            cmbGV.SelectedValue = ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAGV"].ToString();
            cmbLan.SelectedItem = ((DataRowView)bdsGVDK[bdsGVDK.Position])["LAN"].ToString();
        }
    }
}
