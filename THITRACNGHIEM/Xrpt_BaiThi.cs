using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace THITRACNGHIEM
{
    public partial class Xrpt_BaiThi : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_BaiThi(string maSV, string maMH, int lan)
        {
            InitializeComponent();
            string strLenh = "EXEC SP_XTRAREPORTBAITHI '" + maSV + "','" + maMH + "'," + lan;
            SqlCommand command = new SqlCommand(strLenh, Program.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DsBaiThi dsBaiThi = new DsBaiThi();
            adapter.Fill(dsBaiThi.BaiThiSV);
            bds.DataSource = dsBaiThi.BaiThiSV;
        }
    }
}
