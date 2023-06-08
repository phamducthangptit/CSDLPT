using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using THITRACNGHIEM;

namespace TaoFormThiTNTest
{
    public partial class frmThiSinhVien : DevExpress.XtraEditors.XtraForm
    {
        private int CountdownDuration = 0; // Độ dài đếm ngược (số giây)
        private int remainingTime; // Thời gian còn lại (số giây)

        private List<List<RadioButton>> answerList; // danh sách đáp án
        List<CauHoiItem> listCauHoi = new List<CauHoiItem>(); // danh sách câu hỏi
        List<int> CauChuaChonDA = new List<int>(); // danh sách các câu chưa chọn đáp án

        int soCauHoi = 0;
        public frmThiSinhVien(string maMH, string tenMH, string maSV, string tenSV, string maLop, string tenLop, int lan, int soCauThi, int thoiGian)
        {
            InitializeComponent();
            CountdownDuration = thoiGian * 60;
            remainingTime = CountdownDuration;
            int x = 50, y = 50;

            //set các thông tin cần thiết
            txtMonThi.Text = tenMH;
            txtSoCauThi.Text = soCauThi.ToString();
            txtLanThi.Text = lan.ToString();
            txtMaLop.Text = maLop;
            txtTenLop.Text = tenLop;
            txtMaSV.Text = maSV;
            txtHoTen.Text = tenSV;
            

            //lấy đề
            if(listCauHoi != null) listCauHoi.Clear();
            string strLenh = "EXEC SP_LAYDETHI '" + maLop + "', '" + maSV + "', '" + maMH + "'," + lan;
            SqlDataReader sqlDataReaderDeThi = Program.ExecSqlDataReader(strLenh);
            
            //xóa list câu trả lời trước đó
            if(answerList != null) answerList.Clear();

            int stt = 1;
            while (sqlDataReaderDeThi.Read())
            {
                CauHoiItem item = new CauHoiItem();
                item.IdCauHoi = sqlDataReaderDeThi.GetInt32(0);
                item.noiDungCauHoi = sqlDataReaderDeThi.GetString(1);
                item.CauA = sqlDataReaderDeThi.GetString(2);
                item.CauB = sqlDataReaderDeThi.GetString(3);
                item.CauC = sqlDataReaderDeThi.GetString(4);
                item.CauD = sqlDataReaderDeThi.GetString(5);
                item.DapAn = sqlDataReaderDeThi.GetString(6);
                item.IdBaiThi = sqlDataReaderDeThi.GetInt32(7);

                string strLenhUD = "EXEC SP_UPDATESTTCAUHOI " + item.IdBaiThi + "," +item.IdCauHoi + "," + stt;
                stt++;
                int ex = Program.ExecSqlNonQuery(strLenhUD, Program.connstr);
                listCauHoi.Add(item);
            }
            sqlDataReaderDeThi.Close();
            soCauHoi = listCauHoi.Count;
            int iz = 1;
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.TopDown;
            panel.AutoSize = true;
            foreach (var item in listCauHoi)
            {

                Label questionLabel = new Label();
                questionLabel.Text = "Câu " + (iz) + ": " + item.noiDungCauHoi;
                questionLabel.AutoSize = true;
                questionLabel.Font = new Font("Times New Roman", 12, FontStyle.Bold);

                Label cauA = new Label();
                cauA.Text = "A: " + item.CauA;
                cauA.AutoSize = true;
                cauA.Font = new Font("Times New Roman", 12, FontStyle.Regular);

                Label cauB = new Label();
                cauB.Text = "B: " + item.CauB;
                cauB.AutoSize = true;
                cauB.Font = new Font("Times New Roman", 12, FontStyle.Regular);

                Label cauC = new Label();
                cauC.Text = "C: " + item.CauC;
                cauC.AutoSize = true;
                cauC.Font = new Font("Times New Roman", 12, FontStyle.Regular);

                Label cauD = new Label();
                cauD.Text = "D: " + item.CauD;
                cauD.AutoSize = true;
                cauD.Font = new Font("Times New Roman", 12, FontStyle.Regular);

                panel.Controls.Add(questionLabel);
                panel.Controls.Add(cauA);
                panel.Controls.Add(cauB);
                panel.Controls.Add(cauC);
                panel.Controls.Add(cauD);
                iz++;
            }
            xtraScrollableControl1.Controls.Add(panel);

            // tạo list caua trả lời
            answerList = new List<List<RadioButton>>();
            for (int j = 0; j < soCauHoi; j++)
            {
                List<RadioButton> questionAnswers = new List<RadioButton>();
                for (int i = 0; i < 4; i++)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.Text = ((char)('A' + i)).ToString();
                    radioButton.AutoSize = true;
                    questionAnswers.Add(radioButton);
                }
                answerList.Add(questionAnswers);
            }

            ShowAnswerList();
            DisplayTime();

            timer1.Start();

        }
        private void ShowAnswerList()
        {
            int x = 30, y = 35;
            // Hiển thị câu hỏi và câu trả lời trong Form

            for (int i = 0; i < soCauHoi; i++)
            {
                Label questionLabel = new Label();
                questionLabel.Text = "Câu hỏi " + (i + 1);
                questionLabel.Location = new Point(x, y * (i + 1));
                questionLabel.AutoSize = true;

                Panel questionPanel = new Panel();
                questionPanel.Location = new Point(x, y * (i + 1));
                questionPanel.AutoSize = true;


                questionPanel.Controls.Add(questionLabel);

                List<RadioButton> questionAnswers = answerList[i];
                for (int j = 0; j < questionAnswers.Count; j++)
                {
                    RadioButton radioButton = questionAnswers[j];
                    radioButton.Location = new System.Drawing.Point(130 + j * 60, y * (i + 1));
                    questionPanel.Controls.Add(radioButton);
                }
                xtraScrollableControl2.Controls.Add(questionPanel);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // Giảm thời gian còn lại
            remainingTime--;
            DisplayTime();

            // Kiểm tra nếu thời gian còn lại đạt 0
            if (remainingTime <= 0)
            {
                // Dừng Timer
                ((Timer)sender).Stop();

                // Hiển thị thông báo khi đếm ngược kết thúc
                MessageBox.Show("Đã hết thời gian thi", "Thông báo", MessageBoxButtons.OK);

                thongBaoKQ();
                // Đặt lại giá trị cho thời gian còn lại
                remainingTime = CountdownDuration;
            }
        }
        private void DisplayTime()
        {
            string formattedTime = TimeSpan.FromSeconds(remainingTime).ToString("mm\\:ss");

            label5.Text = formattedTime;
        }

        public void kiemTraCauTraLoi()
        {
            string x = "";
            if (CauChuaChonDA != null) CauChuaChonDA.Clear();
            for(int i = 0; i < soCauHoi; i++)
            {
                List<RadioButton> questionAnswers = answerList[i];
                int check = 0;
                for(int j = 0; j < questionAnswers.Count; j++)
                {
                    if (questionAnswers[j].Checked)
                    {
                        check++;
                        if(j == 0)
                        {
                            listCauHoi[i].DapAnChon = "A";
                        } else if(j == 1)
                        {
                            listCauHoi[i].DapAnChon = "B";
                        } else if(j == 2)
                        {
                            listCauHoi[i].DapAnChon = "C";
                        } else if(j == 3)
                        {
                            listCauHoi[i].DapAnChon = "D";
                        }
                    }
                    
                }
                if(check == 0)
                {
                    CauChuaChonDA.Add(i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kiemTraCauTraLoi();
            if (CauChuaChonDA.Count != 0)
            {
                string x = "Các câu chưa chọn đáp án: ";
                foreach (var item in CauChuaChonDA)
                {
                    x = x + (item + 1).ToString() + " ";
                }
                x = x + "\n" + "Bạn có chắc chắn nộp bài?";

                if(MessageBox.Show(x, "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    timer1.Stop();
                    thongBaoKQ();
                }
            } else
            {
                if(MessageBox.Show("Bạn có chắn chắn nộp bài!", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    timer1.Stop();
                    thongBaoKQ();
                }
            }
        }

        public void thongBaoKQ()
        {
            kiemTraCauTraLoi();
            int soCauDung = 0, soCauSai = 0;
            double diem = 0 * 1.0;
            foreach(var item in listCauHoi)
            {
                string strCauTL = "EXEC SP_INSERTCAUTL " + item.IdBaiThi + ", " 
                    + item.IdCauHoi + ", '" + item.DapAnChon + "'";
                Program.ExecSqlNonQuery(strCauTL, Program.connstr);
                if (item.DapAnChon.Equals(item.DapAn))
                {
                    soCauDung++;
                }
                else
                {
                    soCauSai++;
                }
            }
            diem = Math.Round((double)((10 * 1.0 / soCauHoi) * soCauDung), 2);
            string x = "Số câu đúng: " + soCauDung + "\n"
                    + "Số câu sai: " + soCauSai + "\n"
                    + "Điểm: " + diem;
            string strDiem = "EXEC SP_INSERTDIEM " + listCauHoi[0].IdBaiThi + ", " + diem;
            Program.ExecSqlNonQuery(strDiem, Program.connstr);
            this.Close();
            MessageBox.Show(x, "Kết quả", MessageBoxButtons.OK);
        }
    }
}
