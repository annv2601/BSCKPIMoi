using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.NguoiDung;
using DaoBSCKPI.NhanVien;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                Session.Clear();
                LayEmailDangNhap();
            }
        }

        private void LayEmailDangNhap()
        {
            try
            {
                HttpCookie _EmailDangNhap;
                _EmailDangNhap = Request.Cookies["BSCDiaChiEmailDangNhap"];
                txtEmail.Text = _EmailDangNhap.Value;
            }
            catch
            {

            }
        }

        protected void btnDangNhap_Click(object sender, DirectEventArgs e)
        {
            daDangNhap dDN = new daDangNhap();
            dDN.ND.Email = txtEmail.Text.Trim();
            dDN.ND.MatKhau = txtMatKhau.Text.Trim();

            if(dDN.ND.Email=="")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Địa chỉ Email chưa nhập",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnDangNhap.ClientID
                });
                txtEmail.Focus();
                return;
            }

            try
            {
                var mail = new System.Net.Mail.MailAddress(dDN.ND.Email);
            }
            catch
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Địa chỉ Email không đúng",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnDangNhap.ClientID
                });
                return;
            }

            if (dDN.ND.MatKhau == "")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Mật khẩu chưa nhập",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnDangNhap.ClientID
                });
                txtMatKhau.Focus();
                return;
            }


            string KQDN = dDN.DangNhap();
            switch(KQDN)
            {
                case "01":
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Thông báo",
                        Message = "Email này không tồn tại",
                        Buttons = MessageBox.Button.OK,
                        Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                        AnimEl = this.btnDangNhap.ClientID
                    });
                    return;
                case "10":
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Thông báo",
                        Message = "Sai Mật khẩu",
                        Buttons = MessageBox.Button.OK,
                        Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                        AnimEl = this.btnDangNhap.ClientID
                    });
                    return;
                case "11":

                    break;
            }

            //Dang nhap thanh cong
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = Convert.ToByte(DateTime.Now.Month);
            dTTNV.TTNV.Nam = DateTime.Now.Year;
            daPhien.NguoiDung = dTTNV.TimEmail(dDN.ND.Email);

            
            if (chkNho.Checked)
            {
                HttpCookie _E = new HttpCookie("BSCDiaChiEmailDangNhap");
                _E.Value = dDN.ND.Email;
                _E.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(_E);
            }
            else
            {
                Response.Cookies.Remove("BSCDiaChiEmailDangNhap");
            }

            Response.Redirect("Default.aspx");
        }
    }
}