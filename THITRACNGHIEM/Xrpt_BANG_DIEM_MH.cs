using DevExpress.XtraExport.Xls;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace THITRACNGHIEM
{
    public partial class Xrpt_BANG_DIEM_MH : DevExpress.XtraReports.UI.XtraReport
    {
        
        public Xrpt_BANG_DIEM_MH(string maLop, string maMH, int lan)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maLop;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = maMH;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = lan;
            this.sqlDataSource1.Fill();
        }
    }
}
