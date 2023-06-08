using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private Form CheckExist(Type ftype)
        {
            foreach(Form f in this.MdiChildren)
            {
                if (ftype == f.GetType())
                {
                    return f;
                }
            }
            return null;
        }
        public void HienThiMenuGV()
        {
            MA.Text = "Mã GV: " + Program.username;
            HOTEN.Text = "Họ tên: " + Program.mHoTen;
            NHOM.Text = "Nhóm: " + Program.mGroup;
            this.btnDangNhap.Enabled = false;
            this.btnDangXuat.Enabled = true;

            this.ribHeThong.Visible = true;
            this.ribQuanTri.Visible = true;
            this.ribBaoCao.Visible = true;

            if (Program.mGroup.Equals("TRUONG") || Program.mGroup.Equals("COSO")) // phân quyền cho nhóm trường, cơ sở
            {
                this.btnTaoTaiKhoan.Enabled = true;

                this.btnGiangVien.Enabled = true;
                this.btnSinhVien.Enabled = true;
                this.btnMonHoc.Enabled = true;
                this.btnKhoa.Enabled = true;
                this.btnLop.Enabled = true;
                this.btnDkiThi.Enabled = true;
                this.btnBangDiem.Enabled = true;
                this.btnDSDkiThi.Enabled = true;
            } else if (Program.mGroup.Equals("GIANGVIEN")) // phân quyền cho nhóm giảng viên
            {
                this.btnDeThi.Enabled = true;
                //this.btnDkiThi.Enabled = true;
                this.btnThi.Enabled = true;

                this.btnBangDiem.Enabled= true;
            }
        }
        public void HienThiMenuSV()
        {
            MA.Text = "Mã SV: " + Program.username;
            HOTEN.Text = "Họ tên: " + Program.mHoTen;
            NHOM.Text = "Nhóm: " + Program.mGroup;
            this.btnDangNhap.Enabled = false;
            this.btnDangXuat.Enabled = true;

            this.ribHeThong.Visible = true;
            this.ribQuanTri.Visible = true;
            this.ribBaoCao.Visible = true;

            this.btnThi.Enabled = true;
            this.btnXemLaiBT.Enabled = true;

        }

        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmDangNhap));
            if(frm != null) frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                //f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach(Form f in this.MdiChildren)
            {
                f.Dispose();
            }
            btnDangNhap_ItemClick(sender, e);
            foreach(RibbonPage ribbonPage in ribbon.Pages)
            {
                if(ribbonPage.Name != "ribHeThong") ribbonPage.Visible = false;
            }
            this.btnDangNhap.Enabled = true;
            this.btnTaoTaiKhoan.Enabled = false;
            this.btnDangXuat.Enabled = false;

            //đặt lại tất cả các btn về trạng thái Enable = false

            this.btnGiangVien.Enabled = false;
            this.btnSinhVien.Enabled = false;
            this.btnMonHoc.Enabled = false;
            this.btnKhoa.Enabled = false;
            this.btnLop.Enabled = false;
            this.btnDeThi.Enabled = false;
            this.btnDkiThi.Enabled = false;
            this.btnThi.Enabled = false;

            this.btnBangDiem.Enabled = false;
            this.btnDSDkiThi.Enabled = false;
            this.btnXemLaiBT.Enabled = false;

            Program.mlogin = "";
            Program.password = "";
            Program.mloginDN = "";
            Program.passwordDN = "";
            MA.Text = "MA";
            HOTEN.Text = "HOTEN";
            NHOM.Text = "NHOM";
        }

        private void btnTaoTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmTaoTK));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoTK f = new frmTaoTK();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnGiangVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmGiangVien));
            if (frm != null) frm.Activate();
            else
            {
                frmGiangVien f = new frmGiangVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnKhoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmKhoa));
            if (frm != null) frm.Activate();
            else
            {
                frmKhoa f = new frmKhoa();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmLop));
            if (frm != null) frm.Activate();
            else
            {
                frmLop f = new frmLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmSinhVien));
            if (frm != null) frm.Activate();
            else
            {
                frmSinhVien f = new frmSinhVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDeThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmBoDe));
            if (frm != null) frm.Activate();
            else
            {
                frmBoDe f = new frmBoDe();
                f.MdiParent = this;
                f.Show();
            }
        }


        private void btnDkiThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmGVDK));
            if (frm != null) frm.Activate();
            else
            {
                frmGVDK f = new frmGVDK();
                //f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSDkiThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(Frpt_THONG_KE_DK_THI1));
            if (frm != null) frm.Activate();
            else
            {
                Frpt_THONG_KE_DK_THI1 f = new Frpt_THONG_KE_DK_THI1();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBangDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(Frpt_BANG_DIEM_MH));
            if (frm != null) frm.Activate();
            else
            {
                Frpt_BANG_DIEM_MH f = new Frpt_BANG_DIEM_MH();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.mGroup.Equals("GIANGVIEN")) //nếu là giảng viên sẽ ra form khác
            {
                Form frm = this.CheckExist(typeof(frmChuanBiThiGV));
                if (frm != null) frm.Activate();
                else
                {
                    frmChuanBiThiGV f = new frmChuanBiThiGV();
                    f.MdiParent = this;
                    f.Show();
                }
            } else
            {
                Form frm = this.CheckExist(typeof(frmChuanBiThiSV));
                if (frm != null) frm.Activate();
                else
                {
                    frmChuanBiThiSV f = new frmChuanBiThiSV();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            

        }
    }
}