using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.CongViec;
using DaoBSCKPI.Khac;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.KPI
{
    public partial class frmNhiemVuChinhCaNhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                txtThang.Text = Request.QueryString["T"];
                txtNam.Text = Request.QueryString["N"];
                txtIDNhanVien.Text = Request.QueryString["L"];
                DanhSachNVC();
            }
        }

        #region Thuoc tinh
        private byte Thang
        {
            get { return byte.Parse(txtThang.Text); }
            set { txtThang.Text = value.ToString(); }
        }

        private int Nam
        {
            get {return int.Parse(txtNam.Text); }
            set { txtNam.Text = value.ToString(); }
        }

        private Guid IDNhanVien
        {
            get { return Guid.Parse(txtIDNhanVien.Text); }
            set { txtIDNhanVien.Text = value.ToString(); }
        }
        #endregion

        #region Rieng
        private void DanhSachNVC()
        {
            daNhiemVuTrongTam dNVTT = new daNhiemVuTrongTam();
            dNVTT.Thang = Thang;
            dNVTT.Nam = Nam;
            dNVTT.IDNhanVien = IDNhanVien;
            stoNV.DataSource = dNVTT.DanhSachTheoNhanVien();
            stoNV.DataBind();
        }

        private void DSNVNhanCVC()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDNhanVien", typeof(string));
            dt.Columns.Add("TenNhanVien", typeof(string));
        }
        #endregion

        #region Su Kien
        protected void DanhSachNVTTam(object sender, StoreReadDataEventArgs e)
        {
            DanhSachNVC();
        }

        protected void btnThemCVC_Click(object sender, DirectEventArgs e)
        {
            ucNV1.KhoiTao();
            wCVC.Show();
        }
        
        protected void btnCapNhatNV_Click(object sender, DirectEventArgs e)
        {
            daNhiemVuTrongTam dNVu = new daNhiemVuTrongTam();
            dNVu.NVu.ID = ucNV1.IDNVChinh;
            dNVu.NVu.IDNhanVien = IDNhanVien;//ucNV1.IDNhanVien;
            dNVu.NVu.TenCongViec = ucNV1.TenCongViec;
            dNVu.NVu.MucTieu = ucNV1.MucTieu;
            dNVu.NVu.IDDonViTinh = ucNV1.DonViTinh;
            dNVu.NVu.IDTanSuatDo = ucNV1.TanSuatDo;
            dNVu.NVu.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dNVu.NVu.Thang = Thang;
            dNVu.NVu.Nam = Nam;
            dNVu.NVu.IDXuHuongYeuCau = ucNV1.XuHuongYeuCau;
            dNVu.NVu.Ma = ucNV1.Ma;
            if (dNVu.NVu.ID == 0)
            {
                dNVu.NVu.IDTrangThai = (int)daTrangThai.eTrangThai.Nhập;
            }
            else
            {
                dNVu.NVu.IDTrangThai = (int)daTrangThai.eTrangThai.Sửa;
            }
            if (dNVu.NVu.TenCongViec == "")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Tên công việc khổng thể là trống !",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
                });
                return;
            }
            dNVu.ThemSua();
            stoNV.Reload();
            ucNV1.KhoiTao();
        }
        #endregion
    }
}