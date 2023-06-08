using System;

namespace THITRACNGHIEM
{
    public partial class Xrpt_CauHoiTheoGV : DevExpress.XtraReports.UI.XtraReport
    {

        public Xrpt_CauHoiTheoGV(String maGV, String maMH)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maGV;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = maMH;
            this.sqlDataSource1.Fill();
        }
    }
}
