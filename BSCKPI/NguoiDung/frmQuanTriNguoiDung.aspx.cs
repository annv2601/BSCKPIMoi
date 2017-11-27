using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.NguoiDung;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.NguoiDung
{
    public partial class frmQuanTriNguoiDung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                txtIDNhanVienDangNhap.Text = Request.QueryString["IDNhanVienTruyNhap"];
                LayThongTinNhanVien();
            }
        }

        #region Thuoc tinh
        private Guid IDNhanVien
        {
            get { return Guid.Parse(txtIDNhanVienDangNhap.Text); }
            set { txtIDNhanVienDangNhap.Text = value.ToString(); }
        }

        private string EmailDN
        {
            get { return txtEmail.Text.Trim(); }
            set { txtEmail.Text = value; }
        }

        private string MatKhau
        {
            get { return txtMatKhau.Text.Trim(); }
            set { txtMatKhau.Text = value; }
        }

        private string MatKhauNhacLai
        {
            get { return txtMatKhauNhacLai.Text.Trim(); }
            set { txtMatKhauNhacLai.Text = value; }
        }
        #endregion

        #region Rieng
        private void LayThongTinNhanVien()
        {
            daDangNhap dDN = new daDangNhap();
            dDN.ND.IDNhanVien = IDNhanVien;
            dDN.ThongTin();
            EmailDN = dDN.ND.Email;
        }
        #endregion

        #region Su kien
        protected void btnCapNhatMatKhau_Click(object sender, DirectEventArgs e)
        {
            //kiem tra Email
            try
            {
                var mail = new System.Net.Mail.MailAddress(EmailDN);
            }
            catch
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Địa chỉ Email không đúng",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatMatKhau.ClientID
                });
                return;
            }
            //=====================
            //Kiem tra Mat khau
            if(MatKhau!=MatKhauNhacLai)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Mật khẩu nhập vào không đồng nhất!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatMatKhau.ClientID
                });
                return;
            }
            if (MatKhau.Length<5)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Mật khẩu nhập vào quá ít ký tự!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatMatKhau.ClientID
                });
                return;
            }
            if (MatKhau=="12345")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Mật khẩu nhập vào quá đơn giản!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatMatKhau.ClientID
                });
                return;
            }
            //=====================
            daDangNhap dDN = new daDangNhap();
            dDN.ND.IDNhanVien = IDNhanVien;
            dDN.ND.Email = EmailDN;
            dDN.ND.MatKhau = MatKhau;
            dDN.ND.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dDN.ThemSua();
            X.Msg.Alert("", "Đã cập nhật mật khẩu thành công!").Show();
        }
        #endregion
    }
}