using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITRACNGHIEM
{
    internal class CauHoiItem
    {
        private int cauHoi;
        private int idBaiThi;
        private int stt;
        private string noiDung;
        private string cauA;
        private string cauB;
        private string cauC;
        private string cauD;
        private string dapAn = "";
        private string dapAnChon = "";


        [Category("Custom Props")]
        public int IdCauHoi
        { 
            get { return cauHoi; } 
            set { cauHoi = value; } 
        }

        [Category("Custom Props")]
        public int IdBaiThi
        {
            get { return idBaiThi;}
            set { idBaiThi = value;}
        }

        [Category("Custom Props")]
        public int SttCauHoiTrongDe
        { 
            get { return stt; } 
            set { stt = value; } 
        }

        [Category("Custom Props")]
        public String noiDungCauHoi
        {
            get { return noiDung; }
            set { noiDung = value;}
        }

        [Category("Custom Props")]
        public String CauA
        {
            get { return cauA; }
            set { cauA = value; }
        }

        [Category("Custom Props")]
        public String CauB
        {
            get { return cauB; }
            set { cauB = value; }
        }

        [Category("Custom Props")]
        public String CauC
        {
            get { return cauC; }
            set { cauC = value; }
        }

        [Category("Custom Props")]
        public String CauD
        {
            get { return cauD; }
            set { cauD = value; }
        }

        [Category("Custom Props")]
        public String DapAnChon
        {
            get { return dapAnChon; }
            set { dapAnChon = value;}
        }

        [Category("Custom Props")]
        public String DapAn
        {
            get { return dapAn; }
            set { dapAn = value; }
        }
    }
}
