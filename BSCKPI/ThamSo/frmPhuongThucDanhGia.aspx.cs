using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.ThamSoTinhDiem;
using DaoBSCKPI.DanhMucBSCKPI;

using BSCKPI.UIHelper;
using Ext.Net;
namespace BSCKPI.ThamSo
{
    public partial class frmPhuongThucDanhGia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                stoPTDG.Reload();
            }
        }

        #region Rieng
        #endregion

        #region Su kien
        protected void DanhSachPTDG(object sender, StoreReadDataEventArgs e)
        {
            daPhuongThucDanhGiaKetQuaNVTT dPT = new daPhuongThucDanhGiaKetQuaNVTT();
            stoPTDG.DataSource = dPT.DanhSach();
            stoPTDG.DataBind();
        }

        protected void mnuiThongTin_Click(object sender, DirectEventArgs e)
        {

        }

        protected void mnuiXoa_Click(object sender, DirectEventArgs e)
        {

        }

        protected void btnThemPTDG_Click(object sender, DirectEventArgs e)
        {
            ucPT1.KhoiTao();
            ucPT1.DanhSachPhuongThuc();
            wPTDG.Show();
        }

        protected void btnCapNhatPTDG_Click(object sender, DirectEventArgs e)
        {
            daPhuongThucDanhGiaKetQuaNVTT dPT = new daPhuongThucDanhGiaKetQuaNVTT();
            dPT.PT.ID = ucPT1.IDPTDG;
            dPT.PT.IDTanSuatDo = ucPT1.IDTanSuatDo;
            dPT.PT.IDPhuongThuc = ucPT1.IDPhuongThuc;
            dPT.PT.TuNgay = ucPT1.TuNgay;
            dPT.PT.DenNgay = ucPT1.DenNgay;
            dPT.PT.ThuTu = ucPT1.ThuTu;

            dPT.ThemSua();
            ucPT1.KhoiTao();
        }

        protected void btnThemQuyCach_Click(object sender, DirectEventArgs e)
        {
            ucDM1.KhoiTao();
            ucDM1.ThaoTacNhom(true);
            ucDM1.IDNhom = (int)daNhomDanhMucBK.eNhom.Phương_Thức;
            wDanhMuc.Show();
        }

        protected void btnCapNhatDM_Click(object sender, DirectEventArgs e)
        {
            daDanhMucBK dDMBK = new daDanhMucBK();
            dDMBK.DMB.ID = ucDM1.IDDanhMuc;
            dDMBK.DMB.Ma = ucDM1.Ma;
            dDMBK.DMB.TenTat = ucDM1.TenTat;
            dDMBK.DMB.Ten = ucDM1.Ten;
            dDMBK.DMB.GhiChu = ucDM1.GhiChu;
            dDMBK.DMB.STTsx = ucDM1.STTsx;
            dDMBK.DMB.Nhom = ucDM1.IDNhom;
            dDMBK.DMB.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            dDMBK.ThemSua();
            ucDM1.KhoiTao();
            
        }
        #endregion
    }
}