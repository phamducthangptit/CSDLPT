using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace THITRACNGHIEM
{
    public partial class Xrpt_THONG_KE_DK_THI1 : DevExpress.XtraReports.UI.XtraReport
    {
        
         public Xrpt_THONG_KE_DK_THI1(int check, string tuNgay, string denNgay)
        {
            InitializeComponent();
            //this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = check;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = tuNgay;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = denNgay;
            this.sqlDataSource1.Fill();
        }
    }
}
