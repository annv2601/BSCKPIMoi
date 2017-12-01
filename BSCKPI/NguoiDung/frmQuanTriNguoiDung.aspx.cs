using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.NguoiDung;
using DaoBSCKPI.DanhMucHeThong;

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

                DanhSachChucNangChon();
                DanhSachChucNangQTN();
                DanhSachVaiTro();
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

        private int IDVaiTro
        {
            get
            {
                return slbVaiTro.SelectedItem.Value == null ? 0 : int.Parse(slbVaiTro.SelectedItem.Value);
            }
            set
            {
                slbVaiTro.SelectedItems.Clear();
                if(value<=0)
                {
                    slbVaiTro.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbVaiTro.SelectedItems.Add(new Ext.Net.ListItem { Value=value.ToString(), Mode = ParameterMode.Raw });
                }
                slbVaiTro.UpdateSelectedItems();
            }
        }
        #endregion

        #region Rieng
        private void LayThongTinNhanVien()
        {
            daDangNhap dDN = new daDangNhap();
            dDN.ND.IDNhanVien = IDNhanVien;
            dDN.ThongTin();
            EmailDN = dDN.ND.Email;
            IDVaiTro = dDN.ND.IDVaiTro;
        }

        private void DanhSachChucNangChon()
        {
            daChucNang dCN = new daChucNang();
            dCN.CN.Nhom = 0;
            stoDSChucNang.DataSource = dCN.DanhSach();
            stoDSChucNang.DataBind();
        }

        private void DanhSachVaiTro()
        {
            daDangNhap dDN = new daDangNhap();
            stoVaiTro.DataSource = dDN.DanhSachVaiTro();
            stoVaiTro.DataBind();
        }

        private void DanhSachChucNangQTN()
        {
            daNguoiDungQuyen dNDQ = new daNguoiDungQuyen();
            dNDQ.NDQ.IDNhanVien = IDNhanVien;
            stoQTNChucNang.DataSource = dNDQ.DanhSachChucNang();
            stoQTNChucNang.DataBind();
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
            if (MatKhau=="12345" || MatKhau=="123456")
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
            dDN.ND.IDVaiTro = IDVaiTro;
            dDN.ND.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dDN.ThemSua();
            X.Msg.Alert("", "Đã cập nhật mật khẩu thành công!").Show();
        }
        #endregion

        #region Su kien Quyen chuc nang

        protected void DanhSachQuuyenCuaChucNang(object sender, StoreReadDataEventArgs e)
        {

        }

        protected void grdQTNChucNang_Chon(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            daNguoiDungQuyen dNDQ = new daNguoiDungQuyen();
            dNDQ.NDQ.IDNhanVien = IDNhanVien;
            foreach(Dictionary<string,string> row in companies)
            {
                dNDQ.NDQ.IDChucNang = int.Parse(row["IDChucNang"]);
            }
            stoQTNQuyen.DataSource = dNDQ.DanhSachChucQuyen();
            stoQTNQuyen.DataBind();
        }

        protected void btnGanThamChucNang_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            daNguoiDungQuyen dNDQ = new daNguoiDungQuyen();
            dNDQ.NDQ.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dNDQ.NDQ.IDNhanVien = IDNhanVien;
            dNDQ.NDQ.IDQuyenTruyNhap = (int)daQuyenTruyNhap.eQuyen.Xem;
            foreach (Dictionary<string, string> row in companies)
            {
                dNDQ.NDQ.IDChucNang = int.Parse(row["ID"]);
                dNDQ.ThemSua();
            }
            
            wDSChucNang.Hide();

            DanhSachChucNangQTN();
        }

        protected void btnLoaiBoChucNang_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            daNguoiDungQuyen dNDQ = new daNguoiDungQuyen();
            dNDQ.NDQ.IDNhanVien = IDNhanVien;
            foreach (Dictionary<string, string> row in companies)
            {
                dNDQ.NDQ.IDChucNang = int.Parse(row["IDChucNang"]);
            }

            dNDQ.XoaChucNang();

            DanhSachChucNangQTN();

            stoQTNQuyen.DataSource = dNDQ.DanhSachChucQuyen();
            stoQTNQuyen.DataBind();
        }

        protected void btnThemChucNang_Click(object sender, DirectEventArgs e)
        {
            wDSChucNang.Show();
        }

        [DirectMethod(Namespace = "BangQuyenTNX")]
        public void EditQTN(int id, string field, string oldvalue, string newvalue, object BangQTN)
        {
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangQTN.ToString());
            daNguoiDungQuyen dNDQ = new daNguoiDungQuyen();
            dNDQ.NDQ.IDNhanVien = IDNhanVien;
            dNDQ.NDQ.IDChucNang = int.Parse(node.Property("IDChucNang").Value.ToString());
            dNDQ.NDQ.IDQuyenTruyNhap = int.Parse(node.Property("IDQuyenTruyNhap").Value.ToString());
            if(Boolean.Parse(newvalue))
            {
                dNDQ.NDQ.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
                dNDQ.ThemSua();
            }
            else
            {
                dNDQ.Xoa();
            }
            grdQTNQuyen.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}